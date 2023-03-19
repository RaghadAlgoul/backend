using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MP_TS_SHOP_.Models;

namespace MP_TS_SHOP_.Controllers
{
    public class ProductsAdminController : Controller
    {
        public class ViewModel
        {
            public IEnumerable<Category> categories { get; set; }

            public IEnumerable<Product> products { get; set; }

        }
        private TS_SHOPEntities db = new TS_SHOPEntities();

        // GET: ProductsAdmin
        public ActionResult Index()
        {
            ViewModel vm = new ViewModel
            {
             products = db.Products.Include(p => p.Category).Include(p => p.User),
             categories = db.Categories.ToList(),
            };
            return View(vm);
        }

        // GET: ProductsAdmin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // GET: ProductsAdmin/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserImage");
            return View();
        }

        // POST: ProductsAdmin/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,CategoryId,State,Price,Size,Color,Description,Name,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9,Image10,UserID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserImage", product.UserID);
            return View(product);
        }

        // GET: ProductsAdmin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserImage", product.UserID);
            return View(product);
        }

        // POST: ProductsAdmin/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ProductId,CategoryId,State,Price,Size,Color,Description,Name,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9,Image10,UserID")] Product product)
        {
            if (ModelState.IsValid)
            {
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserImage", product.UserID);
            return View(product);
        }

        // GET: ProductsAdmin/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: ProductsAdmin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Product product = db.Products.Find(id);
            db.Products.Remove(product);
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
