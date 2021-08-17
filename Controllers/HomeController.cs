using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index(string lang)
        {
            string myLang = this.Request.UserLanguages[0];
            string myLocal = Request.UserAgent;

            ViewBag.MyLanguage = myLang;
            ViewBag.MyLocal = myLocal;
            if (lang == null)
            {
                return View();
            }
            if (lang.Contains("vi"))
            {
                return View("Index");
            }
            if (lang.Contains("en"))
            {
                return View("Index_EN");
            }
            //if (myLang.Contains("fr"))
            //{
            //    return View("Index_Fr");
            //}
            //if (myLang.Contains("chi"))
            //{
            //    return View("Index_China");
            //}
            return View();
        }
    }
}