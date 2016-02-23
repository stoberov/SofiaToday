namespace SofiaToday.Web.Areas.Administration.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using Data.Models;
    using Infrastructure.Mapping;

    public class MessageViewModel : IMapFrom<Message>
    {
        public string Name { get; set; }

        public string Email { get; set; }

        [Display(Name = "Message Text")]
        public string MessageText { get; set; }
    }
}
