🛡️ JWT Authentication in ASP.NET Core Web API
This project demonstrates how to implement JWT (JSON Web Token) Authentication in an ASP.NET Core Web API microservice. It includes user login, token generation, and securing API endpoints using [Authorize] attributes.

🔧 Features
✅ User Login (/api/Auth/login)
✅ JWT Token Generation
✅ Secure Endpoints with [Authorize]
✅ CRUD Operations on protected resources (/api/Employee)
✅ Swagger UI for API Testing

💻 Technologies Used
ASP.NET Core 7/8/9 Web API

JWT Authentication (Microsoft.AspNetCore.Authentication.JwtBearer)

Swagger / Swashbuckle for API documentation

C# and .NET CLI

🚀 Getting Started
1️⃣ Clone the Repository
bash
Copy
Edit
git clone https://github.com/your-username/your-repo.git
cd your-repo
2️⃣ Install Dependencies
bash
Copy
Edit
dotnet restore
3️⃣ Build & Run
bash
Copy
Edit
dotnet build
dotnet run
🧭 Visit:
➡️ http://localhost:5045/swagger — for interactive API testing via Swagger UI

🔐 Authentication Flow
1️⃣ Get JWT Token
Make a POST request to /api/Auth/login

🧪 Sample Request:
bash
Copy
Edit
curl -X POST http://localhost:5045/api/Auth/login \
  -H "Content-Type: application/json" \
  -d '{
    "username": "indrayudh1111",
    "password": "helolo123323"
}'
📦 Sample Response:
json
Copy
Edit
{
  "token": "eyJhbGciOiJIUzI1NiIsInR..."
}
2️⃣ Access Protected Endpoint
Use the JWT token above in the Authorization header:

bash
Copy
Edit
curl -X GET http://localhost:5045/api/Employee \
  -H "Authorization: Bearer eyJhbGciOiJIUzI1NiIsInR..."
📂 Folder Structure
pgsql
Copy
Edit
WEEK5/
├── Controllers/
│   └── AuthController.cs
├── Models/
│   └── LoginModel.cs
├── Program.cs
├── appsettings.json
├── README.md
🛠 Configuration
📝 appsettings.json
json
Copy
Edit
{
  "Jwt": {
    "Key": "ThisIsASecretKeyForJwtToken_UseSecureLongKey",
    "Issuer": "MyAuthServer",
    "Audience": "MyApiUsers",
    "DurationInMinutes": 60
  }
}
🔒 Note: Make sure the Key is at least 256 bits (32+ characters) to avoid runtime crypto errors.

⚙️ Notes
🧪 Swagger is available only in Development mode.

🔐 Endpoints marked with [Authorize] require a valid Bearer token.

💾 Replace dummy login with real user DB/Identity system for production use.

📫 Contact
Maintained by Indrayudh Mukherjee
For Cognizant Week 5 Hands-On Assignment


