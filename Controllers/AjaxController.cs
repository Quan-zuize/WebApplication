using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class AjaxController : Controller
    {
        // GET: Ajax
        public ActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public JsonResult getStudent()
        {
            var ob = new { name = "Anoymous", age = 28 };
            return Json(ob, JsonRequestBehavior.AllowGet);
        }

        public ActionResult CreateCookie()
        {
            HttpCookie StudentCookies = new HttpCookie("StudentCookies");
            StudentCookies.Value = "Guess ưhat";
            StudentCookies.Expires = DateTime.Now.AddHours(1);
            Response.SetCookie(StudentCookies);
            return View();
        }
        
    }
}