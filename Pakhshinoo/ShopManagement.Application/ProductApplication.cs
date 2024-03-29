﻿using _0_Framework.Application;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.Domain.ProductCategoryAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application
{
    public class ProductApplication : IProductApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProductRepository _productRepository;
        private readonly IProductCategoryRepository _productCategoryRepository;
        public ProductApplication(IProductRepository productRepository, IFileUploader fileUploader, IProductCategoryRepository productCategoryRepository)
        {
            _productRepository = productRepository;
            _fileUploader = fileUploader;
            _productCategoryRepository = productCategoryRepository;
        }
        public OpretaionResult Create(CreateProduct command)
        {
            var operation = new OpretaionResult();
            if (_productRepository.Exists(x => x.Name == command.Name))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            var categoryName = _productCategoryRepository.GetNameById(command.CategoryId);
            //var path = $"{categoryName}//{command.Name}";
            var path = $"ProductPictures";
            var picturePath = _fileUploader.Upload(command.Picture, path);
            var product = new Product(command.Name, command.Code, command.ShortDescription, command.Description, picturePath, command.PictureAlt, command.PictureTitle, command.CategoryId, slug, command.Keywords, command.MetaDescription, command.BrandId);
            _productRepository.Create(product);
            _productRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditProduct command)
        {
            var operation = new OpretaionResult();
            string picturePath = "";
            var product = _productRepository.GetProductWithCategory(command.Id);

            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_productRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
                operation.Failed(ApplicationMessages.DuplicatedRecord);

            var slug = command.Slug.Slugify();

            //var path = $"{product.Category.Name}/{command.Name}";
            var path = $"ProductPictures";

            if (command.Picture == null)
                picturePath = product.Picture;
            else
                picturePath = _fileUploader.Upload(command.Picture, path);

            //var picturePath = _fileUploader.Upload(command.Picture, path);
            product.Edit(command.Name, command.Code, command.ShortDescription, command.Description, picturePath, command.PictureAlt, command.PictureTitle, command.CategoryId, slug, command.Keywords, command.MetaDescription, command.BrandId);

            _productRepository.SaveChanges();
            return operation.Successeded();
        }

        public EditProduct GetDetails(long Id)
        {
            return _productRepository.GetDetails(Id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _productRepository.GetProducts().Where(x => x.IsRemoved == false).OrderByDescending(x=>x.Id).ToList();
        }

        public void IncVisit(long id)
        {
            var operation = new OpretaionResult();
            var product = _productRepository.Get(id);
            //if (product == null)
            //    return operation.Failed(ApplicationMessages.RecordNotFound);
            
            product.VisitIncrease();
            _productRepository.SaveChanges();
            //return operation.Successeded();
        }

        public OpretaionResult NotSpecial(long id)
        {
            var operation = new OpretaionResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            product.NotSpecial();
            _productRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult NotSpecialAll()
        {
            var operation = new OpretaionResult();
            var product = _productRepository.GetProducts();
            foreach (var item in product)
            {
                item.IsSpecial = false;
            }
            
            _productRepository.SaveChanges();
            return operation.Successeded();
        }

        public void Removed(long id)
        {
            var product = _productRepository.Get(id);
            product.Removed();
            _productRepository.SaveChanges();
        }

        public void Restore(long id)
        {
            var product = _productRepository.Get(id);
            product.NotRemoved();
            _productRepository.SaveChanges();
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            return _productRepository.Search(searchModel);
        }

        public OpretaionResult Special(long id)
        {
            var operation = new OpretaionResult();
            var product = _productRepository.Get(id);
            if (product == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            product.Special();
            _productRepository.SaveChanges();
            return operation.Successeded();
        }
    }
}
