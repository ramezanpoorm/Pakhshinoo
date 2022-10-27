
using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Brand
{
    public interface IBrandApplication
    {
        OpretaionResult Create(CreateBrand command);
        OpretaionResult Edit(EditBrand command);
        EditBrand GetDetails(long id);
        List<BrandViewModel> GetBrand();
        List<BrandViewModel> Search(BrandSearchModel searchModel);
        void Removed(long id);
        void Restore(long id);
    }
}
