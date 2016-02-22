namespace SofiaToday.Web.ViewModels.Articles
{
    using System.Collections.Generic;

    public class AllArticlesViewModel
    {
        public IEnumerable<ArticleViewModel> AllArticles { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
