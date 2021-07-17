using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class LopHocsController : Controller
    {
        private SinhVien_Context db = new SinhVien_Context();

        // GET: LopHocs
        public ActionResult Index()
        {
            return View(db.lopHocs.ToList());
        }

        // GET: LopHocs/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHoc lopHoc = db.lopHocs.Find(id);
            if (lopHoc == null)
            {
                return HttpNotFound();
            }
            return View(lopHoc);
        }

        // GET: LopHocs/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: LopHocs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "LopHocId,LopHocName")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                db.lopHocs.Add(lopHoc);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(lopHoc);
        }

        // GET: LopHocs/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHoc lopHoc = db.lopHocs.Find(id);
            if (lopHoc == null)
            {
                return HttpNotFound();
            }
            return View(lopHoc);
        }

        // POST: LopHocs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "LopHocId,LopHocName")] LopHoc lopHoc)
        {
            if (ModelState.IsValid)
            {
                db.Entry(lopHoc).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(lopHoc);
        }

        // GET: LopHocs/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            LopHoc lopHoc = db.lopHocs.Find(id);
            if (lopHoc == null)
            {
                return HttpNotFound();
            }
            return View(lopHoc);
        }

        // POST: LopHocs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            LopHoc lopHoc = db.lopHocs.Find(id);
            db.lopHocs.Remove(lopHoc);
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
