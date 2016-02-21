namespace SofiaToday.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using SofiaToday.Services.Data;
    using ViewModels.Events;

    public class EventsController : BaseController
    {
        private readonly IEventsService events;

        public EventsController(IEventsService events)
        {
            this.events = events;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var upcomingEvents = this.events.GetUpcomingEvents().To<EventViewModel>().ToList();

            return this.View(upcomingEvents);
        }

        [HttpGet]
        public ActionResult Details(int id)
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
                CreatorId = this.User.Identity.GetUserId(),
                Title = model.Title,
                StartDateTime = model.StartDateTime,
                EndDateTime = model.EndDateTime,
                Location = model.Location,
                Description = model.Description,
                Price = model.Price,
                ImageUrl = model.ImageUrl
            };

            this.events.AddNewEvent(newEvent);

            this.TempData["Notification"] = "Event added successfully!";

            return this.Redirect("/");
        }
    }
}
