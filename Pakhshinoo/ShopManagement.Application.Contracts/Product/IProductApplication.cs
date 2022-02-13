using _0_Framework.Application;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
