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
                .Setup(s => s.GetEventById(1))
                .Returns(new Event { Id = 1 });

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

        [Test]
        public void DeleteEventShouldBeCalled()
        {
            mockedEventsData.Object.Delete(new Event());
            mockedEventsData.Verify(s => s.Delete(It.IsAny<Event>()));
        }
    }
}
