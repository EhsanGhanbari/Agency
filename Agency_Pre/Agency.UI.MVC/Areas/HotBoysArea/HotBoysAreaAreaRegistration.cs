using System.Web.Mvc;

namespace Agency.UI.MVC.Areas.HotBoysArea
{
    public class HotBoysAreaAreaRegistration : AreaRegistration
    {
        public override string AreaName
        {
            get
            {
                return "HotBoysArea";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context)
        {
            context.MapRoute(
                "HotBoysArea_default",
                "HotBoysArea/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional },
                new[] { "Agency.UI.MVC.Areas.HotBoysArea.Controllers" }
            );
        }
    }
}
