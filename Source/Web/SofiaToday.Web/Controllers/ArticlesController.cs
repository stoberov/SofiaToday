namespace SofiaToday.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Services.Data;
    using ViewModels.Articles;

    public class ArticlesController : BaseController
    {
        private readonly IArticlesService services;

        public ArticlesController(IArticlesService services)
        {
            this.services = services;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var viewModel = this.services.GetAll().To<ArticleViewModel>().ToList();

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var singleArticle = this.services.GetArticleById(id);
            var viewModel = new DetailsViewModel
            {
                Article = this.Mapper.Map<ArticleViewModel>(singleArticle)
            };

            return this.View(viewModel);
        }
    }
}
