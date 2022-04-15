using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Car;

using System.Collections.Generic;


namespace ShopManagement.Domain.CarAgg
{
    public interface ICarRepository: IRepository<long, Car>
    {
        List<CarViewModel> GetCars();
        EditCar GetDetails(long id);
        string GetNameById(long id);
        List<CarViewModel> Search(CarSearchModel searchModel);
    }
}
