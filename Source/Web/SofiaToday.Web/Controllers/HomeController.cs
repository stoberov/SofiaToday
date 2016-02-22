namespace SofiaToday.Web.Controllers
{
    using System;
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

            var dailyEvents = this.events.GetDailyEvents(DateTime.UtcNow);
            var morningEvents = dailyEvents.Where(x => x.StartDateTime.Hour <= 12).To<EventViewModel>().ToList();
            var afternoonEvents = dailyEvents.Where(x => x.StartDateTime.Hour > 12 && x.StartDateTime.Hour < 20).To<EventViewModel>().ToList();
            var eveningEvents = dailyEvents.Where(x => x.StartDateTime.Hour > 20).To<EventViewModel>().ToList();


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
