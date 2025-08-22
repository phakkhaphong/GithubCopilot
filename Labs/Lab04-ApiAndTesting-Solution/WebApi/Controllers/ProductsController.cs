using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ProductService _service;
        public ProductsController(ProductService service) => _service = service;

        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll() => Ok(_service.GetAll());

        [HttpGet("{id:int}")]
        public ActionResult<Product> GetById(int id)
        {
            var p = _service.GetById(id);
            return p is null ? NotFound() : Ok(p);
        }

        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            if (string.IsNullOrWhiteSpace(product.Name) || product.Price < 0) return BadRequest();
            var created = _service.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest();
            return _service.Update(product) ? NoContent() : NotFound();
        }

        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id) => _service.Delete(id) ? NoContent() : NotFound();
    }
}
