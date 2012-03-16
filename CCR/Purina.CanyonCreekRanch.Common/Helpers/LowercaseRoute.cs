using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Routing;

namespace Purina.CanyonCreekRanch.Common.Helpers
{
  public class LowercaseRoute : Route
  {
    public const string URL_REGEX = @"[A-Z]";
    public const string RESPONSE_MOVED = "301 Moved Permanently";
    public const string HEADER_LOCATION = "Location";

    public LowercaseRoute(string url, IRouteHandler routeHandler)
      : base(url, routeHandler) { }

    public LowercaseRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
      : base(url, defaults, routeHandler) { }

    public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
      : base(url, defaults, constraints, routeHandler) { }

    public LowercaseRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
      : base(url, defaults, constraints, dataTokens, routeHandler) { }

    public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
    {
      VirtualPathData path = base.GetVirtualPath(requestContext, values);

      if (path != null)
        path.VirtualPath = path.VirtualPath.ToLowerInvariant();

      return path;
    }

    public static void CheckRedirect301(HttpRequest request, HttpResponse response)
    {
      string movedURL = "";
      StringBuilder lowercaseURL = new StringBuilder();
      lowercaseURL.Append(request.Url.Scheme);
      lowercaseURL.Append("://");
      lowercaseURL.Append(request.Url.Authority);
      lowercaseURL.Append(request.Url.AbsolutePath);

      movedURL = lowercaseURL.ToString();
      if (Regex.IsMatch(movedURL, URL_REGEX))
      {
        lowercaseURL.Append(request.Url.Query);
        movedURL = lowercaseURL.ToString();

        response.Clear();
        response.Status = RESPONSE_MOVED;
        response.AddHeader(HEADER_LOCATION, movedURL);
        response.End();
      }
    }
  }
}
