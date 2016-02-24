namespace SofiaToday.Web.Areas.Administration.Controllers
{
    using System.Data.Entity;
    using System.Linq;
    using System.Web.Mvc;
    using Data;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data.Contracts;
    using SofiaToday.Data.Models;
    using ViewModels;

    public class EventsManagementController : Controller
    {
        private readonly IEventsService events;

        public EventsManagementController(IEventsService events)
        {
            this.events = events;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.events.GetAll()
                .To<EventViewModel>()
                .ToDataSourceResult(request);

            return this.Json(result, JsonRequestBehavior.AllowGet);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Update([DataSourceRequest]DataSourceRequest request, EventInputModel updatedEvent)
        {
            if (this.ModelState.IsValid)
            {
                var entity = this.events.GetEventById(updatedEvent.Id);
                entity.Title = updatedEvent.Title;
                entity.Description = updatedEvent.Description;
                entity.Location = updatedEvent.Location;
                entity.Category = updatedEvent.Category;
                entity.Price = updatedEvent.Price;
                entity.IsFeatured = updatedEvent.IsFeatured;
                this.events.SaveChanges();
            }

            var eventToDisplay = this.events.GetAll()
                           .To<EventViewModel>()
                           .FirstOrDefault(x => x.Id == updatedEvent.Id);
            return this.Json(new[] { eventToDisplay }.ToDataSourceResult(request, this.ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Destroy([DataSourceRequest]DataSourceRequest request, Event deletedEvent)
        {
            var articleToDelete = events.GetEventById(deletedEvent.Id);
            this.events.Delete(articleToDelete);

            return this.Json(new[] { deletedEvent }.ToDataSourceResult(request, this.ModelState));
        }
    }
}
