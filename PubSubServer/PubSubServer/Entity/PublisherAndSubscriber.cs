using PubSubServer.Enums;
using System;
using System.Threading.Tasks;

namespace PubSubServer.Entity
{
    public  class PublisherAndSubscriber: IPublisherSubscriber
    {
        public PublisherAndSubscriber(PublisherType _type)
        {
            this.type = _type;
        }
        public PublisherType type { get; set; }

        public  event EventHandler<Message> publishEvent;

        public async Task PublishMessage(string message)
        {
            Message msg = new Message(type, message);
            if(publishEvent!=null)
            {
                publishEvent(this, msg);
            }
        }
        public async Task SubscribeMessage(PublisherAndSubscriber pubSub)
        {
            pubSub.publishEvent += ShowMessage;
        }
        public async Task UnSubscribeMessage(PublisherAndSubscriber pubSub)
        {
            pubSub.publishEvent -= ShowMessage;
        }
        public void ShowMessage(object sender, Message messageFormat)
        {
            PublisherAndSubscriber pubSub = (PublisherAndSubscriber)sender;
            Console.WriteLine("Subscriber : " + this.type + "=> Message publish by " + pubSub.type + ":" + messageFormat.message);
        }
    }
}
