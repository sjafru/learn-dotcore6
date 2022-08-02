using DotNetCore.CAP;
using Savorboard.CAP.InMemoryMessageQueue;
using FluentValidation;
using Lib.Products.Domain;
using Lib.Products.Entities;
using Microsoft.EntityFrameworkCore;
using WebApi.Products.CapSubs;
using WebApi.Products.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ProductsDbContext>(opts => opts.UseNpgsql(builder.Configuration.GetConnectionString("Default")));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();

builder.Services.AddValidatorsFromAssemblyContaining<Program>();

builder.Services.AddTransient<ISubscriberService, SubscriberService>();
builder.Services.AddCap(x =>
{
    x.UseDashboard();

    // x.UseEntityFramework<ProductsDbContext>();
    // x.UseNATS("nats://0.0.0.0:4222");

    x.UseInMemoryStorage();
    x.UseInMemoryMessageQueue();
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
void HandleGetProducts()
{
    
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
    bus.Publish("xxx.services.show.time", DateTime.Now);

    return Results.Created($"/{product.ID}", product);
}
#endregion

#region Endpoints

app.MapGet("/products", HandleGetProducts).WithName("GetProducts").ProducesValidationProblem(400).Produces(200);
app.MapPost("/products", HandlePostProduct).WithName("AddProduct").ProducesValidationProblem(400).Produces(200);

#endregion

app.Run();
