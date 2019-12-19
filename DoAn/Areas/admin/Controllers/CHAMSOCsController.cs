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
    public class CHAMSOCsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/CHAMSOCs
        public ActionResult Index()
        {
            var cHAMSOC = db.CHAMSOC.Include(c => c.DMCHAMSOC);
            return View(cHAMSOC.ToList());
        }

        // GET: admin/CHAMSOCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHAMSOC cHAMSOC = db.CHAMSOC.Find(id);
            if (cHAMSOC == null)
            {
                return HttpNotFound();
            }
            return View(cHAMSOC);
        }

        // GET: admin/CHAMSOCs/Create
        public ActionResult Create()
        {
            ViewBag.CS_ID = new SelectList(db.DMCHAMSOC, "ID", "TenDM");
            return View();
        }

        // POST: admin/CHAMSOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenCachChamSoc,MoTa,TuKhoa,CS_ID,TieuDeSeo,Alias")] CHAMSOC cHAMSOC)
        {
            if (ModelState.IsValid)
            {
                db.CHAMSOC.Add(cHAMSOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CS_ID = new SelectList(db.DMCHAMSOC, "ID", "TenDM", cHAMSOC.CS_ID);
            return View(cHAMSOC);
        }

        // GET: admin/CHAMSOCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHAMSOC cHAMSOC = db.CHAMSOC.Find(id);
            if (cHAMSOC == null)
            {
                return HttpNotFound();
            }
            ViewBag.CS_ID = new SelectList(db.DMCHAMSOC, "ID", "TenDM", cHAMSOC.CS_ID);
            return View(cHAMSOC);
        }

        // POST: admin/CHAMSOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenCachChamSoc,MoTa,TuKhoa,CS_ID,TieuDeSeo,Alias")] CHAMSOC cHAMSOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(cHAMSOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CS_ID = new SelectList(db.DMCHAMSOC, "ID", "TenDM", cHAMSOC.CS_ID);
            return View(cHAMSOC);
        }

        // GET: admin/CHAMSOCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            CHAMSOC cHAMSOC = db.CHAMSOC.Find(id);
            if (cHAMSOC == null)
            {
                return HttpNotFound();
            }
            return View(cHAMSOC);
        }

        // POST: admin/CHAMSOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            CHAMSOC cHAMSOC = db.CHAMSOC.Find(id);
            db.CHAMSOC.Remove(cHAMSOC);
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
