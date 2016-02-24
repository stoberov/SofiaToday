namespace SofiaToday.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Moq;
    using NUnit.Framework;
    using SofiaToday.Data.Models;

    [TestFixture]
    public class ArticlesServiceTests
    {
        private IQueryable<Article> mockedArticles;
        private Mock<IArticlesService> mockedArticlesData;

        [OneTimeSetUp]
        public void Init()
        {
            mockedArticles = new List<Article>().AsQueryable();
            mockedArticlesData = new Mock<IArticlesService>();

            mockedArticlesData
                .Setup(s => s.GetAll())
                .Returns(mockedArticles);

            mockedArticlesData
                .Setup(s => s.GetArticleById(1))
                .Returns(new Article { Id = 1 });

            mockedArticlesData
                .Setup(s => s.AddNewArticle(It.IsAny<Article>()))
                .Verifiable();

            mockedArticlesData
                .Setup(s => s.Delete(It.IsAny<Article>()))
                .Verifiable();
        }

        [Test]
        public void GetAllArticlesShouldNotReturnNull()
        {
            var articles = mockedArticlesData.Object.GetAll();
            Assert.AreNotEqual(null, articles);
        }

        [Test]
        public void GetByIdArticleIdShouldNotReturnNull()
        {
            var singleArticle = mockedArticlesData.Object.GetArticleById(1);
            Assert.AreEqual(1, singleArticle.Id);
        }

        [Test]
        public void AddArticleShouldBeCalled()
        {
            mockedArticlesData.Object.AddNewArticle(new Article());
            mockedArticlesData.Verify(s => s.AddNewArticle(It.IsAny<Article>()));
        }

        [Test]
        public void DeleteArticleShouldBeCalled()
        {
            mockedArticlesData.Object.Delete(new Article());
            mockedArticlesData.Verify(s => s.Delete(It.IsAny<Article>()));
        }
    }
}
