using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using _01_PakhshinoQuery.Contract.ProductCategory;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductCategoryModel : PageModel
    {
        public ProductCategoryQueryModel ProductCategory;
        private readonly IProductCategoryQuery _productCategoryQuery;

        public ProductCategoryModel(IProductCategoryQuery productCategoryQuery)
        {
            _productCategoryQuery = productCategoryQuery;            
        }

        public void OnGet(long id, int pageid, long brandId, double startPrice, double endPrice, long carId, long companyId)
        {
            if (endPrice == 0)
                endPrice = 1200000000;
            ProductCategory = _productCategoryQuery.GetProductCategoryWithProductsBy(id, pageid, brandId, startPrice, endPrice, carId, companyId);        
        }
    }
}
