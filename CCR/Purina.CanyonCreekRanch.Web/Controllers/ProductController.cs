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
        }
      
      if ( !TempData.ContainsKey("previous"))
        TempData.Add("previous", products[index == 0 ? products.Count - 1 : index - 1]);
      
      if (!TempData.ContainsKey("next"))
        TempData.Add("next", products[index + 1 == products.Count ? 0 : index + 1]);
      
      if (!TempData.ContainsKey("coupon"))
        TempData.Add("coupon", "http://bricks.coupons.com/enable.asp?o=" + code + "&c=PR&p=" + pin + "&cpt=" + EncodeCPT(pin, code, "rke184ulgt","2rdAinvOmFoVXBa58sp1EZkSucftCg6eqxWlPKRNGzw7YQHJ4Db9UIyM3jTLh"));

      return View(detailType, product);
    }

    public static string EncodeCPT(string pinCode, int offerCode, string shortKey, string longKey)
    {
        string decodeX = " abcdefghijklmnopqrstuvwxyz0123456789!$%()*+,-.@;<=>?[]^_{|}~";
        int[] encodeModulo;
        int[] vob;
        int ocode;
        encodeModulo = new int[256];
        vob = new int[2];

        vob[0] = offerCode % 100;
        vob[1] = (offerCode / 100) % 100;

        for (int i = 0; i < 61; i++)
            encodeModulo[(int)char.Parse(decodeX.Substring(i, 1))] = i;
        pinCode = pinCode.ToLower() + offerCode.ToString();
        if (pinCode.Length < 20)
        {
            pinCode = pinCode + " couponsincproduction";
            pinCode = pinCode.Substring(0, 20);
        }
        int q = 0;
        int j = pinCode.Length;
        int k = shortKey.Length;
        int s1, s2, s3;
        System.Text.StringBuilder cpt = new System.Text.StringBuilder();
        for (int i = 0; i < j; i++)
        {
            s1 = encodeModulo[(int)char.Parse(pinCode.Substring(i, 1))];
            s2 = 2 * encodeModulo[(int)char.Parse(shortKey.Substring(i % k, 1))];
            s3 = vob[i % 2];
            q = (q + s1 + s2 + s3) % 61;
            cpt.Append(longKey.Substring(q, 1));
        }
        return cpt.ToString();

    }
  }
}
