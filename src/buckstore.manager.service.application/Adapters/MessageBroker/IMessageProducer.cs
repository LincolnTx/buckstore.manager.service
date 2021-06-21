using System.Threading.Tasks;
using buckstore.manager.service.application.IntegrationEvents;

namespace buckstore.manager.service.application.Adapters.MessageBroker
{
    public interface IMessageProducer<in TEvent> where TEvent : IntegrationEvent
    {
        Task Produce(TEvent message);
    }
}