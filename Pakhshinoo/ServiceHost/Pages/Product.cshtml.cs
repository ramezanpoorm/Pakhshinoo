
using _01_PakhshinoQuery.Contract.Product;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.InfraStructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ShopManagement.Application.Contracts.Product;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;
        private readonly IProductApplication _productApplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication, IProductApplication productApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
            _productApplication = productApplication;
        }

        public void OnGet(long id)
        {
            Product = _productQuery.GetDetails(id);
            _productApplication.IncVisit(id);
        }
        public IActionResult OnPost(AddComment command, long productId)
        {
            command.Type = CommentType.Product;
            var result = _commentApplication.Add(command);
            return RedirectToPage("/Product", new { Id = productId });
        }
    }
}
