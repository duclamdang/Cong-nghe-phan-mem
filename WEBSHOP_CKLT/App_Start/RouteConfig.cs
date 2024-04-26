using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace WEBSHOP_CKLT
{
    public class RouteConfig
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute(
               name: "Contact",
               url: "lien-he",
               defaults: new { controller = "Contact", action = "Index", Alias = UrlParameter.Optional },
               namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
            );
            routes.MapRoute(
             name: "CheckOut",
             url: "thanh-toan",
             defaults: new { controller = "ShoppingCart", action = "CheckOut", Alias = UrlParameter.Optional },
             namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
          );
            routes.MapRoute(
             name: "ShoppingCart",
             url: "Gio-hang",
             defaults: new { controller = "ShoppingCart", action = "Index", Alias = UrlParameter.Optional },
             namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
          );

            routes.MapRoute(
             name: "CategoryProduct",
             url: "danh-muc-san-pham/{alias}-{id}",
             defaults: new { controller = "Products", action = "ProductCategory", Alias = UrlParameter.Optional },
             namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
          );
            
            routes.MapRoute(
             name: "detailProduct",
             url: "chi-tiet/{alias}-p{id}",
             defaults: new { controller = "Products", action = "Detail", Alias = UrlParameter.Optional },
             namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
          );

            routes.MapRoute(
              name: "Sale",
              url: "khuyen-mai",
              defaults: new { controller = "Products", action = "Index", Alias = UrlParameter.Optional },
              namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
           );
            routes.MapRoute(
           name: "Product",
           url: "san-pham",
           defaults: new { controller = "Products", action = "Index", Alias = UrlParameter.Optional },
           namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
        );
            routes.MapRoute(
           name: "GioiThieu",
           url: "gioi-thieu",
           defaults: new { controller = "GioiThieu", action = "Index", Alias = UrlParameter.Optional },
           namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
        );
            routes.MapRoute(
           name: "News",
           url: "tin-tuc",
           defaults: new { controller = "News", action = "Index", Alias = UrlParameter.Optional },
           namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
        );
            routes.MapRoute(
          name: "DetailNew",
          url: "{alias}-n{id}",
          defaults: new { controller = "News", action = "Detail", Alias = UrlParameter.Optional },
          namespaces: new[] { "WEBSHOP_CKLT.Controllers" }
       );
            routes.MapRoute(
                name: "Default",
                url: "{controller}/{action}/{id}",
                defaults: new { controller = "Home", action = "Index", id = UrlParameter.Optional },
                namespaces : new[] { "WEBSHOP_CKLT.Controllers" }
               
            );
        }
    }
}
