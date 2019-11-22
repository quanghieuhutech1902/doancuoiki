using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DoAn.Models;


namespace DoAn.Controllers
{

    public class HomeController : Controller
    {

        WebCayCanhEntities db = new WebCayCanhEntities();

        public ActionResult Index()
        {
            return View();
        }
  

    }
}