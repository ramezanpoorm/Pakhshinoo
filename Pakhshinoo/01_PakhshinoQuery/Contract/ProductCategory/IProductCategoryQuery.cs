
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProductsBy(long id);
        List<ProductCategoryQueryModel> GetProductCategories();
        List<ProductCategoryQueryModel> GetProductCategoriesWithProduct();
    }
}
