namespace SofiaToday.Services.Data.Contracts
{
    using System;
    using System.Linq;

    using SofiaToday.Data.Models;

    public interface IEventsService
    {
        IQueryable<Event> GetAll();

        IQueryable<Event> GetUpcomingEvents();

        IQueryable<Event> GetPassedEvents();

        IQueryable<Event> GetFeaturedEvents();

        IQueryable<Event> GetDailyEvents(DateTime date);

        Event GetEventById(int id);

        IQueryable<Event> GetEventsByCreatorId(string creatorId);

        IQueryable<Event> GetRandomEvents(int count);

        void AddNewEvent(Event newEvent);

        void SaveChanges();
    }
}
