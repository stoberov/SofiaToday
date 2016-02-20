namespace SofiaToday.Web.Controllers
{
    using System.Web.Mvc;

    public class InformationController : BaseController
    {
        public ActionResult About()
        {
            return this.View();
        }

        public ActionResult Contact()
        {
            return this.View();
        }
    }
}
