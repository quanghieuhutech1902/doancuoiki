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
    public class CTHDsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/CTHDs
        public ActionResult Index()
        {
            var cTHD = db.CTHD.Include(c => c.HOADON).Include(c => c.SANPHAM);
            return View(cTHD.ToList());
        }

        // GET: admin/CTHDs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHD cTHD = db.CTHD.Find(id);
            if (cTHD == null)
            {
                return HttpNotFound();
            }
            return View(cTHD);
        }

        // GET: admin/CTHDs/Create
        public ActionResult Create()
        {
            ViewBag.HoaDonID = new SelectList(db.HOADON, "ID", "Mota");
            ViewBag.SanPhamID = new SelectList(db.SANPHAM, "ID", "TenSP");
            return View();
        }

        // POST: admin/CTHDs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,SanPhamID,SL,HoaDonID")] CTHD cTHD)
        {
            if (ModelState.IsValid)
            {
                db.CTHD.Add(cTHD);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.HoaDonID = new SelectList(db.HOADON, "ID", "Mota", cTHD.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SANPHAM, "ID", "TenSP", cTHD.SanPhamID);
            return View(cTHD);
        }

        // GET: admin/CTHDs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHD cTHD = db.CTHD.Find(id);
            if (cTHD == null)
            {
                return HttpNotFound();
            }
            ViewBag.HoaDonID = new SelectList(db.HOADON, "ID", "Mota", cTHD.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SANPHAM, "ID", "TenSP", cTHD.SanPhamID);
            return View(cTHD);
        }

        // POST: admin/CTHDs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,SanPhamID,SL,HoaDonID")] CTHD cTHD)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cTHD).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.HoaDonID = new SelectList(db.HOADON, "ID", "Mota", cTHD.HoaDonID);
            ViewBag.SanPhamID = new SelectList(db.SANPHAM, "ID", "TenSP", cTHD.SanPhamID);
            return View(cTHD);
        }

        // GET: admin/CTHDs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CTHD cTHD = db.CTHD.Find(id);
            if (cTHD == null)
            {
                return HttpNotFound();
            }
            return View(cTHD);
        }

        // POST: admin/CTHDs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CTHD cTHD = db.CTHD.Find(id);
            db.CTHD.Remove(cTHD);
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
