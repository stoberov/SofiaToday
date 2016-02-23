namespace SofiaToday.Data.Models
{
    using System.ComponentModel.DataAnnotations;
    using Common.Models;

    public class Message : BaseModel<int>
    {
        [Required]
        [StringLength(20)]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string MessageText { get; set; }
    }
}
