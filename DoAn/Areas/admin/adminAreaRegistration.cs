using System.Web.Mvc;

namespace DoAn.Areas.admin
{
    public class adminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "admin";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {

            context.MapRoute(
                "admin-chinh sua tin tuc",
                "admin/{metatitle}-{id}",
                defaults: new { controller = "TINTUCs", action = "Edit", id = UrlParameter.Optional }
            );

            context.MapRoute(
                "admin_default",
                "admin/{controller}/{action}/{id}",
                new { action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}