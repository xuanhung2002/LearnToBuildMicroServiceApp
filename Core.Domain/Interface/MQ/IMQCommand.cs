namespace Core.Domain
{
    public interface IMQCommand
    {
        Task SendAsync<T>(T message) where T : class;
    }
}
