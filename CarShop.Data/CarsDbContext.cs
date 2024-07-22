using Microsoft.EntityFrameworkCore;

namespace CarShop.Data;

public class CarsDbContext : DbContext
{
    // can be set as virtual to override in proxies or test classes
    public DbSet<Brand> Brands { get; set; }
    public DbSet<Car> Cars { get; set; }

    public CarsDbContext()
    {
        Database.EnsureCreated();
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder
                .LogTo(Console.WriteLine)
                .UseLazyLoadingProxies()
                .UseSqlite("Data Source=cars.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Car>(car => {
            car.HasKey(c => c.Id);

            car
                .HasOne<Brand>(c => c.Brand)
                .WithMany(brand => brand.Cars)
                .HasForeignKey(c => c.BrandId);
        });

        // Data seeding
        // !NOT! this.Brands.Add(new Brand() { yyy })
        // !NOT! this.Cars.Add(new Car() { xxx })

        var bmw = new Brand { Id = 1, Name = "BMW" };
        var citroen = new Brand { Id = 2, Name = "Citroen" };
        var audi = new Brand { Id = 3, Name = "Audi" };

        var bmw1 = new Car { Id = 1, BrandId = bmw.Id, Price = 20000, Model = "BMW 116d" };
        var bmw2 = new Car { Id = 2, BrandId = bmw.Id, Price = 30000, Model = "BMW 510" };
        var citroen1 = new Car { Id = 3, BrandId = citroen.Id, Price = 10000, Model = "Citroen C1" };
        var citroen2 = new Car { Id = 4, BrandId = citroen.Id, Price = 15000, Model = "Citroen C3" };
        var audi1 = new Car { Id = 5, BrandId = audi.Id, Price = 20000, Model = "Audi A3" };
        var audi2 = new Car { Id = 6, BrandId = audi.Id, Price = 25000, Model = "Audi A4" };

        modelBuilder.Entity<Brand>().HasData(bmw, citroen, audi);
        modelBuilder.Entity<Car>().HasData(bmw1, bmw2, audi1, audi2, citroen1, citroen2);
    }
}
