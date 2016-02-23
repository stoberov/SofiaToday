namespace SofiaToday.Web.Controllers
{
    using System.Web.Mvc;
    using Common;
    using Data.Models;
    using Services.Data;
    using ViewModels.Articles;

    public class CommentsController : BaseController
    {
        private readonly ICommentsService comments;

        public CommentsController(ICommentsService comments)
        {
            this.comments = comments;
        }

        [HttpGet]
        public ActionResult Comment()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(int id, DetailsViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var comment = new Comment
            {
                Content = model.CommentInputModel.Content,
                Email = model.CommentInputModel.Email,
                Author = model.CommentInputModel.Author,
                ArticleId = id
            };

            this.comments.AddNewComment(comment);

            this.comments.SaveChanges();

            this.TempData["Notification"] = GlobalConstants.CommentAddedSuccess;

            return this.Redirect(this.Request.UrlReferrer.ToString());
        }
    }
}
