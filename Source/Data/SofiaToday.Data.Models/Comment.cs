namespace SofiaToday.Data.Models
{
    using Common.Models;

    public class Comment : BaseModel<int>
    {
        public string Author { get; set; }

        public string Email { get; set; }

        public string Content { get; set; }

        public int ArticleId { get; set; }

        public virtual Article Article { get; set; }
    }
}
