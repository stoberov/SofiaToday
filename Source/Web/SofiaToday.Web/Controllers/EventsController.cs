namespace SofiaToday.Web.Controllers
{
    using System.Web.Mvc;
    using Data.Models;
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

        [HttpGet]
        public ActionResult Create()
        {
            return this.View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CreateEventInputViewModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return this.View(model);
            }

            var newEvent = new Event
            {
                Title = model.Title,
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                Location = model.Location,
                Price = model.Price,
                ImageUrl = model.ImageUrl
            };

            this.events.AddNewEvent(newEvent);

            return this.Redirect("/");
        }
    }
}
