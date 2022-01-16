using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQSim;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsumerSide
{
    internal class Program
    {
        private static Consumer2 _consumer;
        private static readonly string _queueName = "KUYRUK5";
        //  static ManualResetEvent _mre = new ManualResetEvent(false);

        public static void Main(string[] args)
        {

            Console.WriteLine("DB saniye girin:");
            int secRef = Int16.Parse(Console.ReadLine());
            secRef *= 1000;

            
           _consumer = new Consumer2(_queueName,secRef);
         

          
            Console.ReadLine();
            
        }

     
    }
}







