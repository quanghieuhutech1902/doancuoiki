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
    public class DMSPsController : Controller
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
            return View(db.DMSP.ToList());
        }

       

        public ActionResult Create()
        {
            return View();
        }

        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(DMSP dMSP, HttpPostedFileBase hinhanh)
        {
            try
            {
                if (hinhanh != null)
                {
                    dMSP.HinhAnh = UploadImage(hinhanh);
                }
                else
                {
                    dMSP.HinhAnh = "https://png.pngtree.com/png-clipart/20190611/original/pngtree-404-hand-painted-pattern-png-image_2805465.jpg";
                }
                dMSP.Alias = ConfigWeb.convertToUnSign3(dMSP.TenLoai);
                db.DMSP.Add(dMSP);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(dMSP);
            }
            
        }

        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            DMSP dMSp = db.DMSP.Find(id);
            if (dMSp == null)
            {
                return HttpNotFound();
            }
            
            return View(dMSp);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(DMSP dMSP, HttpPostedFileBase hinhanh)
        {
            try
            {
                if (hinhanh != null)
                {
                    dMSP.HinhAnh = UploadImage(hinhanh);
                }

                dMSP.Alias = ConfigWeb.convertToUnSign3(dMSP.TenLoai);
                db.Entry(dMSP).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                
                return View(dMSP);
            }

        }


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
