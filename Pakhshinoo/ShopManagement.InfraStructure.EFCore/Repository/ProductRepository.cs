using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Domain.ProductAgg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.InfraStructure.EFCore.Repository
{
    public class ProductRepository : RepositoryBase<long, Product>, IProductRepository
    {
        private readonly ShopContext _context;
        public ProductRepository(ShopContext context): base(context)
        {
            _context = context;
        }

        public EditProduct GetDetails(long Id)
        {
            return _context.Products.Select(x => new EditProduct
            {
                Id = x.Id,
                Name = x.Name,
                Code = x.Code,
                Slug = x.Slug,
                CategoryId = x.CategoryId,
                Description = x.Description,
                MetaDescription = x.MetaDescription,
                PictureAlt = x.PictureAlt,
                PictureTitle = x.PictureTitle,
                ShortDescription = x.ShortDescription,
                BrandId = x.BrandId
            }).FirstOrDefault(x => x.Id == Id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _context.Products.OrderByDescending(x => x.Id).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).OrderByDescending(x => x.Id).ToList();
        }

        public Product GetProductWithCategory(long id)
        {
            return _context.Products.OrderByDescending(x => x.Id).Include(x => x.Category).FirstOrDefault(x => x.Id == id && x.IsRemoved == false);
        }

        public List<ProductViewModel> Search(ProductSearchModel searchModel)
        {
            var query = _context.Products.OrderByDescending(x => x.Id).Include(x => x.Category).Include(x => x.Brand).Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category.Name,
                CategoryId = x.CategoryId,
                Code = x.Code,
                Picture = x.Picture,
                IsSpecial = x.IsSpecial,
                IsRemoved = x.IsRemoved,
                BrandId = x.BrandId,
                Brand = x.Brand.Name,
                CreationDate = x.CreateDate.ToFarsi()
            });

            if (!string.IsNullOrWhiteSpace(searchModel.Name))
                query = query.Where(x => x.Name.Contains(searchModel.Name));

            if (!string.IsNullOrWhiteSpace(searchModel.Code))
                query = query.Where(x => x.Code.Contains(searchModel.Code));

            if (searchModel.CategoryId != 0)
                query = query.Where(x => x.CategoryId == searchModel.CategoryId);

            if (searchModel.BrandId != 0)
                query = query.Where(x => x.BrandId == searchModel.BrandId);

            query = query.Where(x => x.IsRemoved == searchModel.IsRemoved);

            return query.ToList();
        }
    }
}
