﻿namespace SofiaToday.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models;

    public class CreateEventInputViewModel
    {
        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }

        [AllowHtml]
        [UIHint("Description")]
        public string Description { get; set; }

        public string Location { get; set; }
        
        public CategoryType Category { get; set; }

        public decimal Price { get; set; }

        public string ImageUrl { get; set; }

        public string OfficialUrl { get; set; }
    }
}
