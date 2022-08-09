
using _0_Framework.Application;
using ShopManagement.Application.Contracts.CarProduct;
using ShopManagement.Domain.CarProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class CarProductApplication : ICarProductApplication
    {
        private readonly ICarProductRepository _carProductRepository;

        public CarProductApplication(ICarProductRepository carProductRepository)
        {
            _carProductRepository = carProductRepository;
        }

        public OpretaionResult Create(CreateCarProduct command)
        {
            var operation = new OpretaionResult();
            if (_carProductRepository.Exists(x => x.ProductId == command.ProductId && x.CarId == command.CarId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var companyProduct = new CarProduct(command.ProductId, command.CarId);
            _carProductRepository.Create(companyProduct);
            _carProductRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditCarProduct command)
        {
            var operation = new OpretaionResult();
            var companyProduct = _carProductRepository.Get(command.id);

            if (companyProduct == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_carProductRepository.Exists(x => x.ProductId == command.ProductId && x.CarId == command.CarId))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            companyProduct.Edit(command.ProductId, command.CarId);
            _carProductRepository.SaveChanges();

            return operation.Successeded();
        }

        public EditCarProduct GetDetails(long id)
        {
            return _carProductRepository.GetDetails(id);
        }

        public List<CarProductViewModel> Search(CarProductSearchModel searchModel)
        {
            return _carProductRepository.Search(searchModel);
        }
    }
}
