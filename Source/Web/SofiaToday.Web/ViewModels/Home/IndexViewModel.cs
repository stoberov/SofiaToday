namespace SofiaToday.Web.ViewModels.Home
{
    using System.Collections.Generic;
    using Events;

    public class IndexViewModel
    {
        public IEnumerable<EventViewModel> FeaturedEvents { get; set; }

        public IEnumerable<EventViewModel> UpcomingEvents { get; set; }

        public IEnumerable<EventViewModel> DailyEvents { get; set; }
    }
}
