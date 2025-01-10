using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;

namespace Core.BaseService.MQ
{
    public abstract class MQBaseConsumer<T>
    {
        private readonly string _queue;

        protected MQBaseConsumer(string queue)
        {
            _queue = queue;
            StartAsync();
        }

        private async Task StartAsync()
        {
            var factory = new ConnectionFactory() { HostName = "localhost" };
            using var connection = await factory.CreateConnectionAsync();
            using var channel = await connection.CreateChannelAsync();
            await channel.QueueDeclareAsync(queue: _queue,
                                    durable: false,
                                    exclusive: false,
                                    autoDelete: false,
                                    arguments: null);

            var consumer = new AsyncEventingBasicConsumer(channel);
            consumer.ReceivedAsync += async (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var messageBody = Encoding.UTF8.GetString(body);
                var message = JsonConvert.DeserializeObject<T>(messageBody);
                await HandleMessage(message);
                Console.WriteLine(" [x] Received {0}", messageBody);
            };
            await channel.BasicConsumeAsync(queue: _queue,
                                    autoAck: true,
                                    consumer: consumer);

            Console.WriteLine($"Pushed messsage {typeof(T).FullName}");
        }

        protected abstract Task HandleMessage(T message);
    }
}
