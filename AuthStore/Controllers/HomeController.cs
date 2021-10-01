using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthStore.Models;
using CaptchaMvc.HtmlHelpers;
using CaptchaMvc;

namespace AuthStore.Controllers
{
    public class HomeController : Controller
    {
        AuthenEntities db = new AuthenEntities();
        // GET: Home
        public ActionResult Index()
        {
            // lan luot tao viewbag de lay list so tu csdl
            //List Hang Dong Xuan moi nhat
            var lstHDXM = db.SanPham.Where(n => n.MaLoaiSP == 1 && n.Moi == 1 && n.DaXoa == false);
            ViewBag.ListHDXM = lstHDXM;
            //List Hang Thu Dong moi nhat
            var lstHTDM = db.SanPham.Where(n => n.MaLoaiSP == 2 && n.Moi == 1 && n.DaXoa == false);
            ViewBag.ListHTDM = lstHTDM;
            //List Hang He Thu moi nhat
            var lstHHTM = db.SanPham.Where(n => n.MaLoaiSP == 3 && n.Moi == 1 && n.DaXoa == false);
            ViewBag.ListHHTM = lstHHTM;
            //List Hang Demo moi nhat
            var lstUnknow = db.SanPham.Where(n => n.MaLoaiSP == 5 && n.Moi == 1 && n.DaXoa == false);
            ViewBag.ListUn = lstUnknow;
            return View();
        }
        public ActionResult BannerPartial()
        {
            return PartialView();
        }

        public ActionResult ContentBotPartial()
        {
            return PartialView();
        }
        public ActionResult MenuPartial()
        {
            var lstSP = db.SanPham;
            return PartialView(lstSP);
        }


        public ActionResult HeaderTopPartial()
        {
            return PartialView();
        }

        [HttpPost]
        public ActionResult DangKy(ThanhVien tv)
        {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            // kiểm tra captcha hợp lệ
           
                if (ModelState.IsValid)
                {
                    ViewBag.ThongBao = "Bạn đã đăng ký thành công";
                    db.ThanhVien.Add(tv);
                    db.SaveChanges();
                   
                }
                else
                {
                    ViewBag.Thongbao = "Đăng ký thất bại";
                }
            
            return View();
        }

        [HttpGet]
        public ActionResult DangKy() {
            ViewBag.CauHoi = new SelectList(LoadCauHoi());
            return View();        
        }
        
        public List<String> LoadCauHoi()
        {
            List<String> lstCauHoi = new List<string>();
            lstCauHoi.Add("Con vật mà bạn yêu thích ?");
            lstCauHoi.Add("Ca sĩ mà bạn yêu thích ?");
            lstCauHoi.Add("Hien tại bạn đang làm công việc gì");
            return lstCauHoi;
        }

        [HttpPost]
        public ActionResult DangNhap(FormCollection f) {
            //kiem tra ten dang nhap va mạt khau
            string sTaiKhoan = f["txtTenDangNhap"].ToString();
            string sMatKhau = f["txtMatKhau"].ToString();

            ThanhVien tv = db.ThanhVien.SingleOrDefault(n => n.TaiKhoan == sTaiKhoan && n.MatKhau == sMatKhau);

            if (tv != null) // neu nhu bien thanh vien # rong ==> la co thanh vien do
            {
                Session["TaiKhoan"] = tv;
                return Content("<script>window.location.reload();</script>");
            }

            return Content("Tài Khoản hoặc mật khẩu không đúng", "text/html");
        }

        public ActionResult DangXuat()
        {
            Session["TaiKhoan"] = null;
            return RedirectToAction("Index");
        }
        
    }
}