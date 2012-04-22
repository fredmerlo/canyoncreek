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
    public class BlogCategoryController : Controller
    {
        private CCRDb db = new CCRDb();

        public ViewResult Index()
        {
            return View(db.BlogCategories.ToList());
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
        public ActionResult Create(BlogCategoryModel blogcategorymodel)
        {
            if (ModelState.IsValid)
            {
                db.BlogCategoryModels.Add(blogcategorymodel);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(blogcategorymodel);
        }
        
        public ActionResult Edit(int id)
        {
            BlogCategoryModel blogcategorymodel = db.BlogCategoryModels.Find(id);
            return View(blogcategorymodel);
        }

        [HttpPost]
        public ActionResult Edit(BlogCategoryModel blogcategorymodel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(blogcategorymodel).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(blogcategorymodel);
        }

        public ActionResult Delete(int id)
        {
            BlogCategoryModel blogcategorymodel = db.BlogCategoryModels.Find(id);
            return View(blogcategorymodel);
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            BlogCategoryModel blogcategorymodel = db.BlogCategoryModels.Find(id);
            db.BlogCategoryModels.Remove(blogcategorymodel);
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