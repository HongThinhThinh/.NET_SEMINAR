# Demo2 API - 3-Layer Architecture with Entity Framework Core

Dự án API được xây dựng theo mô hình 3 lớp (Controller-Services-Repository) tuân thủ nguyên tắc SOLID và sử dụng Entity Framework Core. Dự án được tổ chức thành các project riêng biệt trong một solution để đảm bảo tách biệt rõ ràng giữa các layer.

## 🏗️ Kiến trúc dự án

### Cấu trúc Solution

```
Seminar.HandOn/
├── Controller/                    # 🎯 Presentation Layer (Web API)
│   ├── Controllers/              # API Controllers
│   ├── Program.cs               # Entry point & DI configuration
│   ├── appsettings.json         # Configuration settings
│   ├── WeatherForecast.cs       # Sample model
│   ├── api-test.http           # API testing file
│   ├── Demo2.http              # API endpoint examples
│   └── Controller.csproj        # Project file
├── Services/                     # 🔧 Business Logic Layer
│   ├── DTOs/                    # Data Transfer Objects
│   ├── Interfaces/              # Service interfaces
│   ├── Implementations/         # Service implementations
│   ├── Mappings/               # AutoMapper profiles
│   └── Services.csproj         # Project file
├── Repositories/                 # 🗄️ Data Access Layer
│   ├── Models/                  # Domain entities
│   ├── Data/                    # DbContext configuration
│   ├── Interfaces/              # Repository interfaces
│   ├── Implementations/         # Repository implementations
│   ├── Base/                    # Base repository classes
│   ├── Migrations/              # EF Core migrations
│   ├── Class1.cs               # Default class file
│   └── Repositories.csproj     # Project file
├── ClassLibrary1/               # 📚 Additional library (if needed)
│   └── Services.csproj         # Legacy project reference
├── README.md                    # Project documentation
└── Seminar.HandOn.sln          # Solution file
```

### Project Dependencies

```
Controller (Web API)
    ↓ references
Services (Business Logic)
    ↓ references
Repositories (Data Access)
```

### Nguyên tắc SOLID được áp dụng

1. **Single Responsibility Principle (SRP)**

   - Mỗi project có một trách nhiệm duy nhất
   - Controllers chỉ xử lý HTTP requests và routing
   - Services xử lý business logic và validation
   - Repositories chỉ xử lý data access

2. **Open/Closed Principle (OCP)**

   - Generic Repository Pattern cho phép mở rộng mà không cần sửa đổi
   - Interface-based design trên tất cả các layer
   - Dễ dàng thêm features mới mà không ảnh hưởng code cũ

3. **Liskov Substitution Principle (LSP)**

   - Các implementation có thể thay thế interface mà không ảnh hưởng
   - Mock objects có thể thay thế real objects trong testing

4. **Interface Segregation Principle (ISP)**

   - Interfaces nhỏ và chuyên biệt cho từng domain
   - Không ép buộc implement những method không cần thiết

5. **Dependency Inversion Principle (DIP)**
   - High-level modules không phụ thuộc vào low-level modules
   - Dependency Injection được cấu hình trong Program.cs
   - Tất cả dependencies đều được inject qua interfaces

## 🚀 Công nghệ và Framework

### Core Technologies

- **.NET 8.0** - Latest LTS framework
- **ASP.NET Core Web API** - RESTful API framework
- **Entity Framework Core** - Object-Relational Mapping (ORM)
- **SQL Server** - Primary database
- **AutoMapper 12.0.1** - Object-to-object mapping

### Development Tools

- **Swagger/OpenAPI** - API documentation và testing
- **HTTP files** - API endpoint testing
- **Visual Studio 2022** - IDE với Git integration

### Architecture Patterns

- **Generic Repository Pattern** - Data access abstraction
- **Unit of Work Pattern** - Transaction management
- **Dependency Injection** - IoC container
- **DTO Pattern** - Data transfer between layers

## 📊 Database Design

### Domain Entities

**Category Entity**

```csharp
- Id (int, Primary Key, Identity)
- Name (string, Required, MaxLength: 100)
- Description (string, Optional, MaxLength: 500)
- CreatedAt (DateTime, Required)
- UpdatedAt (DateTime, Required)
- IsDeleted (bool, Default: false)
- Products (Navigation Property - One-to-Many)
```

**Product Entity**

```csharp
- Id (int, Primary Key, Identity)
- Name (string, Required, MaxLength: 200)
- Description (string, Optional, MaxLength: 1000)
- Price (decimal, Required, Precision: 18,2)
- Stock (int, Required, Default: 0)
- CategoryId (int, Foreign Key)
- Category (Navigation Property - Many-to-One)
- CreatedAt (DateTime, Required)
- UpdatedAt (DateTime, Required)
- IsDeleted (bool, Default: false)
```

