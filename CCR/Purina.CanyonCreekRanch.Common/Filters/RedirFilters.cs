using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;

namespace Purina.CanyonCreekRanch.Common.Filters
{
  public class RedirFilters : ActionFilterAttribute
  {
    public override void OnActionExecuting(ActionExecutingContext filterContext)
    {
      //if (filterContext.HttpContext.Request.Browser.IsMobileDevice) {
      //  filterContext.HttpContext.Response.Redirect("http://m.canyoncreekranch.com/");
      //}

      //if (filterContext.HttpContext.Request.Url.Host.Contains("canyoncreektreats.com")) {
      //  filterContext.HttpContext.Response.Redirect("http://canyoncreekranch.com/");
      //}
      base.OnActionExecuting(filterContext);
    }
    public override void OnResultExecuted(ResultExecutedContext filterContext)
    {
      base.OnResultExecuted(filterContext);
    }
  }
}
