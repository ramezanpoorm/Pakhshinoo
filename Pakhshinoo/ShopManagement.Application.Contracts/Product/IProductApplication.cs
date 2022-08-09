using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.Product
{
    public interface IProductApplication
    {
        OpretaionResult Create(CreateProduct command);
        OpretaionResult Edit(EditProduct command);
        EditProduct GetDetails(long Id);
        List<ProductViewModel> GetProducts();
        List<ProductViewModel> Search(ProductSearchModel searchModel);
        OpretaionResult Special(long id);
        OpretaionResult NotSpecial(long id);
        OpretaionResult NotSpecialAll();
        void IncVisit(long id);
    }
}
