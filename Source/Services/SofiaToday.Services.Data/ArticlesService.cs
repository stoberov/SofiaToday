namespace SofiaToday.Services.Data
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using SofiaToday.Data.Common;
    using SofiaToday.Data.Models;

    public class ArticlesService : IArticlesService
    {
        IDbRepository<Article> articles;

        public ArticlesService(IDbRepository<Article> articles)
        {
            this.articles = articles;
        }

        public IQueryable<Article> GetAll()
        {
            return this.articles.All();
        }

        public Article GetArticleById(int id)
        {
            return this.articles.GetById(id);
        }
    }
}
