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

    public class GIOITHIEUxController : Controller
    {
        private WebCayCanhEntities db = new WebCayCanhEntities();
        public string urlImage = "/files/image/" + DateTime.Now.Year + "/" + DateTime.Now.Month + "/" + DateTime.Now.Day + "/";
        private object itry;
        private HttpPostedFileBase hinhanh;
        private object gIoiThieu;

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

        // GET: admin/GIOITHIEUx
        public ActionResult Index()
        {
            return View(db.GIOITHIEU.ToList());
        }

        

        // GET: admin/GIOITHIEUx/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: admin/GIOITHIEUx/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(GIOITHIEU gIOITHIEU, HttpPostedFileBase hinhanh)
        {
            try
            {
                if (hinhanh != null)
                {
                    gIOITHIEU.HinhAnh = UploadImage(hinhanh);
                }
                else
                {
                    gIOITHIEU.HinhAnh = "https://png.pngtree.com/png-clipart/20190611/original/pngtree-404-hand-painted-pattern-png-image_2805465.jpg";
                }
                gIOITHIEU.Alias = ConfigWeb.convertToUnSign3(gIOITHIEU.TieuDeSeo);
                db.GIOITHIEU.Add(gIOITHIEU);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View(gIOITHIEU);
            }
            
            
        }

        // GET: admin/GIOITHIEUx/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIOITHIEU gIOITHIEU = db.GIOITHIEU.Find(id);
            if (gIOITHIEU == null)
            {
                return HttpNotFound();
            }
            return View(gIOITHIEU);
        }

       
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(GIOITHIEU gIOITHIEU, HttpPostedFileBase hinhanh)
        {
            try
            {
                if (hinhanh != null)
                {
                    gIOITHIEU.HinhAnh = UploadImage(hinhanh);
                }

                gIOITHIEU.Alias = ConfigWeb.convertToUnSign3(gIOITHIEU.Ten);
                db.Entry(gIOITHIEU).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {  
                return View(gIOITHIEU);
            }
        }

        private string UploadImage(object hinhanh)
        {
            throw new NotImplementedException();
        }

        // GET: admin/GIOITHIEUx/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            GIOITHIEU gIOITHIEU = db.GIOITHIEU.Find(id);
            if (gIOITHIEU == null)
            {
                return HttpNotFound();
            }
            return View(gIOITHIEU);
        }

        // POST: admin/GIOITHIEUx/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            GIOITHIEU gIOITHIEU = db.GIOITHIEU.Find(id);
            db.GIOITHIEU.Remove(gIOITHIEU);
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
