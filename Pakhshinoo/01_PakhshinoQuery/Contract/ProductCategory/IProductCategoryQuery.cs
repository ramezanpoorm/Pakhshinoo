
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProductsBy(long id, int pageId);
        ProductCategoryQueryModel FilterProducts(ProductCategoryQueryModel filter);
        List<ProductCategoryQueryModel> GetProductCategories();
        //List<ProductCategoryQueryModel> GetProductCategoriesWithProduct(int pageid);
    }
}
