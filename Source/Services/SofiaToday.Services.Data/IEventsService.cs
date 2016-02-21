namespace SofiaToday.Services.Data
{
    using System.Linq;

    using SofiaToday.Data.Models;

    public interface IEventsService
    {
        IQueryable<Event> GetAll();

        IQueryable<Event> GetUpcomingEvents();

        IQueryable<Event> GetPassedEvents();

        IQueryable<Event> GetFeaturedEvents();

        Event GetEventById(int id);

        IQueryable<Event> GetEventsByCreatorId(string creatorId);

        IQueryable<Event> GetRandomEvents(int count);

        void AddNewEvent(Event newEvent);

        void SaveChanges();
    }
}
