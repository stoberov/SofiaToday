namespace SofiaToday.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using Data.Models;
    using Infrastructure.Mapping;
    using Microsoft.AspNet.Identity;
    using SofiaToday.Services.Data;
    using ViewModels.Events;

    public class EventsController : BaseController
    {
        private const int ItemsPerPage = 6;

        private readonly IEventsService events;

        public EventsController(IEventsService events)
        {
            this.events = events;
        }

        [HttpGet]
        public ActionResult Index(int page = 1)
        {
            var currentPage = page;
            var allItemsCount = this.events.GetAll().Count();
            var totalPages = (int)Math.Ceiling(allItemsCount / (decimal)ItemsPerPage);
            var itemsToSkip = (currentPage - 1) * ItemsPerPage;

            var events = this.events
                .GetUpcomingEvents()
                .OrderBy(x => x.CreatedOn)
                .ThenBy(x => x.Id)
                .Skip(itemsToSkip)
                .Take(ItemsPerPage)
                .To<EventViewModel>()
                .ToList();

            var viewModel = new AllEventsViewModel
            {
                AllEvents = events,
                CurrentPage = currentPage,
                TotalPages = totalPages
            };

            return this.View(viewModel);
        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var singleEvent = this.events.GetEventById(id);
            var relatedEvents = this.events.GetRandomEvents(2);

            var viewModel = new DetailsViewModel
            {
                Event = this.Mapper.Map<EventViewModel>(singleEvent),
                RelatedEvents = relatedEvents.To<EventViewModel>().ToList()
            };

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
                ImageUrl = model.ImageUrl,
                OfficialUrl = model.OfficialUrl,
                Category = model.Category
            };

            this.events.AddNewEvent(newEvent);

            this.TempData["Notification"] = "Event added successfully!";

            return this.Redirect("/");
        }

        public ActionResult All()
        {

            return this.View();
        }
    }
}
