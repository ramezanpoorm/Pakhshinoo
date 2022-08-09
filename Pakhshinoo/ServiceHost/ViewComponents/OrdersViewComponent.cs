using _01_PakhshinoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class OrdersViewComponent : ViewComponent
    {
        private readonly IProductQuery _productQuery;

        public OrdersViewComponent(IProductQuery productQuery)
        {
            _productQuery = productQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _productQuery.GetOrderItemsIndex();
            return View(products);
        }
    }
}
