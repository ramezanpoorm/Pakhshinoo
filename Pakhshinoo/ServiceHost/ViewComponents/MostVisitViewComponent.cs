using _01_PakhshinoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class MostVisitViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public MostVisitViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productQuery.GetMostVisitProductsIndex();
            return View(products);
        }
    }
}
