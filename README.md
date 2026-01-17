🚀 ASP.NET Core Web API – Clean Architecture Demo

This project demonstrates how to build a scalable and maintainable ASP.NET Core Web API using modern best practices such as CRUD operations, Entity Framework Core, Repository Pattern, DTOs, AutoMapper, Dependency Injection, and Logging.

📌 Features

✔ API CRUD Operations
✔ Database Connectivity using Entity Framework Core
✔ Entity Framework Core (Code First)
✔ Data Annotations for Validation
✔ Dependency Injection (Built-in IoC Container)
✔ Data Transfer Objects (DTO)
✔ AutoMapper for Object Mapping
✔ Logging (Built-in ILogger)
✔ Repository Pattern
✔ Generic Repository Pattern
✔ API Consumption Demo (Swagger / Client App)

🛠️ Technology Stack

.NET 7 / .NET 6

ASP.NET Core Web API

Entity Framework Core

SQL Server

AutoMapper

Swagger (OpenAPI)

Dependency Injection

ILogger

📂 Project Structure
📦 WebApiDemo
 ┣ 📂 Controllers
 ┣ 📂 Models
 ┣ 📂 DTOs
 ┣ 📂 Data
 ┣ 📂 Repositories
 ┃ ┣ 📜 IRepository.cs
 ┃ ┣ 📜 GenericRepository.cs
 ┣ 📂 Services
 ┣ 📂 Mapping
 ┣ 📂 Logs
 ┣ 📜 Program.cs
 ┣ 📜 appsettings.json

🔁 CRUD Operations

The API supports full CRUD functionality:

Method	Endpoint	Description
GET	/api/products	Get all records
GET	/api/products/{id}	Get by ID
POST	/api/products	Create record
PUT	/api/products/{id}	Update record
DELETE	/api/products/{id}	Delete record
🗄️ Database Connectivity

Uses Entity Framework Core

Code-First approach

Migrations enabled

Add-Migration InitialCreate
Update-Database

🏷️ Data Annotations Example
public class Product
{
    [Key]
    public int Id { get; set; }

    [Required]
    [MaxLength(100)]
    public string Name { get; set; }

    [Range(1, 100000)]
    public decimal Price { get; set; }
}

🔌 Dependency Injection

Repositories and services are registered in Program.cs:

builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));

🔄 DTO & AutoMapper
DTO Example
public class ProductDto
{
    public string Name { get; set; }
    public decimal Price { get; set; }
}

AutoMapper Configuration
CreateMap<Product, ProductDto>().ReverseMap();

📜 Logging

Built-in ILogger is used for logging:

_logger.LogInformation("Fetching all products");
_logger.LogError("An error occurred");

🧩 Repository Pattern
Generic Repository Interface
public interface IGenericRepository<T> where T : class
{
    Task<IEnumerable<T>> GetAllAsync();
    Task<T> GetByIdAsync(int id);
    Task AddAsync(T entity);
    void Update(T entity);
    void Delete(T entity);
}

🧪 API Testing & Consumption
Swagger UI

Swagger is enabled for easy testing:

https://localhost:{port}/swagger

Consume API Using:

Postman

Swagger UI

Frontend App (Angular / React / MVC)

▶️ How to Run the Project

Clone the repository

git clone https://github.com/your-username/your-repo-name.git


Update appsettings.json connection string

Run migrations

Update-Database


Run the application

dotnet run

📌 Future Enhancements

Authentication & Authorization (JWT)

Unit Testing

Caching (Redis)

Pagination & Filtering

Global Exception Handling

🤝 Contributing

Contributions are welcome!
Feel free to fork this repository and submit a pull request.
