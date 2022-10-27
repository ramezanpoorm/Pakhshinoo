
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Brand;
using ShopManagement.Domain.BrandAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class BrandApplication : IBrandApplication
    {
        private readonly IBrandRepository _brandRepository;
        private readonly IFileUploader _fileUploader;

        public BrandApplication(IBrandRepository brandRepository, IFileUploader fileUploader)
        {
            _brandRepository = brandRepository;
            _fileUploader = fileUploader;
        }
        public OpretaionResult Create(CreateBrand command)
        {
            var operation = new OpretaionResult();
            if (_brandRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"ProductPictures";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            var brand = new Brand(command.Name, command.Description, picturePath, command.Url);
            _brandRepository.Create(brand);
            _brandRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditBrand command)
        {
            var operation = new OpretaionResult();
            var brand = _brandRepository.Get(command.Id);
            string picturePath = "";
            if (brand == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_brandRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"ProductPictures";
            if (command.Picture == null)
                picturePath = brand.Picture;
            else
                picturePath = _fileUploader.Upload(command.Picture, path);

            brand.Edit(command.Name, command.Description, picturePath, command.Url);

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

        public void Removed(long id)
        {
            var brand = _brandRepository.Get(id);
            brand.Removed();
            _brandRepository.SaveChanges();
        }

        public void Restore(long id)
        {
            var brand = _brandRepository.Get(id);
            brand.NotRemoved();
            _brandRepository.SaveChanges();
        }

        public List<BrandViewModel> Search(BrandSearchModel searchModel)
        {
            return _brandRepository.Search(searchModel);
        }
    }
}
