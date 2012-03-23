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
    public class ProductController : Controller
    {
        private CCRDb repository = new CCRDb();

        public ViewResult Index()
        {
          List<ProductModel> products = new List<ProductModel>();

          foreach (var product in repository.Products.ToList<Product>())
            products.Add(new ProductModel(product));

            return View(products);
        }

        public ViewResult Details(int id)
        {
            return View(new ProductModel(repository.Products.Find(id)));
        }

        public ActionResult Create()
        {
            ProductModel product = new ProductModel();
            return View(product);
        } 

        [HttpPost]
        public ActionResult Create(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                repository.Products.Add(product.GetEntity());
                repository.SaveChanges();
                return RedirectToAction("Index");  
            }

            return View(product);
        }
        
        public ActionResult Edit(int id)
        {
            return View(new ProductModel(repository.Products.Find(id)));
        }

        [HttpPost]
        public ActionResult Edit(ProductModel product)
        {
            if (ModelState.IsValid)
            {
                repository.Entry(product.GetEntity()).State = EntityState.Modified;
                repository.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(product);
        }
 
        public ActionResult Delete(int id)
        {
            return View(new ProductModel(repository.Products.Find(id)));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {            
            Product product = repository.Products.Find(id);
            repository.Products.Remove(product);
            repository.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            repository.Dispose();
            base.Dispose(disposing);
        }
    }
}