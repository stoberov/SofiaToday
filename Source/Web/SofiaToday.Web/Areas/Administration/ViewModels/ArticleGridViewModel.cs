namespace SofiaToday.Web.Areas.Administration.ViewModels
{
    using System;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ArticleGridViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Summary { get; set; }

        public string Content { get; set; }

        public DateTime CreatedOn { get; set; }

        public string Author { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleGridViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.Email));
        }
    }
}
