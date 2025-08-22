using WebApi.Models;

namespace WebApi.Services
{
    public class ProductService
    {
        private readonly List<Product> _products = new()
        {
            new Product { Id = 1, Name = "Keyboard", Price = 1290m, Stock = 10 },
            new Product { Id = 2, Name = "Mouse", Price = 590m, Stock = 25 },
        };

        public IEnumerable<Product> GetAll() => _products;
        public Product? GetById(int id) => _products.FirstOrDefault(p => p.Id == id);
        public Product Add(Product p)
        {
            var nextId = _products.Count == 0 ? 1 : _products.Max(x => x.Id) + 1;
            var toAdd = p with { Id = nextId };
            _products.Add(toAdd);
            return toAdd;
        }
        public bool Update(Product p)
        {
            var idx = _products.FindIndex(x => x.Id == p.Id);
            if (idx < 0) return false;
            _products[idx] = p;
            return true;
        }
        public bool Delete(int id)
        {
            var idx = _products.FindIndex(x => x.Id == id);
            if (idx < 0) return false;
            _products.RemoveAt(idx);
            return true;
        }
    }
}
