
using System.Collections.Generic;

namespace _01_PakhshinoQuery.Contract.Product
{
    public interface IProductQuery
    {
        ProductQueryModel GetDetails(long id);
        List<ProductQueryModel> GetSpecialProducts();
        List<ProductQueryModel> GetLatestProducts();
    }
}
