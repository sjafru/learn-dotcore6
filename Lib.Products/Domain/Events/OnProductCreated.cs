namespace Lib.Products.Domain.Events;

public record OnProductCreated(int ProductID, string UserID)
{
    public const string NAME = "products.events.oncreated";
}
