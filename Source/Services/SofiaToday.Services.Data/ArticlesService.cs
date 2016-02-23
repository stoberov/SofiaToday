namespace SofiaToday.Services.Data
{
    using System;
    using System.Linq;
    using SofiaToday.Data.Common;
    using SofiaToday.Data.Models;

    public class ArticlesService : IArticlesService
    {
        private IDbRepository<Article> articles;
        private IDbRepository<Comment> comments;

        public ArticlesService(IDbRepository<Article> articles, IDbRepository<Comment> comments)
        {
            this.articles = articles;
            this.comments = comments;
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles.All();
        }

        public Article GetArticleById(int id)
        {
            return this.articles.GetById(id);
        }

        public void AddNewArticle(Article newArticle)
        {
            this.articles.Add(newArticle);
            this.articles.Save();
        }

        public void Save()
        {
            this.articles.Save();
        }

        public void Delete(Article model)
        {
            this.articles.Delete(model);
            this.articles.Save();
        }

        public void Delete(int id)
        {
            this.articles.Delete(id);
            this.articles.Save();
        }
    }
}
