
namespace ShopManagement.Application.Contracts.ProductCompany
{
    public class ProductCompanyViewModel
    {
        public long Id { get; set; }        
        public string Company { get; set; }
        public long CompanyId { get; set; }
        public string CreationDate { get; set; }
        public string Product { get; set; }
        public long ProductId { get; set; }        
    }
}
