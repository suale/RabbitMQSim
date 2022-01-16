using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RabbitMQSim
{
    internal class CreateMessageList
    {


        public static int count = 0;

        public List<RabbitMessage> CreateList(int clientNumber, int initialRandom)
        {
            List<RabbitMessage> publishedMessages = new List<RabbitMessage>();

            

            Console.WriteLine(initialRandom);
            Console.WriteLine("-----------------------------");
            count++;

            for (int i = 0; i < clientNumber; i++)
            {
                
                RabbitMessage rabbitMessage = new RabbitMessage();
                rabbitMessage.ClientNo = i;
                rabbitMessage.DataNumber = count;

                if (initialRandom > 300)
                {
                    initialRandom -= 60;
                }
                else if (initialRandom < 0)
                {
                    initialRandom += 60;
                }

                if (rabbitMessage.Data > 300)
                {
                    rabbitMessage.Data -= 60;
                }
                else if (rabbitMessage.Data < 0)
                {
                    rabbitMessage.Data += 60;
                }


                rabbitMessage.Data = initialRandom;
                publishedMessages.Add(rabbitMessage);

                int secRandom;

                using (RNGCryptoServiceProvider rg = new RNGCryptoServiceProvider())
                {
                    byte[] rno = new byte[5];
                    rg.GetBytes(rno);
                    int randomvalue = BitConverter.ToInt32(rno, 0);
                    secRandom = randomvalue % 30;
                }

                initialRandom += secRandom;

            }
            return publishedMessages;
        }

    }
}
