using Lib.Products.Domain;

namespace WebApi.Products.Queries;

public interface IFindProducts {
    IFindProducts WithProductTypes(IEnumerable<ProductType> types);
    IFindProducts WithCategories(IEnumerable<int> categories);
    IReadOnlyList<ProductDetail> ToList();
}

public class FindProducts : IFindProducts
{
    public IReadOnlyList<ProductDetail> ToList()
    {
        throw new NotImplementedException();
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