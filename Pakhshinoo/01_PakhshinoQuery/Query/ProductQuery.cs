
using _0_Framework.Application;
using _01_PakhshinoQuery.Contract.Comment;
using _01_PakhshinoQuery.Contract.Product;
using CommentManagement.InfraStructure.EFCore;
using DiscountManagement.Infrastructure.EFCore;
using InventoryMangement.InfraStructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Domain.ProductPictureAgg;
using ShopManagement.InfraStructure.EFCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace _01_PakhshinoQuery.Query
{
    public class ProductQuery : IProductQuery
    {
        private readonly ShopContext _context;
        private readonly InventoryContext _inventoryContext;
        private readonly DiscountContext _discountContext;
        private readonly CommentContext _commentContext;

        public ProductQuery(ShopContext context, InventoryContext inventory, DiscountContext discountContext, CommentContext commentContext)
        {
            _context = context;
            _inventoryContext = inventory;
            _discountContext = discountContext;
            _commentContext = commentContext;
        }

        public ProductQueryModel GetDetails(long id)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice, x.InStock }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var product = _context.Products.Include(x => x.ProductPictures).Include(x => x.Category).Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
                IsSpecial = product.IsSpecial,
                CategoryId = product.Category.Id,
                Code = product.Code,
                Description = product.Description,
                Keywords = product.Keywords,
                MetaDescription = product.MetaDescription,
                ShortDescription = product.ShortDescription,
                Pictures = MapProductPictures(product.ProductPictures)
            }).FirstOrDefault(x => x.Id == id);

            if (product == null)
                return new ProductQueryModel();


            var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
            if (productInventory != null)
            {
                product.IsStock = productInventory.InStock;
                var price = productInventory.UnitPrice;
                product.Price = price.ToMoney();
                product.DoublePrice = price;

                var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);

                if (discount != null)
                {
                    int discountRate = discount.DiscountRate;
                    product.DiscountRate = discountRate;
                    product.HasDiscount = discountRate > 0;
                    var discountAmount = Math.Round((price * discountRate) / 100);
                    product.PriceWithDiscountForShow = (price - discountAmount).ToMoney();
                    product.PriceWithDiscountForCart = (price - discountAmount);
                }

            }

            product.Comments = _commentContext.Comments
                .Where(x => !x.IsCanceled)
                .Where(x => x.IsConfirmed)
                .Where(x => x.Type == CommentType.Product)
                .Where(x => x.OwnerRecordId == product.Id)
                .Select(x => new CommentQueryModel
                {
                    Id = x.Id,
                    Message = x.Message,
                    Name = x.Name,
                    CreationDate = x.CreateDate.ToFarsi()
                }).OrderByDescending(x => x.Id).ToList();

            return product;
        }

        private static List<ProductPictureQueryModel> MapProductPictures(List<ProductPicture> pictures)
        {
            return pictures.Select(x => new ProductPictureQueryModel
            {
                IsRemoved = x.IsRemoved,
                Picture = x.Picture,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ProductId = x.ProductId
            }).Where(x => !x.IsRemoved).ToList();
        }

        public List<ProductQueryModel> GetLatestProducts()
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var products = _context.Products.Include(x => x.Category).Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
                IsSpecial = product.IsSpecial
            }).OrderByDescending(x => x.Id).Take(6).ToList();

            foreach (var product in products)
            {
                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();

                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);

                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscountForShow = (price - discountAmount).ToMoney();
                        product.PriceWithDiscountForCart = (price - discountAmount);
                    }
                    
                }
            }
            return products;
        }

        public List<ProductQueryModel> GetSpecialProducts()
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId, x.EndDate, x.IsSpecial }).ToList();

            var products = _context.Products.Include(x => x.Category).Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
            }).ToList();

            foreach (var product in products)
            {

                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();

                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);

                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.EndDate = discount.EndDate.ToString();
                        product.HasDiscount = discountRate > 0;
                        product.IsSpecial = discount.IsSpecial;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscountForShow = (price - discountAmount).ToMoney();
                        product.PriceWithDiscountForCart = (price - discountAmount);
                    }

                }
            }
            return products.Where(c => c.IsSpecial == true).ToList();
        }

        
        public List<ProductQueryModel> GetAllProducts(int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId)
        {
            int skip = (pageid - 1) * 80;
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId }).ToList();


            var products = _context.Products.Where(s => s.UnitPrice >= startPrice && (categoryId == 0 || s.CategoryId == categoryId) && s.UnitPrice <= endPrice && (brandId == 0 || s.BrandId == brandId) && (carId == 0 || s.CarProducts.Where(p => p.ProductId == s.Id && p.CarId == carId).Any()) && (companyId == 0 || s.CompanyProducts.Where(p => p.ProductId == s.Id && p.CompanyId == companyId).Any())).Include(x => x.Category).Select(product => new ProductQueryModel
            {
                StartPrice = startPrice,
                EndPrice = endPrice,
                ActivePage = pageid,
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
                IsSpecial = product.IsSpecial,
                BrandId = brandId,
                CompanyId = companyId,
                CarId = carId,
                CategoryId = categoryId,
                PageCount = _context.Products.Where(s => s.UnitPrice >= startPrice && s.UnitPrice <= endPrice && (categoryId == 0 || s.CategoryId == categoryId) && (brandId == 0 || s.BrandId == brandId) && (carId == 0 || s.CarProducts.Where(p => p.ProductId == s.Id && p.CarId == carId).Any()) && (companyId == 0 || s.CompanyProducts.Where(p => p.ProductId == s.Id && p.CompanyId == companyId).Any())).ToList().Count
            }).Skip(skip).Take(80).ToList();

            foreach (var product in products)
            {

                var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                if (productInventory != null)
                {
                    var price = productInventory.UnitPrice;
                    product.Price = price.ToMoney();

                    var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);

                    if (discount != null)
                    {
                        int discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                        product.PriceWithDiscountForShow = (price - discountAmount).ToMoney();
                        product.PriceWithDiscountForCart = (price - discountAmount);
                    }
                }                
            }
            return products;
        }
    }
}
