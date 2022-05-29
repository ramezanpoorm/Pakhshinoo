using _01_LampshadeQuery.Contracts.ArticleCategory;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServiceHost.ViewComponents
{
    public class ArticleIndexPageViewComponent : ViewComponent
    {
        private readonly IArticleCategoryQuery _ArticleCategoryQuery;
        public ArticleIndexPageViewComponent(IArticleCategoryQuery ArticleCategoryQuery)
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
