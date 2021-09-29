using System;
using RabbitMQ.Client;
using System.Text;
using Newtonsoft.Json;
using common;

namespace Send
{
    class Send
    {
        private const string HOST = "localhost";
        private const string QUEUE = "summaries";
        private const int MIN_LIST_VALUE = 2;
        private const int MAX_LIST_VALUE = 10;
        private const string ROUTING_KEY = "summaries";

        static void Main(string[] args)
        {
            var factory = new ConnectionFactory() { HostName = HOST };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: QUEUE,
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);



                int listCount = new Random().Next(MIN_LIST_VALUE, MAX_LIST_VALUE);

                while (listCount > 0)
                {
                    Summary summary = SummaryFactory.CreateRandomSummary();
                    Console.WriteLine("summary before entering the queue: " + summary);
                    string jsonString = JsonConvert.SerializeObject(summary);
                    string encriptedString = new Encryptor().Encrypt(jsonString);
                    Console.WriteLine("summary in JSON: " + jsonString);
                    Console.WriteLine("summary after encryption:" + encriptedString);
                    Console.WriteLine();
                    byte[] body = Encoding.Default.GetBytes(encriptedString);
                    channel.BasicPublish(exchange: "",
                                    routingKey: ROUTING_KEY,
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

