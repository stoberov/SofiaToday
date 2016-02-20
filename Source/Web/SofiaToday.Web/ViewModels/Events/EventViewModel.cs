namespace SofiaToday.Web.ViewModels.Events
{
    using System;
    using System.Collections.Generic;

    public class EventViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Location { get; set; }
    }
}
