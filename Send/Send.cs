using System;
using System.Text;
using RabbitMQ.Client;
namespace Send
{
    class Program
    {
        static void Main(string[] args)
        {
            var factoty = new ConnectionFactory() { HostName = "localhost" };
            using (var connection=factoty.CreateConnection())
            {
                using (var channel=connection.CreateModel())
                {
                    channel.QueueDeclare(queue: "hello",
                                          durable: true,
                                          exclusive: false,
                                          autoDelete: false,
                                          arguments: null);
                    var msg = "Hello World!";
                    var body = Encoding.UTF8.GetBytes(msg);
                    channel.BasicPublish(exchange: "",
                         routingKey: "hello",
                         basicProperties: null,
                         body: body);
                    Console.WriteLine($"[X] send a msg {msg}");

                }
                Console.WriteLine(" Press [enter] to exit.");
              
            }
            Console.Read();
        }
    }
}
