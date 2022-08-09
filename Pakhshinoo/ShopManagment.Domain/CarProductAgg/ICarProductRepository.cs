
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Car;
using ShopManagement.Application.Contracts.CarProduct;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ShopManagement.Domain.CarProductAgg
{
    public interface ICarProductRepository : IRepository<long, CarProduct>
    {
        EditCarProduct GetDetails(long Id);
        List<CarViewModel> GetCar();
        List<ProductViewModel> GetProducts();
        List<CarProductViewModel> Search(CarProductSearchModel searchModel);
    }
}
