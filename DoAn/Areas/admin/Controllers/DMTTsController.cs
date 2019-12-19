using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
using DoAn.App_Start;

namespace DoAn.Areas.admin.Controllers
{
    public class DMTTsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();

        //lấy toàn bộ danh sách
        public ActionResult Index()
        {
            return View(db.DMTT.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DMTT dMTT)
        {
            try
            {
                dMTT.NgayCN = DateTime.Now;
                dMTT.Alias = ConfigWeb.convertToUnSign3(dMTT.TenDMTT).ToLower();
                db.DMTT.Add(dMTT);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dMTT);
            }
        }

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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DMTT dMTT)
        {
            try
            {
                dMTT.NgayCN = DateTime.Now;
                dMTT.Alias = ConfigWeb.convertToUnSign3(dMTT.TenDMTT).ToLower();
                db.Entry(dMTT).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dMTT);
            }
            
        }

        [HttpPost]
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
