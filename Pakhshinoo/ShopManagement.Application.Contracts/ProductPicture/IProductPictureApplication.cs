
using _0_Framework.Application;
using System.Collections.Generic;

namespace ShopManagement.Application.Contracts.ProductPicture
{
    public interface IProductPictureApplication
    {
        OpretaionResult Create(CreateProductPicture command);
        OpretaionResult Edit(EditProductPicture command);
        OpretaionResult Remove(long id);
        OpretaionResult Restore(long id);
        EditProductPicture GetDetails(long id);
        List<ProductPictureViewModel> Search(ProductPictureSearchModel searchModel);
    }
}
