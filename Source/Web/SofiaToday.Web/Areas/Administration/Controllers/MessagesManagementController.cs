using System.Linq;
using System.Web.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using SofiaToday.Data;
using SofiaToday.Data.Models;
using SofiaToday.Web.Areas.Administration.ViewModels;

namespace SofiaToday.Web.Areas.Administration.Controllers
{
    public class MessagesManagementController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Messages_Read([DataSourceRequest]DataSourceRequest request)
        {
            IQueryable<Message> messages = db.Messages;
            DataSourceResult result = messages.ToDataSourceResult(request, c => new MessageViewModel
            {
                Name = c.Name,
                Email = c.Email,
                MessageText = c.MessageText
            });

            return Json(result);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}
