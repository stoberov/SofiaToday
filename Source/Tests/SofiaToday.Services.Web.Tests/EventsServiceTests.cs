namespace SofiaToday.Services.Web.Tests
{
    using System.Collections.Generic;
    using System.Linq;
    using Data.Contracts;
    using Moq;
    using NUnit.Framework;
    using SofiaToday.Data.Models;

    [TestFixture]
    public class EventsServiceTests
    {
        private IQueryable<Event> mockedEvents;
        private Mock<IEventsService> mockedEventsData;

        [OneTimeSetUp]
        public void Init()
        {
            mockedEvents = new List<Event>().AsQueryable();
            mockedEventsData = new Mock<IEventsService>();

            mockedEventsData
                .Setup(s => s.GetAll())
                .Returns(mockedEvents);

            mockedEventsData
                .Setup(s => s.GetEventById(1))
                .Returns(new Event { Id = 1 });

            mockedEventsData
                .Setup(s => s.AddNewEvent(It.IsAny<Event>()))
                .Verifiable();
        }

        [Test]
        public void GetAllEventsShouldNotReturnNull()
        {
            IQueryable<Event> events = mockedEventsData.Object.GetAll();
            Assert.AreNotEqual(null, events);
        }

        [Test]
        public void GetByIdEventIdShouldNotReturnNull()
        {
            Event singleEvent = mockedEventsData.Object.GetEventById(1);
            Assert.AreEqual(1, singleEvent.Id);
        }

        [Test]
        public void AddEventShouldBeCalled()
        {
            mockedEventsData.Object.AddNewEvent(new Event());
            mockedEventsData.Verify(s => s.AddNewEvent(It.IsAny<Event>()));
        }
    }
}
