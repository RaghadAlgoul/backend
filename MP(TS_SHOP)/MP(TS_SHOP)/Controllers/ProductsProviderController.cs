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
    public class ProductsProviderController : Controller
    {
        private TS_SHOPEntities db = new TS_SHOPEntities();

        // GET: ProductsProvider
        public ActionResult Index()
        {
            string id = User.Identity.GetUserId();
            ViewBag.UserId = db.Users.FirstOrDefault(x => x.Id == id).UserId;

            var products = db.Products.Include(p => p.Category).Include(p => p.User);
            return View(products.ToList());
        }

        // GET: ProductsProvider/Details/5
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

        // GET: ProductsProvider/Create
        public ActionResult Create()
        {
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName");
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserImage");
            return View();
        }

        // POST: ProductsProvider/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ProductId,CategoryId,State,Price,Size,Color,Description,Name,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9,Image10,UserID")] Product product, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, HttpPostedFileBase Image5, HttpPostedFileBase Image6, HttpPostedFileBase Image7, HttpPostedFileBase Image8, HttpPostedFileBase Image9, HttpPostedFileBase Image10)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image1.FileName);
                    string path2 = Path.GetFileName(Image1.FileName);
                    Image1.SaveAs(Server.MapPath(path));
                    product.Image1 = path2.ToString();
                }
                catch { }
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image2.FileName);
                    string path2 = Path.GetFileName(Image2.FileName);
                    Image2.SaveAs(Server.MapPath(path));
                    product.Image2 = path2.ToString();
                }
                catch { }
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image3.FileName);
                    string path2 = Path.GetFileName(Image3.FileName);
                    Image3.SaveAs(Server.MapPath(path));
                    product.Image3 = path2.ToString();
                }
                catch { }
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image4.FileName);
                    string path2 = Path.GetFileName(Image4.FileName);
                    Image4.SaveAs(Server.MapPath(path));
                    product.Image4 = path2.ToString();
                }
                catch { }
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image5.FileName);
                    string path2 = Path.GetFileName(Image5.FileName);
                    Image5.SaveAs(Server.MapPath(path));
                    product.Image5 = path2.ToString();
                }
                catch { }
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image6.FileName);
                    string path2 = Path.GetFileName(Image6.FileName);
                    Image6.SaveAs(Server.MapPath(path));
                    product.Image6 = path2.ToString();
                }
                catch { }
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image7.FileName);
                    string path2 = Path.GetFileName(Image7.FileName);
                    Image7.SaveAs(Server.MapPath(path));
                    product.Image7 = path2.ToString();
                }
                catch { }
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image8.FileName);
                    string path2 = Path.GetFileName(Image8.FileName);
                    Image8.SaveAs(Server.MapPath(path));
                    product.Image8 = path2.ToString();
                }
                catch { }
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image9.FileName);
                    string path2 = Path.GetFileName(Image9.FileName);
                    Image9.SaveAs(Server.MapPath(path));
                    product.Image9 = path2.ToString();
                }
                catch { }
                try
                {
                    string path = "~/Image/" + Path.GetFileName(Image10.FileName);
                    string path2 = Path.GetFileName(Image10.FileName);
                    Image10.SaveAs(Server.MapPath(path));
                    product.Image10 = path2.ToString();
                }
                catch { }

                string AspId = User.Identity.GetUserId();
                int id = db.Users.FirstOrDefault(x => x.Id == AspId).UserId;
                product.UserID = id;
                db.Products.Add(product);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserImage", product.UserID);
            return View(product);
        }

        // GET: ProductsProvider/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            ViewBag.Image1= product.Image1;
            ViewBag.Image2= product.Image2;
            ViewBag.Image3= product.Image3;
            ViewBag.Image4= product.Image4;
            ViewBag.Image5= product.Image5;
            ViewBag.Image6= product.Image6;
            ViewBag.Image7= product.Image7;
            ViewBag.Image8= product.Image8;
            ViewBag.Image9 = product.Image9;
            ViewBag.Image10 = product.Image10;
            if (product == null)
            {
                return HttpNotFound();
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserImage", product.UserID);
            return View(product);
        }

        // POST: ProductsProvider/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id ,[Bind(Include = "ProductId,CategoryId,State,Price,Size,Color,Description,Name,Image1,Image2,Image3,Image4,Image5,Image6,Image7,Image8,Image9,Image10,UserID")] Product product, HttpPostedFileBase Image1, HttpPostedFileBase Image2, HttpPostedFileBase Image3, HttpPostedFileBase Image4, HttpPostedFileBase Image5, HttpPostedFileBase Image6, HttpPostedFileBase Image7, HttpPostedFileBase Image8, HttpPostedFileBase Image9, HttpPostedFileBase Image10)
        {
            if (ModelState.IsValid)
            {
                var existingModel = db.Products.AsNoTracking().FirstOrDefault(x => x.ProductId == id);

                if (Image1 != null)
                {
                    string fileName = Path.GetFileName(Image1.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image1.FileName);
                    Image1.SaveAs(Server.MapPath(path));
                    product.Image1 = Image1.FileName;


                }
                else
                {
                    product.Image1 = existingModel.Image1;
                }


                if (Image2 != null)
                {
                    string fileName = Path.GetFileName(Image2.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image2.FileName);
                    Image2.SaveAs(Server.MapPath(path));
                    product.Image2 = Image2.FileName;


                }
                else
                {
                    product.Image2 = existingModel.Image2;
                }


                if (Image3 != null)
                {
                    string fileName = Path.GetFileName(Image3.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image3.FileName);
                    Image3.SaveAs(Server.MapPath(path));
                    product.Image3 = Image3.FileName;


                }
                else
                {
                    product.Image3 = existingModel.Image3;
                }




                if (Image4 != null)
                {
                    string fileName = Path.GetFileName(Image4.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image4.FileName);
                    Image4.SaveAs(Server.MapPath(path));
                    product.Image4 = Image4.FileName;


                }
                else
                {
                    product.Image4 = existingModel.Image4;
                }


                if (Image5 != null)
                {
                    string fileName = Path.GetFileName(Image5.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image5.FileName);
                    Image5.SaveAs(Server.MapPath(path));
                    product.Image5 = Image5.FileName;


                }
                else
                {
                    product.Image5 = existingModel.Image5;
                }


                if (Image6 != null)
                {
                    string fileName = Path.GetFileName(Image6.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image6.FileName);
                    Image6.SaveAs(Server.MapPath(path));
                    product.Image6 = Image6.FileName;


                }
                else
                {
                    product.Image6 = existingModel.Image6;
                }


                if (Image7 != null)
                {
                    string fileName = Path.GetFileName(Image7.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image7.FileName);
                    Image7.SaveAs(Server.MapPath(path));
                    product.Image7 = Image7.FileName;


                }
                else
                {
                    product.Image7 = existingModel.Image7;
                }


                if (Image8 != null)
                {
                    string fileName = Path.GetFileName(Image8.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image8.FileName);
                    Image8.SaveAs(Server.MapPath(path));
                    product.Image8 = Image8.FileName;


                }
                else
                {
                    product.Image8 = existingModel.Image8;
                }


                if (Image9 != null)
                {
                    string fileName = Path.GetFileName(Image9.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image9.FileName);
                    Image9.SaveAs(Server.MapPath(path));
                    product.Image9 = Image9.FileName;


                }
                else
                {
                    product.Image9 = existingModel.Image9;
                }

                if (Image10 != null)
                {
                    string fileName = Path.GetFileName(Image10.FileName);
                    string path = "~/Image/" + Path.GetFileName(Image10.FileName);
                    Image10.SaveAs(Server.MapPath(path));
                    product.Image10 = Image10.FileName;


                }
                else
                {
                    product.Image10 = existingModel.Image10;
                }


                string AspId = User.Identity.GetUserId();
                int UserID = db.Users.FirstOrDefault(x => x.Id == AspId).UserId;
                product.UserID = UserID;
                db.Entry(product).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CategoryId = new SelectList(db.Categories, "CategoryId", "CategoryName", product.CategoryId);
            ViewBag.UserID = new SelectList(db.Users, "UserId", "UserImage", product.UserID);
            return View(product);
        }

        // GET: ProductsProvider/Delete/5
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

        // POST: ProductsProvider/Delete/5
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
