using _01_PakhshinoQuery.Contract.Brand;
using _01_PakhshinoQuery.Contract.Company;
using _01_PakhshinoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class CompanyViewComponent : ViewComponent
    {
        private readonly ICompanyQuery _companyQuery;

        public CompanyViewComponent(ICompanyQuery companyQuery)
        {
            _companyQuery = companyQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _companyQuery.GetCompany();
            return View(products);
        }
    }
}
