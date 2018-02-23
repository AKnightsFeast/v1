using System.Web;
using System.Web.Optimization;

namespace web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery/jquery-{version}.js",
                "~/Scripts/jquery/jquery.browser.js",
                "~/Scripts/jquery/jquery.unobtrusive*"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/jquery/jquery-ui-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery/jquery.validate.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/inputmask").Include(
                "~/Scripts/jquery/jquery.inputmask/jquery.inputmask-{version}.js",
                "~/Scripts/jquery/jquery.inputmask/jquery.inputmask.extensions-{version}.js",
                "~/Scripts/jquery/jquery.inputmask/jquery.inputmask.date.extensions-{version}.js",
                "~/Scripts/jquery/jquery.inputmask/jquery.inputmask.regex.extensions-{version}.js",
                "~/Scripts/jquery/jquery.inputmask/jquery.inputmask.numeric.extensions-{version}.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/jquery/effects").Include(
                "~/Scripts/jquery/jquery.backstretch.js",
                "~/Scripts/jquery/jquery.animate-enhanced.js"
            ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
            ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/styles/main.css",
                "~/Content/styles/navbar.css",
                "~/Content/styles/font-awesome.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Home/css").Include(
                "~/Content/styles/home.css",
                "~/Content/styles/gh-fork-ribbon.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Assessment/css").Include(
                "~/Content/styles/assessment.css"
            ));

            bundles.Add(new StyleBundle("~/Content/AssessmentReview/css").Include(
                "~/Content/styles/assessmentreview.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Policies/css").Include(
                "~/Content/styles/policies.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Menus/css").Include(
                "~/Content/styles/menus.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Testimonials/css").Include(
                "~/Content/styles/testimonials.css"
            ));

            bundles.Add(new StyleBundle("~/Content/Friends/css").Include(
                "~/Content/styles/friends.css"
            ));

            bundles.Add(new StyleBundle("~/Content/About/css").Include(
                "~/Content/styles/about.css"
            ));

            bundles.Add(new StyleBundle("~/Content/themes/base/css").Include(
                "~/Content/themes/base/jquery.ui.core.css",
                "~/Content/themes/base/jquery.ui.resizable.css",
                "~/Content/themes/base/jquery.ui.selectable.css",
                "~/Content/themes/base/jquery.ui.accordion.css",
                "~/Content/themes/base/jquery.ui.autocomplete.css",
                "~/Content/themes/base/jquery.ui.button.css",
                "~/Content/themes/base/jquery.ui.dialog.css",
                "~/Content/themes/base/jquery.ui.slider.css",
                "~/Content/themes/base/jquery.ui.tabs.css",
                "~/Content/themes/base/jquery.ui.datepicker.css",
                "~/Content/themes/base/jquery.ui.progressbar.css",
                "~/Content/themes/base/jquery.ui.theme.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap/bootstrap.js",
                "~/Scripts/bootstrap/bootstrap-modal.js",
                "~/Scripts/bootstrap/bootstrap-modalmanager.js",
                "~/Scripts/bootstrap/bootstrap-hover-dropdown.js"
            ));

            bundles.Add(new StyleBundle("~/Content/bootstrap").Include(
                "~/Content/styles/bootstrap/bootstrap.css",
                "~/Content/styles/bootstrap/bootstrap.non-responsive.css",
                "~/Content/styles/bootstrap/bootstrap-modal-bs3patch.css",
                "~/Content/styles/bootstrap/bootstrap-modal.css"
            ));

            bundles.Add(new ScriptBundle("~/bundles/site").Include(
                "~/Scripts/site.js"
            ));

            bundles.Add(new ScriptBundle("~/bundles/assessment").Include(
                "~/Scripts/assessment.js"
            ));
        }
    }
}