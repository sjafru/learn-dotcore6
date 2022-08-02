# learn-dotcore6

## Scaffold Database

Scaffold Contacts DB

```sh
dotnet ef dbcontext scaffold "Host=localhost;Database=northwind;Username=postgres;Password=mssql1Ipw" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities -t employees -t customers -c ContactDbContext
```

Scaffold Employees DB

```sh
dotnet ef dbcontext scaffold "Host=localhost;Database=northwind;Username=postgres;Password=mssql1Ipw" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities -t employees -t employee_territories -t territories -t region  -c EmployeeDbContext
```

Scaffold Orders DB

```sh
dotnet ef dbcontext scaffold "Host=localhost;Database=northwind;Username=postgres;Password=mssql1Ipw" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities -t orders -t order_details -t shippers -c OrdersDbContext
```

Scaffold Products DB

```sh
dotnet ef dbcontext scaffold "Host=localhost;Database=northwind;Username=postgres;Password=mssql1Ipw" Npgsql.EntityFrameworkCore.PostgreSQL -o Entities -t products -c ProductsDbContext
```