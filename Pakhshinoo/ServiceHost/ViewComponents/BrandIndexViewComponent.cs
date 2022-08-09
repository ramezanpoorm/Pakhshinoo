using _01_PakhshinoQuery.Contract.Brand;
using _01_PakhshinoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class BrandIndexViewComponent : ViewComponent
    {
        private readonly IBrandQuery _brandQuery;

        public BrandIndexViewComponent(IBrandQuery brandQuery)
        {
            _brandQuery = brandQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _brandQuery.GetBrand();
            return View(products);
        }
    }
}
