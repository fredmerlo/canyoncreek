using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Admin.Controllers
{ 
    public class GuaranteeController : Controller
    {
        private CCRDb db = new CCRDb();

        //
        // GET: /Guarantee/

        public ViewResult Index()
        {
            return View(db.Guarantees.ToList());
        }

        //
        // GET: /Guarantee/Details/5

        public ViewResult Details(int id)
        {
            Guarantee guarantee = db.Guarantees.Find(id);
            return View(guarantee);
        }

        //
        // GET: /Guarantee/Create

        public ActionResult Create()
        {
            return View();
        } 

        //
        // POST: /Guarantee/Create

        [HttpPost]
        public ActionResult Create(Guarantee guarantee)
        {
            if (ModelState.IsValid)
            {
                db.Guarantees.Add(guarantee);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(guarantee);
        }
        
        //
        // GET: /Guarantee/Edit/5
 
        public ActionResult Edit(int id)
        {
            Guarantee guarantee = db.Guarantees.Find(id);
            return View(guarantee);
        }

        //
        // POST: /Guarantee/Edit/5

        [HttpPost]
        public ActionResult Edit(Guarantee guarantee)
        {
            if (ModelState.IsValid)
            {
                db.Entry(guarantee).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(guarantee);
        }

        //
        // GET: /Guarantee/Delete/5
 
        public ActionResult Delete(int id)
        {
            Guarantee guarantee = db.Guarantees.Find(id);
            return View(guarantee);
        }

        //
        // POST: /Guarantee/Delete/5

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Guarantee guarantee = db.Guarantees.Find(id);
            db.Guarantees.Remove(guarantee);
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