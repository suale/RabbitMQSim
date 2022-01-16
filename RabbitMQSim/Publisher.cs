using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;




namespace RabbitMQSim
{
    internal class Publisher
    {
        private readonly RabbitMQService _rabbitMQService;

        public Publisher(string queueName, List<RabbitMessage> message)
        {
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(queueName, false, false, false, null);

                    foreach (var item in message)
                    {

                        string json = JsonConvert.SerializeObject(item);

                        channel.BasicPublish("", queueName, null, Encoding.UTF8.GetBytes(json));
                        Console.WriteLine(json);
                    }
                }
            }
        }

    }
}
