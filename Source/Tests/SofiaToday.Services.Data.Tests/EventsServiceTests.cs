using System;
using System.Collections.Generic;
using System.Linq;
using Moq;
using NUnit.Framework;
using SofiaToday.Data.Models;
using SofiaToday.Services.Data.Contracts;

namespace SofiaToday.Services.Data.Tests
{
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
                .Setup(s => s.GetUpcomingEvents())
                .Returns(mockedEvents);

            mockedEventsData
                .Setup(s => s.GetPassedEvents())
                .Returns(mockedEvents);

            mockedEventsData
                .Setup(s => s.GetFeaturedEvents())
                .Returns(mockedEvents);

            mockedEventsData
                .Setup(s => s.GetDailyEvents(DateTime.Now))
                .Returns(mockedEvents);

            mockedEventsData
                .Setup(s => s.GetEventById(1))
                .Returns(new Event { Id = 1 });

            mockedEventsData
                .Setup(s => s.GetEventsByCreatorId("abcd123"))
                .Returns(mockedEvents);

            mockedEventsData
                .Setup(s => s.GetRandomEvents(3))
                .Returns(mockedEvents);

            mockedEventsData
                .Setup(s => s.AddNewEvent(It.IsAny<Event>()))
                .Verifiable();

            mockedEventsData
                .Setup(s => s.Delete(It.IsAny<Event>()))
                .Verifiable();
        }

        [Test]
        public void GetAllEventsShouldNotReturnNull()
        {
            var events = mockedEventsData.Object.GetAll();
            Assert.AreNotEqual(null, events);
        }

        [Test]
        public void GetUpcomingEventsShouldNotReturnNull()
        {
            var events = mockedEventsData.Object.GetUpcomingEvents();
            Assert.AreNotEqual(null, events);
        }

        [Test]
        public void GetPassedEventsShouldNotReturnNull()
        {
            var events = mockedEventsData.Object.GetPassedEvents();
            Assert.AreNotEqual(null, events);
        }

        [Test]
        public void GetFeaturedEventsShouldNotReturnNull()
        {
            var events = mockedEventsData.Object.GetFeaturedEvents();
            Assert.AreNotEqual(null, events);
        }

        [Test]
        public void GetDailyEventsShouldNotReturnNull()
        {
            var events = mockedEventsData.Object.GetDailyEvents(DateTime.Now);
            Assert.AreNotEqual(null, events);
        }

        [Test]
        public void GetEventByIdShouldNotReturnNull()
        {
            var singleEvent = mockedEventsData.Object.GetEventById(1);
            Assert.AreEqual(1, singleEvent.Id);
        }

        [Test]
        public void GetEventsByCreatorIdShouldNotReturnNull()
        {
            var events = mockedEventsData.Object.GetEventsByCreatorId("abcd123");
            Assert.AreNotEqual(null, events);
        }

        [Test]
        public void GetRandomEventsShouldNotReturnNull()
        {
            var events = mockedEventsData.Object.GetRandomEvents(3);
            Assert.AreNotEqual(null, events);
        }

        [Test]
        public void AddEventShouldBeCalled()
        {
            mockedEventsData.Object.AddNewEvent(new Event());
            mockedEventsData.Verify(s => s.AddNewEvent(It.IsAny<Event>()));
        }

        [Test]
        public void DeleteEventShouldBeCalled()
        {
            mockedEventsData.Object.Delete(new Event());
            mockedEventsData.Verify(s => s.Delete(It.IsAny<Event>()));
        }
    }
}
