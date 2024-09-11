
namespace Customer.API.Test
{
    public class MyProductRepository : IMyProductRepository
    {
        private static List<MyProduct> products = new List<MyProduct>()
        {
            new MyProduct { Id = 1, ProductId = 1, Quantity = 2 },
            new MyProduct { Id = 2, ProductId = 2, Quantity = 3 },
            new MyProduct { Id = 3, ProductId = 3, Quantity = 4 },
            new MyProduct { Id = 4, ProductId = 4, Quantity = 5 }
        };
        public Task<List<MyProduct>> GetAllAsync()
        {
            return Task.FromResult(products);
        }

        public Task<MyProduct?> GetAsync(int id)
        {
            var res = products.FirstOrDefault(x => x.Id == id);
            return Task.FromResult(res);
        }
    }
}
