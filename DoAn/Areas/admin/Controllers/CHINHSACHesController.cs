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
    public class CHINHSACHesController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/CHINHSACHes
        public ActionResult Index()
        {
            var cHINHSACH = db.CHINHSACH.Include(c => c.DMCHINHSACH);
            return View(cHINHSACH.ToList());
        }

        // GET: admin/CHINHSACHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHINHSACH cHINHSACH = db.CHINHSACH.Find(id);
            if (cHINHSACH == null)
            {
                return HttpNotFound();
            }
            return View(cHINHSACH);
        }

        // GET: admin/CHINHSACHes/Create
        public ActionResult Create()
        {
            ViewBag.CHNHSACH_ID = new SelectList(db.DMCHINHSACH, "ID", "TenDM");
            return View();
        }

        // POST: admin/CHINHSACHes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenChinhSach,NoiDung,TuKhoa,CHNHSACH_ID,TieuDeSeo,Alias")] CHINHSACH cHINHSACH)
        {
            if (ModelState.IsValid)
            {
                db.CHINHSACH.Add(cHINHSACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CHNHSACH_ID = new SelectList(db.DMCHINHSACH, "ID", "TenDM", cHINHSACH.CHNHSACH_ID);
            return View(cHINHSACH);
        }

        // GET: admin/CHINHSACHes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHINHSACH cHINHSACH = db.CHINHSACH.Find(id);
            if (cHINHSACH == null)
            {
                return HttpNotFound();
            }
            ViewBag.CHNHSACH_ID = new SelectList(db.DMCHINHSACH, "ID", "TenDM", cHINHSACH.CHNHSACH_ID);
            return View(cHINHSACH);
        }

        // POST: admin/CHINHSACHes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenChinhSach,NoiDung,TuKhoa,CHNHSACH_ID,TieuDeSeo,Alias")] CHINHSACH cHINHSACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHINHSACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CHNHSACH_ID = new SelectList(db.DMCHINHSACH, "ID", "TenDM", cHINHSACH.CHNHSACH_ID);
            return View(cHINHSACH);
        }

        // GET: admin/CHINHSACHes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHINHSACH cHINHSACH = db.CHINHSACH.Find(id);
            if (cHINHSACH == null)
            {
                return HttpNotFound();
            }
            return View(cHINHSACH);
        }

        // POST: admin/CHINHSACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHINHSACH cHINHSACH = db.CHINHSACH.Find(id);
            db.CHINHSACH.Remove(cHINHSACH);
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
