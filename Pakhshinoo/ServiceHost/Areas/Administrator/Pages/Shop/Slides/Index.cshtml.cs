using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using ShopManagement.Application.Contracts.ProductPicture;
using ShopManagement.Application.Contracts.Slide;

namespace ServiceHost.Areas.Administrator.Pages.Shop.Slides
{
    public class IndexModel : PageModel
    {
        [TempData]
        public string Message { get; set; }
        public List<SlideViewModel> Slides;

        private readonly ISlideApplication _slideApplication;

        public IndexModel(ISlideApplication slideApplication)
        {
            _slideApplication = slideApplication;
        }

        public void OnGet()
        {
            Slides = _slideApplication.GetList();
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateSlide();
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateSlide command)
        {
            var result = _slideApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long Id)
        {
            var slide = _slideApplication.GetDetails(Id);
            return Partial("Edit", slide);
        }

        public JsonResult OnPostEdit(EditSlide command)
        {
            var result = _slideApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            var result = _slideApplication.Remove(id);
            if (result.IsSuccesseded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            var result = _slideApplication.Restore(id);
            if (result.IsSuccesseded)
                return RedirectToPage("./Index");
            Message = result.Message;
            return RedirectToPage("./Index");
        }
    }
}
