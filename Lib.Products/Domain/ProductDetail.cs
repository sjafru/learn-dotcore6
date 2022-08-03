using Lib.Products.Entities;

namespace Lib.Products.Domain;

public interface IProductDetail
{
    void SetProductName(string newName);
    void SetStatus(string status);
}

public class ProductDetail : IProductDetail
{
    private Product? entity;

    public ProductDetail()
    {
        entity = new Product();
    }

    public ProductDetail(Product? product)
    {
        this.entity = product;
    }

    public int ID => entity.ProductId;
    public string ProductName => entity.ProductName;

    public void SetProductName(string newName)
    {
        throw new NotImplementedException();
    }

    public void SetStatus(string status)
    {
        throw new NotImplementedException();
    }
}
