namespace SofiaToday.Web.ViewModels.Events
{
    using System.Collections.Generic;

    public class AllEventsViewModel
    {
        public IEnumerable<EventViewModel> AllEvents { get; set; }

        public int CurrentPage { get; set; }

        public int TotalPages { get; set; }
    }
}
