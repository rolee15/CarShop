using CarShop.Data;

namespace CarShop.Repositories.Interfaces;

public interface ICarRepository : IRepository<Car>
{
    bool InflateCar(int id, int priceDelta);
}
