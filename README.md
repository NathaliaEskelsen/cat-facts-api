# 🐱 Cat Facts API

A simple RESTful API built with **ASP.NET Core** and **SQL Server (MSSQL)** that allows users to perform CRUD operations on cat records. Each cat has attributes such as name, age, breed, and color.

## 🚀 Features

- Get all cats
- Get a single cat by ID
- Create a new cat
- Update a cat (PUT & PATCH)
- Delete a cat

## 🛠️ Technologies Used

- ASP.NET Core Web API
- Entity Framework Core
- AutoMapper
- SQL Server (MSSQL)
- JSON Patch support (`Microsoft.AspNetCore.JsonPatch`)

## 📁 Project Structure

- `Controllers/` — Handles HTTP requests (CatsController)
- `Models/` — Contains Cat model
- `Dtos/` — Data Transfer Objects for creating, reading, and updating cats
- `Data/` — Repository pattern (interface and SQL implementation)
- `Profiles/` — AutoMapper profiles
- `Startup.cs` — Configures services and middleware
- `appsettings.json` — Contains the connection string to the database

## 🔧 Setup Instructions

1. Clone the repo:
   ```bash
   git clone https://github.com/NathaliaEskelsen/cat-facts-api.git
   cd cat-facts-api
