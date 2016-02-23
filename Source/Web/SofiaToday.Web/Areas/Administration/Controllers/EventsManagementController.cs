namespace SofiaToday.Web.Areas.Administration.Controllers
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using Data;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using SofiaToday.Data.Models;
    using ViewModels;
    public class EventsManagementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Events_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Event> events = db.Events;
            DataSourceResult result = events.ToDataSourceResult(request, c => new EventViewModel 
            {
                Id = c.Id,
                Title = c.Title,
                StartDateTime = c.StartDateTime,
                EndDateTime = c.EndDateTime,
                Location = c.Location,
                Category = c.Category,
                Price = c.Price,
                IsFeatured = c.IsFeatured
            });

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Create([DataSourceRequest]DataSourceRequest request, EventInputModel newEvent)
        {
            if (ModelState.IsValid)
            {
                var entity = new Event
                {
                    Title = newEvent.Title,
                    Location = newEvent.Location,
                    Category = newEvent.Category,
                    Price = newEvent.Price,
                    IsFeatured = newEvent.IsFeatured
                };

                db.Events.Add(entity);
                db.SaveChanges();
                newEvent.Id = entity.Id;
            }

            return Json(new[] { newEvent }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Update([DataSourceRequest]DataSourceRequest request, EventViewModel updatedEvent)
        {
            if (ModelState.IsValid)
            {
                var entity = new Event
                {
                    Id = updatedEvent.Id,
                    Title = updatedEvent.Title,
                    StartDateTime = updatedEvent.StartDateTime,
                    EndDateTime = updatedEvent.EndDateTime,
                    Location = updatedEvent.Location,
                    Category = updatedEvent.Category,
                    Price = updatedEvent.Price,
                    IsFeatured = updatedEvent.IsFeatured
                };

                db.Events.Attach(entity);
                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
            }

            return Json(new[] { updatedEvent }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Destroy([DataSourceRequest]DataSourceRequest request, EventViewModel deletedEvent)
        {
            if (ModelState.IsValid)
            {
                var entity = new Event
                {
                    Id = deletedEvent.Id,
                    Title = deletedEvent.Title,
                    StartDateTime = deletedEvent.StartDateTime,
                    EndDateTime = deletedEvent.EndDateTime,
                    Location = deletedEvent.Location,
                    Category = deletedEvent.Category,
                    Price = deletedEvent.Price,
                    IsFeatured = deletedEvent.IsFeatured
                };

                db.Events.Attach(entity);
                db.Events.Remove(entity);
                db.SaveChanges();
            }

            return Json(new[] { deletedEvent }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}