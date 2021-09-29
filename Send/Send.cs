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
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using (var connection = factory.CreateConnection())
            using (var channel = connection.CreateModel())
            {
                channel.QueueDeclare(queue: "summaries",
                                     durable: false,
                                     exclusive: false,
                                     autoDelete: false,
                                     arguments: null);

                List<Summary> summaryList = generateRandomSummaryList();

                foreach(var summary in summaryList)
                {
                    Console.WriteLine("summary before entering the queue" + summary);
                    byte[] body = Encoding.Default.GetBytes(JsonConvert.SerializeObject(summary));
                    channel.BasicPublish(exchange: "",
                                    routingKey: "summaries",
                                    basicProperties: null,
                                    body: body);
                }
            }

            Console.WriteLine(" Press [enter] to exit.");
            Console.ReadLine();
        }
        private static List<Summary> generateRandomSummaryList()
        {
            List<Summary> summaryList = new List<Summary>();
            int listCount = new Random().Next(2, 10);

            while (listCount > 0)
            {
                summaryList.Add(SummaryFactory.CreateRandomSummary());
                listCount--;
            }

            return summaryList;
        }
    }
}

