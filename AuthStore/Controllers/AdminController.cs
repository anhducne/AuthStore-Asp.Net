using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthStore.Models;

namespace AuthStore.Controllers
{
    public class AdminController : Controller
    {
        // GET: Admin
        AuthenEntities db = new AuthenEntities();
        public ActionResult Index()
        {
            return View(db.SanPham.Where(n => n.DaXoa == false).OrderByDescending(n => n.MaSP));
        }
        [HttpGet]
        public ActionResult TaoMoiSanPham()
        {
            // load dropdownlist nhà cung cấp và dropdownlist loại sản phẩm, mã nhà sản xuất
            ViewBag.MaNCC = new SelectList(db.NhaCungCap.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPham.OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "TenLoai");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuat.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX");
            return View();
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult TaoMoiSanPham(SanPham sp, HttpPostedFileBase HinhAnh)
        {
            // Load dropdownlist nhà cung caaos và drop diwnlist loại sản phâmr
            ViewBag.MaNCC = new SelectList(db.NhaCungCap.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC");
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPham.OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "TenLoai");
            ViewBag.MaNSX = new SelectList(db.NhaSanXuat.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX");
            //Kiem tra xem hinh anh ton tai trong csdl chua
            //if (HinhAnh.ContentLength > 0)
            //{
            //    //lay ten hinh anh 
            //    var fileName = Path.GetFileName(HinhAnh.FileName);
            //    //lay hinh anh chuyen vao thu muc chua hinh anh cua he thong, đây là đường dẫn để lưu ảnh vào
            //    var path = Path.Combine(Server.MapPath("~/Content/images/product/"),fileName);
            //    //Neu thư muc chua hinh anh đó rồi thì xuất ra thông báo
            //    if (System.IO.File.Exists(path))
            //    {
            //        ViewBag.upload = "Hinh đã tồn tại";
            //        return View();
            //    }
            //    else
            //    {
            //        // lấy hình ảnh rồi đưa vào thư mục product
            //        HinhAnh.SaveAs(path);
            //        sp.HinhAnh = fileName;
            //    } 
            //}
            db.SanPham.Add(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    // Chỉnh sửa sản phẩm 
    [HttpGet]
        public ActionResult ChinhSuaSanPham(int? MaSP)
        {
            if (MaSP == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == MaSP);
            if (sp == null)
            {
                return HttpNotFound();
            }
            //load dropdownlist nhà cung cấp, loại sản phẩm, nhà sản xuất
            ViewBag.MaNCC = new SelectList(db.NhaCungCap.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", sp.MaNCC);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPham.OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "TenLoai", sp.MaLoaiSP);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuat.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX", sp.MaNSX);
            return View(sp);
        }
        [ValidateInput(false)]
        [HttpPost]
        public ActionResult ChinhSuaSanPham (SanPham model)
        {
            ViewBag.MaNCC = new SelectList(db.NhaCungCap.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", model.MaNCC);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPham.OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "TenLoai", model.MaLoaiSP);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuat.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX", model.MaNSX);
            db.Entry(model).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
        }


        // Xóa sản phẩm 
        [HttpGet]
        public ActionResult XoaSanPham(int? id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            //load dropdownlist nhà cung cấp, loại sản phẩm, nhà sản xuất
            ViewBag.MaNCC = new SelectList(db.NhaCungCap.OrderBy(n => n.TenNCC), "MaNCC", "TenNCC", sp.MaNCC);
            ViewBag.MaLoaiSP = new SelectList(db.LoaiSanPham.OrderBy(n => n.MaLoaiSP), "MaLoaiSP", "TenLoai", sp.MaLoaiSP);
            ViewBag.MaNSX = new SelectList(db.NhaSanXuat.OrderBy(n => n.MaNSX), "MaNSX", "TenNSX", sp.MaNSX);
            return View(sp);
        }
 
        [HttpPost]
        public ActionResult XoaSanPham(int id)
        {
            if (id == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == id);
            if (sp == null)
            {
                return HttpNotFound();
            }
            // du lieu dau vao ok
            db.SanPham.Remove(sp);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}