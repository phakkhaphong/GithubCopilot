using WebApi.Models;
using WebApi.Services;

namespace WebApi.Tests;

public class ProductServiceTests
{
    [Fact]
    public void GetAll_ReturnsSeededItems()
    {
        var svc = new ProductService();

        var items = svc.GetAll().ToList();

        Assert.NotEmpty(items);
        Assert.All(items, p => Assert.True(p.Id > 0));
    }

    [Fact]
    public void GetById_WhenNotFound_ReturnsNull()
    {
        var svc = new ProductService();

        var item = svc.GetById(-123);

        Assert.Null(item);
    }

    [Fact]
    public void Add_AssignsIncrementalId_AndPersists()
    {
        var svc = new ProductService();
        var before = svc.GetAll().Count();

        var created = svc.Add(new Product { Id = 0, Name = "Monitor", Price = 4590m, Stock = 5 });

        Assert.True(created.Id > 0);
        Assert.Equal(before + 1, svc.GetAll().Count());
        Assert.Equal("Monitor", created.Name);
    }

    [Fact]
    public void Update_WhenIdExists_ReplacesItem_ReturnsTrue()
    {
        var svc = new ProductService();
        var existing = svc.GetAll().First();
        var updated = existing with { Name = existing.Name + " Pro", Stock = existing.Stock + 1 };

        var ok = svc.Update(updated);

        Assert.True(ok);
        var fetched = svc.GetById(updated.Id);
        Assert.NotNull(fetched);
        Assert.Equal(updated.Name, fetched!.Name);
        Assert.Equal(updated.Stock, fetched!.Stock);
    }

    [Fact]
    public void Update_WhenIdMissing_ReturnsFalse()
    {
        var svc = new ProductService();
        var notExists = new Product { Id = 9999, Name = "Ghost", Price = 1m, Stock = 0 };

        var ok = svc.Update(notExists);

        Assert.False(ok);
    }

    [Fact]
    public void Delete_WhenExists_RemovesAndReturnsTrue()
    {
        var svc = new ProductService();
        var created = svc.Add(new Product { Id = 0, Name = "Temp", Price = 1m, Stock = 1 });

        var ok = svc.Delete(created.Id);

        Assert.True(ok);
        Assert.Null(svc.GetById(created.Id));
    }

    [Fact]
    public void Delete_WhenMissing_ReturnsFalse()
    {
        var svc = new ProductService();

        var ok = svc.Delete(-42);

        Assert.False(ok);
    }
}
