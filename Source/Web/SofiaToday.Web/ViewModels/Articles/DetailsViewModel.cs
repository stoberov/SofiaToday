namespace SofiaToday.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using Comments;

    public class DetailsViewModel
    {
        public ArticleViewModel Article { get; set; }

        public CommentInputModel CommentInputModel { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
