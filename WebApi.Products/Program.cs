using DotNetCore.CAP;
using Savorboard.CAP.InMemoryMessageQueue;
using FluentValidation;
using Lib.Products.Domain;
using Lib.Products.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Products.EventHandlers;
using WebApi.Products.Models;
using Lib.Products.Domain.Events;
using WebApi.Products.Queries;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductsDbContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddTransient<IFindProducts, FindProducts>();

builder.Services.AddTransient<ISubscriberService, SubscriberService>();
builder.Services.AddTransient<IOnProductCreatedHandler, OnProductCreatedHandler>();

builder.Services.AddCap(x =>
{
    x.UseDashboard();

    if (builder.Environment.EnvironmentName == "Development")
    {
        x.UseInMemoryStorage();
        x.UseInMemoryMessageQueue();
    }
    else
    {
        // x.UseEntityFramework<ProductsDbContext>();
        // x.UseNATS("nats://0.0.0.0:4222");
    }

});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region Handlers
IResult HandleGetProducts(IFindProducts q)
{
    return Results.Ok(q.ToList());
}

async Task<IResult> HandlePostProduct(NewProduct req, IValidator<NewProduct> validator, ICapPublisher bus, ProductsDbContext db)
{
    // validate
    var valresult = validator.Validate(req);
    if (!valresult.IsValid)
        return Results.ValidationProblem(valresult.ToDictionary());

    // processing
    var product = new ProductDetail();

    await db.SaveChangesAsync();

    // notification
    bus.Publish(OnProductCreated.NAME, new OnProductCreated(product.ID, "system"));

    return Results.Created($"/{product.ID}", product);
}
#endregion

#region Endpoints

app.MapGet("/products", HandleGetProducts).WithName("GetProducts").ProducesValidationProblem(400).Produces(200);
app.MapPost("/products", HandlePostProduct).WithName("AddProduct").ProducesValidationProblem(400).Produces(200);

#endregion

app.Run();
