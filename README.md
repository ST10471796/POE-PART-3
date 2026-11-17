# RaceDay API & MVC Web Application

##  Project Description
The **RaceDay** system is a comprehensive full-stack application designed to manage running, walking, and cycling events. It consists of a RESTful Web API built with ASP.NET Core (Part 2) and a front-end MVC Web Application (Part 3). The system handles event creation, participant enrolments, and result capturing, securely managed by two distinct user roles.

##  User Roles
The application enforces strict Role-Based Access Control (RBAC):
1. **Organiser:** 
   - Can create, update, and delete events.
   - Can define categories for events (e.g., Senior, 10km, 21km).
   - Can view all enrolments for their events.
   - Can capture finish times and positions for participants.
2. **Participant:**
   - Can view available events and categories.
   - Can enrol in an event by selecting a specific category.
   - Can view their own race results.

---

## Tech Stack
- **Backend:** C# / ASP.NET Core Web API (.NET 8)
- **Frontend:** ASP.NET Core MVC
- **Database:** SQL Server (Entity Framework Core - Code First)
- **Authentication:** JWT (JSON Web Tokens) & Session Management
- **API Documentation:** Swagger (Swashbuckle)
- **Testing:** xUnit & EF Core InMemory
- **CI/CD:** GitHub Actions

---

##  Setup and Run Instructions

### Prerequisites
- Visual Studio 2022
- .NET 8.0 SDK
- SQL Server (LocalDB is sufficient)

### 1. Database Setup
1. Open the solution in Visual Studio.
2. In `RaceDay.API`, open the `appsettings.json` file and ensure the connection string points to your local SQL Server instance.
3. Open the **Package Manager Console** (Tools -> NuGet Package Manager -> Package Manager Console).
4. Select `RaceDay.API` as the Default Project.
5. Run the following commands:
   ```powershell
   Update-Database
