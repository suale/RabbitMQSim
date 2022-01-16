using FastMember;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Timers;



namespace RabbitMQSim
{
    internal class Consumer2
    {
        static ManualResetEvent _mre = new ManualResetEvent(false);
        private readonly RabbitMQService _rabbitMQService;

        public Consumer2(string queueName, int waitSec)
        {
            
            _rabbitMQService = new RabbitMQService();

            using (var connection = _rabbitMQService.GetRabbitMQConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    var consumer = new EventingBasicConsumer(channel);
                    //var aTimer = new System.Timers.Timer();
                    //aTimer.Interval = 3000;
                    //aTimer.Elapsed += OnTimedEventA;
                    //aTimer.AutoReset = true;
                    //aTimer.Enabled = true;
                    Thread t1 = new Thread(() =>
                     {
                         
                         consumer.Received += (model, ea) =>
                         {

                             _mre.WaitOne();
                             var body = ea.Body.ToArray();
                             var message = Encoding.UTF8.GetString(body);
                             Console.WriteLine("aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa");
                             var result = JsonConvert.DeserializeObject<RabbitMessage>(message);
                             DataRow r1 = GlobalDT.GlobalDt.NewRow();
                             r1["clientno"] = result.ClientNo;
                             r1["data"] = result.Data;
                             r1["datanumber"] = result.DataNumber;
                             GlobalDT.GlobalDt.Rows.Add(r1);




                            // Thread.Sleep(2000);

                         };
                         
                     });
                    t1.Start();

                    Thread t2 = new Thread(() =>
                    {
                        while (true)
                        {
                            _mre.Reset();
                            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
                            DBWriter dBWriter = new DBWriter();
                            dBWriter.Write();
                            _mre.Set();
                            Thread.Sleep(waitSec);
                            
                        }

                    });
                    t2.Start();


                    Console.WriteLine("Consume'a burada ne oluyor");
                    string consumerTag = channel.BasicConsume(queueName, true, consumer);                  
                    Console.ReadLine();
                }

            }
        }
        //private static void OnTimedEventA(Object source, System.Timers.ElapsedEventArgs e)
        //{
        //    Task.Run(() =>
        //    {
        //        Thread t2 = new Thread(() =>
        //        {
        //            Console.WriteLine("------------------------------------------------------------------------------------------------------------------");
        //            DBWriter dBWriter = new DBWriter();
        //            dBWriter.Write();
        //            Thread.Sleep(3000);

        //        });
        //        t2.Start();
        //        Console.WriteLine("The Elapsed event A was raised at {0}", DateTime.Now);

        //    });
        //}
    }
}





