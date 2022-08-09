using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Car;
using ShopManagement.Application.Contracts.CarProduct;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Areas.Administrator.Pages.Shop.CarProduct
{
    public class IndexModel : PageModel
    {
        private readonly ICarProductApplication _carProductApplication;
        private readonly ICarApplication _carApplication;
        private readonly IProductApplication _productApplication;
        public SelectList Car;
        public SelectList Product;
        public CarProductSearchModel SearchModel;
        public List<CarProductViewModel> CarProduct;
        public string Message { get; set; }

        public IndexModel(ICarProductApplication carProductApplication, ICarApplication carApplication, IProductApplication productApplication)
        {
            _carProductApplication = carProductApplication;
            _carApplication = carApplication;
            _productApplication = productApplication;
        }
        public void OnGet(CarProductSearchModel searchModel)
        {
            Car = new SelectList(_carApplication.GetCar(), "Id", "Name");
            Product = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            CarProduct = _carProductApplication.Search(searchModel);
        }
        public IActionResult OnGetCreate()
        {
            var command = new CreateCarProduct
            {
                Product = _productApplication.GetProducts(),
                Car = _carApplication.GetCar()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateCarProduct command)
        {
            var result = _carProductApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long Id)
        {
            var productCompany = _carProductApplication.GetDetails(Id);
            productCompany.Product = _productApplication.GetProducts();
            productCompany.Car = _carApplication.GetCar();
            return Partial("Edit", productCompany);
        }

        public JsonResult OnPostEdit(EditCarProduct command)
        {
            var result = _carProductApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
