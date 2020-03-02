using System.Web;
using System.Web.Optimization;

namespace EpreuveIzabela
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/assets/bootstrap/css/bootstrap.css",
                      "~/assets/style.css"));
            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                    "~/assets/bootstrap/js/bootstrap.js"));
            bundles.Add(new ScriptBundle("~/bundles/script").Include(
                     "~/assets/script.js"));
            bundles.Add(new StyleBundle("~/Content/carousel").Include(
                  "~/assets/owl-carousel/owl.carousel.css",
                  "~/assets/owl-carousel/owl.theme.css"));
            bundles.Add(new ScriptBundle("~/bundles/carousel").Include(
                    "~/assets/owl-carousel/owl.carousel.js"));
            bundles.Add(new StyleBundle("~/Content/slitslider").Include(
                    "~/assets/slitslider/css/style.css",
                    "~/assets/slitslider/css/custom.css"));
            bundles.Add(new ScriptBundle("~/bundles/slitslider").Include(
                    "~/assets/slitslider/js/modernizr.custom.79639.js",
                    "~/assets/slitslider/js/jquery.ba-cond.min.js",
                    "~/assets/slitslider/js/jquery.slitslider.js"));

        }
    }
}
