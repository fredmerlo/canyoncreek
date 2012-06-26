using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace Purina.CanyonCreekRanch.Common.Helpers
{
  public static class HtmlClassSelectedExtension
  {
    public static MvcHtmlString Selected(this HtmlHelper htmlHelper, string category)
    {
      switch (category)
      {
        case "story":
          if (htmlHelper.ViewContext.HttpContext.Request.RawUrl.Contains("our-story"))
            return new MvcHtmlString("class=\"selected\"");
        break;
        case "health":
          if (htmlHelper.ViewContext.HttpContext.Request.RawUrl.Contains("health") ||
              htmlHelper.ViewContext.HttpContext.Request.RawUrl.Contains("holistic"))
            return new MvcHtmlString("class=\"selected\"");
        break;
        case "dogs":
          if (htmlHelper.ViewContext.HttpContext.Request.RawUrl.Contains("dog"))
            return new MvcHtmlString("class=\"selected\"");
        break;
        case "cats":
          if (htmlHelper.ViewContext.HttpContext.Request.RawUrl.Contains("cat"))
            return new MvcHtmlString("class=\"selected\"");
        break;
        case "snacks":
          if (htmlHelper.ViewContext.HttpContext.Request.RawUrl.Contains("snack"))
            return new MvcHtmlString("class=\"selected\"");
        break;
      }

      return new MvcHtmlString(string.Empty);
    }
  }
}
