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

        public void OnGet(long id, int pageid)
        {
            ProductCategory = _productCategoryQuery.GetProductCategoryWithProductsBy(id, pageid);        
        }
    }
}
