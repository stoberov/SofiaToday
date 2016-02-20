namespace SofiaToday.Web.ViewModels.Events
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class EventViewModel : IMapFrom<Event>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public DateTime StartDateTime { get; set; }

        public DateTime EndDateTime { get; set; }
       
        public string Location { get; set; }

        [DisplayFormat(DataFormatString = "{0:C}")]
        public double Price { get; set; }

        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.ToString()));
        }
    }
}
