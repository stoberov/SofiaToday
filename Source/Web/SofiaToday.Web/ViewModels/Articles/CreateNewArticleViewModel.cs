namespace SofiaToday.Web.ViewModels.Articles
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateNewArticleViewModel : IMapFrom<Article>
    {
        [Required]
        public string Title { get; set; }

        [Required]
        public string Summary { get; set; }

        [AllowHtml]
        [UIHint("Content")]
        public string Content { get; set; }

        public string ImageUrl { get; set; }
    }
}
