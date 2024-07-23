using CarShop.Data;

namespace CarShop.Logic;

public interface ILogic
{
    IList<Brand> GetAllBrands();
    IList<Car> GetAllCars();

    Car GetOneCar(int id);

    bool IncPrice(int id);

    IList<AveragesResult> GetBrandAverages();
}