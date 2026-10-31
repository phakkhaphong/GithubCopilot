using Microsoft.AspNetCore.Mvc;
using WebApi.Models;
using WebApi.Services;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly IProductService _service;

        public ProductsController(IProductService service)
        {
            _service = service;
        }

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> GetAll()
        {
            var items = _service.GetAll();
            return Ok(items);
        }

        // GET: api/products/5
        [HttpGet("{id:int}")]
        public ActionResult<Product> GetById(int id)
        {
            var item = _service.GetById(id);
            if (item is null) return NotFound();
            return Ok(item);
        }

        // POST: api/products
        [HttpPost]
        public ActionResult<Product> Create(Product product)
        {
            var created = _service.Add(product);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/products/5
        [HttpPut("{id:int}")]
        public IActionResult Update(int id, Product product)
        {
            if (id != product.Id) return BadRequest("ID mismatch");
            var ok = _service.Update(product);
            if (!ok) return NotFound();
            return NoContent();
        }

        // DELETE: api/products/5
        [HttpDelete("{id:int}")]
        public IActionResult Delete(int id)
        {
            var ok = _service.Delete(id);
            if (!ok) return NotFound();
            return NoContent();
        }
    }
}
