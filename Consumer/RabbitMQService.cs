using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSim
{
    internal class RabbitMQService
    {
       
        private readonly string _hostName = "localhost";

        public IConnection GetRabbitMQConnection()
        {
            ConnectionFactory connectionFactory = new ConnectionFactory()
            {
                
                HostName = _hostName
                

        };

           // connectionFactory.DispatchConsumersAsync = true;
            return connectionFactory.CreateConnection();
        }
    }
}
