﻿namespace SofiaToday.Web
{
    using System.Web.Optimization;

    public static class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterScripts(bundles);
            RegisterStyles(bundles);
        }

        private static void RegisterScripts(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-{version}.js"));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include("~/Scripts/jquery.validate*"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include("~/Scripts/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/material").Include("~/Scripts/MaterialDesign/material.min.js", "~/Scripts/MaterialDesign/ripples.min.js"));
            bundles.Add(new ScriptBundle("~/bundles/kendo").Include("~/Scripts/KendoUI/kendo.all.min.js", "~/Scripts/KendoUI/kendo.aspnetmvc.min.js"));
        }

        private static void RegisterStyles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/bootstrap.min.css", "~/Content/site.css"));
            bundles.Add(new StyleBundle("~/Content/material").Include("~/Content/MaterialDesign/bootstrap-material-design.css", "~/Content/MaterialDesign/ripples.css"));
            bundles.Add(new StyleBundle("~/Content/kendo").Include("~/Content/KendoUI/kendo.common-material.min.css", "~/Content/KendoUI/kendo.material.min.css"));
        }
    }
}
