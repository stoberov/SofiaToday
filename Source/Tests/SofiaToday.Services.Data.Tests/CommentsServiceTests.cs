namespace SofiaToday.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Moq;
    using NUnit.Framework;
    using SofiaToday.Data.Models;
    using SofiaToday.Services.Data.Contracts;

    [TestFixture]
    public class CommentsServiceTests
    {
        private IQueryable<Comment> mockedComments;
        private Mock<ICommentsService> mockedCommentsData;

        [OneTimeSetUp]
        public void Init()
        {
            mockedComments = new List<Comment>().AsQueryable();
            mockedCommentsData = new Mock<ICommentsService>();


            mockedCommentsData
                .Setup(s => s.GetArticleComments(1))
                .Returns(mockedComments);

            mockedCommentsData
                .Setup(s => s.AddNewComment(It.IsAny<Comment>()))
                .Verifiable();
        }

        [Test]
        public void GetArticleCommentsShouldNotReturnNull()
        {
            var comments = mockedCommentsData.Object.GetArticleComments(1);
            Assert.AreNotEqual(null, comments);
        }

        [Test]
        public void AddCommentShouldBeCalled()
        {
            mockedCommentsData.Object.AddNewComment(new Comment());
            mockedCommentsData.Verify(s => s.AddNewComment(It.IsAny<Comment>()));
        }
    }
}
