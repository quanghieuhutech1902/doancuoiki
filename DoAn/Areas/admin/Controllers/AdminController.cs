using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DoAn.Areas.admin.Controllers
{
    public class AdminController : Controller
    {
        // GET: admin/Admin
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Table()
        {
            return View();
        }

        public ActionResult Card()
        {
            return View();
        }

        public ActionResult ChiTietDanhMuc(int id)
        {
            return View();
        }
    }
}