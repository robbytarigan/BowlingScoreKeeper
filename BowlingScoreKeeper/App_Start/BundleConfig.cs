﻿using System.Diagnostics.Contracts;
using System.Web;
using System.Web.Optimization;

namespace BowlingScoreKeeper
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            Contract.Requires(bundles != null);

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include("~/Scripts/jquery-2.1.3.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/bowlingApp").Include(
                "~/Scripts/angular.js",
                "~/Scripts/angular-route.js", 
                "~/Scripts/app/bowlingApp.module.js",
                "~/Scripts/app/bowlingApp.config.js", 
                "~/Scripts/app/bowlingApp.controller.js",
                "~/Scripts/app/bowlingApp.filter.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}
