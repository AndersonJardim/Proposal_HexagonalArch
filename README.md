# ProjetoProposta

## Overview

ProjetoProposta is a sample project demonstrating the use of Hexagonal Architecture, Domain-Driven Design (DDD), SOLID principles, and Test-Driven Development (TDD) in a .NET 8 environment. It includes an API built with C# and Entity Framework, with comprehensive testing using XUnit.

## Key Features

- **Hexagonal Architecture:** Clear separation of concerns for maintainability and testability.
- **Domain-Driven Design (DDD):** Rich and expressive domain model.
- **SOLID Principles:** Maintainable, extensible, and robust codebase.
- **Test-Driven Development (TDD):** XUnit tests drive the development process.
- **API:** Built with .NET, providing endpoints for application interaction.
- **Entity Framework:** ORM for database interaction.
- **XUnit:** Testing framework for unit and integration tests.
- **RabbitMQ Integration:** Asynchronous communication between projects.
- **Database Versioning:** Database schema is versioned using Entity Framework migrations or SQL scripts.

## Projects

### ProjetoProposta

The main project, implementing business logic, API endpoints, and data persistence.

### ProjetoContrato

A companion project that follows the same architectural and development practices (Hexagonal, DDD, SOLID, TDD, .NET 8, Entity Framework, XUnit).  
**ProjetoProposta** and **ProjetoContrato** communicate asynchronously via RabbitMQ, enabling decoupled and scalable integration between services.

## Technologies Used

- .NET 8
- C#
- Entity Framework
- XUnit
- RabbitMQ

## Database Versioning

The database schema is managed and versioned using Entity Framework migrations. This ensures that all changes to the database structure are tracked and can be applied consistently across different environments.

### Common Commands

- **Add a new migration:**
    ```bash
    dotnet ef migrations add <MigrationName> --project <Project>.Infrastructure --startup-project <Project>.API
    ```
    Replace `<MigrationName>` with a descriptive name and `<Project>` with either `ProjetoProposta` or `ProjetoContrato`.

- **Update the database to the latest migration:**
    ```bash
    dotnet ef database update --project <Project>.Infrastructure --startup-project <Project>.API
    ```

- **Generate SQL script for migrations:**
    ```bash
    dotnet ef migrations script --project <Project>.Infrastructure --startup-project <Project>.API
    ```

> If you prefer, you can also manage the database schema using custom SQL scripts. Place your scripts in a dedicated folder (e.g., `Scripts/`) and execute them manually or via CI/CD pipelines.

## Getting Started

### Prerequisites

- .NET 8 SDK
- RabbitMQ server (for inter-project communication)

### Installation

1. Clone the repository:

    ```bash
    git clone https://github.com/AndersonJardim/Proposal_HexagonalArch.git
    ```
2. Navigate to the project directory:

    ```bash
    cd ProjetoProposta
    ```
3. Restore NuGet packages:

    ```bash
    dotnet restore
    ```

### Running the Applications

1. Build the solution:

    ```bash
    dotnet build
    ```
2. Start RabbitMQ (if not already running).
3. Run the API projects:

    ```bash
    dotnet run --project ProjetoProposta.API
    dotnet run --project ProjetoContrato.API
    ```

### Running Tests

1. Navigate to the test project directory:

    ```bash
    cd ProjetoProposta.Tests
    ```
2. Run the tests:

    ```bash
    dotnet test
    ```

## 🧱 Architecture / Project Structure 
<img width="1529" height="664" alt="Image" src="https://github.com/user-attachments/assets/9f8c6f64-0f03-48d0-8064-e0792aef34f4" />
---

