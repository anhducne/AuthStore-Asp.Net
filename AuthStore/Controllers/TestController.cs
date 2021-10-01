using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthStore.Models;

namespace AuthStore.Controllers
{
    public class TestController : Controller
    {
        AuthenEntities db = new AuthenEntities();
        public ActionResult KhachhangIndex()
        {
            var lstKH = from kh in db.KhachHang select kh;
            return View(lstKH);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult SPne()
        {
            var lstSP = from sp in db.SanPham select sp;
            return View(lstSP);
        }

    }
}