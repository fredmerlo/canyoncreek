using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Purina.CanyonCreekRanch.Admin.Models;
using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Admin.Controllers
{
    [Authorize(Roles = "CCRAdmin")]
    public class BlogCategoryController : Controller
    {
        private CCRDb db = new CCRDb();

        public ViewResult Index()
        {
            return View(db.BlogCategories.OrderBy(c => c.Name).ToList());
        }

        public ViewResult Details(int id)
        {
            BlogCategory category = db.BlogCategories.Find(id);
            return View(category);
        }

        public ActionResult Create()
        {
            return View();
        } 

        [HttpPost]
        public ActionResult Create(BlogCategory blogcategory)
        {
            if (ModelState.IsValid)
            {
              db.BlogCategories.Add(blogcategory);
              db.SaveChanges();
              return RedirectToAction("Index");  
            }

            return View(blogcategory);
        }
        
        public ActionResult Edit(int id)
        {
          BlogCategory blogcategory = db.BlogCategories.Find(id);
          return View(blogcategory);
        }

        [HttpPost]
        public ActionResult Edit(BlogCategory blogcategory)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogcategory).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogcategory);
        }

        public ActionResult Delete(int id)
        {
          BlogCategory blogcategory = db.BlogCategories.Find(id);
          return View(blogcategory);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
          BlogCategory blogcategory = db.BlogCategories.Find(id);
          db.BlogCategories.Remove(blogcategory);
          db.SaveChanges();
          return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}