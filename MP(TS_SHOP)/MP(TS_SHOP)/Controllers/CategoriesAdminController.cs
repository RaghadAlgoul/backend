using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using MP_TS_SHOP_.Models;

namespace MP_TS_SHOP_.Controllers
{
    public class CategoriesAdminController : Controller
    {
        private TS_SHOPEntities db = new TS_SHOPEntities();

        // GET: CategoriesAdmin
        public ActionResult Index()
        {
            return View(db.Categories.ToList());
        }

        // GET: CategoriesAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // GET: CategoriesAdmin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CategoriesAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "CategoryId,CategoryName,CategoryImage")] Category category,HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image.FileName);
                    string path2 = Path.GetFileName(Image.FileName);
                    Image.SaveAs(Server.MapPath(path));
                    category.CategoryImage = path2.ToString();
                }
                catch { }
                db.Categories.Add(category);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(category);
        }

        // GET: CategoriesAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: CategoriesAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id ,[Bind(Include = "CategoryId,CategoryName,CategoryImage")] Category category, HttpPostedFileBase Image)
        {
            if (ModelState.IsValid)
            {
                var existingModel = db.Categories.AsNoTracking().FirstOrDefault(x => x.CategoryId == id);

                if (Image != null)
                {
                    string fileName = Path.GetFileName(Image.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image.FileName);
                    Image.SaveAs(Server.MapPath(path));
                    category.CategoryImage = Image.FileName;


                }
                else
                {
                    category.CategoryImage = existingModel.CategoryImage;

                }
                db.Entry(category).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(category);
        }

        // GET: CategoriesAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Category category = db.Categories.Find(id);
            if (category == null)
            {
                return HttpNotFound();
            }
            return View(category);
        }

        // POST: CategoriesAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Category category = db.Categories.Find(id);
            db.Categories.Remove(category);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
