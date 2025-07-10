# WEEK 4 - Cognizant Web API Hands-on

**Name:** Indrayudh Mukherjee  
**SUPERSET ID:** 6364163 

---

## ✅ Features Implemented

- ✅ ASP.NET Core Web API (.NET 6/7+)
- ✅ JWT-based Authentication and Token Generation
- ✅ Role-based Authorization using `[Authorize(Roles = "...")]`
- ✅ Secure Endpoints: Employee CRUD
- ✅ Swagger UI Integration with JWT Bearer token input
- ✅ Clean separation: Controllers, Models, Services, Filters, Utils
- ✅ Hardcoded data used for simulation
- ✅ Proper GitHub structure and documentation

---

## 📦 Technologies Used

- ASP.NET Core Web API
- JWT (JSON Web Tokens)
- Swagger (Swashbuckle)
- Dependency Injection
- CORS (optional), Filters, Exception Handling

---

## 🚀 How to Run the Project Locally

1. **Clone the Repository**

```bash
git clone https://github.com/IndrayudhMukherjee/COGNIZANT-6364163_INDRAYUDH-MUKHERJEE.git
cd COGNIZANT-6364163_INDRAYUDH-MUKHERJEE/WEEK-4
Restore and Build

bash

dotnet restore
dotnet build
Run the Web API

bash

dotnet run
Access Swagger UI


http://localhost:5026/swagger
🔐 Generate JWT Token
Expand GET /api/Auth/token

Click Try it out → Execute

Copy the token from the response

🔓 Authenticate Swagger Requests
Click Authorize (top right in Swagger UI)

Paste:
Bearer <your_token_here>
Click Authorize

🔄 Test API Endpoints
Method	Endpoint	Description
GET	/api/Employee	Get all employees
GET	/api/Employee/{id}	Get employee by ID
POST	/api/Employee	Add new employee
PUT	/api/Employee/{id}	Update employee by ID
DELETE	/api/Employee/{id}	Delete employee by ID

🔒 All /api/Employee/* endpoints are protected by JWT + Role Admin.

📁 Project Structure
mathematica
Copy
Edit
WEEK-4/
├── Controllers/
├── Models/
├── Filters/
├── Services/
├── Utils/
├── Properties/
├── Program.cs
├── MyWebApi.csproj
├── .gitignore
└── README.md
🙌 Author
Indrayudh Mukherjee
Cognizant Hands-on Submission (Week 4)
Employee ID: 6364163


---

## 📌 What to Do Next

1. Copy this text into your `README.md` file inside `WEEK-4/`
2. Commit and push:

```bash
git add README.md
git commit -m "Added project README for Cognizant submission"
git push
