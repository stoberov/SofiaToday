namespace SofiaToday.Web.Areas.Administration.ViewModels
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;

    public class EventInputModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public string Location { get; set; }

        public CategoryType Category { get; set; }

        public decimal Price { get; set; }

        public bool IsFeatured { get; set; }
    }
}
