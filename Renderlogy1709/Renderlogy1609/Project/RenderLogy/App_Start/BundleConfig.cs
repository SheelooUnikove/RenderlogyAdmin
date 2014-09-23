using System;
using System.Web;
using System.Web.Optimization;

namespace RenderLogy
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725

        public static void AddDefaultIgnorePatterns(IgnoreList ignoreList)
        {
            if (ignoreList == null)
                throw new ArgumentNullException("ignoreList");
            ignoreList.Ignore("*.intellisense.js");
            ignoreList.Ignore("*-vsdoc.js");
            ignoreList.Ignore("*.debug.js", OptimizationMode.WhenEnabled);
            ignoreList.Ignore("*.min.js", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.min.css", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.datetimepicker.css", OptimizationMode.WhenDisabled);
            ignoreList.Ignore("*.-bootstrap.css", OptimizationMode.WhenDisabled);

        }
        public static void RegisterBundles(BundleCollection bundles)
        {

          

            bundles.Add(new StyleBundle("~/assets/css").Include(
                   "~/assets/css/icons/iconsmin.css", 
"~/assets/css/bootstrapmin.css",
"~/assets/css/pluginsmin.css", 
"~/assets/css/stylemin.css", 
"~/assets/css/select2bootstrap.css", 
"~/assets/css/custom.css" 
                    ));


 
 
              
            bundles.Add(new ScriptBundle("~/jquery").Include(
 "~/assets/plugins/jquery111.js",
 "~/assets/plugins/jquerymigrate121.js",
 "~/assets/plugins/jqueryui/jqueryui1104min.js",
 "~/assets/plugins/jquerymobile/jquerymobile142.js",
 "~/assets/plugins/bootstrap/bootstrapmin.js",
 "~/assets/plugins/bootstrapdropdown/bootstraphoverdropdown.js",
 "~/assets/plugins/bootstrapselect/bootstrapselect.js",
 "~/assets/plugins/mcustomscrollbar/jquerymCustomScrollbarconcatmin.js",
 "~/assets/plugins/mmenu/js/jquerymmenuminall.js",
 "~/assets/plugins/nprogress/nprogress.js",
 "~/assets/plugins/chartssparkline/sparklinemin.js",
 "~/assets/plugins/breakpoints/breakpoints.js",
 "~/assets/plugins/numerator/jquerynumerator.js",
 "~/assets/js/mailbox.js",
 "~/assets/plugins/jquerycookiemin.js"
            
                        ));  

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.unobtrusive*",
            //            "~/Scripts/jquery.validate*"));

            //// Use the development version of Modernizr to develop with and learn from. Then, when you're
            //// ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

           // bundles.Add(new StyleBundle("~/Content/css").Include("~/Content/site.css"));

        
 
        }
    }
}