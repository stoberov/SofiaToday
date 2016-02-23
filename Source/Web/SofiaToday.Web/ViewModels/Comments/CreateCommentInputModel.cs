namespace SofiaToday.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CreateCommentInputModel : IMapFrom<Comment>
    {
        public int ArticleId { get; set; }

        [Required]
        public string Author { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
