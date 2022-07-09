
using _01_PakhshinoQuery.Contract.Product;

using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class AllProductModel : PageModel
    {
        public List<ProductQueryModel> AllProducts;
        private readonly IProductQuery _productQuery;

        public AllProductModel(IProductQuery productQuery)
        {
            _productQuery = productQuery;            
        }

        public void OnGet(int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId)
        {
            if (endPrice == 0)
                endPrice = 1200000000;
            //pageid = 1;
            AllProducts = _productQuery.GetAllProducts(pageid, brandId, startPrice, endPrice, carId, companyId, categoryId);
        }
    }
}
