using System.Web;
using System.Web.Optimization;

namespace QuizForam
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/Default_Js/jquery-2.1.1.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                "~/Scripts/Default_Js/jquery-ui-1.10.3.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/Default_Js/jquery.unobtrusive*",
                "~/Scripts/Default_Js/jquery.validate*"
                ));
            bundles.Add(new ScriptBundle("~/bundles/QuizForam").Include(
                "~/Scripts/Default_Js/jquery.json-2.4.min.js",
                "~/Scripts/Comman_Js/jQuery.multiselect.min.js",
                "~/Scripts/Comman_Js/jQuery.print.js",
                "~/Scripts/Default_Js/jquery.validationEngine-en.js",
                "~/Scripts/Default_Js/jquery.validationEngine.js",
                "~/Scripts/Comman_Js/mindzFunction.js",
                "~/Scripts/Comman_Js/popup_content.js",
                "~/Scripts/Comman_Js/tabcontent.js",
                "~/Scripts/Comman_Js/ui.dropdownchecklist-1.4-min.js",
                "~/Scripts/Comman_Js/shortcutKeys.js",
                "~/Scripts/Comman_Js/CommanJs.js"
                ));
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"
                ));
            bundles.Add(new ScriptBundle("~/bundles/custom").Include(
                "~/scripts/autocompletescript.js"
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
            bundles.Add(new ScriptBundle("~/bundles/bootstrapjs").Include(
                "~/Scripts/Common_Js/bootstrap.js"
                ));
            bundles.Add(new StyleBundle("~/Content/bootstrapcss").Include(
                "~/Content/common/bootstrap.css",
                "~/Content/font-awesome.css"
                ));
            bundles.Add(new ScriptBundle("~/bundles/ImageResize").Include(
                "~/Scripts/ImageResize/modernizr.custom.js",
                "~/Scripts/ImageResize/boxgrid.js",
                "~/Scripts/ImageResize/jquery.fittext.js"
                ));
        }
    }
}
