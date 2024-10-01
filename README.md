# OrdersApi
This repository features a sample API for managing customer orders using C#. It includes key operations like order creation and retrieval, while showcasing FluentValidation for clean, robust request validation. Ideal for demonstrating best practices in API development and validation in C#.

### Databae migrations

In order to execute EF Core commands from .NET CLI install EF Core Tools.

To create a new migration you can use .NET CLI and execute the following command: 

```
dotnet ef migrations add <NAME> --project <PathToProjectWhereIsDbContext> --startup-project <PathToMainApiProject> --context <ContextName> --output-dir <PathToMigrationsDir> --configuration Debug --no-build
```
Migration script example: 
```
dotnet ef migrations add AddProductIdToOrderLineTable --project .\src\modules\core\infrastructure --startup-project .\src\api\app --context CoreDbContext --output-dir .\Migrations --configuration Debug --no-build
```
 To remove latest migration you can use .NET CLI and execute the following command: 

```
dotnet ef migrations remove --project <PathToProjectWhereIsDbContext> --startup-project <PathToMainApiProject> --context <ContextName> --configuration Debug --no-build
```
Migration script example: 
```
dotnet ef migrations remove  --project .\src\modules\core\infrastructure --startup-project .\src\api\app --context CoreDbContext --configuration Debug --no-build
```