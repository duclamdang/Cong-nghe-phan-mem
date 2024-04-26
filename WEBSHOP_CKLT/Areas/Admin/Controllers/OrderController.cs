using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI;
using WEBSHOP_CKLT.Models;
using PagedList;
using System.Data.Entity.Validation;
using WEBSHOP_CKLT.Models.entity_framework;

namespace WEBSHOP_CKLT.Areas.Admin.Controllers
{
    [Authorize(Roles = "Admin,Employee")]

    public class OrderController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/Order
        public ActionResult Index(int? page)
        {
            var items = db.Order.OrderByDescending(x => x.CreatedDate).ToList();
            if (page == null)
            {
                page = 1;
            }
            var pageNumber = page ?? 1;
            var pageSize = 10;
            ViewBag.PageSize = pageSize;
            ViewBag.Page = pageNumber;
            return View(items.ToPagedList(pageNumber, pageSize));
        }
        public ActionResult View(int id)
        {
            var item = db.Order.Find(id);
            return View(item);
        }
        public ActionResult Partical_SanPham(int id)
        {
            var items = db.OrderDetail.Where(x => x.OrderID == id).ToList();
            return PartialView(items);
        }
        [HttpPost]
        public ActionResult UpdateTT(int id,int trangthai)
        {
            var item = db.Order.Find(id);
                if (item!=null)
            {
                db.Order.Attach(item);
                item.TypePayment = trangthai;
                db.Entry(item).Property(x=>x.TypePayment).IsModified=true;
                db.SaveChanges();
                return Json(new { message = "Success", Success = true });

            }
            return Json(new { message = "Unsuccess", Success = false });

        }
        public ActionResult Delete(int id)
        {
            var item = db.Order.Find(id);
            if (item != null)
            {
                db.Order.Remove(item);
                db.SaveChanges();
                return Json(new { success = true });
            }
            return Json(new { success = false });
        }
    }
}