using Lib.Products.Entities;

namespace Lib.Products.Domain;

public interface IProductDetail
{
    IProductDetail SetProductName(string newName);
    IProductDetail SetStatus(string status);
}

public class ProductDetail : IProductDetail
{
    private Product? _entity;

    public ProductDetail()
    {
        this._entity = new Product();
    }

    public ProductDetail(Product? product)
    {
        this._entity = product;
    }

    public int ID => _entity.ProductId;
    public string ProductName => _entity.ProductName;

    public IProductDetail SetProductName(string newName)
    {
        throw new NotImplementedException();
    }

    public IProductDetail SetStatus(string status)
    {
        throw new NotImplementedException();
    }
}
