using PagedList;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class ExamsController : Controller
    {
        private School_Context db = new School_Context();
        // GET: Exams

        public ActionResult Index(string option, string search, string subject, int? Page_No)
        {
            var exams = from a in db.Exams
                        join b in db.Students on a.StudentId equals b.StudentId
                        join c in db.Subjects on a.SubjectId equals c.SubjectId
                        select a;

            var subjectQry = from d in db.Subjects orderby d.SubjectId select d.SubjectName;
            var subjectList = new List<String>();
            subjectList.AddRange(subjectQry.Distinct());
            ViewBag.subject = new SelectList(subjectList);

            if (!String.IsNullOrEmpty(subject)){
                exams = exams.Where(a => a.Subjects.SubjectName.Equals(subject));
            }

            if (!String.IsNullOrEmpty(search))
            {
                exams = exams.Where(a => a.Students.StudentName.Contains(search));
            }

            switch (option)
            {
                case "pass":
                    exams = exams.Where(X => X.Mark >= 40 );
                    break;
                case "fail":
                    exams = exams.Where(X => X.Mark < 40);
                    break;
                default:
                    break;
            }
            int Page_Size = 4;
            int No_Of_Page = (Page_No ?? 1);
            return View(exams.ToPagedList(No_Of_Page, Page_Size));
        }

        // GET: Exams/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // GET: Exams/Create
        public ActionResult Create()
        {
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName");
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName");
            return View();
        }

        // POST: Exams/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ExamId,SubjectId,StudentId,Mark")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Exams.Add(exam);
                db.SaveChanges();
                TempData["AlertMessage"] = "Create succesfully ";
                return RedirectToAction("Index");
            }

            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", exam.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", exam.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", exam.SubjectId);
            return View(exam);
        }

        // POST: Exams/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ExamId,SubjectId,StudentId,Mark")] Exam exam)
        {
            if (ModelState.IsValid)
            {
                db.Entry(exam).State = EntityState.Modified;
                db.SaveChanges();
                TempData["AlertMessage"] = "Edit succesfully ";
                return RedirectToAction("Index");
            }
            ViewBag.StudentId = new SelectList(db.Students, "StudentId", "StudentName", exam.StudentId);
            ViewBag.SubjectId = new SelectList(db.Subjects, "SubjectId", "SubjectName", exam.SubjectId);
            return View(exam);
        }

        // GET: Exams/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Exam exam = db.Exams.Find(id);
            if (exam == null)
            {
                return HttpNotFound();
            }
            return View(exam);
        }

        // POST: Exams/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]

        public ActionResult DeleteConfirmed(int id)
        {
            Exam exam = db.Exams.Find(id);
            db.Exams.Remove(exam);
            db.SaveChanges();
            TempData["AlertMessage"] = "Delete succesfully ";
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
