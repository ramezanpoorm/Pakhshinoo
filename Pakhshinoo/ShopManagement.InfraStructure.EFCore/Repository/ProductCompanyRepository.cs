
using _0_Framework.Application;
using _0_Framework.InfraStructure;
using Microsoft.EntityFrameworkCore;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCompany;
using ShopManagement.Domain.CompanyProductAgg;
using System.Collections.Generic;
using System.Linq;

namespace ShopManagement.InfraStructure.EFCore.Repository
{
    public class ProductCompanyRepository : RepositoryBase<long, CompanyProduct>, ICompanyProductRepository
    {
        private readonly ShopContext _shopContext;
        public ProductCompanyRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public List<CompanyViewModel> GetCompany()
        {
            return _shopContext.Companies.Select(x => new CompanyViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public EditProductCompany GetDetails(long Id)
        {
            return _shopContext.CompanyProducts.Select(x => new EditProductCompany()
            {
                id = x.Id,
                CompanyId = x.CompanyId,
                ProductId = x.ProductId
            }).FirstOrDefault(x => x.id == Id);
        }

        public List<ProductViewModel> GetProducts()
        {
            return _shopContext.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name
            }).ToList();
        }

        public List<ProductCompanyViewModel> Search(ProductCompanySearchModel searchModel)
        {
            var query = _shopContext.CompanyProducts.Include(x => x.Product).Include(s=>s.Company).Select(x => new ProductCompanyViewModel
            {
                Id = x.Id,
                Product = x.Product.Name,
                CreationDate = x.CreateDate.ToFarsi(),
                Company = x.Company.Name
            });

            if (searchModel.ProductId != 0)
                query = query.Where(x => x.ProductId == searchModel.ProductId);

            return query.OrderByDescending(x => x.Id).ToList();
        }
    }
}
