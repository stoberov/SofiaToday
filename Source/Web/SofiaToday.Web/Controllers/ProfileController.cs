namespace SofiaToday.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using SofiaToday.Services.Data;
    using ViewModels.Events;

    public class ProfileController : BaseController
    {
        private readonly IEventsService events;

        public ProfileController(IEventsService events)
        {
            this.events = events;
        }

        public ActionResult Index()
        {
            return this.View();
        }

        [HttpGet]
        public ActionResult Calendar()
        {
            var myEvents = this.events.GetEventsByCreatorId(this.User.Identity.GetUserId()).To<EventViewModel>().ToList();

            return this.View(myEvents);
        }
    }
}
