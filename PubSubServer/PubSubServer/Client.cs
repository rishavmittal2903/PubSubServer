using PubSubServer.Entity;
using PubSubServer.Enums;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace PubSubServer
{
   public class Client
    {
        private string[] Greetings = { "Hello, How are you?", "Hey, I am good", "Hi, What is your good name?", "Hi, I am living in America" };
        private Random random = new Random();
        Task[] taskArray = new Task[10];
        private T RandomEnumValue<T>()
        {
            var v = Enum.GetValues(typeof(T));
            return (T)v.GetValue(random.Next(v.Length));
        }
        private async Task SendMessage(Task data)
        {
            var message = data.AsyncState as PublisherAndSubscriber;
            await message.PublishMessage(Greetings[random.Next(0, Greetings.Length)]);
        }
        public async Task CreatePublisherAndSubscriber()
        {
            
            #region Creating random publisher for different news channels
           
            for (int i = 0; i < taskArray.Length; i++)
            {
                var value = RandomEnumValue<PublisherType>();
                taskArray[i] = Task.Factory.StartNew((Object obj) => {
                    PublisherAndSubscriber data = obj as PublisherAndSubscriber;
                }, new PublisherAndSubscriber(value));
            }
            #endregion
            Task.WaitAll(taskArray);
            #region Creating subscriber for publishers 
            foreach (var task in taskArray)
            {
                var data = task.AsyncState as PublisherAndSubscriber;
                if (data != null)
                {
                    var subscriberObject = taskArray[random.Next(taskArray.Length)].AsyncState as PublisherAndSubscriber;
                    await data.SubscribeMessage(subscriberObject);
                }
            }
            #endregion
            #region Publish messages
            Parallel.ForEach(taskArray, item => SendMessage(item));
            #endregion

        }
    }
}


