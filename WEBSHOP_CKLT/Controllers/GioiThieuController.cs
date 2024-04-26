using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WEBSHOP_CKLT.Models;

namespace WEBSHOP_CKLT.Controllers
{
    public class GioiThieuController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();
        // GET: GioiThieu
        public ActionResult Index()
        {
            return View();
        }
    }
}