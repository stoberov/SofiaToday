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
        public decimal Price { get; set; }

        [DataType(DataType.ImageUrl)]
        public string ImageUrl { get; set; }

        public string Category { get; set; }

        public string Description { get; set; }

        [DataType(DataType.Url)]
        public string OfficialUrl { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Event, EventViewModel>()
                .ForMember(x => x.Category, opt => opt.MapFrom(x => x.Category.ToString()));
        }
    }
}
