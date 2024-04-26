using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSHOP_CKLT.Models;

namespace WEBSHOP_CKLT.Controllers
{
    public class ProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Products
        public ActionResult Index(int? id)
        {
               
            var items = db.Product.ToList();
            
            return View(items);
        }

        public ActionResult Detail (string alias, int id)
        {
            var item = db.Product.Find(id);
            return View(item);
        }
        public ActionResult ProductCategory(string alias,int id)
        {

            var items = db.Product.ToList();
            if (id > 0)
            {
                items = items.Where(x => x.ProductCategoryID == id).ToList();
            }
            var cate=db.ProductCategory.Find(id);
            {
                if (cate != null)
                {
                    ViewBag.CateName = cate.Title;
                }
            }
            ViewBag.CateId = id;
            return View(items);
        }
        public ActionResult Parital_ItemsBycCateId()
        {
            var items=db.Product.Where(x=>x.IsHome && x.IsActived).Take(10).ToList();
            return PartialView(items);
        }
        public ActionResult Parital_ProductSales()
        {
            var items = db.Product.Where(x => x.IsSale && x.IsActived).Take(50).ToList();
            return PartialView(items);
        }
    }
}