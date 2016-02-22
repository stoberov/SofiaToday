namespace SofiaToday.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [Required]
        public string Content { get; set; }

        public string ImageUrl { get; set; }

        [UIHint("Author")]
        public string Author { get; set; }

        public DateTime CreatedOn { get; set; }

        public ICollection<Comment> Comments { get; set; }

        public void CreateMappings(IMapperConfiguration configuration)
        {
            configuration.CreateMap<Article, ArticleViewModel>()
                .ForMember(x => x.Author, opt => opt.MapFrom(x => x.Author.Email));
        }
    }
}
