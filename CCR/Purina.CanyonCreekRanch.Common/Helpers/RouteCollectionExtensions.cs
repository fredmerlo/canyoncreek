using System;
using System.Web.Mvc;
using System.Web.Routing;

namespace Purina.CanyonCreekRanch.Common.Helpers
{
  public static class RouteCollectionExtensions
  {
    public static void MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults)
    {
      routes.MapRouteLowercase(name, url, defaults, null);
    }

    public static void MapRouteLowercase(this RouteCollection routes, string name, string url, object defaults, object constraints)
    {
      if (routes == null)
        throw new ArgumentException("routes");

      if (url == null)
        throw new ArgumentException("url");

      LowercaseRoute route = new LowercaseRoute(url, new MvcRouteHandler())
      {
        Defaults = new RouteValueDictionary(defaults),
        Constraints = new RouteValueDictionary(constraints)
      };

      if (string.IsNullOrEmpty(name))
        routes.Add(route);
      else
        routes.Add(name, route);
    }
  }
}
