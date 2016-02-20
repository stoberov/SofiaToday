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

        public CategoryType Category { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
