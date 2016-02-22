using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SofiaToday.Data.Common;
using SofiaToday.Data.Models;
using SofiaToday.Web.Areas.Administration.ViewModels;
using SofiaToday.Web.Infrastructure.Mapping;
using SofiaToday.Web.ViewModels.Events;

namespace SofiaToday.Web.Areas.Administration.Controllers
{
    public class EventsManagementController : Controller
    {
        private IDbRepository<Event> events;

        public EventsManagementController(IDbRepository<Event> events)
        {
            this.events = events;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.events.All()
                .To<EventInputModel>()
                .ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Create([DataSourceRequest]DataSourceRequest request, EventInputModel model)
        {
            var newId = 0;
            if (ModelState.IsValid)
            {
                var entity = new Event
                {
                    Title = model.Title,
                    Location = model.Location,
                    Category = model.Category,
                    Price = model.Price,
                    IsFeatured = model.IsFeatured
                };

                this.events.Add(entity);
                this.events.Save();
                newId = entity.Id;
            }

            var eventToDisplay = this.events.All()
                .To<EventViewModel>()
                .FirstOrDefault(x => x.Id == newId);

            return Json(new[] { model }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Update([DataSourceRequest]DataSourceRequest request, EventInputModel singleEvent)
        {
            if (ModelState.IsValid)
            {
                var entity = this.events.GetById(singleEvent.Id);
                entity.Title = singleEvent.Title;
                entity.StartDateTime = singleEvent.StartDateTime;
                entity.EndDateTime = singleEvent.EndDateTime;
                entity.Location = singleEvent.Location;
                entity.Price = singleEvent.Price;
                entity.IsFeatured = singleEvent.IsFeatured;

                this.events.Save();
            }

            var eventToDisplay = this.events.All()
                           .To<EventViewModel>()
                           .FirstOrDefault(x => x.Id == singleEvent.Id);

            return Json(new[] { eventToDisplay }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Destroy([DataSourceRequest]DataSourceRequest request, EventInputModel singleEvent)
        {
            if (ModelState.IsValid)
            {
                var entity = this.events.GetById(singleEvent.Id);
                this.events.Delete(entity);
                this.events.Save();

                return Json(new[] { singleEvent }.ToDataSourceResult(request, ModelState));
            }

            return Json(new[] { singleEvent }.ToDataSourceResult(request, ModelState));
        }
    }
}
