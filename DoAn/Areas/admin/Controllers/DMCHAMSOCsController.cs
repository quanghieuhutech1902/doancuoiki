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
    public class DMCHAMSOCsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/DMCHAMSOCs
        public ActionResult Index()
        {
            return View(db.DMCHAMSOC.ToList());
        }

        // GET: admin/DMCHAMSOCs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMCHAMSOC dMCHAMSOC = db.DMCHAMSOC.Find(id);
            if (dMCHAMSOC == null)
            {
                return HttpNotFound();
            }
            return View(dMCHAMSOC);
        }

        // GET: admin/DMCHAMSOCs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/DMCHAMSOCs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,TenDM,Tukhoa,TieuDeSeo")] DMCHAMSOC dMCHAMSOC)
        {
            if (ModelState.IsValid)
            {
                db.DMCHAMSOC.Add(dMCHAMSOC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(dMCHAMSOC);
        }

        // GET: admin/DMCHAMSOCs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMCHAMSOC dMCHAMSOC = db.DMCHAMSOC.Find(id);
            if (dMCHAMSOC == null)
            {
                return HttpNotFound();
            }
            return View(dMCHAMSOC);
        }

        // POST: admin/DMCHAMSOCs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,TenDM,Tukhoa,TieuDeSeo")] DMCHAMSOC dMCHAMSOC)
        {
            if (ModelState.IsValid)
            {
                db.Entry(dMCHAMSOC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(dMCHAMSOC);
        }

        // GET: admin/DMCHAMSOCs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMCHAMSOC dMCHAMSOC = db.DMCHAMSOC.Find(id);
            if (dMCHAMSOC == null)
            {
                return HttpNotFound();
            }
            return View(dMCHAMSOC);
        }

        // POST: admin/DMCHAMSOCs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            DMCHAMSOC dMCHAMSOC = db.DMCHAMSOC.Find(id);
            db.DMCHAMSOC.Remove(dMCHAMSOC);
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
