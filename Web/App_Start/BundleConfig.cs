using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/JQuery/jquery-2.*"));
            
            bundles.Add(new ScriptBundle("~/bundles/angularJS").Include(
                "~/Scripts/AngularJS/angular.js",
                "~/Scripts/AngularJS/angular-route.js"));
            
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/Bootstrap/ui-bootstrap.*"));

            bundles.Add(new ScriptBundle("~/bundles/angularApp").IncludeDirectory("~/app/", "*.js", true));
            
            bundles.Add(new StyleBundle("~/Content/css").IncludeDirectory("~/Content/", "*.css", true));
        }
    }
}