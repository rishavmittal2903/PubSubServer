using PubSubServer.Entity;
using PubSubServer.Enums;
using System;
using System.Threading.Tasks;

namespace PubSubServer
{
    class Program
    {
        static void Main(string[] args)
        {
            Client client = new Client();
            client.CreatePublisherAndSubscriber();
            Console.ReadLine();
        }
    }
}
