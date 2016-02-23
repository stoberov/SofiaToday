namespace SofiaToday.Web.ViewModels.Articles
{
    using System.Collections.Generic;
    using Comments;

    public class ArticlePageViewModel
    {
        public ArticleViewModel Article { get; set; }

        public CreateCommentInputModel CommentInputModel { get; set; }

        public IEnumerable<CommentViewModel> Comments { get; set; }
    }
}
