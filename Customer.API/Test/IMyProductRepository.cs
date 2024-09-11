namespace Customer.API.Test
{
    public interface IMyProductRepository
    {
        Task<MyProduct?> GetAsync(int id);
        Task<List<MyProduct>> GetAllAsync();
    }
}
