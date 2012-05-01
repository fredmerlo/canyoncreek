using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purina.CanyonCreekRanch.Web.Controllers
{
  public class HomeController : Controller
  {
    public ActionResult Index()
    {
      ViewBag.Message = "Welcome to ASP.NET MVC!";

      return View();
    }

    public ActionResult About()
    {
      return View();
    }

    [ActionName("holistic-living")]
    public ActionResult HolisticLiving() { return View(); }

    [ActionName("ingredient-dictionary")]
    public ActionResult IngredientDictionary() { return View(); }

    [ActionName("our-story")]
    public ActionResult OurStory() { return View(); }

    [ActionName("our-story-faq")]
    public ActionResult OurStoryFaq() { return View(); }
  }
}
