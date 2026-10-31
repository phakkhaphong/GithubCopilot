var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// Register ProductService in DI
builder.Services.AddSingleton<WebApi.Services.IProductService, WebApi.Services.ProductService>();
var app = builder.Build();
app.MapControllers();
app.Run();
