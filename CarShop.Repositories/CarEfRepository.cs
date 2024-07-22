using CarShop.Data;
using CarShop.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CarShop.Repositories;

public class CarEfRepository : EfRepository<Car>, ICarRepository
{
    public CarEfRepository(DbContext ctx) : base(ctx) { }

    public bool InflateCar(int id, int priceDelta)
    {
        Car car = GetById(id);
        car.Price += priceDelta;
        return Update(car);
    }
}
