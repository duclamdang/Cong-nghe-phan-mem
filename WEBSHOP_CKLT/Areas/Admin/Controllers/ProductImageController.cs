using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSHOP_CKLT.Models;

namespace WEBSHOP_CKLT.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ProductImageController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProductImage

        public ActionResult Index(int ID)
        {
            var items=db.ProductImages.Where(x=>x.ProductID == ID).ToList();
            return View(items);
        }
        
        
        [HttpPost]
        public ActionResult Delete(int ID)
        {
            var item = db.ProductImages.Find(ID);
            db.ProductImages.Remove(item);
            db.SaveChanges();
            return Json(new { success = true });
        }
    }
}