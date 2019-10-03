using PubSubServer.Entity;
using System;
using System.Threading.Tasks;

namespace PubSubServer
{
    public interface IPublisherSubscriber
    {
        event EventHandler<Message> publishEvent;
        Task PublishMessage(string message);
         Task SubscribeMessage(PublisherAndSubscriber pubSub);
        Task UnSubscribeMessage(PublisherAndSubscriber pubSub);
        void ShowMessage(object sender, Message messageFormat);

    }

}
