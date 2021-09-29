using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using Newtonsoft.Json;
using common;

namespace Receive
{
    class Receive
    {
        private const string HOST = "localhost";
        private const string QUEUE = "summaries";

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

                var consumer = new EventingBasicConsumer(channel);
                consumer.Received += (model, ea) =>
                {
                    var body = ea.Body.ToArray();
                    string encryptedMessage = Encoding.UTF8.GetString(body);
                    Console.WriteLine("Received encrypted message: {0}", encryptedMessage);
                    string decryptedMessage = new Decryptor().Decrypt(encryptedMessage);
                    Console.WriteLine("after decryption: {0}", decryptedMessage);
                    Summary summary = JsonConvert.DeserializeObject<Summary>(decryptedMessage);
    
                    Console.WriteLine("Received after deserialization: {0}", summary);
                    Console.WriteLine();
                };
                channel.BasicConsume(queue: QUEUE,
                                     autoAck: true,
                                     consumer: consumer);

                Console.WriteLine(" Press [enter] to exit.");
                Console.ReadLine();
            }
        }
    }
}
