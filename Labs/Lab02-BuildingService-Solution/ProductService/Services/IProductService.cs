using ProductService.Models;
namespace ProductService.Services
{
    public interface IProductService
    {
        IEnumerable<Product> GetAll();
        Product? GetById(int id);
        Product Add(Product p);
        bool Update(Product p);
        bool Delete(int id);
    }
}
