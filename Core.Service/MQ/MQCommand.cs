using Core.Domain.Interface.MQ;
using Newtonsoft.Json;
using RabbitMQ.Client;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            channel.BasicPublishAsync(exchange: "",
                                    routingKey: _queue,
                                    basicProperties: null,
                                    body: body);
            Console.WriteLine(" [x] Sent {0}", messageBody);
    }
    }
}
