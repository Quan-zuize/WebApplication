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
    public class TreesController : Controller
    {
        private Tree_Context db = new Tree_Context();

        // GET: Trees
        public ActionResult Index()
        {
            return View(db.Cay.ToList());
        }

        // GET: Trees/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tree tree = db.Cay.Find(id);
            if (tree == null)
            {
                return HttpNotFound();
            }
            return View(tree);
        }

        // GET: Trees/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Trees/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "TreeId,TreeType,TreeQuantity")] Tree tree)
        {
            if (ModelState.IsValid)
            {
                db.Cay.Add(tree);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(tree);
        }

        // GET: Trees/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tree tree = db.Cay.Find(id);
            if (tree == null)
            {
                return HttpNotFound();
            }
            return View(tree);
        }

        // POST: Trees/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "TreeId,TreeType,TreeQuantity")] Tree tree)
        {
            if (ModelState.IsValid)
            {
                db.Entry(tree).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(tree);
        }

        // GET: Trees/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Tree tree = db.Cay.Find(id);
            if (tree == null)
            {
                return HttpNotFound();
            }
            return View(tree);
        }

        // POST: Trees/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Tree tree = db.Cay.Find(id);
            db.Cay.Remove(tree);
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
