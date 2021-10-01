using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AuthStore.Models;
namespace AuthStore.Controllers
{
    public class SanPhamController : Controller
    {
        AuthenEntities db = new AuthenEntities();
        //tao 2 parrtial view san pham 1 va 2 de hien thi sanpham theo 2 style khac nhau
      
     

        public ActionResult SanPhamStylePartial1()
        {
            return PartialView();
        }
        public ActionResult SanPhamStylePartial2()
        {
            return PartialView();
        }

   
     

        // xây dựng trang xem chi tiết 
        public ActionResult XemChiTiet (int? id, string tensp)
        {

            // Kiểm tra tham số truyền vào có rỗng hay không
            if (id == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            // nếu không thì truy xuất csdl lấy ra sản phẩm tương ứng
            SanPham sp = db.SanPham.SingleOrDefault(n => n.MaSP == id && n.DaXoa == false);
            if (sp == null)
            {
                //Thong báo nếu như không có sản phẩm đó 
                return HttpNotFound();
            }
                return View(sp);
        }

        public ActionResult SanPham(int? MaLoaiSP, int? MaNSX)
        {
            if (MaLoaiSP == null || MaNSX == null)
            {
                return new HttpStatusCodeResult(System.Net.HttpStatusCode.BadRequest);
            }
            //Load  sản phẩm dựa trên 2 tiêu chí là mã loại sản phẩm và mã nhà sản xuất ( trong 2 trường trong bảng sản phẩm ) 
            var lstSP = db.SanPham.Where(n => n.MaLoaiSP == MaLoaiSP && n.MaNSX == MaNSX);    
            if (lstSP.Count() == 0)
            {
                return HttpNotFound();
            }
            return View(lstSP);
        }


    }
}