using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQSim
{
    internal class Program
    {
        private static readonly string _queueName = "KUYRUK5";
       


        static void Main(string[] args)
        {

            Console.WriteLine("Istemci sayisi girin:");
            int clientNumber = Int32.Parse(Console.ReadLine());
            
            

            PublisherToLoop publisherToLoop = new PublisherToLoop();

            new Thread(() =>
            {
                Thread.CurrentThread.IsBackground = true;
                
                publisherToLoop.PublishToLoop(clientNumber, _queueName);
            }).Start();


            //CreateMessageList createMessageList = new CreateMessageList();

            //List<RabbitMessage> publishedMessages = new List<RabbitMessage>();

            //publishedMessages = createMessageList.CreateList(clientNumber);

            //_publisher = new Publisher(_queueName, publishedMessages);


            //foreach (var item in publishedMessages)
            //{
            //    Console.WriteLine(item.ClientNo+" "+item.DataNumber+" "+item.Data);
            //}


            Console.ReadKey();

        }
    }
}
