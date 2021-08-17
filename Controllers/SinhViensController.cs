using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class SinhViensController : Controller
    {
        private SinhVien_Context db = new SinhVien_Context();

        // GET: SinhViens
        public ActionResult Index()
        {
            var sinhviens = db.sinhviens.Include(s => s.LopHoc);
            return View(sinhviens.ToList());
        }

        // GET: SinhViens/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.sinhviens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // GET: SinhViens/Create
        public ActionResult Create()
        {
            ViewBag.LopHocId = new SelectList(db.lopHocs, "LopHocId", "LopHocName");
            return View();
        }

        // POST: SinhViens/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "SinhVienId,SinhName,SinhVienEmail,LopHocId")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.sinhviens.Add(sinhVien);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.LopHocId = new SelectList(db.lopHocs, "LopHocId", "LopHocName", sinhVien.LopHocId);
            return View(sinhVien);
        }

        // GET: SinhViens/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.sinhviens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            ViewBag.LopHocId = new SelectList(db.lopHocs, "LopHocId", "LopHocName", sinhVien.LopHocId);
            return View(sinhVien);
        }

        // POST: SinhViens/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "SinhVienId,SinhName,SinhVienEmail,LopHocId")] SinhVien sinhVien)
        {
            if (ModelState.IsValid)
            {
                db.Entry(sinhVien).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.LopHocId = new SelectList(db.lopHocs, "LopHocId", "LopHocName", sinhVien.LopHocId);
            return View(sinhVien);
        }

        // GET: SinhViens/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            SinhVien sinhVien = db.sinhviens.Find(id);
            if (sinhVien == null)
            {
                return HttpNotFound();
            }
            return View(sinhVien);
        }

        // POST: SinhViens/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            SinhVien sinhVien = db.sinhviens.Find(id);
            db.sinhviens.Remove(sinhVien);
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
