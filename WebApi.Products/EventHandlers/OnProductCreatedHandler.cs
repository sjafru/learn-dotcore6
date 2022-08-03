
using DotNetCore.CAP;
using Lib.Products.Domain.Events;

namespace WebApi.Products.CapSubs;

public interface IOnProductCreatedHandler : ICapSubscribe
{

}

public class OnProductCreatedHandler : IOnProductCreatedHandler
{
    [CapSubscribe(OnProductCreated.NAME)]
    public void Do(OnProductCreated @event)
    {
    }
}