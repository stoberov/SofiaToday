namespace SofiaToday.Data.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Event : BaseModel<int>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public DateTime StartDateTime { get; set; }

        [Required]
        [Display(Name = "End Date")]
        public DateTime EndDateTime { get; set; }

        [Required]
        public string Description { get; set; }

        public string Location { get; set; }

        public CategoryType Category { get; set; }

        public string CreatorId { get; set; }

        public virtual ApplicationUser Creator { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public bool IsFeatured { get; set; }

        [Display(Name = "Event website")]
        public string OfficialUrl { get; set; }
    }
}
