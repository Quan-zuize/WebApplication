using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class TinhToanController : Controller
    {
        // GET: TinhToan
        public ActionResult Index()
        {
            return View();
        }

        // GET: TinhToan/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: TinhToan/Create
        //[HttpGet]
        public ActionResult Create(TinhToan t)
        {
            int so1 = t.a;
            int so2 = t.b;
            int kq = 0;
            string ptinh = t.operation;
            switch (ptinh)
            {
                case "Cộng":
                    kq = so1 + so2;
                    break;
                case "Trừ":
                    kq = so1 - so2;
                    break;
                case "Nhân":
                    kq = so1 * so2;
                    break;
                case "Chia":
                    kq = so1 / so2;
                    break;
            }
            ViewBag.Result = kq;
            return View();
        }

        // POST: TinhToan/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TinhToan/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: TinhToan/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: TinhToan/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: TinhToan/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
