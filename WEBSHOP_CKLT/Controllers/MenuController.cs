using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSHOP_CKLT.Models;
using WEBSHOP_CKLT.Models.entity_framework;
namespace WEBSHOP_CKLT.Controllers
{
    public class MenuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Menu

        public ActionResult Index()
        {
            return View();
        }
        public ActionResult MenuTop()
        {
            var items = db.Category.OrderBy(x => x.Position).ToList();
            return PartialView("_MenuTop", items);
        }
        public ActionResult MenuProductCategory()
        {
            var items = db.ProductCategory.ToList();
            return PartialView("_MenuProductCategory", items);
        }
        public ActionResult MenuLeft(int ?id)
        {
            if(id != null)
            {
                ViewBag.CateId = id;
            }    
            var items = db.ProductCategory.ToList();
            return PartialView("_MenuLeft", items);
        }
        public ActionResult MenuArrivals()
        {
            var items = db.ProductCategory.ToList();
            return PartialView("_MenuArrivals", items);
        }

    }
}