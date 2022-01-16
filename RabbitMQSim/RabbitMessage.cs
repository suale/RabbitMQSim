using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSim
{
    internal class RabbitMessage
    {
        public int ClientNo { get; set; }
        public int DataNumber { get; set; }
        public int Data { get; set; }
    }
}
