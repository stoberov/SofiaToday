namespace SofiaToday.Web.Controllers
{
    using System.Web.Mvc;

    using SofiaToday.Services.Data;
    using ViewModels.Events;

    public class EventsController : BaseController
    {
        private readonly IEventsService events;

        public EventsController(IEventsService events)
        {
            this.events = events;
        }

        public ActionResult ById(int id)
        {
            var singleEvent = this.events.GetEventById(id);
            var viewModel = this.Mapper.Map<EventViewModel>(singleEvent);

            return this.View(viewModel);
        }
    }
}
