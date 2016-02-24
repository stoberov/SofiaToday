namespace SofiaToday.Web.Routes.Tests
{
    using System.Web.Mvc;
    using System.Web.Routing;
    using MvcRouteTester;
    using NUnit.Framework;
    using SofiaToday.Web.Controllers;

    [TestFixture]
    public class ArticleRouteTests
    {
        [Test]
        public void ArticleDetailsRouteById()
        {
            const string Url = "/Articles/Details/1";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ArticlesController>(c => c.Details(1));
        }

        [Test]
        public void TestRouteByAction()
        {
            const string Url = "/Articles/Create";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ArticlesController>(c => c.Create());
        }

        [Test]
        public void TestRouteByActionAndId()
        {
            const string Url = "/Articles?page=2";
            var routeCollection = new RouteCollection();
            RouteConfig.RegisterRoutes(routeCollection);
            routeCollection.ShouldMap(Url).To<ArticlesController>(c => c.Index(2));
        }
    }
}
