using System.Collections.ObjectModel;
using Lib.Products.Domain;
using Lib.Products.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebApi.Products.Queries;

public interface IFindProducts {
    IFindProducts WithProductTypes(IEnumerable<ProductType> types);
    IFindProducts WithCategories(IEnumerable<int> categories);
    ReadOnlyCollection<ProductDetail> ToList();

    ProductDetail Get(int productID);
}

public class FindProducts : IFindProducts
{
    private readonly ProductsDbContext _db;

    public FindProducts(ProductsDbContext db)
    {
        _db = db;
    }

    public ProductDetail Get(int productID)
    {
        var product = _db.Products.Find(productID);

        return new ProductDetail(product);
    }

    public ReadOnlyCollection<ProductDetail> ToList()
    {
        return _db.Products.AsNoTracking()
                           .ToList()
                           .Select(o => new ProductDetail(o))
                           .ToList()
                           .AsReadOnly();
    }

    public IFindProducts WithCategories(IEnumerable<int> categories)
    {
        return this;
    }

    public IFindProducts WithProductTypes(IEnumerable<ProductType> types)
    {
        return this;
    }
}