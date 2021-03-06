﻿namespace SofiaToday.Web.Routes.Tests
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using SofiaToday.Web.Controllers;

    [TestFixture]
    public class EventsRouteTests
    {
        [Test]
        public void EventsDetailsRouteById()
        {
            const string Url = "/Events/Details/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventsController>(c => c.Details(1));
        }

        [Test]
        public void TestRouteByAction()
        {
            const string Url = "/Events/Create";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventsController>(c => c.Create());
        }

        [Test]
        public void TestRouteByActionAndId()
        {
            const string Url = "/Events?page=2";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<EventsController>(c => c.Index(2));
        }
    }
}
