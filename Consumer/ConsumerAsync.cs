using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSim
{
    internal class ConsumerAsync
    {
        private readonly AsyncRabbitMQService _rabbitMQService;

        public ConsumerAsync(string queueName)
        {

            _rabbitMQService = new AsyncRabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new AsyncEventingBasicConsumer(channel);
                    consumer.Received += async (model, ea) =>
                    {


                        var body = ea.Body.ToArray();
                        var message = Encoding.UTF8.GetString(body);
                        //Console.WriteLine("*************************************************************************");
                        var result = JsonConvert.DeserializeObject<RabbitMessage>(message);
                        DataRow r1 = GlobalDT.GlobalDt.NewRow();
                        r1["clientno"] = result.ClientNo;
                        r1["data"] = result.Data;
                        r1["datanumber"] = result.DataNumber;
                        GlobalDT.GlobalDt.Rows.Add(r1);
                        channel.BasicAck(ea.DeliveryTag, false);
                        await Task.Yield();

                    };

                    Console.WriteLine("Consume'a burada ne oluyor");
                    string consumerTag = channel.BasicConsume(queueName, false, consumer);
                    Console.ReadLine();
                }

            }
        }
    }
}