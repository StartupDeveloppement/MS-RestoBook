using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Optimization;

namespace RestoBook
{
    class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/Css").Include(
            "~/Content/Css/bootstrap.min.css",
            "~/Content/Css/Site.css"));

            bundles.Add(new StyleBundle("~/Content/Css/jqueryui").Include(
            "~/Content/themes/base/core.css",
            "~/Content/themes/base/autocomplete.css",
            "~/Content/themes/base/menu.css",
            "~/Content/themes/base/theme.css"));

            bundles.Add(new StyleBundle("~/Content/Css/font-awesome").Include(
            "~/Content/Css/font-awesome.css"));

            bundles.Add(new StyleBundle("~/Content/Css/chosen").Include(
            "~/Content/Css/bootstrap-chosen.css"));

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            "~/Scripts/modernizr-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/chosen").Include(
            "~/Scripts/chosen.jquery.js"));

            bundles.Add(new ScriptBundle("~/bundles/homesearch").Include(
            "~/Scripts/homesearch-autocomplete.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
            "~/Scripts/jquery-ui-{version}.js"));

        }
    }
}
