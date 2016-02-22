namespace SofiaToday.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Comment : BaseModel<int>
    {
        [Required]
        public string Author { get; set; }

        public string Email { get; set; }

        [Required]
        public string Content { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
