﻿namespace SofiaToday.Web.ViewModels.Articles
{
    using System;
    using System.Collections.Generic;
    using AutoMapper;
    using Data.Models;
    using Infrastructure.Mapping;

    public class ArticleViewModel : IMapFrom<Article>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

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