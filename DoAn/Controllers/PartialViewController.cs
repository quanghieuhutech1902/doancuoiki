using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;

namespace DoAn.Controllers
{
    public class PartialViewController : Controller
    {
        //danhmucSP
        WebCayCanhEntities db = new WebCayCanhEntities();
        public PartialViewResult DMSPPartial()
        {
            return PartialView(db.DMSP.ToList());
        }

        //capnhatcaymoi
        public PartialViewResult CayMoiPartial()
        {
            return PartialView(db.SANPHAM.Where(n => n.Moi == 1).Take(5).ToList());
        }
        //danhmucaycanh
        public PartialViewResult DMCayPartial()
        {
            return PartialView(db.DMSP.ToList());
        }
        //listchinhsach
        public ActionResult DMCHINHSACHPartial()
        {
            return PartialView(db.DMCHINHSACH.ToList());
        }
        //listchamsoc
        public ActionResult DMCSPartial()
        {
            return PartialView(db.DMCHAMSOC.ToList());
        }
        //baivietcaycanhmoi
        public ActionResult BaiVietCCPartial()
        {
            return PartialView(db.TINTUC.Take(3).ToList());
        }
    }
}