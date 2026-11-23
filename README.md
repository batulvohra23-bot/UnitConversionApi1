# UnitConversionApi 

A RESTful **ASP.NET Core 10 Web API** for converting numerical values between different units of measurement. The API follows a clean, maintainable architecture with separation of concerns, dependency injection, centralized exception handling, and unit testing support.

## Features

- Convert values between different measurement units.
- Support for multiple conversion categories:
  - **Length:** Meter, Kilometer, Centimeter, Mile, Foot, Inch.
  - **Weight:** Kilogram, Gram, Pound, Ounce.
  - **Temperature:** Celsius, Fahrenheit, Kelvin.
- RESTful API endpoints.
- Centralized exception handling using custom middleware.
- Dependency Injection for service management.
- Swagger/OpenAPI documentation.
- Unit testing support using xUnit.
- Extensible architecture for adding new conversion categories.

## Technologies Used

- ASP.NET Core 10 Web API
- C# 
- .NET 10 SDK
- Swagger / OpenAPI
- Dependency Injection
- Custom Exception Middleware
- xUnit
- Git / GitHub

## Project Architecture

The application follows a layered structure to separate API handling, business logic, and error handling.

```text
UnitConversionApi1
│
├── UnitConversionApi1.Api
│   ├── Controllers
│   │   └── ConversionController.cs
│   │
│   ├── Services
│   │   ├── IConversionService.cs
│   │   └── ConversionService.cs
│   │
│   ├── Middleware
│   │   └── ExceptionMiddleware.cs
│   │
│   ├── Program.cs
│   └── appsettings.json
│
└── UnitConversionApi1.Tests
    └── ConversionServiceTests.cs
```

## Prerequisites

Before running the application, ensure you have installed:

- .NET 10 SDK
- Visual Studio 2026 or a compatible editor
- Git

## Getting Started

### 1. Clone the Repository

```bash
git clone https://github.com/yourusername/UnitConversionApi1.git
```

### 2. Navigate to the Project

```bash
cd UnitConversionApi1
```

### 3. Restore Dependencies

```bash
dotnet restore
```

### 4. Build the Application

```bash
dotnet build
```

### 5. Run the API

```bash
dotnet run --project src/UnitConversionApi
```

Update the project path if your actual `.csproj` file is located elsewhere.

## Swagger API Documentation

Once the application is running, open:

```text
https://localhost:5109/swagger/index.html
```

Swagger provides an interactive interface to explore and test the available API endpoints.

Use the actual HTTPS port displayed in your application startup output.

## Example API Usage

**Convert Length**

```http
POST /api/conversion
Content-Type: application/json
```

Request:

```json
{
  "category": "temperature",
  "fromUnit": "celsius",
  "toUnit": "fahrenheit",
  "value": 100
}
```

Example response:

```json
{
  "originalValue": 100,
  "fromUnit": "celsius",
  "toUnit": "fahrenheit",
  "convertedValue": 212
}

```

*The response illustrates the expected conversion format.*

## Running Unit Tests

Execute the following command from the solution directory:

```bash
dotnet test
```

The xUnit test project verifies conversion calculations and helps maintain application reliability.

## Design Decisions

**1. Separation of Concerns**

Controllers handle HTTP requests, while conversion calculations are maintained in a separate service layer.

**2. Dependency Injection**

The conversion service is registered using Scoped lifetime, making it easy to maintain and test.

**3. Centralized Exception Handling**

Custom exception middleware handles unhandled exceptions and provides consistent error responses.

**4. Testability**

The service interface allows unit testing independently of the API controller.

**5. Extensibility**

The architecture makes it easier to introduce additional conversion categories and units without tightly coupling business logic to controllers.

## Future Enhancements

- Database-driven conversion factors.
- Redis caching for frequently requested conversions.
- API versioning.
- Authentication and authorization.
- Admin management portal.
- Additional measurement categories.
- Improved logging and monitoring.

## Author

Batul Trunkwala

**UnitConversionApi**
