using System;
using System.Text;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class EnCodeController : Controller
    {
        // GET: EnCode
        public ActionResult Index(string text)
        {
            if (text != null)
            {
                byte[] data = Encoding.ASCII.GetBytes(text);
                string encodedText = Convert.ToBase64String(data);
                TempData["Mes"] = encodedText;
                return View();
            }
            return View();
        }
    }
}