# ASP.NET Core DTO Example

A REST API using ASP.NET Core, following best practices and implementing a simple Data Transfer Object (DTO) pattern.

## Features

- CRUD operations for Student entities
- Uses DTOs for request/response
- Entity Framework Core with MySQL
- Follows clean architecture principles

## Dependencies

- ASP.NET Core
- EntityFrameworkCore
- MySQL

## Getting Started

### Prerequisites

- [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
- [MySQL Server](https://dev.mysql.com/downloads/)

### Setup

1. Clone the repository:
   ```bash
   git clone <your-repo-url>
   cd student-api
   ```
2. Update the `appsettings.json` or `appsettings.Development.json` with your MySQL connection string.
3. Apply database migrations:
   ```bash
   dotnet ef database update
   ```
4. Run the API:
   ```bash
   dotnet run
   ```

### API Endpoints

- `GET /api/student` - List all students
- `GET /api/student/{id}` - Get a student by ID
- `POST /api/student` - Create a new student
- `PUT /api/student/{id}` - Update a student
- `DELETE /api/student/{id}` - Delete a student

### Example Request (Create Student)

```json
POST /api/student
{
  "name": "John Doe",
  "age": 21,
  "email": "john@example.com"
}
```

## Project Structure

- `Controllers/` - API controllers
- `DTO/` - Data Transfer Objects
- `Models/` - Entity models and DbContext
- `Services/` - Business logic
- `Migrations/` - EF Core migrations

## License

MIT
