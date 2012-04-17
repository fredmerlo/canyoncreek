using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Purina.CanyonCreekRanch.Web.Controllers
{
    public class StaticController : Controller
    {
        //
        // GET: /Static/

        public ActionResult Index() {return View();}

        public ActionResult Contact() {return View();}
        
        public ActionResult FindRetailer() {return View();}

        public ActionResult HealthAndNurtrition() {return View();}

        public ActionResult HolisticLiving() {return View();}

        public ActionResult IngredientDictionary() {return View();}

        public ActionResult IngredientList() {return View();}

        public ActionResult OurStory() {return View();}

        public ActionResult OurStoryFaq() {return View();}

        public ActionResult SatisfactionGuarantee() {return View();}

        public ActionResult SiteMap() {return View();}

        public ActionResult TermsAndConditions() {return View();}
    }
}
