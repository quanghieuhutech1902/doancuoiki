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
    public class DMCHINHSACHesController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/DMCHINHSACHes
        public ActionResult Index()
        {
            return View(db.DMCHINHSACH.ToList());
        }

        // GET: admin/DMCHINHSACHes/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMCHINHSACH dMCHINHSACH = db.DMCHINHSACH.Find(id);
            if (dMCHINHSACH == null)
            {
                return HttpNotFound();
            }
            return View(dMCHINHSACH);
        }

        // GET: admin/DMCHINHSACHes/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/DMCHINHSACHes/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenDM,TuKhoa,TieuDeSeo")] DMCHINHSACH dMCHINHSACH)
        {
            if (ModelState.IsValid)
            {
                db.DMCHINHSACH.Add(dMCHINHSACH);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMCHINHSACH);
        }

        // GET: admin/DMCHINHSACHes/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMCHINHSACH dMCHINHSACH = db.DMCHINHSACH.Find(id);
            if (dMCHINHSACH == null)
            {
                return HttpNotFound();
            }
            return View(dMCHINHSACH);
        }

        // POST: admin/DMCHINHSACHes/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenDM,TuKhoa,TieuDeSeo")] DMCHINHSACH dMCHINHSACH)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMCHINHSACH).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMCHINHSACH);
        }

        // GET: admin/DMCHINHSACHes/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMCHINHSACH dMCHINHSACH = db.DMCHINHSACH.Find(id);
            if (dMCHINHSACH == null)
            {
                return HttpNotFound();
            }
            return View(dMCHINHSACH);
        }

        // POST: admin/DMCHINHSACHes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DMCHINHSACH dMCHINHSACH = db.DMCHINHSACH.Find(id);
            db.DMCHINHSACH.Remove(dMCHINHSACH);
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
