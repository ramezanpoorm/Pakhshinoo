
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Car;
using ShopManagement.Application.Contracts.CarProduct;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.CarProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.InfraStructure.EFCore.Repository
{
    public class CarProductRepository : RepositoryBase<long, CarProduct>, ICarProductRepository
    {
        private readonly ShopContext _shopContext;
        public CarProductRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public List<CarViewModel> GetCar()
        {
            return _shopContext.Cars.Select(x => new CarViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditCarProduct GetDetails(long Id)
        {
            return _shopContext.CarProducts.Select(x => new EditCarProduct()
            {
                id = x.Id,
                CarId = x.CarId,
                ProductId = x.ProductId
            }).FirstOrDefault(x => x.id == Id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _shopContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<CarProductViewModel> Search(CarProductSearchModel searchModel)
        {
            var query = _shopContext.CarProducts.Include(x => x.Product).Include(s => s.Car).Select(x => new CarProductViewModel
            {
                Id = x.Id,
                Product = x.Product.Name,
                CreationDate = x.CreateDate.ToFarsi(),
                Car = x.Car.Name
            });

            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
