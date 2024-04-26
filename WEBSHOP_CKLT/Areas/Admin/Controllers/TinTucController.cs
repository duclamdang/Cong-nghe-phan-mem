﻿using PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebGrease;
using WebGrease.Css.ImageAssemblyAnalysis.LogModel;
using WEBSHOP_CKLT.Models;
using WEBSHOP_CKLT.Models.entity_framework;

namespace WEBSHOP_CKLT.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]
    public class TinTucController : Controller
    {
      private  ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/TinTuc
        public ActionResult Index(string SearchText,int? page)
        {
            var pageSize = 10;
            if (page == null)
            {
                page = 1;
            }          
            IEnumerable<News> items = db.News.OrderByDescending(x => x.ID);
            if(!string.IsNullOrEmpty(SearchText))
            {
                items = items.Where(x=>x.Alias.Contains(SearchText) || x.Title.Contains(SearchText));
            }
            var pageIndex = page.HasValue ? Convert.ToInt32(page) : 1;
            items =items.ToPagedList(pageIndex, pageSize);
            ViewBag.PageSize=pageSize;
            ViewBag.Page = page;
            return View(items);
        }
        public ActionResult Add()
        {
            return  View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(News model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate=DateTime.Now; 
                model.CategoryID = 1;
                model.ModiferDate=DateTime.Now;
                model.Alias = WEBSHOP_CKLT.Models.Common.Filter.FilterChar(model.Title);
                db.News.Add(model);
                db.SaveChanges();   
                return RedirectToAction("Index");
            }
            return View(model);
        }
        public ActionResult Edit(int id)
        {
            var item = db.News.Find(id);
            return View(item);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(News model)
        {
            if (ModelState.IsValid)
            {
                model.ModiferDate = DateTime.Now;
                model.Alias = WEBSHOP_CKLT.Models.Common.Filter.FilterChar(model.Title);
                db.News.Attach(model);
                db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(model);
        }

        [HttpPost]
        public ActionResult Delete(int id) 
        {
            var item = db.News.Find(id);
            if(item!=null)
            {
                db.News.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }

        [HttpPost]
        public ActionResult IsActive(int id)
        {
            var item = db.News.Find(id);
            if (item != null)
            {
                item.IsActived = !item.IsActived;
                db.Entry(item).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return Json(new { success = true , isAcive = item.IsActived});
            }

            return Json(new {success = false});
        }

        [HttpPost]
        public ActionResult DeleteAll(string ids)
        {
            if (!string.IsNullOrEmpty(ids))
            {
                var items = ids.Split(',');
                if(items!=null && items.Any())
                {
                    foreach(var item in items)
                    {
                        var obj=db.News.Find(Convert.ToInt32(item)); 
                        db.News.Remove(obj);
                        db.SaveChanges();
                    }
                }
                return Json(new { success = true });
            }
            return Json(new {success = false });
        }
    }
}