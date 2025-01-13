using Core.Domain;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System.Text;

namespace Core.Service.MQ
{
    public class MQCommand : IMQCommand
    {
        private readonly string _queue;
        public MQCommand(string queue)
        {

            _queue = queue;

        }
        public async Task SendAsync<T>(T message) where T : class
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: _queue,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var messageBody = JsonConvert.SerializeObject(message);
            var body = Encoding.UTF8.GetBytes(messageBody);

            await channel.BasicPublishAsync(exchange: String.Empty,
                                    routingKey: _queue,
                                    body: body); 
            Console.WriteLine(" [x] Sent {0}", messageBody);
        }
    }
}
