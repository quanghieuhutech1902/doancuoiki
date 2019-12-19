using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

// nén dữ liệu
// Tối ưu model

namespace DoAn.Controllers
{
    public class ProductsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // Lấy danh sách sản phẩm tất cả
        public ActionResult Index()
        {
            List<SANPHAM> lst = new List<SANPHAM> ();
            lst = db.SANPHAM.ToList();
            return View(lst);
        }
        // lấy dánh sách sản phảm theo danh mục (DMSP_ID)
        public ActionResult GetProductByDMSP_ID(int? id)
        {
            ViewBag.tenDanhMuc = db.DMSP.Find(id).TenLoai;
            List<SANPHAM> lst = new List<SANPHAM>();
            lst = db.SANPHAM.Where(s=>s.DMSP_ID== id).ToList();
            return View(lst);
        }

        //Lấy thông tin chi tiết sản phẩm
        public ActionResult XemChiTiet(int id)
        {
            SANPHAM sanpham = db.SANPHAM.SingleOrDefault(n => n.ID == id);
            if (sanpham == null)
            {
                Response.StatusCode = 404;
                return null;
            }
            return View(sanpham);
        }
    }
}