### Connection String

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=HONGTHINH\\HONGTHINH;Database=demo;User Id=sa;Password=123;TrustServerCertificate=true;"
  }
}
```

## 🔧 Cài đặt và Triển khai

### Yêu cầu hệ thống

- **.NET 8.0 SDK** - [Download](https://dotnet.microsoft.com/download/dotnet/8.0)
- **SQL Server** (SQL Server Express/LocalDB/Full version)
- **Visual Studio 2022** hoặc **VS Code** với C# extension
- **Git** - Version control

### Các bước cài đặt

1. **Clone repository**

   ```bash
   https://github.com/HongThinhThinh/.NET_SEMINAR.git
   cd ".NET_SEMINAR"
   ```

2. **Restore NuGet packages**

   ```bash
   dotnet restore Seminar.HandOn.sln
   ```

3. **Cấu hình database connection** (nếu cần)

   Chỉnh sửa `Controller/appsettings.json`:

   ```json
   {
     "ConnectionStrings": {
       "DefaultConnection": "Server=YOUR_SERVER;Database=demo;User Id=YOUR_USER;Password=YOUR_PASSWORD;TrustServerCertificate=true;"
     }
   }
   ```

4. **Tạo và chạy database migrations**

   ```bash
   cd Controller
   dotnet ef database update
   ```

5. **Build solution**

   ```bash
   dotnet build Seminar.HandOn.sln
   ```

6. **Chạy ứng dụng**

   ```bash
   cd Controller
   dotnet run
   ```

7. **Truy cập API documentation**
   - Swagger UI: `https://localhost:5001/swagger`
   - API Base URL: `https://localhost:5001/api`

## 🔒 Tính năng chính

### Core Features

- ✅ **RESTful API Design** - Following REST principles
- ✅ **Soft Delete Pattern** - Data preservation với IsDeleted flag
- ✅ **Audit Fields** - Automatic tracking CreatedAt, UpdatedAt
- ✅ **Data Validation** - Comprehensive validation với Data Annotations
- ✅ **Global Exception Handling** - Centralized error management
- ✅ **Auto Mapping** - AutoMapper cho entity-DTO conversion
- ✅ **Generic Repository** - Reusable CRUD operations
- ✅ **Unit of Work** - Transaction management pattern
- ✅ **Dependency Injection** - Built-in IoC container

### Technical Features

- 🔧 **Configuration Management** - appsettings.json với environment support
- 🔧 **API Documentation** - Interactive Swagger UI
- 🔧 **HTTP Testing** - Pre-configured .http files
- 🔧 **Database Migrations** - EF Core Code-First approach
- 🔧 **Project Separation** - Clean architecture với separate assemblies

## 📝 Design Patterns Implementation

1. **Repository Pattern**

   - Generic base repository for common operations
   - Specific repositories for domain-specific queries
   - Interface segregation for better testability

2. **Unit of Work Pattern**

   - Coordinate multiple repositories
   - Transaction boundary management
   - Ensure data consistency

3. **DTO Pattern**

   - Separate models for API contracts
   - Input validation và output formatting
   - Prevent over-posting attacks

4. **Dependency Injection**

   - Constructor injection throughout
   - Interface-based programming
   - Testable và loosely coupled code

5. **Generic Programming**
   - Type-safe operations
   - Code reusability
   - Reduced boilerplate code

## 🎯 Best Practices Implemented

### Code Quality

- ✅ **Separation of Concerns** - Clear layer boundaries
- ✅ **Single Responsibility** - Each class has one job
- ✅ **Interface Programming** - Depend on abstractions
- ✅ **Configuration Management** - Externalized settings
- ✅ **Error Handling** - Comprehensive exception management
- ✅ **Data Validation** - Multiple validation layers
- ✅ **API Documentation** - Self-documenting endpoints

### Architecture

- ✅ **Clean Architecture** - Dependency flow inward
- ✅ **SOLID Principles** - All five principles applied
- ✅ **Domain-Driven Design** - Rich domain models
- ✅ **Test-Friendly Design** - Easy to mock và test

## 🔄 Request/Response Flow

```
1. HTTP Request → Controller (Presentation Layer)
   ├── Route mapping và parameter binding
   ├── Model validation với DTOs

2. Controller → Service (Business Layer)
   ├── Business logic execution
   ├── Data validation và processing
   └── Transaction coordination

3. Service → Repository (Data Layer)
   ├── Data access operations
   ├── Entity Framework queries
   └── Database transactions

4. Database → Repository → Service → Controller
   ├── Entity to DTO mapping
   ├── Response formatting
   └── HTTP response with status codes
```

### Official Documentation

- [ASP.NET Core Documentation](https://docs.microsoft.com/en-us/aspnet/core/)
- [Entity Framework Core](https://docs.microsoft.com/en-us/ef/core/)

### Architecture References

- [Clean Architecture by Robert Martin](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)
- [Repository Pattern](https://docs.microsoft.com/en-us/dotnet/architecture/microservices/microservice-ddd-cqrs-patterns/infrastructure-persistence-layer-design)
- [Unit of Work Pattern](https://www.martinfowler.com/eaaCatalog/unitOfWork.html)

## 📞 Support & Contact

- **Repository**: [GitHub Repository](https://github.com/HongThinhThinh)
- **Issues**: Create GitHub issues for bugs và feature requests
- **Documentation**: README.md và inline code comments

---

**Developed with ❤️ using .NET 8 và Clean Architecture principles**
