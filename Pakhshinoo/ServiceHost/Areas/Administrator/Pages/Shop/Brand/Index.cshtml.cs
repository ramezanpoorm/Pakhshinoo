using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Brand;

namespace ServiceHost.Areas.Administrator.Pages.Shop.Brand
{
    public class IndexModel : PageModel
    {
        public BrandSearchModel SearchModel;
        public List<BrandViewModel> brands;
        private readonly IBrandApplication _brandApplication;
        public IndexModel(IBrandApplication brandApplication)
        {
            _brandApplication = brandApplication;
        }
        public void OnGet(BrandSearchModel searchModel)
        {
            brands = _brandApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateBrand());
        }

        public JsonResult OnPostCreate(CreateBrand command)
        {
            var result = _brandApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long Id)
        {
            var brand = _brandApplication.GetDetails(Id);
            return Partial("Edit", brand);
        }

        public JsonResult OnPostEdit(EditBrand command)
        {
            var result = _brandApplication.Edit(command);
            return new JsonResult(result);
        }
        public IActionResult OnGetRemove(long id)
        {
            _brandApplication.Removed(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _brandApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
