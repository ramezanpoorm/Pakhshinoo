using _01_LampshadeQuery.Contracts.Article;
using System.Collections.Generic;

namespace _01_LampshadeQuery.Contracts.ArticleCategory
{
    public interface IArticleCategoryQuery
    {
        ArticleCategoryQueryModel GetArticleCategory(string slug);
        List<ArticleCategoryQueryModel> GetArticleCategories();
        List<ArticleQueryModel> GetLatestArticleCategories();
    }
}
