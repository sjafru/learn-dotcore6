namespace Lib.Products.Exceptions;

public class ProductDetailException : Exception
{
    public ProductDetailException()
    { }

    public ProductDetailException(string message)
        : base(message)
    { }

    public ProductDetailException(string message, Exception innerException)
        : base(message, innerException)
    { }
}