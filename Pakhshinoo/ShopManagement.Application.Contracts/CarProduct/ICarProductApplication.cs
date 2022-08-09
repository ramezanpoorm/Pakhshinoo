using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.CarProduct
{
    public interface ICarProductApplication
    {
        OpretaionResult Create(CreateCarProduct command);
        OpretaionResult Edit(EditCarProduct command);
        EditCarProduct GetDetails(long id);
        List<CarProductViewModel> Search(CarProductSearchModel searchModel);
    }
}
