
using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductCompany
{
    public interface IProductCompanyApplication
    {
        OpretaionResult Create(CreateProductCompany command);
        OpretaionResult Edit(EditProductCompany command);
        EditProductCompany GetDetails(long id);
        List<ProductCompanyViewModel> Search(ProductCompanySearchModel searchModel);
    }
}
