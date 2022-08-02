
using DotNetCore.CAP;
using Lib.Products.Domain.Events;

namespace WebApi.Products.CapSubs;

public interface IOnProductCreatedHandler : ICapSubscribe
{

}

public class OnProductCreatedHandler : IOnProductCreatedHandler
{
    [CapSubscribe("products.events.oncreated")]
    public void Do(OnProductCreated @event)
    {
    }
}