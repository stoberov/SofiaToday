namespace SofiaToday.Web.ViewModels.Messages
{
    using System.ComponentModel.DataAnnotations;
    using System.Web.Mvc;
    using SofiaToday.Data.Models;
    using SofiaToday.Web.Infrastructure.Mapping;

    public class CreateMessageInputModel : IMapTo<Message>
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [AllowHtml]
        public string MessageText { get; set; }
    }
}
