namespace SofiaToday.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;
    using Data.Common;
    using Data.Models;
    using Infrastructure.Mapping;
    using Kendo.Mvc.Extensions;
    using Kendo.Mvc.UI;
    using Services.Data;
    using SofiaToday.Data;
    using SofiaToday.Web.ViewModels.Events;
    using ViewModels;
    public class MyEventsController : Controller
    {
        IEventsService events;

        public MyEventsController(IEventsService events)
        {
            this.events = events;
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult MyEvents_Read([DataSourceRequest]DataSourceRequest request)
        {
            DataSourceResult result = this.events.GetAll().To<EventViewModel>().ToDataSourceResult(request);

            return Json(result);
        }

        [AcceptVerbs(HttpVerbs.Post)]
        public ActionResult MyEvents_Update([DataSourceRequest]DataSourceRequest request, EventInputModel singleEvent)
        {
            if (ModelState.IsValid)
            {
                var entity = this.events.GetEventById(singleEvent.Id);
                entity.Title = singleEvent.Title;

                this.events.SaveChanges();
            }
            var singleEventToDisplay = this.events.GetAll()
                           .To<EventViewModel>()
                           .FirstOrDefault(x => x.Id == singleEvent.Id);

            return Json(new[] { singleEventToDisplay }.ToDataSourceResult(request, ModelState));
        }
    }
}
