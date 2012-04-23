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

    public ActionResult Products(string url)
    {
      try
      {
        var category = db.Categories.FirstOrDefault<Category>(c => c.FriendlyUrl == url);
        var products = db.Products.Where<Product>(p => p.ProductCategory.Id == category.Id).ToList();

        return PartialView(products);
      }
      catch
      {
        return PartialView(null);
      }
    }
  }
}
