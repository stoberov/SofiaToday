namespace SofiaToday.Web.ViewModels.Events
{
    using System;

    public class CreateEventInputViewModel
    {
        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Location { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
