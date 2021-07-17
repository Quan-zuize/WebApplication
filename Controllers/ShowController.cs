using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class ShowController : Controller
    {
        // GET: Show
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Login()
        {
            return View();
        }
        public ActionResult ShowData()
        {
            ViewData["svName"] = Request.Form["svName"];
            ViewData["svEmail"] = Request.Form["svEmail"];
            ViewData["svPhone"] = Request.Form["svPhone"];
            return View();
        }
    }
}