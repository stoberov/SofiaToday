namespace SofiaToday.Web.ViewModels.Events
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EventViewModel : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Location { get; set; }
    }
}
