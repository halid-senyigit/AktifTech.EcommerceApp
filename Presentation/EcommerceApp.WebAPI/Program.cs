using EcommerceApp.Persistence.DatabaseContext;
using EcommerceApp.Persistence.Repositories.Common;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddPersistence(builder.Configuration["ConnectionStrings:DefaultConnection"]);
builder.Services.AddRepositories();

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();


app.UseSwagger();
app.UseSwaggerUI();

app.MapControllers();

app.Run();
