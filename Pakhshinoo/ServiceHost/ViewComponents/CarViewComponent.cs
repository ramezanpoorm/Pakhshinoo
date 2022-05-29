using _01_PakhshinoQuery.Contract.Car;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class CarViewComponent : ViewComponent
    {
        private readonly ICarQuery _carQuery;

        public CarViewComponent(ICarQuery carQuery)
        {
            _carQuery = carQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _carQuery.GetCar();
            return View(products);
        }
    }
}
