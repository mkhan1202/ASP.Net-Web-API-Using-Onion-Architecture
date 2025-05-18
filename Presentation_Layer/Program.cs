using Application_Layer.IService;
using Application_Layer.Service;
using Domain_Layer.IRepository;
using Infrastructure_Layer.Persistance.Context;
using Infrastructure_Layer.Persistance.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presentation_Layer.Controllers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        //var errors = context.ModelState.Where(e => e.Value != null && e.Value.Errors.Count > 0).Select(e => new
        //{
        //    Field = e.Key,
        //    Errors = e.Value!.Errors.Select(x => x.ErrorMessage).ToArray()
        //}).ToList();
        //var errorString = string.Join("; ", errors.Select(e => $"{e.Field}: {string.Join(", ", e.Errors)}"));
        //return new BadRequestObjectResult(new
        //{
        //    Message = "Validation failed",
        //    Errors = errorString
        //});
        {
            var errors = context.ModelState
                .Where(e => e.Value != null && e.Value.Errors.Count > 0)
                .SelectMany(e => e.Value?.Errors != null ? e.Value.Errors.Select(x => x.ErrorMessage): new List<string>()).ToList();

            return new BadRequestObjectResult(ApiResponse<object>.ErrorResponse(errors, 400, "Validation failed"));
        };
    };
});

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
