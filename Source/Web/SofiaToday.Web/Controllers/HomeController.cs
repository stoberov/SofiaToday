namespace SofiaToday.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;

    using Services.Data;
    using ViewModels.Events;
    using ViewModels.Home;

    public class HomeController : BaseController
    {
        private readonly IEventsService events;

        public HomeController(IEventsService events)
        {
            this.events = events;
        }

        [HttpGet]
        public ActionResult Index()
        {
            var upcomingEvents = this.events.GetUpcomingEvents().To<EventViewModel>().ToList();
            var featuredEvents = this.events.GetFeaturedEvents().To<EventViewModel>().ToList();

            var viewModel = new IndexViewModel
            {
                FeaturedEvents = featuredEvents,
                UpcomingEvents = upcomingEvents
            };

            return this.View(viewModel);
        }
    }
}
