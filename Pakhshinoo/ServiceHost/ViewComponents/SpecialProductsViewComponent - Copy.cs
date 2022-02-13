using _01_PakhshinoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class SpecialProductsViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public SpecialProductsViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke() 
        {
            var products = _productQuery.GetSpecialProducts();
            return View(products);
        }
    }
}
