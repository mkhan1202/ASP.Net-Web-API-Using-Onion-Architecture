using Application_Layer.IService;
using Application_Layer.Service;
using Domain_Layer.IRepository;
using Infrastructure_Layer.Persistance.Context;
using Infrastructure_Layer.Persistance.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Dependency Register
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IProductService, ProductService>();

//DBContext Register
builder.Services.AddDbContext<AppDBContext>(options => 
        options.UseSqlServer(builder.Configuration.GetConnectionString("appCon")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
