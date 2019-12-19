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
    public class DMKMsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/DMKMs
        public ActionResult Index()
        {
            return View(db.DMKM.ToList());
        }

        // GET: admin/DMKMs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMKM dMKM = db.DMKM.Find(id);
            if (dMKM == null)
            {
                return HttpNotFound();
            }
            return View(dMKM);
        }

        // GET: admin/DMKMs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/DMKMs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenKM,TuKhoa,TieuDeSeo")] DMKM dMKM)
        {
            if (ModelState.IsValid)
            {
                db.DMKM.Add(dMKM);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMKM);
        }

        // GET: admin/DMKMs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMKM dMKM = db.DMKM.Find(id);
            if (dMKM == null)
            {
                return HttpNotFound();
            }
            return View(dMKM);
        }

        // POST: admin/DMKMs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenKM,TuKhoa,TieuDeSeo")] DMKM dMKM)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMKM).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMKM);
        }

        // GET: admin/DMKMs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMKM dMKM = db.DMKM.Find(id);
            if (dMKM == null)
            {
                return HttpNotFound();
            }
            return View(dMKM);
        }

        // POST: admin/DMKMs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DMKM dMKM = db.DMKM.Find(id);
            db.DMKM.Remove(dMKM);
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
