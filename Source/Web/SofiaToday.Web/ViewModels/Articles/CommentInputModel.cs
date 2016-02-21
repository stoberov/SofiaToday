namespace SofiaToday.Web.ViewModels.Comments
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class CommentInputModel : IMapFrom<Comment>
    {
        public int ArticleId { get; set; }

        public string Author { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
