namespace SofiaToday.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;

    using Infrastructure.Mapping;
    using Services.Data.Contracts;
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
            var upcomingEvents =
                this.Cache.Get(
                    "upcomingEvents",
                    () => this.events.GetUpcomingEvents().To<EventViewModel>().ToList(),
                    30 * 60);

            var featuredEvents =
                this.Cache.Get(
                    "featuredEvents",
                    () => this.events.GetFeaturedEvents().To<EventViewModel>().ToList(),
                    30 * 60);

            var morningEvents =
                this.Cache.Get(
                    "morningEvents",
                    () => this.events.GetDailyEvents(DateTime.UtcNow).Where(x => x.StartDateTime.Hour <= 12).To<EventViewModel>().ToList(),
                    30 * 60);

            var afternoonEvents =
                this.Cache.Get(
                    "afternoonEvents",
                    () => this.events.GetDailyEvents(DateTime.UtcNow).Where(x => x.StartDateTime.Hour > 12 && x.StartDateTime.Hour < 20).To<EventViewModel>().ToList(),
                    30 * 60);

            var eveningEvents =
                this.Cache.Get(
                    "eveningEvents",
                    () => this.events.GetDailyEvents(DateTime.UtcNow).Where(x => x.StartDateTime.Hour > 20).To<EventViewModel>().ToList(),
                    30 * 60);

            var viewModel = new IndexViewModel
            {
                FeaturedEvents = featuredEvents,
                UpcomingEvents = upcomingEvents,
                DailyMorningEvents = morningEvents,
                DailyAfternoonEvents = afternoonEvents,
                DailyEveningEvents = eveningEvents
            };

            return this.View(viewModel);
        }
    }
}
