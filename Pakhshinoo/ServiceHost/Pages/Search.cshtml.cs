
using _01_PakhshinoQuery.Contract.Product;

using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Collections.Generic;

namespace ServiceHost.Pages
{
    public class Search : PageModel
    {
        public string Value;
        public List<ProductQueryModel> AllProducts;
        private readonly IProductQuery _productQuery;

        public Search(IProductQuery productQuery)
        {
            _productQuery = productQuery;            
        }

        public void OnGet(string value, int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId, long categoryId)
        {
            if (endPrice == 0)
                endPrice = 1200000000;
            //pageid = 1;
            Value = value;
            AllProducts = _productQuery.Search(value, pageid, brandId, startPrice, endPrice, carId, companyId, categoryId);
        }
    }
}
