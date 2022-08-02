using Lib.Products.Domain;

namespace Lib.Products.Queries;

public interface IFindProducts {
    IReadOnlyList<ProductDetail> ToList();
}

public class FindProducts : IFindProducts
{
    public IReadOnlyList<ProductDetail> ToList()
    {
        throw new NotImplementedException();
    }
}