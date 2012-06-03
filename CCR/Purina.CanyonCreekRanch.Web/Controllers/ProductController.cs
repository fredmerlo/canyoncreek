using System;
using System.Collections;
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

      if (product == null)
        return RedirectToAction("Index", "Home");

      var products = db.Products.Where(p => p.Active == true && p.ProductCategory.Id == product.ProductCategory.Id).OrderBy(o => o.Title).ToList();
      var detailType = Enum.GetName(typeof(Category.Classifier), product.ProductCategory.Type) + "Detail";
      var index = products.IndexOf(product);

      TempData.Add("previous", products[index == 0 ? products.Count - 1 : index - 1]);
      TempData.Add("next", products[index + 1 == products.Count ? 0 : index + 1]);

      return View(detailType, product);
    }
  }
}
