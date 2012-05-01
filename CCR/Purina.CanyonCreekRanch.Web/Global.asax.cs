using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

using Purina.CanyonCreekRanch.Common.Helpers;

namespace Purina.CanyonCreekRanch.Web
{
  // Note: For instructions on enabling IIS6 or IIS7 classic mode, 
  // visit http://go.microsoft.com/?LinkId=9394801

  public class MvcApplication : System.Web.HttpApplication
  {
    public static void RegisterGlobalFilters(GlobalFilterCollection filters)
    {
      filters.Add(new HandleErrorAttribute());
    }

    public static void RegisterRoutes(RouteCollection routes)
    {
      routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

      routes.MapRouteLowercase(
          "CategoryType", // Route name
          "type/{type}", // URL with parameters
          new { controller = "Category", action = "Type" }
      );

      routes.MapRouteLowercase(
          "CategoryInfo", // Route name
          "info/{type}", // URL with parameters
          new { controller = "Category", action = "Info" }
      );

      routes.MapRouteLowercase(
          "CategoryHome", // Route name
          "category/{url}", // URL with parameters
          new { controller = "Category", action = "Category" }
      );

      routes.MapRouteLowercase(
          "ProductDetail", // Route name
          "product/{url}", // URL with parameters
          new { controller = "Product", action = "Detail" }
      );


      routes.MapRouteLowercase(
          "HomeAction", // Route name
          "{action}", // URL with parameters
          new { controller = "Home", action = "Index" } // Parameter defaults
      );

      routes.MapRouteLowercase(
          "Default", // Route name
          "{controller}/{action}/{id}", // URL with parameters
          new { controller = "Home", action = "Index", id = UrlParameter.Optional } // Parameter defaults
      );
    }

    protected void Application_Start()
    {
      AreaRegistration.RegisterAllAreas();

      RegisterGlobalFilters(GlobalFilters.Filters);
      RegisterRoutes(RouteTable.Routes);
    }
  }
}