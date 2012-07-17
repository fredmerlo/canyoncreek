using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Purina.CanyonCreekRanch.Common.Helpers;

namespace Purina.CanyonCreekRanch.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index() { return View(); }

    [ActionName("natural-food-for-cats")]
    public ActionResult NaturalFoodForCats() { return new TransferResult(new { controller = "Category", action = "Info", type = "cat" }); }

    [ActionName("natural-food-for-dogs")]
    public ActionResult NaturalFoodForDogs() { return new TransferResult(new { controller = "Category", action = "Info", type = "dog" }); }

    [ActionName("snacks")]
    public ActionResult Snacks() { return new TransferResult(new { controller = "Category", action = "Info", type = "snack" }); }

    [ActionName("holistic-living")]
    public ActionResult HolisticLiving() { return View("HolisticLiving"); }

    [ActionName("ingredient-dictionary")]
    public ActionResult IngredientDictionary() { return View("IngredientDictionary"); }

    [ActionName("our-story")]
    public ActionResult OurStory() { return View("OurStory"); }

    [ActionName("our-story-faq")]
    public ActionResult OurStoryFaq() { return View("OurStoryFaq"); }

    [ActionName("health-and-nutrition")]
    public ActionResult HealthAndNutrition() { return View("HealthAndNutrition"); }

    [ActionName("find-a-retailer")]
    public ActionResult FindRetailser() { return View("FindRetailer"); }

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
  }
}
