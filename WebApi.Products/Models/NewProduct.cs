using System.Text.Json.Serialization;
using FluentValidation;
using Lib.Products.Domain;

namespace WebApi.Products.Models;


public record NewProduct(string Name, ProductType Type = ProductType.Standard)
{
    public decimal BasePrice { get; set; }
    public string SKU { get; set; }
}

public class NewProductValidator : AbstractValidator<NewProduct>
{
    public NewProductValidator()
    {
        RuleFor(p => p.Name).NotEmpty().MinimumLength(3);

    }
}