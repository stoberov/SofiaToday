namespace SofiaToday.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using Services.Data;
    using ViewModels.Articles;
    using ViewModels.Comments;

    public class ArticlesController : BaseController
    {
        private const int ItemsPerPage = 6;

        private readonly IArticlesService articles;
        private readonly ICommentsService comments;

        public ArticlesController(IArticlesService articles, ICommentsService comments)
        {
            this.articles = articles;
            this.comments = comments;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var currentPage = page;
            var allItemsCount = this.articles.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (currentPage - 1) * ItemsPerPage;

            var allArticles = this.articles
                .GetAll()
                .OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .To<ArticleViewModel>()
                .ToList();

            var viewModel = new AllArticlesViewModel
            {
                AllArticles = allArticles,
                TotalPages = totalPages,
                CurrentPage = currentPage
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var singleArticle = this.articles.GetArticleById(id);
            var articleComments = this.comments.GetArticleComments(id).To<CommentViewModel>().ToList();

            var viewModel = new ArticlePageViewModel
            {
                Article = this.Mapper.Map<ArticleViewModel>(singleArticle),
                Comments = articleComments
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateArticleInputModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var newArticle = new Article
            {
                AuthorId = this.User.Identity.GetUserId(),
                Title = model.Title,
                Summary = model.Summary,
                Content = model.Content,
                ImageUrl = model.ImageUrl
            };

            this.articles.AddNewArticle(newArticle);

            this.TempData["Notification"] = GlobalConstants.ArticleAddedSuccess;

            return this.Redirect("/");
        }
    }
}
