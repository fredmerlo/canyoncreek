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
    [Authorize]
    public class GuaranteeController : Controller
    {
        private CCRDb db = new CCRDb();

        public ViewResult Index()
        {
          List<GuaranteeModel> guarantees = new List<GuaranteeModel>();

          foreach (var guarantee in db.Guarantees.ToList<Guarantee>())
            guarantees.Add(new GuaranteeModel(guarantee) { Products = db.Products.ToList<Product>() });

          return View(guarantees);
        }

        public ViewResult Details(int id)
        {
          return View(new GuaranteeModel(db.Guarantees.Find(id)) { Products = db.Products.ToList<Product>() });
        }

        public ActionResult Create()
        {
          GuaranteeModel guarantee = new GuaranteeModel { Products = db.Products.ToList<Product>() };
          return View(guarantee);
        }

        [HttpPost]
        public ActionResult Create(GuaranteeModel guarantee)
        {
          if (ModelState.IsValid)
          {
            var entity = guarantee.GetEntity();
            entity.Product = db.Products.Find(entity.Product.Id);
            db.Guarantees.Add(entity);
            db.SaveChanges();
            return RedirectToAction("Index");
          }

          return View(guarantee);
        }

        public ActionResult Edit(int id)
        {
          GuaranteeModel guarantee = new GuaranteeModel(db.Guarantees.Find(id)) { Products = db.Products.ToList<Product>() };
          return View(guarantee);

        }

        [HttpPost]
        public ActionResult Edit(GuaranteeModel guarantee)
        {
          if (ModelState.IsValid)
          {
            var entity = db.Guarantees.Find(guarantee.Id);
            guarantee.GuarnateeProduct = db.Products.Find(guarantee.GuarnateeProduct.Id);
            guarantee.MapEntity(entity);

            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
            return RedirectToAction("Index");
          }
          return View(guarantee);
        }

        public ActionResult Delete(int id)
        {
          return View(new GuaranteeModel(db.Guarantees.Find(id)));
        }

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