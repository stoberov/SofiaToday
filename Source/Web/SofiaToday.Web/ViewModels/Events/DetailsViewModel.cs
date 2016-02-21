namespace SofiaToday.Web.ViewModels.Events
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class DetailsViewModel
    {
        public EventViewModel Event { get; set; }

        [UIHint("RelatedEvent")]
        public IEnumerable<EventViewModel> RelatedEvents { get; set; }
    }
}
