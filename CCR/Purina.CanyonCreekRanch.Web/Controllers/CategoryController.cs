using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Purina.CanyonCreekRanch.Common.Entities;
using Purina.CanyonCreekRanch.Common.Helpers;

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
        if (Session["guid"] == null)
            Session.Add("guid", Guid.NewGuid().ToString());

        var classType = (int)Enum.GetValues(typeof(Category.Classifier))
           .Cast<Category.Classifier>().
           First(e => e.ToString().ToLower().Equals(type));

        var detailType = Enum.GetName(typeof(Category.Classifier), classType) + "Info";

        var pin = ((string)Session["guid"]);
        var code = 1;

        switch (classType)
        {
            case 1:
                code = 102276;
                break;
            default:
                code = 102270;
                break;
        }

        if (!TempData.ContainsKey("coupon"))
            TempData.Add("coupon", "http://bricks.coupons.com/enable.asp?o=" + code + "&c=PR&p=" + pin + "&cpt=" + CouponEncode.EncodeCPT(pin, code));


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
