namespace SofiaToday.Web.Routes.Tests
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using SofiaToday.Web.Controllers;

    [TestFixture]
    public class MessagesRouteTests
    {
        [Test]
        public void MessagesIndexRoute()
        {
            const string Url = "/Messages/";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<MessagesController>(c => c.Index());
        }
    }
}
