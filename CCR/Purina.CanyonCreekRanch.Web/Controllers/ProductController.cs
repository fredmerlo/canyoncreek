using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Web.Controllers
{
  public class ProductController : Controller
  {
    private CCRDb db = new CCRDb();

    public ActionResult Detail(string url)
    {
      var product = db.Products.Where(p => p.Active == true && p.FriendlyUrl == url).FirstOrDefault();

      if(product == null)
        return RedirectToAction("Index", "Home");

      var detailType = Enum.GetName(typeof(Category.Classifier), product.ProductCategory.Type) + "Detail";

      return View(detailType, product);
    }
  }
}
