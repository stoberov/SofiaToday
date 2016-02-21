namespace SofiaToday.Data.Models
{
    using System.Collections.Generic;
    using Common.Models;

    public class Article : BaseModel<int>
    {
        public Article()
        {
            this.Comments = new HashSet<Comment>();
        }

        public string Title { get; set; }

        public string Content { get; set; }

        public string ImageUrl { get; set; }

        public string AuthorId { get; set; }

        public virtual ApplicationUser Author { get; set; }

        public ICollection<Comment> Comments { get; set; }
    }
}
