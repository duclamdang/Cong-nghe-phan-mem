using PagedList;
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
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Products
        public ActionResult Index(int? page)
        {
            IEnumerable<Product> items = db.Product.OrderByDescending(x => x.ID);
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items = items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize = pageSize;
            ViewBag.Page = page;
            return View(items);
        }

        public ActionResult Add()
        {
            ViewBag.ProdustCategoly = new SelectList(db.ProductCategory.ToList(), "ID", "Title");
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(Product model, List<string> Images, List<int> rdDefault)
        {
            if (ModelState.IsValid)
            {
                if(Images != null && Images.Count > 0)
                {
                    for(int i = 0; i<Images.Count; i++)
                    {
                        if(i + 1 == rdDefault[0])
                        {
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductID = model.ID,
                                Image = Images[i],
                                IsDefault = true
                            });
                        }
                        else
                        {
                            model.ProductImage.Add(new ProductImage
                            {
                                ProductID = model.ID,
                                Image = Images[i],
                                IsDefault = false
                            });
                        }
                    }
                }    
                model.CreatedDate = DateTime.Now;
                model.ModiferDate = DateTime.Now;
                if (string.IsNullOrEmpty(model.SeoTitle))
                {
                    model.SeoTitle = model.Title;
                }    
                    if (string.IsNullOrEmpty(model.Alias))
                    model.Alias = WEBSHOP_CKLT.Models.Common.Filter.FilterChar(model.Title);
                db.Product.Add(model);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ProdustCategoly = new SelectList(db.ProductCategory.ToList(), "ID", "Title");
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            ViewBag.ProdustCategoly = new SelectList(db.ProductCategory.ToList(), "ID", "Title");
            var item = db.Product.Find(id);
            return View(item);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Product model)
        {
            if (ModelState.IsValid)
            {
                model.ModiferDate = DateTime.Now;
                model.Alias = WEBSHOP_CKLT.Models.Common.Filter.FilterChar(model.Title);
                db.Product.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id)
        {
            var item = db.Product.Find(id);
            if (item != null)
            {
                db.Product.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.Product.Find(id);
            if (item != null)
            {
                item.IsActived = !item.IsActived;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, isAcive = item.IsActived });
            }

            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsHome(int id)
        {
            var item = db.Product.Find(id);
            if (item != null)
            {
                item.IsHome = !item.IsHome;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, IsHome = item.IsHome});
            }

            return Json(new { success = false });
        }
        [HttpPost]
        public ActionResult IsSale(int id)
        {
            var item = db.Product.Find(id);
            if (item != null)
            {
                item.IsSale = !item.IsSale;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true, IsSale = item.IsSale });
            }

            return Json(new { success = false });
        }
    }
}