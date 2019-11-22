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
    public class DMTTsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/DMTTs
        public ActionResult Index()
        {
            return View(db.DMTT.ToList());
        }

        // GET: admin/DMTTs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTT dMTT = db.DMTT.Find(id);
            if (dMTT == null)
            {
                return HttpNotFound();
            }
            return View(dMTT);
        }

        // GET: admin/DMTTs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/DMTTs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenDMTT,NgayCN,MoTa,TuKhoa,TieuDeSeo")] DMTT dMTT)
        {
            if (ModelState.IsValid)
            {
                db.DMTT.Add(dMTT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMTT);
        }

        // GET: admin/DMTTs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTT dMTT = db.DMTT.Find(id);
            if (dMTT == null)
            {
                return HttpNotFound();
            }
            return View(dMTT);
        }

        // POST: admin/DMTTs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenDMTT,NgayCN,MoTa,TuKhoa,TieuDeSeo")] DMTT dMTT)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMTT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMTT);
        }

        // GET: admin/DMTTs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMTT dMTT = db.DMTT.Find(id);
            if (dMTT == null)
            {
                return HttpNotFound();
            }
            return View(dMTT);
        }

        // POST: admin/DMTTs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DMTT dMTT = db.DMTT.Find(id);
            db.DMTT.Remove(dMTT);
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
