using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace AuthStore
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");


            // cấu hình đường dẫn trang index của controller test KO THAM SỐ
            routes.MapRoute(
                 name: "test",
                 url: "dev-test",
                 defaults: new { controller = "Test", action = "Index", id = UrlParameter.Optional }
             );
            routes.MapRoute(
               name: "test_Member",
               url: "dev-test-user",
               defaults: new { controller = "Test", action = "KhachhangIndex", id = UrlParameter.Optional }
           );
            routes.MapRoute(
               name: "test_Product",
               url: "dev-test-item",
               defaults: new { controller = "Test", action = "SPne", id = UrlParameter.Optional }
           );

            //cấu hình đường dẫn trang xem chi tiết của controller sản phẩm
            routes.MapRoute(
            name: "XemChiTiet",
            url: "{tensp}-{id}",
            defaults: new { controller = "SanPham", action = "XemChiTiet", id = UrlParameter.Optional }
        );


            // route default
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional }
            );
        }
    }
}
