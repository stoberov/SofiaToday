namespace SofiaToday.Services.Data
{
    using System.Linq;
    using SofiaToday.Data.Models;

    public interface IArticlesService
    {
        IQueryable<Article> GetAll();

        Article GetArticleById(int id);

        void AddNewArticle(Article newArticle);

        void Save();

        void Delete(Article model);

        void Delete(int id);
    }
}
