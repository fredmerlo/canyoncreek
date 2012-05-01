using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace Purina.CanyonCreekRanch.Common.Helpers
{
  public class TransferResult : RedirectResult
  {
    public TransferResult(string url) : base(url) { }

    public TransferResult(object routeValues)
      : base(GetRouteURL(routeValues)) { }

    private static string GetRouteURL(object routeValues)
    {
        UrlHelper url = new UrlHelper(new RequestContext(new HttpContextWrapper(HttpContext.Current), new RouteData()), RouteTable.Routes);
        return url.RouteUrl(routeValues);
    }

    public override void ExecuteResult(ControllerContext context)
    {
      if (context == null)
        throw new ArgumentNullException("context");

      if (context.Controller.TempData != null && context.Controller.TempData.Count > 0)
        throw new ApplicationException("TempData won't work with Server.TransferRequest!");

      if (HttpRuntime.UsingIntegratedPipeline)
      {
        HttpContext.Current.Server.TransferRequest(Url, true);
      }
      else
      {
        HttpContext.Current.RewritePath(Url, false);
        IHttpHandler httpHandler = new MvcHttpHandler();

        httpHandler.ProcessRequest(HttpContext.Current);
      }

    }
  }
}
