using System;
using Microsoft.Data.Sqlite;

class ProgramAlt
{
    static void Main()
    {
        string connectionString = "Data Source=employee.db";

        using (var connection = new SqliteConnection(connectionString))
        {
            connection.Open();
            CreateSchema(connection);
            InsertSampleData(connection);

            while (true)
            {
                Console.WriteLine("\n--- Employee Management ---");
                Console.WriteLine("1. View All Employees");
                Console.WriteLine("2. Count Employees by Department");
                Console.WriteLine("3. Exit");
                Console.Write("Choose an option: ");
                string option = Console.ReadLine();

                if (option == "1")
                {
                    DisplayAllEmployees(connection);
                }
                else if (option == "2")
                {
                    Console.Write("Enter Department ID: ");
                    if (int.TryParse(Console.ReadLine(), out int deptId))
                    {
                        int count = GetEmployeeCountByDepartment(connection, deptId);
                        Console.WriteLine($"Total Employees in Department {deptId}: {count}");
                    }
                    else
                    {
                        Console.WriteLine("Invalid department ID.");
                    }
                }
                else if (option == "3")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid choice. Try again.");
                }
            }
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
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            INSERT OR IGNORE INTO Departments (DepartmentID, DepartmentName) VALUES
            (1, 'HR'), (2, 'Finance'), (3, 'IT'), (4, 'Marketing');

            INSERT OR IGNORE INTO Employees (EmployeeID, FirstName, LastName, DepartmentID, Salary, JoinDate) VALUES
            (1, 'Indrayudh', 'Mukherjee', 1, 20000.00, '2020-01-15'),
            (2, 'Harshita', 'Avi', 2, 15000.00, '2019-03-22'),
            (3, 'Devansh', 'Mihantuy', 3, 23000.00, '2018-07-30'),
            (4, 'Tarun', 'Sai Nath', 4, 23000.00, '2021-11-05');
        ";
        cmd.ExecuteNonQuery();
    }

    static int GetEmployeeCountByDepartment(SqliteConnection conn, int deptId)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = "SELECT COUNT(*) FROM Employees WHERE DepartmentID = $deptId;";
        cmd.Parameters.AddWithValue("$deptId", deptId);
        return Convert.ToInt32(cmd.ExecuteScalar());
    }

    static void DisplayAllEmployees(SqliteConnection conn)
    {
        var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            SELECT E.EmployeeID, E.FirstName, E.LastName, D.DepartmentName, E.Salary, E.JoinDate
            FROM Employees E
            JOIN Departments D ON E.DepartmentID = D.DepartmentID;
        ";

        using (var reader = cmd.ExecuteReader())
        {
            Console.WriteLine($"\n{"ID",-5} {"Name",-20} {"Department",-15} {"Salary",-10} {"Join Date"}");
            Console.WriteLine(new string('-', 60));

            while (reader.Read())
            {
                int id = reader.GetInt32(0);
                string fullName = reader.GetString(1) + " " + reader.GetString(2);
                string dept = reader.GetString(3);
                decimal salary = reader.GetDecimal(4);
                string date = reader.GetString(5);

                Console.WriteLine($"{id,-5} {fullName,-20} {dept,-15} {salary,-10:C} {date}");
            }
        }
    }
}
