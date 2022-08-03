using DotNetCore.CAP;

namespace WebApi.Products.EventHandlers;

public interface ISubscriberService : ICapSubscribe
{
    void CheckReceivedMessage(DateTime datetime);
}

public class SubscriberService : ISubscriberService
{
    [CapSubscribe("xxx.services.show.time")]
    public void CheckReceivedMessage(DateTime datetime)
    {
    }
}