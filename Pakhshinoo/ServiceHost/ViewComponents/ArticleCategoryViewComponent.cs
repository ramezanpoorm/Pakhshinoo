using _01_LampshadeQuery.Contracts.ArticleCategory;
using _01_PakhshinoQuery.Contract.Brand;
using _01_PakhshinoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class ArticleCategoryViewComponent : ViewComponent
    {
        private readonly IArticleCategoryQuery _ArticleCategoryQuery;

        public ArticleCategoryViewComponent(IArticleCategoryQuery ArticleCategoryQuery)
        {
            _ArticleCategoryQuery = ArticleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _ArticleCategoryQuery.GetArticleCategories();
            return View(products);
        }
    }
}
