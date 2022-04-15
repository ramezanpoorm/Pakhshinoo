using _0_Framework.InfraStructure;
using ShopManagement.Application.Contracts.Car;
using ShopManagement.Domain.CarAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.InfraStructure.EFCore.Repository
{
    public class CarRepository : RepositoryBase<long, Car>, ICarRepository
    {
        private readonly ShopContext _shopContext;
        public CarRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }
        public List<CarViewModel> GetCars()
        {
            return _shopContext.Cars.Select(x => new CarViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditCar GetDetails(long id)
        {
            return _shopContext.Cars.Select(x => new EditCar()
            {
                Id = x.Id,
                Description = x.Description,
                Name = x.Name,
            }).FirstOrDefault(x => x.Id == id);
        }

        public string GetNameById(long id)
        {
            return _shopContext.Cars.Select(x => new { x.Id, x.Name }).FirstOrDefault(x => x.Id == id).Name;
        }

        public List<CarViewModel> Search(CarSearchModel searchModel)
        {
            var query = _shopContext.Cars.Select(x => new CarViewModel
            {
                Id = x.Id,
                Name = x.Name
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
