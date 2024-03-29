﻿
using _0_Framework.Application;
using _01_PakhshinoQuery.Contract.Comment;
using _01_PakhshinoQuery.Contract.Product;
using CommentManagement.InfraStructure.EFCore;
using DiscountManagement.Infrastructure.EFCore;
using InventoryMangement.InfraStructure.EFCore;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Order;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.OrderAgg;
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
        private readonly IProductApplication _productApplication;

        public ProductQuery(ShopContext context, InventoryContext inventory, DiscountContext discountContext, CommentContext commentContext, IProductApplication productApplication)
        {
            _context = context;
            _inventoryContext = inventory;
            _discountContext = discountContext;
            _commentContext = commentContext;
            _productApplication = productApplication;
        }

        public ProductQueryModel GetDetails(long id)
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice, x.InStock }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId }).AsNoTracking().ToList();

            var product = _context.Products.Where(x => x.IsRemoved == false).Include(x => x.ProductPictures).Include(x => x.Category).Select(product => new ProductQueryModel
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
            }).AsNoTracking().FirstOrDefault(x => x.Id == id);

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
                }).AsNoTracking().OrderByDescending(x => x.Id).ToList();

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

            var products = _context.Products.Where(x => x.IsRemoved == false).Include(x => x.Category).Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
                IsSpecial = product.IsSpecial
            }).AsNoTracking().OrderByDescending(x => x.Id).Take(6).ToList();

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
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId, x.EndDate, x.IsSpecial }).AsNoTracking().ToList();

            var products = _context.Products.Where(x => x.IsRemoved == false).Include(x => x.Category).Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
            }).AsNoTracking().ToList();

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
            return products.Where(c => c.IsSpecial == true).Take(10).ToList();
        }

        
        public List<ProductQueryModel> GetAllProducts(int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId)
        {
            int skip = (pageid - 1) * 80;
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId }).ToList();


            var products = _context.Products.Where(s => s.UnitPrice >= startPrice && s.IsRemoved == false && (categoryId == 0 || s.CategoryId == categoryId) && s.UnitPrice <= endPrice && (brandId == 0 || s.BrandId == brandId) && (carId == 0 || s.CarProducts.Where(p => p.ProductId == s.Id && p.CarId == carId).Any()) && (companyId == 0 || s.CompanyProducts.Where(p => p.ProductId == s.Id && p.CompanyId == companyId).Any())).Include(x => x.Category).Select(product => new ProductQueryModel
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
            }).AsNoTracking().Skip(skip).Take(80).ToList();

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

        public List<CartItem> CheckInventoryStatus(List<CartItem> cartItems)
        {
            var inventory = _inventoryContext.Inventory.ToList();

            foreach (var cartItem in cartItems.Where(cartItem =>
                inventory.Any(x => x.ProductId == cartItem.Id && x.InStock)))
            {
                var itemInventory = inventory.Find(x => x.ProductId == cartItem.Id);
                cartItem.IsInStock = itemInventory.CalculateCurrentCount() >= cartItem.Count;
            }

            return cartItems;
        }

        public List<ProductQueryModel> GetAllSpecialProducts(int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId)
        {
            int skip = (pageid - 1) * 80;
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId, x.EndDate, x.IsSpecial }).AsNoTracking().ToList();

            _productApplication.NotSpecialAll();
            
            foreach (var dis in discounts)
            {
                _productApplication.Special(dis.ProductId);                
            }

            var products = _context.Products.Where(s => s.UnitPrice >= startPrice && s.IsRemoved == false && (categoryId == 0 || s.CategoryId == categoryId) && s.UnitPrice <= endPrice && (brandId == 0 || s.BrandId == brandId) && (carId == 0 || s.CarProducts.Where(p => p.ProductId == s.Id && p.CarId == carId).Any()) && (companyId == 0 || s.CompanyProducts.Where(p => p.ProductId == s.Id && p.CompanyId == companyId).Any()) && s.IsSpecial == true).Include(x => x.Category).Select(product => new ProductQueryModel
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
                BrandId = brandId,
                CompanyId = companyId,
                CarId = carId,
                CategoryId = categoryId,
                PageCount = _context.Products.Where(s => s.UnitPrice >= startPrice && s.UnitPrice <= endPrice && (categoryId == 0 || s.CategoryId == categoryId) && (brandId == 0 || s.BrandId == brandId) && (carId == 0 || s.CarProducts.Where(p => p.ProductId == s.Id && p.CarId == carId).Any()) && (companyId == 0 || s.CompanyProducts.Where(p => p.ProductId == s.Id && p.CompanyId == companyId).Any()) && s.IsSpecial == true).ToList().Count
            }).AsNoTracking().Skip(skip).Take(80).ToList();

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
            
            return products.ToList();
        }

        public List<OrderItemViewModel> GetOrderItemsIndex()
        {
            var products = _context.Products.Where(x => x.IsRemoved == false).Select(x => new { x.Id, x.Name, x.Picture }).ToList();
            var order = _context.OrderItems.AsNoTracking().ToList();


            //var items = order.Items.GroupBy(c => new { c.DiscountRate, c.ProductId, c.UnitPrice }).Select(x => new OrderItemViewModel
            //{
            //    Sum = x.Sum(x => x.Count),
            //    DiscountRate = x.Key.DiscountRate,
            //    ProductId = x.Key.ProductId,
            //    UnitPrice = x.Key.UnitPrice
            //}).ToList();

            var items = order.GroupBy(c => new { c.DiscountRate, c.ProductId, c.UnitPrice }).Select(x => new OrderItemViewModel
            {
                Sum = x.Sum(x => x.Count),
                DiscountRate = x.Key.DiscountRate,
                ProductId = x.Key.ProductId,
                UnitPrice = x.Key.UnitPrice
            }).ToList();

            foreach (var item in items)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
                item.ProductPicture = products.FirstOrDefault(x => x.Id == item.ProductId)?.Picture;
            }
            return items.ToList();
        }

        public List<OrderItemViewModel> GetOrderItems()
        {
            var products = _context.Products.Where(x => x.IsRemoved == false).Select(x => new { x.Id, x.Name }).ToList();
            var order = _context.Orders.FirstOrDefault();
            

            var items = order.Items.Select(x => new OrderItemViewModel
            {
                Id = x.Id,
                Count = x.Count,
                DiscountRate = x.DiscountRate,
                OrderId = x.OrderId,
                ProductId = x.ProductId,
                UnitPrice = x.UnitPrice
            }).ToList();

            foreach (var item in items)
            {
                item.Product = products.FirstOrDefault(x => x.Id == item.ProductId)?.Name;
            }

            return items.ToList();
        }

        public List<ProductQueryModel> GetMostVisitProducts(int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId)
        {
            int skip = (pageid - 1) * 80;
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId, x.EndDate, x.IsSpecial }).ToList();

            _productApplication.NotSpecialAll();

            foreach (var dis in discounts)
            {
                _productApplication.Special(dis.ProductId);
            }

            var products = _context.Products.Where(s => s.UnitPrice >= startPrice && s.IsRemoved == false && (categoryId == 0 || s.CategoryId == categoryId) && s.UnitPrice <= endPrice && (brandId == 0 || s.BrandId == brandId) && (carId == 0 || s.CarProducts.Where(p => p.ProductId == s.Id && p.CarId == carId).Any()) && (companyId == 0 || s.CompanyProducts.Where(p => p.ProductId == s.Id && p.CompanyId == companyId).Any())).OrderByDescending(d => d.VisitCount).Include(x => x.Category).Select(product => new ProductQueryModel
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
                BrandId = brandId,
                CompanyId = companyId,
                CarId = carId,
                CategoryId = categoryId,
                PageCount = _context.Products.Where(s => s.UnitPrice >= startPrice && s.UnitPrice <= endPrice && (categoryId == 0 || s.CategoryId == categoryId) && (brandId == 0 || s.BrandId == brandId) && (carId == 0 || s.CarProducts.Where(p => p.ProductId == s.Id && p.CarId == carId).Any()) && (companyId == 0 || s.CompanyProducts.Where(p => p.ProductId == s.Id && p.CompanyId == companyId).Any())).ToList().Count
            }).Skip(skip).Take(80).AsNoTracking().ToList();

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

            return products.ToList();
        }

        public List<ProductQueryModel> GetMostVisitProductsIndex()
        {
            var inventory = _inventoryContext.Inventory.Select(x => new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts.Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now).Select(x => new { x.DiscountRate, x.ProductId }).ToList();

            var products = _context.Products.Where(x => x.IsRemoved == false).Include(x => x.Category).Select(product => new ProductQueryModel
            {
                Id = product.Id,
                Category = product.Category.Name,
                Name = product.Name,
                Picture = product.Picture,
                PictureAlt = product.PictureAlt,
                PictureTitle = product.PictureTitle,
                Slug = product.Slug,
                IsSpecial = product.IsSpecial,
                MostVisit = product.VisitCount
            }).OrderByDescending(x => x.MostVisit).Take(3).AsNoTracking().ToList();

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

        public List<ProductQueryModel> Search(string value, int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId)
        {
            var inventory = _inventoryContext.Inventory.Select(x =>
                new { x.ProductId, x.UnitPrice }).ToList();
            var discounts = _discountContext.CustomerDiscounts
                .Where(x => x.StartDate < DateTime.Now && x.EndDate > DateTime.Now)
                .Select(x => new { x.DiscountRate, x.ProductId, x.EndDate }).AsNoTracking().ToList();

            var query = _context.Products.Where(x=>x.IsRemoved == false)
                .Include(x => x.Category)
                .Select(product => new ProductQueryModel
                {
                    Id = product.Id,
                    Category = product.Category.Name,
                    Name = product.Name,
                    Picture = product.Picture,
                    PictureAlt = product.PictureAlt,
                    PictureTitle = product.PictureTitle,
                    ShortDescription = product.ShortDescription,
                    Slug = product.Slug
                }).AsNoTracking();

            if (!string.IsNullOrWhiteSpace(value))
                //value = value.Replace("ی", "ئ");
                query = query.Where(x => x.Name.Contains(value) || x.ShortDescription.Contains(value));

            var products = query.OrderByDescending(x => x.Id).ToList();

            if (products.Count != 0)
            {
                foreach (var product in products)
                {
                    var productInventory = inventory.FirstOrDefault(x => x.ProductId == product.Id);
                    if (productInventory != null)
                    {
                        var price = productInventory.UnitPrice;
                        product.Price = price.ToMoney();
                        var discount = discounts.FirstOrDefault(x => x.ProductId == product.Id);
                        if (discount == null) continue;

                        var discountRate = discount.DiscountRate;
                        product.DiscountRate = discountRate;
                        product.HasDiscount = discountRate > 0;
                        var discountAmount = Math.Round((price * discountRate) / 100);
                    }
                }
            }
            return products;
        }
    }
}
