using Microsoft.AspNetCore.Mvc;
using WebApi.Controllers;
using WebApi.Models;
using WebApi.Services;
using Xunit;

public class ProductsControllerTests
{
    [Fact]
    public void GetAll_ReturnsOk_WithProducts()
    {
        var controller = new ProductsController(new ProductService());
        var result = controller.GetAll().Result as OkObjectResult;
        Assert.NotNull(result);
        var list = Assert.IsAssignableFrom<IEnumerable<Product>>(result.Value);
        Assert.NotEmpty(list);
    }

    [Fact]
    public void Create_ReturnsBadRequest_WhenInvalid()
    {
        var controller = new ProductsController(new ProductService());
        var result = controller.Create(new Product { Name = "", Price = -1, Stock = 0 });
        Assert.IsType<BadRequestResult>(result.Result);
    }
}
