
using _01_PakhshinoQuery.Contract.Product;
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.ProductCategory
{
    public interface IProductCategoryQuery
    {
        ProductCategoryQueryModel GetProductCategoryWithProductsBy(long id, int pageId, long brandId, double startPrice, double endPrice, long carId, long companyId);
        List<ProductCategoryQueryModel> GetProductCategories();
        //List<ProductCategoryQueryModel> GetProductCategoriesWithProduct(int pageid);
    }
}
