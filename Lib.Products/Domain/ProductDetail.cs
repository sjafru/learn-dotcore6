namespace Lib.Products.Domain;

public interface IProductDetail
{
    int ID { get; }
}

public class ProductDetail : IProductDetail
{
    public int ID { get; internal set; }
}
