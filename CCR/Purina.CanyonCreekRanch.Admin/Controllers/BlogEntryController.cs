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
    public class BlogEntryController : Controller
    {
        private CCRDb db = new CCRDb();

        public ViewResult Index()
        {
            return View(db.BlogEntries.ToList());
        }

        public ViewResult Details(int id)
        {
            BlogEntryModel blogentrymodel = db.BlogEntryModels.Find(id);
            return View(blogentrymodel);
        }
        public ActionResult Create()
        {
            return View();
        } 

      [HttpPost]
        public ActionResult Create(BlogEntryModel blogentrymodel)
        {
            if (ModelState.IsValid)
            {
                db.BlogEntryModels.Add(blogentrymodel);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(blogentrymodel);
        }
        
        public ActionResult Edit(int id)
        {
            BlogEntryModel blogentrymodel = db.BlogEntryModels.Find(id);
            return View(blogentrymodel);
        }

        [HttpPost]
        public ActionResult Edit(BlogEntryModel blogentrymodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogentrymodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogentrymodel);
        }

        public ActionResult Delete(int id)
        {
            BlogEntryModel blogentrymodel = db.BlogEntryModels.Find(id);
            return View(blogentrymodel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            BlogEntryModel blogentrymodel = db.BlogEntryModels.Find(id);
            db.BlogEntryModels.Remove(blogentrymodel);
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