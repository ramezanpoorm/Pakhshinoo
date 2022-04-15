

using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Brand;
using System.Collections.Generic;

namespace ShopManagement.Domain.BrandAgg
{
    public interface IBrandRepository : IRepository<long, Brand>
    {
        List<BrandViewModel> GetBrands();
        EditBrand GetDetails(long id);
        string GetNameById(long id);
        List<BrandViewModel> Search(BrandSearchModel searchModel);
    }
}
