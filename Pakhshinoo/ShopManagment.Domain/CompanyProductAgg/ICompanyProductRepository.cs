
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCompany;
using ShopManagement.Domain.ProductAgg;
using System.Collections.Generic;

namespace ShopManagement.Domain.CompanyProductAgg
{
    public interface ICompanyProductRepository : IRepository<long, CompanyProduct>
    {
        EditProductCompany GetDetails(long Id);
        List<CompanyViewModel> GetCompany();
        List<ProductViewModel> GetProducts();
        List<ProductCompanyViewModel> Search(ProductCompanySearchModel searchModel);
    }
}
