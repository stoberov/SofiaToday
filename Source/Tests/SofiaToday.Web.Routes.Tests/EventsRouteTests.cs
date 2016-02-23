namespace SofiaToday.Web.Routes.Tests
{
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using SofiaToday.Web.Controllers;

    [TestFixture]
    public class EventsRouteTests
    {
        [Test]
        public void EventsRouteDetails()
        {
            const string Url = "/Events/Details/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventsController>(c => c.Details(1));
        }
    }
}
