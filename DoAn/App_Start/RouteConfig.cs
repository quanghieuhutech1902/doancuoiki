using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace DoAn
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            routes.MapRoute(
                name: "ChiTietSanPham",
                url: "san-pham/{metatitle}-{id}",
                defaults: new { controller = "Products", action = "Xemchitiet", id = UrlParameter.Optional }
            );
            routes.MapRoute(
                name: "SanPhamtheoDanhMuc",
                url: "danh-muc-san-pham/{metatitle}-{id}",
                defaults: new { controller = "Products", action = "GetProductByDMSP_ID", id = UrlParameter.Optional }
            );

            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
