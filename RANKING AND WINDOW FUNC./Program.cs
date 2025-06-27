using System;
using Microsoft.Data.Sqlite;

class Program
{
   

    static void Main()
    {
         File.Delete("employee.db");
        string connectionString = "Data Source=employee.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();

            // Create tables
            CreateSchema(connection);

            // Insert sample data
            InsertSampleData(connection);

            // Insert a new employee only if not already present
            InsertEmployee(connection, "Alice", "Williams", 2, 6200.00m, "2023-05-10");

            // Get employees by department
            Console.WriteLine("\nEmployees in Department 2:");
            GetEmployeesByDepartment(connection, 2);
        }
    }

    static void CreateSchema(SqliteConnection conn)
    {
        var cmd = conn.CreateCommand();

        cmd.CommandText = @"
            CREATE TABLE IF NOT EXISTS Departments (
                DepartmentID INTEGER PRIMARY KEY,
                DepartmentName TEXT
            );
            CREATE TABLE IF NOT EXISTS Employees (
                EmployeeID INTEGER PRIMARY KEY AUTOINCREMENT,
                FirstName TEXT,
                LastName TEXT,
                DepartmentID INTEGER,
                Salary REAL,
                JoinDate TEXT,
                FOREIGN KEY (DepartmentID) REFERENCES Departments(DepartmentID)
            );
        ";
        cmd.ExecuteNonQuery();
    }

    static void InsertSampleData(SqliteConnection conn)
    {
        var insertDept = conn.CreateCommand();
        insertDept.CommandText = @"
            INSERT OR IGNORE INTO Departments (DepartmentID, DepartmentName) VALUES
            (1, 'HR'),
            (2, 'Finance'),
            (3, 'IT'),
            (4, 'Marketing');
        ";
        insertDept.ExecuteNonQuery();

        var insertEmp = conn.CreateCommand();
        insertEmp.CommandText = @"
            INSERT OR IGNORE INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
            (1, 'Indrayudh', 'Mukherjee', 1, 20000.00, '2020-01-15'),
            (2, 'Harshita', 'Avi', 2, 15000.00, '2019-03-22'),
            (3, 'Devansh', 'Mihantuy', 3, 23000.00, '2018-07-30'),
            (4, 'Tarun', 'Sai Nath', 4, 23000.00, '2021-11-05');
        ";
        insertEmp.ExecuteNonQuery();
    }

    static void InsertEmployee(SqliteConnection conn, string firstName, string lastName, int deptId, decimal salary, string joinDate)
    {
        // Check if employee already exists
        var checkCmd = conn.CreateCommand();
        checkCmd.CommandText = @"
            SELECT COUNT(*) FROM Employees
            WHERE FirstName = $firstName AND LastName = $lastName AND DepartmentID = $deptId AND JoinDate = $joinDate;
        ";
        checkCmd.Parameters.AddWithValue("$firstName", firstName);
        checkCmd.Parameters.AddWithValue("$lastName", lastName);
        checkCmd.Parameters.AddWithValue("$deptId", deptId);
        checkCmd.Parameters.AddWithValue("$joinDate", joinDate);

        long count = (long)checkCmd.ExecuteScalar();

        if (count == 0)
        {
            var cmd = conn.CreateCommand();
            cmd.CommandText = @"
                INSERT INTO Employees (FirstName, LastName, DepartmentID, Salary, JoinDate)
                VALUES ($firstName, $lastName, $deptId, $salary, $joinDate);
            ";

            cmd.Parameters.AddWithValue("$firstName", firstName);
            cmd.Parameters.AddWithValue("$lastName", lastName);
            cmd.Parameters.AddWithValue("$deptId", deptId);
            cmd.Parameters.AddWithValue("$salary", salary);
            cmd.Parameters.AddWithValue("$joinDate", joinDate);

            cmd.ExecuteNonQuery();
            Console.WriteLine("✅ Inserted employee.");
        }
        else
        {
            Console.WriteLine("⚠️ Employee already exists. Skipping insert.");
        }
    }

    static void GetEmployeesByDepartment(SqliteConnection conn, int deptId)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            SELECT E.EmployeeID, E.FirstName, E.LastName, D.DepartmentName, E.Salary, E.JoinDate
            FROM Employees E
            JOIN Departments D ON E.DepartmentID = D.DepartmentID
            WHERE E.DepartmentID = $deptId;
        ";

        cmd.Parameters.AddWithValue("$deptId", deptId);

        using (var reader = cmd.ExecuteReader())
        {
            Console.WriteLine($"{"ID",-5} {"Name",-20} {"Department",-15} {"Salary",-10} {"Join Date"}");
            Console.WriteLine(new string('-', 60));

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string fullName = reader.GetString(1) + " " + reader.GetString(2);
                string deptName = reader.GetString(3);
                decimal salary = reader.GetDecimal(4);
                string joinDate = reader.GetString(5);

                Console.WriteLine($"{id,-5} {fullName,-20} {deptName,-15} {salary,-10:C} {joinDate}");
            }
        }
    }
}
