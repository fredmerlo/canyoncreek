using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Purina.CanyonCreekRanch.Common.Entities;
using Purina.CanyonCreekRanch.Common.Helpers;

namespace Purina.CanyonCreekRanch.Web.Controllers
{
  public class ProductController : Controller
  {
    private CCRDb db = new CCRDb();

    public ActionResult Detail(string url)
    {
      if(Session["guid"] == null)
          Session.Add("guid", Guid.NewGuid().ToString());
      
      var product = db.Products.Where(p => p.Active == true && p.FriendlyUrl == url).FirstOrDefault();

      if (product == null)
        return RedirectToAction("Index", "Home");

      var products = db.Products.Where(p => p.Active == true && p.ProductCategory.Id == product.ProductCategory.Id).OrderBy(o => o.Title).ToList();
      var detailType = Enum.GetName(typeof(Category.Classifier), product.ProductCategory.Type) + "Detail";
      var index = products.IndexOf(product);
      var pin = ((string)Session["guid"]);
      var code = 1;

        switch (product.ProductCategory.Type)
        {
            case 1:
                if(product.ProductCategory.FriendlyUrl.Contains("dry"))
                    code = 102276;
                else
                    code = 102277;
                break;
            case 2:
                if(product.ProductCategory.FriendlyUrl.Contains("dry"))
                    code = 102270;
                else
                    code = 102275;
                break;
            default:
                code = 102270;
                break;
        }
      
      if ( !TempData.ContainsKey("previous"))
        TempData.Add("previous", products[index == 0 ? products.Count - 1 : index - 1]);
      
      if (!TempData.ContainsKey("next"))
        TempData.Add("next", products[index + 1 == products.Count ? 0 : index + 1]);
      
      if (!TempData.ContainsKey("coupon"))
        TempData.Add("coupon", "http://bricks.coupons.com/enable.asp?o=" + code + "&c=PR&p=" + pin + "&cpt=" + CouponEncode.EncodeCPT(pin, code));

      return View(detailType, product);
    }
  }
}
