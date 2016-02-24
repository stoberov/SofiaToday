namespace SofiaToday.Services.Data.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Contracts;
    using Moq;
    using NUnit.Framework;
    using SofiaToday.Data.Models;

    [TestFixture]
    public class MessagesServiceTests
    {
        private IQueryable<Message> mockedMessages;
        private Mock<IMessagesService> mockedMessagesData;

        [OneTimeSetUp]
        public void Init()
        {
            mockedMessages = new List<Message>().AsQueryable();
            mockedMessagesData = new Mock<IMessagesService>();

            mockedMessagesData
                .Setup(s => s.Add(It.IsAny<Message>()))
                .Verifiable();
        }

        [Test]
        public void AddMessageShouldBeCalled()
        {
            mockedMessagesData.Object.Add(new Message());
            mockedMessagesData.Verify(s => s.Add(It.IsAny<Message>()));
        }
    }
}
