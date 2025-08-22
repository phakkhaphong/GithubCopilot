var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
// TODO: Register ProductService and IProductService after completing Lab02.
var app = builder.Build();
app.MapControllers();
app.Run();
