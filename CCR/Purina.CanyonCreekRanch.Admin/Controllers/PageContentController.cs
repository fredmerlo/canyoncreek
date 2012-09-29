using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using Purina.CanyonCreekRanch.Admin.Models;
using Purina.CanyonCreekRanch.Common.Entities;

namespace Purina.CanyonCreekRanch.Admin.Controllers
{
    [Authorize(Roles = "CCRAdmin")]
    public class PageContentController : Controller
    {
        private CCRDb db = new CCRDb();

        public ViewResult Index()
        {
            List<PageContentModel> pages = new List<PageContentModel>();

            foreach (var page in db.PageContents.ToList())
              pages.Add(new PageContentModel(page));

            return View(pages.OrderBy(c => c.Page).ToList());
        }

        public ViewResult Details(int id)
        {
            return View(new PageContentModel(db.PageContents.Find(id)));
        }

        public ActionResult Create()
        {
            return View(new PageContentModel
                            {
                                Page = "",
                                Meta = ""
                            });
        }

        [HttpPost]
        public ActionResult Create(PageContentModel content)
        {
            if (ModelState.IsValid)
            {
                var entity = content.GetEntity();
                db.PageContents.Add(entity);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(content);
        }

        public ActionResult Edit(int id)
        {
            return View(new PageContentModel(db.PageContents.Find(id)));
        }

        [HttpPost]
        public ActionResult Edit(PageContentModel content)
        {
            if (ModelState.IsValid)
            {
                var entity = db.PageContents.Find(content.Id);
                content.MapEntity(entity);

                db.Entry(entity).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(content);
        }

        public ActionResult Delete(int id)
        {
            return View(new PageContentModel(db.PageContents.Find(id)));
        }

        [HttpPost, ActionName("Delete")]
        public ActionResult DeleteConfirmed(int id)
        {
            PageContent content = db.PageContents.Find(id);
            db.PageContents.Remove(content);
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