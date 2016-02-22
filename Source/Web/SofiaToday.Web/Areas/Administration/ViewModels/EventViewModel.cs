namespace SofiaToday.Web.Areas.Administration.ViewModels
{
    using System;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EventViewMode : IMapFrom<Event>
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Location { get; set; }

        public CategoryType Category { get; set; }

        public decimal Price { get; set; }

        public bool IsFeatured { get; set; }
    }
}
