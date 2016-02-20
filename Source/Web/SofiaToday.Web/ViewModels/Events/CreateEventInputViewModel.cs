namespace SofiaToday.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class CreateEventInputViewModel
    {
        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        [Required]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        public string Location { get; set; }

        public double Price { get; set; }

        public string ImageUrl { get; set; }
    }
}
