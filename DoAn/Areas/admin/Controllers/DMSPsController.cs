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
    public class DMSPsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/DMSPs
        public ActionResult Index()
        {
            return View(db.DMSP.ToList());
        }

        // GET: admin/DMSPs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSP dMSP = db.DMSP.Find(id);
            if (dMSP == null)
            {
                return HttpNotFound();
            }
            return View(dMSP);
        }

        // GET: admin/DMSPs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/DMSPs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenLoai,TieuDeSeo,TuKhoa,XoaTam")] DMSP dMSP)
        {
            if (ModelState.IsValid)
            {
                db.DMSP.Add(dMSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMSP);
        }

        // GET: admin/DMSPs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSP dMSP = db.DMSP.Find(id);
            if (dMSP == null)
            {
                return HttpNotFound();
            }
            return View(dMSP);
        }

        // POST: admin/DMSPs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenLoai,TieuDeSeo,TuKhoa,XoaTam")] DMSP dMSP)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMSP);
        }

        // GET: admin/DMSPs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSP dMSP = db.DMSP.Find(id);
            if (dMSP == null)
            {
                return HttpNotFound();
            }
            return View(dMSP);
        }

        // POST: admin/DMSPs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DMSP dMSP = db.DMSP.Find(id);
            db.DMSP.Remove(dMSP);
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
