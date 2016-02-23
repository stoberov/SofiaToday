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

            return this.Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Update([DataSourceRequest]DataSourceRequest request, EventViewModel updatedEvent)
        {
            if (this.ModelState.IsValid)
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

                this.db.Events.Attach(entity);
                this.db.Entry(entity).State = EntityState.Modified;
                this.db.SaveChanges();
            }

            return this.Json(new[] { updatedEvent }.ToDataSourceResult(request, ModelState));
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult Events_Destroy([DataSourceRequest]DataSourceRequest request, EventViewModel deletedEvent)
        {
            if (this.ModelState.IsValid)
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

                this.db.Events.Attach(entity);
                this.db.Events.Remove(entity);
                this.db.SaveChanges();
            }

            return Json(new[] { deletedEvent }.ToDataSourceResult(request, ModelState));
        }

        protected override void Dispose(bool disposing)
        {
            this.db.Dispose();
            base.Dispose(disposing);
        }
    }
}