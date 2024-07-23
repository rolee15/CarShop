using CarShop.Data;
using CarShop.Logic;
using CarShop.Repositories;
using CarShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var ctx = new CarsDbContext();
Console.WriteLine("Number of cars: " + ctx.Cars.Count());
Console.WriteLine("Number of brands: " + ctx.Brands.Count());

var builder = Host.CreateDefaultBuilder();
builder.ConfigureServices(services => {
    services.AddScoped<DbContext, CarsDbContext>();
    services.AddScoped<ICarRepository, CarEfRepository>();
    services.AddScoped<IBrandRepository, BrandEfRepository>();
    services.AddScoped<ILogic, CarShopLogic>();
});

var host = builder.Build();

var logic = host.Services.GetService<ILogic>()!;

foreach (var brand in logic.GetAllBrands())
{
    Console.WriteLine($"BRAND #{brand.Id}: {brand.Name}");
}
foreach (var car in logic.GetAllCars())
{
    Console.WriteLine($"CAR #{car.Id}: {car.Brand.Name} {car.Model} ${car.Price}");
}
foreach (var average in logic.GetBrandAverages())
{
    Console.WriteLine($"AVG {average.BrandName} = ${average.AveragePrice}");
}