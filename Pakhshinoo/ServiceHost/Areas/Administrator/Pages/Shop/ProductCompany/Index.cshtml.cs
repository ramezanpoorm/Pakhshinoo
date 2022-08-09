using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Company;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCompany;

namespace ServiceHost.Areas.Administrator.Pages.Shop.ProductCompany
{
    public class IndexModel : PageModel
    {
        //[TempData]
        private readonly IProductCompanyApplication _productCompanyApplication;
        private readonly ICompanyApplication _companyApplication;
        private readonly IProductApplication _productApplication;
        public SelectList Company;
        public SelectList Product;
        public ProductCompanySearchModel SearchModel;
        public List<ProductCompanyViewModel> ProductCompany;
        public string Message { get; set; }

        public IndexModel(IProductCompanyApplication productCompanyApplication, ICompanyApplication companyApplication, IProductApplication productApplication)
        {
            _productCompanyApplication = productCompanyApplication;
            _companyApplication = companyApplication;
            _productApplication = productApplication;
        }

        public void OnGet(ProductCompanySearchModel searchModel)
        {
            Company = new SelectList(_companyApplication.GetCompany(), "Id", "Name");
            Product = new SelectList(_productApplication.GetProducts(), "Id", "Name");
            ProductCompany = _productCompanyApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProductCompany
            {
                Product = _productApplication.GetProducts(),
                Company=_companyApplication.GetCompany()
            };
            return Partial("./Create", command);
        }

        public JsonResult OnPostCreate(CreateProductCompany command)
        {
            var result = _productCompanyApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long Id)
        {
            var productCompany = _productCompanyApplication.GetDetails(Id);
            productCompany.Product = _productApplication.GetProducts();
            productCompany.Company = _companyApplication.GetCompany();
            return Partial("Edit", productCompany);
        }

        public JsonResult OnPostEdit(EditProductCompany command)
        {
            var result = _productCompanyApplication.Edit(command);
            return new JsonResult(result);
        }
    }
}
