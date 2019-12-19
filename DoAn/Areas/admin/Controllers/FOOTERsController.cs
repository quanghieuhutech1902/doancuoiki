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
    public class FOOTERsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        // GET: admin/FOOTERs
        public ActionResult Index()
        {
            return View(db.FOOTER.ToList());
        }

        // GET: admin/FOOTERs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOTER fOOTER = db.FOOTER.Find(id);
            if (fOOTER == null)
            {
                return HttpNotFound();
            }
            return View(fOOTER);
        }

        // GET: admin/FOOTERs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/FOOTERs/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,NoiDung,TinhTrang")] FOOTER fOOTER)
        {
            if (ModelState.IsValid)
            {
                db.FOOTER.Add(fOOTER);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(fOOTER);
        }

        // GET: admin/FOOTERs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOTER fOOTER = db.FOOTER.Find(id);
            if (fOOTER == null)
            {
                return HttpNotFound();
            }
            return View(fOOTER);
        }

        // POST: admin/FOOTERs/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,NoiDung,TinhTrang")] FOOTER fOOTER)
        {
            if (ModelState.IsValid)
            {
                db.Entry(fOOTER).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(fOOTER);
        }

        // GET: admin/FOOTERs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            FOOTER fOOTER = db.FOOTER.Find(id);
            if (fOOTER == null)
            {
                return HttpNotFound();
            }
            return View(fOOTER);
        }

        // POST: admin/FOOTERs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            FOOTER fOOTER = db.FOOTER.Find(id);
            db.FOOTER.Remove(fOOTER);
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
