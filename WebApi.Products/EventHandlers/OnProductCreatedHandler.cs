
using DotNetCore.CAP;
using Lib.Products.Domain.Events;

namespace WebApi.Products.EventHandlers;

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