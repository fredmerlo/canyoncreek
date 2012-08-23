using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

using Purina.CanyonCreekRanch.Common.Helpers;

namespace Purina.CanyonCreekRanch.Web.Controllers
{
  public class HomeController : Controller
  {
    private void SetCouponData()
    {
        if (Session["guid"] == null)
            Session.Add("guid", Guid.NewGuid().ToString());

        var pin = ((string)Session["guid"]);
        var code = 102270;

        if (!TempData.ContainsKey("coupon"))
            TempData.Add("coupon",
                        "http://bricks.coupons.com/enable.asp?o=" + code + "&c=PR&p=" + pin + "&cpt=" +
                        CouponEncode.EncodeCPT(pin, code));
    }

    public ActionResult Index()
    {
        SetCouponData();
        return View();
    }

    [ActionName("natural-food-for-cats")]
    public ActionResult NaturalFoodForCats() { return new TransferResult(new { controller = "Category", action = "Info", type = "cat" }); }

    [ActionName("natural-food-for-dogs")]
    public ActionResult NaturalFoodForDogs() { return new TransferResult(new { controller = "Category", action = "Info", type = "dog" }); }

    [ActionName("snacks")]
    public ActionResult Snacks() { return new TransferResult(new { controller = "Category", action = "Info", type = "snack" }); }

    [ActionName("holistic-living")]
    public ActionResult HolisticLiving()
    {
        SetCouponData();
        return View("HolisticLiving");
    }

    [ActionName("ingredient-dictionary")]
    public ActionResult IngredientDictionary() { return View("IngredientDictionary"); }

    [ActionName("our-story")]
    public ActionResult OurStory() { return View("OurStory"); }

    [ActionName("our-story-faq")]
    public ActionResult OurStoryFaq() { return View("OurStoryFaq"); }

    [ActionName("health-and-nutrition")]
    public ActionResult HealthAndNutrition()
    {
        SetCouponData();
        return View("HealthAndNutrition");
    }

    [ActionName("find-a-retailer")]
    public ActionResult FindRetailer() 
    { 
      SetCouponData();
      return View("FindRetailer"); 
    }

    [ActionName("site-map")]
    public ActionResult SiteMap() { return View("SiteMap"); }

    [ActionName("terms-and-conditions")]
    public ActionResult TermsAndConditions() { return View("TermsAndConditions"); }

    public ActionResult Contact() { return View(); }

    [ActionName("companions")]
    public ActionResult RetailerProgram() { return View("Companions"); }

    [ActionName("satisfaction-guarantee")]
    public ActionResult OurGuarantee() { return View("Guarantee"); }

    [ActionName("privacy-policy")]
    public ActionResult PrivacyPolicy() { return View("PrivacyPolicy"); }

    [ActionName("register-email")]
    public void Register(string email)
    {
        if (string.IsNullOrEmpty(email) || email.Equals("Enter your email address"))
        {
            Response.Redirect(Request.UrlReferrer.AbsoluteUri);
            return;
        }

        HttpWebRequest request = (HttpWebRequest) WebRequest.Create("https://ansira.purina.com/et-api/et_caller/");

        request.AllowAutoRedirect = false;
        request.Method = "POST";

        string id = "canUser1";
        string pass = "canPass1";
        string call = "dataext";
        
        string postData = "client_id=" + id + "&client_sec=" + pass + "&call=" + call + "&send_mail=" + email;

        //string urlEncodedPostData = HttpUtility.UrlEncode(postData);

        byte[] data = System.Text.Encoding.ASCII.GetBytes(postData);

        request.ContentType = "application/x-www-form-urlencoded";
        request.ContentLength = data.Length;
        Stream response = request.GetRequestStream();
        response.Write(data, 0, data.Length);
        response.Close();

        HttpWebResponse res = (HttpWebResponse) request.GetResponse();

        StreamReader body = new StreamReader(res.GetResponseStream());
        string str = body.ReadToEnd();
        
        Response.Redirect(Request.UrlReferrer.AbsoluteUri);
    }
  }
}
