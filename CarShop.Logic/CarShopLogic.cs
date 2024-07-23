using CarShop.Data;
using CarShop.Repositories.Interfaces;

namespace CarShop.Logic;

public class CarShopLogic : ILogic
{
    private readonly ICarRepository _carRepository;
    private readonly IBrandRepository _brandRepository;

    public CarShopLogic(ICarRepository carRepository, IBrandRepository brandRepository)
    {
        _carRepository = carRepository;
        _brandRepository = brandRepository;
    }

    public IList<Brand> GetAllBrands()
    {
        return _brandRepository.GetAll().ToList();
    }

    public IList<Car> GetAllCars()
    {
        return _carRepository.GetAll().ToList();
    }

    public Car GetOneCar(int id)
    {
        return _carRepository.GetById(id);
    }

    public bool IncPrice(int id)
    {
        return _carRepository.InflateCar(id, Random.Shared.Next(1000, 10000));
    }

    public IList<AveragesResult> GetBrandAverages()
    {
        return _carRepository
            .GetAll()
            .GroupBy(c => c.Brand.Name)
            .Select(g => new AveragesResult(g.Key, g.Average(c => c.Price ?? 0)))
            .ToList();
    }
}
