
using _0_Framework.Domain;
using ShopManagement.Domain.CompanyAgg;
using ShopManagement.Domain.ProductAgg;

namespace ShopManagement.Domain.CompanyProductAgg
{
    public class CompanyProduct: EntityBase
    {
        public long ProductId { get; private set; }
        public long CompanyId { get; private set; }
        public Product Product { get; private set; }
        public Company Company { get; private set; }
        
        public CompanyProduct(long productId, long companyId)
        {
            ProductId = productId;
            CompanyId = companyId;
        }

        public void Edit(long productId, long companyId)
        {
            ProductId = productId;
            CompanyId = companyId;
        }
    }
}
