using CarShop.Data;

var ctx = new CarsDbContext();
Console.WriteLine("Number of cars: " + ctx.Cars.Count());
Console.WriteLine("Number of brands: " + ctx.Brands.Count());