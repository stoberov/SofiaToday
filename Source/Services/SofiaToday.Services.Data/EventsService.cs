namespace SofiaToday.Services.Data
{
    using System;
    using System.Linq;

    using SofiaToday.Data.Common;
    using SofiaToday.Data.Models;

    public class EventsService : IEventsService
    {
        private readonly IDbRepository<Event> events;

        public EventsService(IDbRepository<Event> events)
        {
            this.events = events;
        }

        public IQueryable<Event> GetAll()
        {
            return this.events.All();
        }

        public IQueryable<Event> GetUpcomingEvents()
        {
            return this.events.All().Where(x => x.StartDateTime > DateTime.Now);
        }

        public IQueryable<Event> GetPassedEvents()
        {
            return this.events.All().Where(x => x.StartDateTime < DateTime.Now);
        }

        public Event GetEventById(int id)
        {
            return this.events.GetById(id);
        }

        public IQueryable<Event> GetRandomEvents(int count)
        {
            return this.events.All().OrderBy(x => Guid.NewGuid()).Take(count);
        }

        public void AddNewEvent(Event newEvent)
        {
            this.events.Add(newEvent);
            this.events.Save();
        }

        public IQueryable<Event> GetEventsByCreatorId(string creatorId)
        {
            return this.events.All().Where(x => x.CreatorId == creatorId);
        }

        public IQueryable<Event> GetFeaturedEvents()
        {
            return this.events.All().Where(x => x.IsFeatured);
        }
    }
}
