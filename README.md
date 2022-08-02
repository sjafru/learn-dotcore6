# learn-dotcore6

| Minimal APIs are a good starting point for .NET to become lighter and have fewer ceremonies. Each abstraction brings additional cost. We should be trying to cut all the redundant layers to make our code composable and straightforward. CQRS can help with that by giving you the basic rules and skeleton for segregating your application behaviours. Are Minimal APIs and CQRS a perfect match? Nothing is perfect, but I think they’re good enough to at least play with it and consider it a building block in your architecture design.
[see](https://event-driven.io/en/cqrs_is_simpler_than_you_think_with_net6/)

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