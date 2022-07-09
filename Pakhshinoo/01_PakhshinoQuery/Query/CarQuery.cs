
using _01_PakhshinoQuery.Contract.Car;
using ShopManagement.InfraStructure.EFCore;
using System.Collections.Generic;
using System.Linq;

namespace _01_PakhshinoQuery.Query
{
    public class CarQuery : ICarQuery
    {
        private readonly ShopContext _shopContext;
        public CarQuery(ShopContext shopContext)
        {
            _shopContext = shopContext;
        }
        public List<CarQueryModel> GetCar()
        {
            return _shopContext.Cars.Select(x => new CarQueryModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }
    }
}
