namespace SofiaToday.Services.Data
{
    using System.Linq;
    using SofiaToday.Data.Models;

    public interface ICommentsService
    {
        IQueryable<Comment> GetArticleComments(int id);

        void AddNewComment(Comment newComment);

        void SaveChanges();
    }
}
