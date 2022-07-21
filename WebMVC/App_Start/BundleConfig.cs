using System.Web.Optimization;

namespace WebMVC.App_Start
{
    public class BundleConfig
    {   
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new StyleBundle("~/Content/css").Include(                      
                      "~/CSS/css-core.css",
                      "~/CSS/layout.css",
                      "~/CSS/ajuste-forms.css",
                      "~/CSS/bootstrap-datetimepicker.css",
                      "~/CSS/bootstrap-formhelpers.min.css",
                      "~/CSS/bootstrap-menu.css",
                      "~/CSS/bootstrap.min.css",
                      "~/CSS/css-adicional.css"));
        }
    }
}