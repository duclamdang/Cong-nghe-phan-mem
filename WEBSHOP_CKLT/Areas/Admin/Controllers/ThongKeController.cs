using Microsoft.Owin.Security.Provider;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSHOP_CKLT.Models;

namespace WEBSHOP_CKLT.Areas.Admin.Controllers
{
    public class ThongKeController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: Admin/ThongKe
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public ActionResult Statistical(string fromDate, string toDate)
        {
            var query = from o in db.Order
                        join od in db.OrderDetail
                        on o.ID equals od.OrderID
                        join p in db.Product
                        on od.ProductID equals p.ID
                        select new
                        {
                            CreatedDate = o.CreatedDate,
                            Quantity = od.Quantity,
                            Price = od.Price,
                            OriginalPrice = p.OriginalPrice
                        };      
            if(string.IsNullOrEmpty(fromDate) )
            {
                DateTime startDate = DateTime.ParseExact(fromDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate >= startDate);
            }
            if (string.IsNullOrEmpty(toDate))
            {
                DateTime endDate = DateTime.ParseExact(toDate, "dd/MM/yyyy", null);
                query = query.Where(x => x.CreatedDate < endDate);
            }

            var result = query.GroupBy(x => DbFunctions.TruncateTime(x.CreatedDate)).Select(x => new
            {
                Date = x.Key.Value,
                TotalBuy = x.Sum(y => y.Quantity * y.OriginalPrice),
                TotalSell = x.Sum(y => y.Quantity * y.Price),
            }).Select(x => new
            {
                Date = x.Date,
                DoanhThu = x.TotalSell,
                LoiNhuan = x.TotalSell -x.TotalBuy
            });
            return Json(new {Date = result}, JsonRequestBehavior.AllowGet);
        }
    }
}