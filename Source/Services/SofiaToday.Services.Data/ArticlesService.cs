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
        IDbRepository<Comment> comments;

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
    }
}
