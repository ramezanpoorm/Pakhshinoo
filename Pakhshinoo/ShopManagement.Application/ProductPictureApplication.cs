
using _0_Framework.Application;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductPictureAgg;
using System.Collections.Generic;

namespace ShopManagement.Application
{
    public class ProductPictureApplication : IProductPictureApplication
    {
        private readonly IProductPictureRepository _productPictureRepository;
        private readonly IProductRepository _productRepository;
        private readonly IFileUploader _fileUploader;
        public ProductPictureApplication(IProductPictureRepository productPictureRepository, IProductRepository productRepository, IFileUploader fileUploader)
        {
            _productPictureRepository = productPictureRepository;
            _productRepository = productRepository;
            _fileUploader = fileUploader;
        }

        public OpretaionResult Create(CreateProductPicture command)
        {
            var operation = new OpretaionResult();
            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var product = _productRepository.GetProductWithCategory(command.ProductId);
            //var path = $"{product.Category.Name}//{product.Name}";
            var path = $"ProductPictures";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            var productPicture = new ProductPicture(command.ProductId, picturePath, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.Create(productPicture);
            _productPictureRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditProductPicture command)
        {
            var operation = new OpretaionResult();
            var productPicture = _productPictureRepository.GetWithProductAndCategoryById(command.Id);
            
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            //if (_productPictureRepository.Exists(x => x.Picture == command.Picture && x.ProductId == command.ProductId && x.Id != command.Id))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);

            //var path = $"{productPicture.Product.Category.Name}//{productPicture.Product.Name}";
            var path = $"ProductPictures";
            var picturePath = _fileUploader.Upload(command.Picture, path);

            productPicture.Edit(command.ProductId, picturePath, command.PictureAlt, command.PictureTitle);
            _productPictureRepository.SaveChanges();
            return operation.Successeded();
        }

        public EditProductPicture GetDetails(long id)
        {
            return _productPictureRepository.GetDetails(id);
        }

        public OpretaionResult Remove(long id)
        {
            var operation = new OpretaionResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Remove();
            _productPictureRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Restore(long id)
        {
            var operation = new OpretaionResult();
            var productPicture = _productPictureRepository.Get(id);
            if (productPicture == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            productPicture.Restore();
            _productPictureRepository.SaveChanges();
            return operation.Successeded();
        }

        public List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel)
        {
            return _productPictureRepository.Search(searchModel);
        }
    }
}
