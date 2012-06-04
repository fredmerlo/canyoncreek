using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Web.Controllers
{
  public class CategoryController : Controller
  {
    private CCRDb db = new CCRDb();

    public ActionResult Type(string type)
    {
      try
      {
        var classType = (int)Enum.GetValues(typeof(Category.Classifier))
           .Cast<Category.Classifier>().
           First(e => e.ToString().ToLower().Equals(type));

        var categories = db.Categories.Where<Category>(c => c.Type == classType).OrderBy(o => o.Sequence).ToList();

        foreach(var category in categories)
        {
          if (category.FriendlyUrl.Equals("snacks-variety", StringComparison.OrdinalIgnoreCase))
            ((List<Product>)TempData["snacks-chews"]).AddRange(db.Products.Where<Product>(p => p.ProductCategory.Id == category.Id && p.Active == true).OrderBy(o => o.Title).ToList());
          else
            TempData.Add(category.FriendlyUrl, db.Products.Where<Product>(p => p.ProductCategory.Id == category.Id && p.Active == true).OrderBy(o => o.Title).ToList());
        }

        return PartialView(categories.Where(c => !c.FriendlyUrl.Equals("snacks-variety",StringComparison.OrdinalIgnoreCase)).ToList());
      }
      catch
      {
        return PartialView(null);
      }
    }

    public ActionResult Info(string type)
    {
      try
      {
        var classType = (int)Enum.GetValues(typeof(Category.Classifier))
           .Cast<Category.Classifier>().
           First(e => e.ToString().ToLower().Equals(type));

        var detailType = Enum.GetName(typeof(Category.Classifier), classType) + "Info";

        return View(detailType);
      }
      catch
      {
        return RedirectToAction("Index", "Home");
      }
    }

    public ActionResult Category(string url)
    {
      var category = db.Categories.Where<Category>(c => c.FriendlyUrl == url).FirstOrDefault();

      if (category == null)
        return PartialView(null);

      var products = db.Products.Where<Product>(p => p.ProductCategory.Id == category.Id).OrderBy(o => o.Title).ToList();

      return PartialView(products);
    }
  }
}
