namespace SofiaToday.Data.Models
{
    using System;
    using Common.Models;

    public class Event : BaseModel<int>
    {
        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public Category Category { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }
    }
}
