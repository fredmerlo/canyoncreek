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
          List<BlogEntryModel> entries = new List<BlogEntryModel>();

          foreach (var entry in db.BlogEntries.OrderByDescending(e => e.Created).ToList<BlogEntry>())
            entries.Add(new BlogEntryModel(entry) { Categories = db.BlogCategories.OrderBy(c => c.Name).ToList<BlogCategory>() });

          return View(entries);
        }

        public ViewResult Details(int id)
        {
          return View(new BlogEntryModel(db.BlogEntries.Find(id)) { Categories = db.BlogCategories.OrderBy(c => c.Name).ToList<BlogCategory>() });
        }

        public ActionResult Create()
        {
          return View(new BlogEntryModel { Active = true, Created = DateTime.Now, Categories = db.BlogCategories.OrderBy(c => c.Name).ToList<BlogCategory>() });
        } 

        [HttpPost]
        public ActionResult Create(BlogEntryModel entry)
        {
            if (ModelState.IsValid)
            {
              var entity = entry.GetEntity();
              entity.EntryCategory = db.BlogCategories.Find(entry.EntryCategory.Id);
              db.BlogEntries.Add(entity);
              db.SaveChanges();
              return RedirectToAction("Index");  
            }

            return View(entry);
        }
        
        public ActionResult Edit(int id)
        {
          return View(new BlogEntryModel(db.BlogEntries.Find(id)) { Categories = db.BlogCategories.OrderBy(c => c.Name).ToList<BlogCategory>() });
        }

        [HttpPost]
        public ActionResult Edit(BlogEntryModel entry)
        {
            if (ModelState.IsValid)
            {
              var entity = db.BlogEntries.Find(entry.Id);
              entry.EntryCategory = db.BlogCategories.Find(entry.EntryCategory.Id);
              entry.MapEntity(entity);

              db.Entry<BlogEntry>(entity).State = EntityState.Modified;
              db.SaveChanges();
              return RedirectToAction("Index");
            }

            return View(entry);
        }

        public ActionResult Delete(int id)
        {
          return View(new BlogEntryModel(db.BlogEntries.Find(id)));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            BlogEntry entry = db.BlogEntries.Find(id);
            db.BlogEntries.Remove(entry);
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