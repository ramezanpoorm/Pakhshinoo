using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Car;

namespace ServiceHost.Areas.Administrator.Pages.Shop.Cars
{
    public class IndexModel : PageModel
    {
        public CarSearchModel SearchModel;
        public List<CarViewModel> cars;
        private readonly ICarApplication _carApplication;
        public IndexModel(ICarApplication carApplication)
        {
            _carApplication = carApplication;
        }
        public void OnGet(CarSearchModel searchModel)
        {
            cars = _carApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateCar());
        }

        public JsonResult OnPostCreate(CreateCar command)
        {
            var result = _carApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long Id)
        {
            var car = _carApplication.GetDetails(Id);
            return Partial("Edit", car);
        }

        public JsonResult OnPostEdit(EditCar command)
        {
            var result = _carApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            _carApplication.Removed(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _carApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
