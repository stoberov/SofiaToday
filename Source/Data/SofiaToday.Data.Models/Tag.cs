namespace SofiaToday.Data.Models
{
    using SofiaToday.Data.Common.Models;

    public class Tag : BaseModel<int>
    {
        public string Name { get; set; }

        public int EventId { get; set; }

        public virtual Event Event { get; set; }
    }
}
