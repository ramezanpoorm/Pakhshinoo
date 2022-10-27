using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Domain.ProductCategoryAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductCategoryApplication : IProductCategoryApplication
    {
        private readonly IFileUploader _fileUploader;

        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductCategoryApplication(IProductCategoryRepository productCategoryRepository, IFileUploader fileUploader)
        {
            _productCategoryRepository = productCategoryRepository;
            _fileUploader = fileUploader;
        }

        public OpretaionResult Create(CreateProductCategory command)
        {
            var operation = new OpretaionResult();
            if (_productCategoryRepository.Exists(x => x.Name == command.Name))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var picturePath = $"ProductPictures";
            //var picturePath = $"{command.Name}";
            var pictureName = _fileUploader.Upload(command.Picture, picturePath);

            var productCategory = new ProductCategory(command.Name, command.Description, command.Picture.FileName, command.PictureAlt,command.PictureTitle, command.Keywords, command.MetaDescription, command.Slug);

            _productCategoryRepository.Create(productCategory);
            _productCategoryRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditProductCategory command)
        {
            var operation = new OpretaionResult();
            var productCategory = _productCategoryRepository.Get(command.Id);
            
            if (productCategory == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);
            
            if (_productCategoryRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            //var picturePath = $"{command.Name}";
            var picturePath = $"ProductPictures";
            var fileName = _fileUploader.Upload(command.Picture, picturePath);

            productCategory.Edit(command.Name, command.Description, command.Picture.FileName, command.PictureAlt, command.PictureTitle, command.Keywords, command.MetaDescription, slug);
            _productCategoryRepository.SaveChanges();
            return operation.Successeded();
        }

        public EditProductCategory GetDetails(long id)
        {
            return _productCategoryRepository.GetDetails(id);
        }

        public List<ProductCategoryViewModel> GetProductCategories()
        {
            return _productCategoryRepository.GetProductCategories();
        }

        public List<ProductCategoryViewModel> Search(ProductCategorySearchModel searchModel)
        {
            return _productCategoryRepository.Search(searchModel);
        }
    }
}
