using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;
using System.IO;
using ImageResizer;
using DoAn.App_Start;

namespace DoAn.Areas.admin.Controllers
{
    public class TINTUCsController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();
        public string urlImage = "/files/image/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";

        public string UploadImage(HttpPostedFileBase hinhanh)
        {
            string pic = Path.GetFileName(hinhanh.FileName);
            string pfull = System.IO.Path.Combine(Server.MapPath(urlImage));
            if (!Directory.Exists(pfull))
                Directory.CreateDirectory(pfull);
            string path = System.IO.Path.Combine(Server.MapPath(urlImage), pic);

            hinhanh.SaveAs(path);
            ResizeSettings resizeSetting = new ResizeSettings
            {
                Width = 320,
                Height = 320,
                Format = "png"
            };
            ImageBuilder.Current.Build(path, path, resizeSetting);
            return urlImage + pic;
        }

        public ActionResult Index()
        {
            var tINTUC = db.TINTUC.Include(t => t.DMTT);
            return View(tINTUC.ToList());
        }

        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = db.TINTUC.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
        }


        public ActionResult Create()
        {
            ViewBag.DMTT_ID = new SelectList(db.DMTT, "ID", "TenDMTT");
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(TINTUC tINTUC, HttpPostedFileBase hinhanh)
        {
            try
            {
                if (hinhanh != null)
                {
                    tINTUC.HinhAnh = UploadImage(hinhanh);
                }
                else
                {
                    tINTUC.HinhAnh = "https://png.pngtree.com/png-clipart/20190611/original/pngtree-404-hand-painted-pattern-png-image_2805465.jpg";
                }
                tINTUC.Alias = ConfigWeb.convertToUnSign3(tINTUC.TenTinTuc);
                db.TINTUC.Add(tINTUC);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {

            }
            ViewBag.DMTT_ID = new SelectList(db.DMTT, "ID", "TenDMTT", tINTUC.DMTT_ID);
            return View(tINTUC);
        }


        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = db.TINTUC.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            ViewBag.DMTT_ID = new SelectList(db.DMTT, "ID", "TenDMTT", tINTUC.DMTT_ID);
            return View(tINTUC);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(TINTUC tINTUC, HttpPostedFileBase hinhanh)
        {
            try
            {
                if (hinhanh != null)
                {
                    tINTUC.HinhAnh = UploadImage(hinhanh);
                }
                 
                tINTUC.Alias = ConfigWeb.convertToUnSign3(tINTUC.TenTinTuc);
                db.Entry(tINTUC).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                ViewBag.DMTT_ID = new SelectList(db.DMTT, "ID", "TenDMTT", tINTUC.DMTT_ID);
                return View(tINTUC);
            }

        }


        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            TINTUC tINTUC = db.TINTUC.Find(id);
            if (tINTUC == null)
            {
                return HttpNotFound();
            }
            return View(tINTUC);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            TINTUC tINTUC = db.TINTUC.Find(id);
            db.TINTUC.Remove(tINTUC);
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
