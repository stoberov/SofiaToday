namespace SofiaToday.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Articles;
    using ViewModels.Comments;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService articles;

        private readonly ICommentsService comments;

        public ArticlesController(IArticlesService articles, ICommentsService comments)
        {
            this.articles = articles;
            this.comments = comments;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = this.articles.GetAll().To<ArticleViewModel>().ToList();

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var singleArticle = this.articles.GetArticleById(id);
            var articleComments = this.comments.GetArticleComments(id).To<CommentViewModel>().ToList();

            var viewModel = new DetailsViewModel
            {
                Article = this.Mapper.Map<ArticleViewModel>(singleArticle),
                Comments = articleComments
            };

            return this.View(viewModel);
        }
    }
}
