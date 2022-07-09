
using _0_Framework.Application;
using _01_PakhshinoQuery.Contract.Paging;
using _01_PakhshinoQuery.Contract.Product;
using _01_PakhshinoQuery.Contract.ProductCategory;
using DiscountManagement.Infrastructure.EFCore;
using InventoryMangement.InfraStructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductAgg;
using ShopManagement.InfraStructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_PakhshinoQuery.Query
{
    public class ProductCategoryQuery : IProductCategoryQuery
    {
        private readonly ShopContext _shopContext;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;

        public ProductCategoryQuery(ShopContext shopContext, InventoryContext inventory, DiscountContext discountContext)
        {
            _shopContext = shopContext;
            _inventoryContext = inventory;
            _discountContext = discountContext;
        }

        public List<ProductCategoryQueryModel> GetProductCategories()
        {
            return _shopContext.ProductCategories.Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                Slug = x.Slug
            }).ToList();
        }

        public List<ProductCategoryQueryModel> GetProductCategoriesWithProduct(int pageid)
        {
            int skip = (pageid - 1) * 20;
            return _shopContext.ProductCategories.Include(x => x.Products).ThenInclude(x => x.Category).Select(x => new ProductCategoryQueryModel
            {
                Id = x.Id,
                Name = x.Name,
                //Products = MapProducts(x.Products, skip)
            }).ToList();
        }
        
        public ProductCategoryQueryModel GetProductCategoryWithProductsBy(long id, int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId)
        {
            int skip = (pageid - 1) * 40;
            var inventory = _inventoryContext.Inventory.Select(x =>
                new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).ToList();
            
            var category = _shopContext.ProductCategories
                    .Include(a => a.Products)
                    .ThenInclude(x => x.Category)
                    .Select(x => new ProductCategoryQueryModel
                    {
                        Id = x.Id,
                        Name = x.Name,
                        Description = x.Description,
                        MetaDescription = x.MetaDescription,
                        Keywords = x.Keywords,
                        Slug = x.Slug,
                        Products = MapProducts(x.Products.Where(s => s.UnitPrice >= startPrice && s.UnitPrice <= endPrice && (brandId == 0 || s.BrandId == brandId) && (carId == 0 || s.CarProducts.Where(p => p.ProductId == s.Id && p.CarId == carId).Any()) && (companyId == 0 || s.CompanyProducts.Where(p => p.ProductId == s.Id && p.CompanyId == companyId).Any())).ToList(), skip),
                        PageCount = x.Products.Where(s => s.UnitPrice >= startPrice && s.UnitPrice <= endPrice && (brandId == 0 || s.BrandId == brandId) && (carId == 0 || s.CarProducts.Where(p => p.ProductId == s.Id && p.CarId == carId).Any()) && (companyId == 0 || s.CompanyProducts.Where(p => p.ProductId == s.Id && p.CompanyId == companyId).Any())).ToList().Count,
                        ActivePage = pageid,
                        StartPrice = startPrice,
                        EndPrice = endPrice,
                        CarId = carId,
                        CompanyId = companyId,
                        BrandId = brandId
                    }).FirstOrDefault(x => x.Id == id);

            
            foreach (var product in category.Products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();
                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                    product.DoublePrice = price;
                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        //product.DiscountExpireDate = discount.EndDate.ToDiscountFormat();
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscountForShow = (price - discountAmount).ToMoney();
                        product.PriceWithDiscountForCart = (price - discountAmount);
                    }
                }
            }

            return category;
        }

        private static List<ProductQueryModel> MapProducts(List<Product> products, int skip)
        {
            return products.Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug               
            }).Skip(skip).Take(40).ToList();
        }
    }
}
