# ECommerce API

A modern and scalable E-Commerce Web API built with ASP.NET Core. This project demonstrates best practices for building secure and
maintainable RESTful APIs using Clean Architecture, Entity Framework Core, ASP.NET Core Identity, and JWT Authentication.
The API provides authentication, user management, product management, categories, shopping cart, orders,
and reviews while following a layered architecture that keeps the code clean, organized, and easy to extend.
---------------------------------
## Features

- User Registration & Login
- JWT Authentication
- Refresh Token
- ASP.NET Core Identity
- Role-Based Authorization
- Policy-Based Authorization
- Claims-Based Authorization
- Email Confirmation
- Forgot & Reset Password
- Product Management
- Category Management
- Shopping Cart
- Order Management
- Product Reviews
- FluentValidation
- AutoMapper
- Repository Pattern
- Unit of Work
- Global Exception Handling
- SQL Server Database
- Swagger API Documentation
  
--------------------------------------
## Built With

- ASP.NET Core
- C#
- Entity Framework Core
- SQL Server
- ASP.NET Core Identity
- JWT Bearer Authentication
- AutoMapper
- FluentValidation
- Clean Architecture
- Repository Pattern
- Unit of Work
- Swagger (OpenAPI)

-----------

## Project Structure

ECommerce
│
├── Controllers
├── Services
├── Repositories
├── Interfaces
├── DTOs
├── Models
├── Data
├── Migrations
├── Mapping
├── Validators
└── Program.cs

## Getting Started

### Clone the repository

```bash
git clone https://github.com/Momen054/ECommerce-API.git
```

### Navigate to the project

```bash
cd ECommerce-API
```

### Restore dependencies

```bash
dotnet restore
```

### Apply database migrations
```bash
dotnet ef database update
```

### Run the application
```bash
dotnet run
```

Open Swagger in your browser:
```
https://localhost:xxxx/swagger
```

## Authentication

The API uses JWT Bearer Authentication.
After logging in, include the access token in the Authorization header.

```http
Authorization: Bearer YOUR_ACCESS_TOKEN
```
---
## API Modules

- Authentication
- Users
- Roles
- Products
- Categories
- Shopping Cart
- Orders
- Reviews

---

## Design Principles

This project follows Clean Architecture principles to achieve:

- Separation of Concerns
- Scalability
- Maintainability
- Reusability
- Dependency Injection
- Clean and Organized Code

---

## Future Enhancements

- Payment Gateway Integration (Stripe)
- Redis Caching
- SignalR Notifications
- Docker Support
- Unit Testing
- Integration Testing
- GitHub Actions (CI/CD)
- Azure Deployment

---

## Author

Momen Ahmed

GitHub: https://github.com/Momen054

---

## License

This project is licensed under the MIT License.
