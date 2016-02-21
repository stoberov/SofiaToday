namespace SofiaToday.Services.Data
{
    using System.Linq;
    using SofiaToday.Data.Models;

    public interface IArticlesService
    {
        IQueryable<Article> GetAll();

        Article GetArticleById(int id);
    }
}
