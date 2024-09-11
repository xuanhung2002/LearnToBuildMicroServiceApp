
namespace CET.API.Test
{
    public class ProductRepository : IProductRepository
    {
        private static List<Product> products = new List<Product>()
        {
            new Product { Id = 1, Name = "Product 1"},
            new Product { Id = 2, Name = "Product 2"},
            new Product { Id = 3, Name = "Product 3"},
            new Product { Id = 4, Name = "Product 4"},
        };
        public Task<Product?> Get(int id)
        {
            var result = products.FirstOrDefault(s => s.Id == id);
            return Task.FromResult(result);
        }

        public Task<List<Product>> GetAll()
        {
            return Task.FromResult(products);
        }
    }
}
