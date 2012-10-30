using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Common.Controllers
{
    public class BaseController : Controller
    {
        private CCRDb db = new CCRDb();

        protected new ViewResult View(string viewName)
        {
            var page = db.PageContents.ToList().FirstOrDefault(p => p.Page == Url.RequestContext.RouteData.Values["action"] as string) ??
                       db.PageContents.ToList().FirstOrDefault(p => p.Page == Request.RawUrl.TrimStart(new[] {'/'}));

            return page == null ? base.View(viewName) : View(viewName, page);
        }
    }
}
