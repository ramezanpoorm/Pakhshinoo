using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using ShopManagement.Application.Contracts.Product;
using ShopManagement.Application.Contracts.ProductCategory;
using System.Collections.Generic;
using _0_Framework.Infrastructure;
using ShopManagement.Configuration.Permissions;
using ShopManagement.Application.Contracts.Brand;

namespace ServiceHost.Areas.Administration.Pages.Shop.Products
{
    public class IndexModel : PageModel
    {
        [TempData] public string Message { get; set; }
        public ProductSearchModel SearchModel;
        public List<ProductViewModel> Products;
        public SelectList ProductCategories;
        public SelectList Brand;

        private readonly IProductApplication _productApplication;
        private readonly IProductCategoryApplication _productCategoryApplication;
        private readonly IBrandApplication _brandApplication;

        public IndexModel(IProductApplication productApplication,
            IProductCategoryApplication productCategoryApplication, IBrandApplication brandApplication)
        {
            _productApplication = productApplication;
            _productCategoryApplication = productCategoryApplication;
            _brandApplication = brandApplication;
        }

        //[NeedsPermission(ShopPermissions.ListProducts)]
        public void OnGet(ProductSearchModel searchModel)
        {
            ProductCategories = new SelectList(_productCategoryApplication.GetProductCategories(), "Id", "Name");
            Brand = new SelectList(_brandApplication.GetBrand(), "Id", "Name");
            Products = _productApplication.Search(searchModel);
        }

        public IActionResult OnGetCreate()
        {
            var command = new CreateProduct
            {
                Categories = _productCategoryApplication.GetProductCategories(),
                Brands = _brandApplication.GetBrand()
            };
            return Partial("./Create", command);
        }

        //[NeedsPermission(ShopPermissions.CreateProduct)]
        public JsonResult OnPostCreate(CreateProduct command)
        {
            var result = _productApplication.Create(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetEdit(long id)
        {
            var product = _productApplication.GetDetails(id);
            product.Categories = _productCategoryApplication.GetProductCategories();
            product.Brands = _brandApplication.GetBrand();
            return Partial("Edit", product);
        }

        //[NeedsPermission(ShopPermissions.EditProduct)]
        public JsonResult OnPostEdit(EditProduct command)
        {
            var result = _productApplication.Edit(command);
            return new JsonResult(result);
        }

        public IActionResult OnGetRemove(long id)
        {
            _productApplication.Removed(id);
            return RedirectToPage("./Index");
        }

        public IActionResult OnGetRestore(long id)
        {
            _productApplication.Restore(id);
            return RedirectToPage("./Index");
        }
    }
}