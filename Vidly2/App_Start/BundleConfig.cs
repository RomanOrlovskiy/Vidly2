using System.Web;
using System.Web.Optimization;

namespace Vidly2
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            #region Enabling Client-side validation
            //All files that match the pattern "~/Scripts/jquery.validate*"
            //will be combined and compressed and they will be available
            //at the adress "~/bundles/jqueryval". This adress is used in
            //"section scripts" to anable client-side validation in CustomerForm view.
            //Client-side validations only works with standart data annotations like
            //required, stringlength, range, etc. Attribute like Min18YearsIfAMember
            //will require additional jQuery code to be able to catch it client-side.
            //But in this case, if there would be a need to change something in the logic
            //then you would need to change the server-side AND client-side code.
            //Thats why it is better to validate bussiness logic purely on the server
            //while client-side validation takes care of some simple stuff.
            #endregion
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/bootbox.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap-lumen.css",
                      "~/Content/site.css"));
        }
    }
}
