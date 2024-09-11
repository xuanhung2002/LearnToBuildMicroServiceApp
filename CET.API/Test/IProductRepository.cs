namespace CET.API.Test
{
    public interface IProductRepository
    {
       Task<List<Product>> GetAll();
        Task<Product?> Get(int id);
    }
}
