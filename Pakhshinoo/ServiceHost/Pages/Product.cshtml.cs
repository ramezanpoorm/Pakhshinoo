
using _01_PakhshinoQuery.Contract.Product;
using CommentManagement.Application.Contracts.Comment;
using CommentManagement.InfraStructure.EFCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ServiceHost.Pages
{
    public class ProductModel : PageModel
    {
        public ProductQueryModel Product;
        private readonly IProductQuery _productQuery;
        private readonly ICommentApplication _commentApplication;

        public ProductModel(IProductQuery productQuery, ICommentApplication commentApplication)
        {
            _productQuery = productQuery;
            _commentApplication = commentApplication;
        }

        public void OnGet(long id)
        {
            Product = _productQuery.GetDetails(id);
        }
        public IActionResult OnPost(AddComment command, long productId)
        {
            command.Type = CommentType.Product;
            var result = _commentApplication.Add(command);
            return RedirectToPage("/Product", new { Id = productId });
        }
    }
}
