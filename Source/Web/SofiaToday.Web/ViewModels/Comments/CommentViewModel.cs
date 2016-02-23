namespace SofiaToday.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        private readonly ISanitizer sanitizer;

        public CommentViewModel()
        {
            this.sanitizer = new HtmlSanitizerAdapter();
        }

        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; private set; }

        public string ContentSanitized => this.sanitizer.Sanitize(this.Content);

        public DateTime CreatedOn { get; set; }
    }
}
