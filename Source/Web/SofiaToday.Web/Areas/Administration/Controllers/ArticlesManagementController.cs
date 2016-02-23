namespace SofiaToday.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Microsoft.AspNet.Identity;
    using SofiaToday.Data.Common;
    using SofiaToday.Data.Models;
    using SofiaToday.Web.Infrastructure.Mapping;
    using SofiaToday.Web.ViewModels.Articles;
    using ViewModels;

    public class ArticlesManagementController : AdministrationController
    {
        private readonly IDbRepository<Article> articles;

        public ArticlesManagementController(IDbRepository<Article> articles)
        {
            this.articles = articles;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        public ActionResult Articles_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.articles.All()
                .To<ArticleGridViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Create([DataSourceRequest]DataSourceRequest request, CreateNewArticleViewModel article)
        {
            var newId = 0;
            if (this.ModelState.IsValid)
            {
                var entity = new Article
                {
                    AuthorId = this.User.Identity.GetUserId(),
                    Title = article.Title,
                    Summary = article.Summary,
                    Content = article.Content,
                    ImageUrl = article.ImageUrl
                };

                this.articles.Add(entity);
                this.articles.Save();
                newId = entity.Id;
            }

            var articleToDisplay = this.articles.All()
                .To<ArticleGridViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return this.Json(new[] { articleToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Update([DataSourceRequest]DataSourceRequest request, CreateNewArticleViewModel article)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.articles.GetById(article.Id);
                entity.Title = article.Title;
                entity.Summary = article.Summary;
                entity.Content = article.Content;
                entity.ImageUrl = article.ImageUrl;

                this.articles.Save();
            }

            var articleToDisplay = this.articles.All()
                           .To<ArticleGridViewModel>()
                           .FirstOrDefault(x => x.Id == article.Id);

            return this.Json(new[] { articleToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Articles_Destroy([DataSourceRequest]DataSourceRequest request, Article article)
        {
            this.articles.Delete(article);
            this.articles.Save();

            return this.Json(new[] { article }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
