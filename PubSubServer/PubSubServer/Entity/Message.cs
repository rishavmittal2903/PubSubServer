using PubSubServer.Enums;

namespace PubSubServer.Entity
{
    public class Message
    {
        public PublisherType type { get; set; }
        public string message { get; set; }
        public Message(PublisherType _type,string _message)
        {
            this.type = _type;
            this.message = _message;
        }
    }
}
