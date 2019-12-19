using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Areas.admin.Controllers
{
    public class HOADONsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/HOADONs
        public ActionResult Index()
        {
            var hOADON = db.HOADON.Include(h => h.KHACHHANG);
            return View(hOADON.ToList());
        }

        // GET: admin/HOADONs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADON.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // GET: admin/HOADONs/Create
        public ActionResult Create()
        {
            ViewBag.KhachHangID = new SelectList(db.KHACHHANG, "ID", "TenKH");
            return View();
        }

        // POST: admin/HOADONs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,ThoiGian,TongTien,TinhTrang,NhanVienID,KhachHangID,PTTTID,Mota,SoLuongDonHang")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.HOADON.Add(hOADON);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.KhachHangID = new SelectList(db.KHACHHANG, "ID", "TenKH", hOADON.KhachHangID);
            return View(hOADON);
        }

        // GET: admin/HOADONs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADON.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            ViewBag.KhachHangID = new SelectList(db.KHACHHANG, "ID", "TenKH", hOADON.KhachHangID);
            return View(hOADON);
        }

        // POST: admin/HOADONs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,ThoiGian,TongTien,TinhTrang,NhanVienID,KhachHangID,PTTTID,Mota,SoLuongDonHang")] HOADON hOADON)
        {
            if (ModelState.IsValid)
            {
                db.Entry(hOADON).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.KhachHangID = new SelectList(db.KHACHHANG, "ID", "TenKH", hOADON.KhachHangID);
            return View(hOADON);
        }

        // GET: admin/HOADONs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            HOADON hOADON = db.HOADON.Find(id);
            if (hOADON == null)
            {
                return HttpNotFound();
            }
            return View(hOADON);
        }

        // POST: admin/HOADONs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            HOADON hOADON = db.HOADON.Find(id);
            db.HOADON.Remove(hOADON);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
