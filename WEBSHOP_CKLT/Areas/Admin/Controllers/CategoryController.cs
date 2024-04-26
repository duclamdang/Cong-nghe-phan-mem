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
    public class CategoryController : Controller
    {
       private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Category
        public ActionResult Index()
        {
            var items = db.Category;
            return View(items);
        }

        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Category model)
        {
            if(ModelState.IsValid)
            {
                model.CreatedDate= DateTime.Now;
                model.ModiferDate = DateTime.Now;
                model.Alias = WEBSHOP_CKLT.Models.Common.Filter.FilterChar(model.Title);
                   
            
                db.Category.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
                
            } 
            return View(model);
        }
        public ActionResult Edit(int id) 
        {
            var item = db.Category.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Category model)
        {
            if (ModelState.IsValid)
            {
                db.Category.Attach(model);
                model.ModiferDate = DateTime.Now;
                model.Alias = WEBSHOP_CKLT.Models.Common.Filter.FilterChar(model.Title);
                db.Entry(model).Property(x => x.Title).IsModified = true;
                db.Entry(model).Property(x => x.Description).IsModified = true;
                db.Entry(model).Property(x => x.Alias).IsModified = true;
                db.Entry(model).Property(x => x.SeoDescription).IsModified = true;
                db.Entry(model).Property(x => x.SeoKeywords).IsModified = true;
                db.Entry(model).Property(x => x.SeoTitle).IsModified = true;
                db.Entry(model).Property(x => x.Position).IsModified = true;
                db.Entry(model).Property(x => x.ModiferDate).IsModified = true;
                db.Entry(model).Property(x => x.ModifierBy).IsModified = true;
                db.SaveChanges();
                return RedirectToAction("Index");

            }
            return View(model);
        }
        public ActionResult Delete (int id)
        {
            var item = db.Category.Find(id);
            if(item != null)
            {
                db.Category.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });

        }
    }
}