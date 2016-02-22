namespace SofiaToday.Web.ViewModels.Comments
{
    using System;
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentViewModel : IMapFrom<Comment>
    {
        [Required]
        public string Author { get; set; }

        [Required]
        public string Content { get; private set; }

        public DateTime CreatedOn { get; set; }
    }
}
