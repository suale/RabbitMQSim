using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace RabbitMQSim
{
    internal class PublisherToLoop
    {
        private static Publisher _publisher;

        public void PublishToLoop(int clientNumber, string _queueName)
        {
            Random rnd = new Random();
            int initialRandom = rnd.Next(100, 200);

            while (true)
            {
                CreateMessageList createMessageList = new CreateMessageList();

                List<RabbitMessage> publishedMessages = new List<RabbitMessage>();
                
                publishedMessages = createMessageList.CreateList(clientNumber, initialRandom);

                initialRandom = publishedMessages[clientNumber - 1].Data;
                
                

                _publisher = new Publisher(_queueName, publishedMessages);
                Thread.Sleep(1);
            }
        }
    }
}
