using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSHOP_CKLT.Models;
using WEBSHOP_CKLT.Models.entity_framework;

namespace WEBSHOP_CKLT.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class ProdustCategolyController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ProdustsCategoly
        public ActionResult Index()
        {
            var items = db.ProductCategory;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(ProductCategory model )
        {
            if(ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                model.ModiferDate = DateTime.Now;
                model.Alias = WEBSHOP_CKLT.Models.Common.Filter.FilterChar(model.Title);
                db.ProductCategory.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }    
            return View();
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.ProductCategory.Find(id);
            if (item != null)
            {
                db.ProductCategory.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        public ActionResult Edit(int id)
        {
            var item=db.ProductCategory.Find(id);
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductCategory model) 
        {
            if (ModelState.IsValid)
            {
                model.ModiferDate = DateTime.Now;
                model.Alias = WEBSHOP_CKLT.Models.Common.Filter.FilterChar(model.Title);
                db.ProductCategory.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
    }
}