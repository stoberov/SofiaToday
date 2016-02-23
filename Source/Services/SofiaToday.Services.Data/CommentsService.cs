namespace SofiaToday.Services.Data
{
    using System.Linq;
    using Contracts;
    using SofiaToday.Data.Common;
    using SofiaToday.Data.Models;

    public class CommentsService : ICommentsService
    {
        private readonly IDbRepository<Comment> comments;

        public CommentsService(IDbRepository<Comment> comments)
        {
            this.comments = comments;
        }

        public IQueryable<Comment> GetArticleComments(int id)
        {
            return this.comments.All().Where(x => x.ArticleId == id);
        }

        public void AddNewComment(Comment newComment)
        {
            this.comments.Add(newComment);
            this.comments.Save();
        }

        public void SaveChanges()
        {
            this.comments.Save();
        }
    }
}
