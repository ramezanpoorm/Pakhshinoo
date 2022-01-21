using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IProductRepository _productRepository;
        public ProductApplication(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public OpretaionResult Create(CreateProduct command)
        {
            var operation = new OpretaionResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            var product = new Product(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.CategoryId, slug, command.Keywords, command.MetaDescription);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditProduct command)
        {
            var operation = new OpretaionResult();
            var product = _productRepository.Get(command.Id);

            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();
            product.Edit(command.Name, command.Code, command.UnitPrice, command.ShortDescription, command.Description, command.Picture, command.PictureAlt, command.PictureTitle, command.CategoryId, slug, command.Keywords, command.MetaDescription);

            _productRepository.SaveChanges();
            return operation.Successeded();
        }

        public EditProduct GetDetails(long Id)
        {
            return _productRepository.GetDetails(Id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts();
        }

        public OpretaionResult IsStock(long id)
        {
            var operation = new OpretaionResult();
            var product = _productRepository.Get(id);

            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            product.InStock();

            _productRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult NotInStock(long id)
        {
            var operation = new OpretaionResult();
            var product = _productRepository.Get(id);

            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            product.NotInStock();

            _productRepository.SaveChanges();
            return operation.Successeded();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }
    }
}
