using WebApi.Models;
using WebApi.Services;
using Xunit;

public class ProductServiceTests
{
    [Fact]
    public void Add_ShouldAssignId_AndReturnCreated()
    {
        var svc = new ProductService();
        var created = svc.Add(new Product { Name = "USB-C Cable", Price = 190m, Stock = 50 });
        Assert.True(created.Id > 0);
        Assert.Equal("USB-C Cable", created.Name);
    }

    [Fact]
    public void GetById_ShouldReturnNull_WhenNotFound()
    {
        var svc = new ProductService();
        var result = svc.GetById(999);
        Assert.Null(result);
    }
}
