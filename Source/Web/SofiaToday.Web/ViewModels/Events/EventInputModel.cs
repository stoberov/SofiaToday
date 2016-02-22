namespace SofiaToday.Web.ViewModels
{
    using System.ComponentModel.DataAnnotations;

    public class EventInputModel
    {
        public int Id { get; set; }

        [Required]
        public string Title { get; set; }
    }
}
