namespace SofiaToday.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using SofiaToday.Data.Common;
    using SofiaToday.Data.Models;
    using SofiaToday.Web.Infrastructure.Mapping;
    using ViewModels;

    public class ArticlesManagementController : AdministrationController
    {
        private readonly IArticlesService articles;

        public ArticlesManagementController(IArticlesService articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Articles_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.articles.GetAll()
                .To<ArticleGridViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Update([DataSourceRequest]DataSourceRequest request, ArticleInputModel article)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.articles.GetArticleById(article.Id);

                entity.Title = article.Title;
                entity.Summary = article.Summary;
                entity.Content = article.Content;

                this.articles.Save();
            }

            var articleToDisplay = this.articles.GetAll()
                           .To<ArticleGridViewModel>()
                           .FirstOrDefault(x => x.Id == article.Id);

            return this.Json(new[] { articleToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Destroy([DataSourceRequest]DataSourceRequest request, Article article)
        {
            this.articles.Delete(article.Id);

            return this.Json(new[] { article }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
