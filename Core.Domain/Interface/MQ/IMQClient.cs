namespace Core.Domain
{
    public interface IMQClient 
    {
        Task PublishAsync<T>(T message) where T : class;
        IMQCommand Admin {  get; }
        IMQCommand Customer { get; }
        IMQCommand CreateMQCommand(string queue);
    }
}
