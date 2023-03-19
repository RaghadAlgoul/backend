using Microsoft.AspNet.Identity;
using MP_TS_SHOP_.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace MP_TS_SHOP_.Controllers
{
    public class HomeController : Controller
    {
        public class ViewModel
        {
            public IEnumerable<User> User { get; set; }
            public IEnumerable<Comment> Comments { get; set; }
            public IEnumerable<Product> products  { get; set; }

        }
        TS_SHOPEntities db = new TS_SHOPEntities();

        
        public ActionResult Home()
        {
            return View(db.Categories.ToList());
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult PersonalProfile()
        {

            string id = User.Identity.GetUserId();
            ViewModel vm = new ViewModel
            {
                User = db.Users.Where(x => x.Id == id).ToList(),
                Comments = db.Comments.ToList(),
                products = db.Products.ToList()
            };
            return View(vm);
        }

        public ActionResult ProductOwnerProfile(int ? id)
        {
            ViewBag.id =id;
            ViewModel vm2 = new ViewModel
            {
                User = db.Users.Where(x=>x.UserId==id).ToList(),
                Comments = db.Comments.Where(x => x.UserId == id).ToList(),
                products = db.Products.Where(x => x.UserID == id).ToList(),
            };
            return View("PersonalProfile", vm2);
        }
        [HttpGet]
        public ActionResult Catigory(int ? id)
        {
            return View(db.Products.Where(x=>x.CategoryId==id).ToList());
        }
        public ActionResult Single(int? id)
        {
            ViewBag.ProductOwnerImage = db.Products.FirstOrDefault(x => x.ProductId == id).User.UserImage;
            ViewBag.ProductOwnerName = db.Products.FirstOrDefault(x => x.ProductId == id).User.Name;
            ViewBag.ProductOwnerLocation = db.Products.FirstOrDefault(x => x.ProductId == id).User.UserLocation;
            ViewBag.ProductOwnerId = db.Products.FirstOrDefault(x => x.ProductId == id).User.UserId;
            return View(db.Products.Where(x => x.ProductId == id).ToList());
        }

        public ActionResult ProviderDashboard()
        {
            string id = User.Identity.GetUserId();
            ViewModel vm = new ViewModel
            {
                User = db.Users.Where(x => x.Id == id).ToList(),
                Comments = db.Comments.ToList(),
                products = db.Products.ToList()
            };
            return View(vm);
        }
        public ActionResult AdminDashBoard()
        {
            string id = User.Identity.GetUserId();
            ViewModel vm = new ViewModel
            {
                User = db.Users.ToList(),
                products = db.Products.ToList()
            };
            return View(vm);
        }

    }
}