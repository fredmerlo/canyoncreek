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
    public class FeedController : Controller
    {
        private CCRDb db = new CCRDb();

        public ViewResult Index()
        {
          List<FeedModel> feeds = new List<FeedModel>();

          foreach (var feed in db.Feeds.ToList<Feed>())
            feeds.Add(new FeedModel(feed) { Products = db.Products.ToList<Product>() });

          return View(feeds);
        }

        public ViewResult Details(int id)
        {
          return View(new FeedModel(db.Feeds.Find(id)) { Products = db.Products.ToList<Product>() });
        }

        public ActionResult Create()
        {
          FeedModel feed = new FeedModel { Products = db.Products.ToList<Product>() };
          return View(feed);
        } 

        [HttpPost]
        public ActionResult Create(FeedModel feed)
        {
            if (ModelState.IsValid)
            {
              var entity = feed.GetEntity();
              entity.Product = db.Products.Find(entity.Product.Id);
              db.Feeds.Add(entity);
              db.SaveChanges();
              return RedirectToAction("Index");  
            }

            return View(feed);
        }
        
        public ActionResult Edit(int id)
        {
          FeedModel feed = new FeedModel(db.Feeds.Find(id)) { Products = db.Products.ToList<Product>() };
          return View(feed);

        }

        [HttpPost]
        public ActionResult Edit(FeedModel feed)
        {
            if (ModelState.IsValid)
            {
              var entity = feed.GetEntity();
              entity.Product = db.Products.Find(entity.Product.Id);
              db.Entry(entity).State = EntityState.Modified;
              db.SaveChanges();
              return RedirectToAction("Index");
            }
            return View(feed);
        }

        public ActionResult Delete(int id)
        {
            return View(new FeedModel(db.Feeds.Find(id)));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Feed feed = db.Feeds.Find(id);
            db.Feeds.Remove(feed);
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