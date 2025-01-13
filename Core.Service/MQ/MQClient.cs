using Core.Domain;

namespace Core.Service.MQ
{
    public class MQClient : IMQClient
    {
        public IMQCommand Admin => new MQCommand("Admin");

        public IMQCommand Customer => new MQCommand("Customer");

        public IMQCommand CreateMQCommand(string queue)
        {
            return new MQCommand(queue);
        }
    }
}
