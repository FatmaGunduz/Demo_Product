📌 About the Project
This project was developed by following the lessons of MuratYucedag.

DemoProduct is a product management system developed using ASP.NET Core MVC. The project uses Identity for authentication and authorization, and follows a layered architecture to ensure flexibility and maintainability.

The application provides Admin and User roles with different permission levels, product CRUD operations, dashboard management, and dynamic content components.

🏗 Technologies Used
ASP.NET Core MVC 8.0

Entity Framework Core

ASP.NET Core Identity

SQL Server (Database)

Bootstrap 5

JavaScript / jQuery

Layered Architecture

EntityLayer

DataAccessLayer

BusinessLayer

PresentationLayer (UI)

DemoProduct/
│
├── EntityLayer/         # Entity classes (AppUser, Product, Category, etc.)
├── DataAccessLayer/     # Repository and DbContext
├── BusinessLayer/       # Service layer and business logic
├── PresentationLayer/   # ASP.NET Core MVC Controllers, Views, ViewComponents
│   ├── Controllers/
│   ├── Views/
│   ├── ViewComponents/
│   └── wwwroot/
└── Demo_Product.sln

🔑 Authentication & Authorization
User Login: Managed via ASP.NET Core Identity SignInManager.

Password Security: Passwords are securely stored in the database using hashing.

Roles: Admin and User roles with different permissions.

Access Control: [Authorize] and [AllowAnonymous] attributes for restricted access.

⚙️ Features
User Login / Logout

Admin Panel:

Add / Edit / Delete Products (CRUD)

Category Management

Dashboard Statistics

ViewComponent Usage:

Dynamic dashboard cards

Notifications

Contact Form

Responsive UI (Bootstrap 5)







