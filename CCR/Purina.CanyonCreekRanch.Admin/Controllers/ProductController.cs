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
    public class ProductController : Controller
    {
        private CCRDb db = new CCRDb();

        public ViewResult Index()
        {
          List<ProductModel> products = new List<ProductModel>();

          foreach (var product in db.Products.ToList<Product>())
            products.Add(new ProductModel(product) { Categories = db.Categories.ToList<Category>() });

            return View(products);
        }

        public ViewResult Details(int id)
        {
            return View(new ProductModel(db.Products.Find(id)) { Categories = db.Categories.ToList<Category>() });
        }

        public ActionResult Create()
        {
            ProductModel product = new ProductModel { Categories = db.Categories.ToList<Category>() };
            return View(product);
        } 

        [HttpPost]
        public ActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                var entity = product.GetEntity();
                entity.ProductCategory = db.Categories.Find(product.ProductCategory.Id);
                db.Products.Add(entity);
                db.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(product);
        }
        
        public ActionResult Edit(int id)
        {
          return View(new ProductModel(db.Products.Find(id)) { Categories = db.Categories.ToList<Category>() });
        }

        [HttpPost]
        public ActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
              var entity = db.Products.Find(product.Id);
              product.ProductCategory = db.Categories.Find(product.ProductCategory.Id);
              product.MapEntity(entity);

              db.Entry<Product>(entity).State = EntityState.Modified;
              db.SaveChanges();
              return RedirectToAction("Index");
            }
            return View(product);
        }
 
        public ActionResult Delete(int id)
        {
            return View(new ProductModel(db.Products.Find(id)));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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