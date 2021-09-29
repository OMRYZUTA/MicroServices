using System;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using common;

namespace Send
{
    class Send
    {
        static void Main(string[] args)
        {
            //trial
            //Console.WriteLine("Jah");
            //string message = new Encriptor().Encript("Jah");
            //Console.WriteLine(message); 
            //Console.WriteLine(new Decryptor().Decrypt(message));

            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "summaries",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);



                int listCount = new Random().Next(2, 10);

                while (listCount > 0)
                {
                    Summary summary = SummaryFactory.CreateRandomSummary();
                    Console.WriteLine("summary before entering the queue: " + summary);
                    string jsonString = JsonConvert.SerializeObject(summary);
                    string encriptedString = new Encryptor().Encrypt(jsonString);
                    Console.WriteLine("summary in JSON: " + jsonString);
                    Console.WriteLine("summary after encryption:" + encriptedString);
                    byte[] body = Encoding.Default.GetBytes(encriptedString);
                    channel.BasicPublish(exchange: "",
                                    routingKey: "summaries",
                                    basicProperties: null,
                                    body: body);
                    listCount--;
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }

    }
}

