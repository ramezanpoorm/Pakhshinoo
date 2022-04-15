
using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Car
{
    public interface ICarApplication
    {
        OpretaionResult Create(CreateCar command);
        OpretaionResult Edit(EditCar command);
        EditCar GetDetails(long id);
        List<CarViewModel> GetCar();
        List<CarViewModel> Search(CarSearchModel searchModel);
    }
}
