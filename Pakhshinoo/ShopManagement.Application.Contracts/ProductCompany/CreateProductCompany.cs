
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.Product;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductCompany
{
    public class CreateProductCompany
    {
        public long CompanyId { get; set; }
        public long ProductId { get; set; }
        public List<ProductViewModel> Product { get; set; }
        public List<CompanyViewModel> Company { get; set; }
    }
}
