using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Company;

namespace ServiceHost.Areas.Administrator.Pages.Shop.Company
{
    public class IndexModel : PageModel
    {
        public CompanySearchModel SearchModel;
        public List<CompanyViewModel> companies;
        private readonly ICompanyApplication _companyApplication;
        public IndexModel(ICompanyApplication companyApplication)
        {
            _companyApplication = companyApplication;
        }
        public void OnGet(CompanySearchModel searchModel)
        {
            companies = _companyApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            return Partial("./Create", new CreateCompany());
        }

        public JsonResult OnPostCreate(CreateCompany command)
        {
            var result = _companyApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long Id)
        {
            var company = _companyApplication.GetDetails(Id);
            return Partial("Edit", company);
        }

        public JsonResult OnPostEdit(EditCompany command)
        {
            var result = _companyApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            _companyApplication.Removed(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _companyApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}
