using _01_LampshadeQuery.Contracts.ArticleCategory;
using _01_PakhshinoQuery.Contract.Brand;
using _01_PakhshinoQuery.Contract.Product;
using Microsoft.AspNetCore.Mvc;


namespace ServiceHost.ViewComponents
{
    public class ArticleLatestCategoryViewComponent : ViewComponent
    {
        private readonly IArticleCategoryQuery _ArticleCategoryQuery;

        public ArticleLatestCategoryViewComponent(IArticleCategoryQuery ArticleCategoryQuery)
        {
            _ArticleCategoryQuery = ArticleCategoryQuery;
        }

        public IViewComponentResult Invoke()
        {
            var products = _ArticleCategoryQuery.GetLatestArticleCategories();
            return View(products);
        }
    }
}
