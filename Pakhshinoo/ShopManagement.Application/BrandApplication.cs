
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Brand;
using ShopManagement.Domain.BrandAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class BrandApplication : IBrandApplication
    {
        private readonly IBrandRepository _brandRepository;

        public BrandApplication(IBrandRepository brandRepository)
        {
            _brandRepository = brandRepository;
        }
        public OpretaionResult Create(CreateBrand command)
        {
            var operation = new OpretaionResult();
            if (_brandRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var brand = new Brand(command.Name, command.Description);
            _brandRepository.Create(brand);
            _brandRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditBrand command)
        {
            var operation = new OpretaionResult();
            var car = _brandRepository.Get(command.Id);

            if (car == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_brandRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            car.Edit(command.Name, command.Description);

            _brandRepository.SaveChanges();
            return operation.Successeded();
        }

        public List<BrandViewModel> GetBrand()
        {
            return _brandRepository.GetBrands();
        }

        public EditBrand GetDetails(long id)
        {
            return _brandRepository.GetDetails(id);
        }

        public List<BrandViewModel> Search(BrandSearchModel searchModel)
        {
            return _brandRepository.Search(searchModel);
        }
    }
}
