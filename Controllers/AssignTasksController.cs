using PagedList;
using System;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class AssignTasksController : Controller
    {
        private Project_Context db = new Project_Context();

        // GET: AssignTasks
        [OutputCache(Duration = 15, VaryByParam = "none", Location = System.Web.UI.OutputCacheLocation.Client)]
        public ActionResult Index(string search, string department, string company, string status, int? Page_No, string SortOrder)
        {
            //var assignTasks = db.AssignTasks.Include(a => a.Client).Include(a => a.Employee).Include(a => a.Project);
            //ViewBag.department = new SelectList(db.Employees.OrderBy(so => so.EmployeeDepartment).Distinct());
            //ViewBag.company = new SelectList(db.Clients.OrderBy(so => so.ClientCompany).Distinct());

            //ViewBag.department = new SelectList((from d in db.Employees
            //                                     orderby d.EmployeeId
            //                                     select d.EmployeeDepartment).Distinct());
            //ViewBag.company = new SelectList((from c in db.Clients
            //                                  orderby c.ClientId
            //                                  select c.ClientCompany).Distinct());

            int pageSize = 7;
            int pageIndex = (Page_No ?? 1);
            IPagedList<AssignTask> assigns = db.AssignTasks.OrderBy(a => a.Client.ClientName).Include(a => a.Employee).Include(a => a.Project).ToPagedList(pageIndex, pageSize);

            if (!String.IsNullOrEmpty(search))
            {
                assigns = db.AssignTasks.Where(X => X.Employee.EmployeeName.Contains(search) || X.Client.ClientName.Contains(search) || X.Project.ProjectName.Contains(search)).OrderBy(X => X.AssignTaskId).ToPagedList(pageIndex, pageSize);
            }
            else if (!String.IsNullOrEmpty(department))
            {
                assigns = db.AssignTasks.Where(X => (X.Employee.EmployeeName.Contains(search) || X.Client.ClientName.Contains(search) || X.Project.ProjectName.Contains(search)) && X.Employee.EmployeeDepartment.Equals(department)).OrderBy(X => X.AssignTaskId).ToPagedList(pageIndex, pageSize);
            }
            else if (!String.IsNullOrEmpty(company))
            {
                assigns = db.AssignTasks.Where(X => (X.Employee.EmployeeName.Contains(search) || X.Client.ClientName.Contains(search) || X.Project.ProjectName.Contains(search)) && X.Client.ClientCompany.Equals(company)).OrderBy(X => X.AssignTaskId).ToPagedList(pageIndex, pageSize);
            }
            else
            {
                switch (status)
                {
                    case "Notyet":
                        assigns = db.AssignTasks.Where(a => a.Project.ProjectEnd == null
                        || a.Project.ProjectEnd > DateTime.Now).OrderBy(X => X.AssignTaskId).ToPagedList(pageIndex, pageSize);
                        break;
                    case "Done":
                        assigns = db.AssignTasks.Where(a => a.Project.ProjectEnd != null
                        || a.Project.ProjectEnd < DateTime.Now).OrderBy(X => X.AssignTaskId).ToPagedList(pageIndex, pageSize);
                        break;
                    default:
                        break;
                }
            }

            switch (SortOrder)
            {
                case "ClientName":
                    assigns = assigns.OrderByDescending(a => a.Client.ClientName).ToPagedList(pageIndex, pageSize);
                    break;
                case "EmployeeName":
                    assigns = assigns.OrderByDescending(a => a.Employee.EmployeeName).ToPagedList(pageIndex, pageSize);
                    break;
                case "ProjectName":
                    assigns = assigns.OrderByDescending(a => a.Project.ProjectName).ToPagedList(pageIndex, pageSize);
                    break;
                default:
                    break;
            }
            return View(assigns);
        }

        // GET: AssignTasks/Details/5
        [OutputCache(Duration = int.MaxValue, VaryByParam = "id")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignTask assignTask = db.AssignTasks.Find(id);
            if (assignTask == null)
            {
                return HttpNotFound();
            }
            return View(assignTask);
        }

        // GET: AssignTasks/Create
        public ActionResult Create()
        {
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientName");
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName");
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName");
            return View();
        }

        // POST: AssignTasks/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "AssignTaskId,EmployeeId,ClientId,ProjectId,Task,Note")] AssignTask assignTask)
        {
            if (ModelState.IsValid)
            {
                db.AssignTasks.Add(assignTask);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientName", assignTask.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", assignTask.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", assignTask.ProjectId);
            return View(assignTask);
        }

        // GET: AssignTasks/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignTask assignTask = db.AssignTasks.Find(id);
            if (assignTask == null)
            {
                return HttpNotFound();
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientName", assignTask.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", assignTask.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", assignTask.ProjectId);
            return View(assignTask);
        }

        // POST: AssignTasks/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "AssignTaskId,EmployeeId,ClientId,ProjectId,Task,Note")] AssignTask assignTask)
        {
            if (ModelState.IsValid)
            {
                db.Entry(assignTask).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.ClientId = new SelectList(db.Clients, "ClientId", "ClientName", assignTask.ClientId);
            ViewBag.EmployeeId = new SelectList(db.Employees, "EmployeeId", "EmployeeName", assignTask.EmployeeId);
            ViewBag.ProjectId = new SelectList(db.Projects, "ProjectId", "ProjectName", assignTask.ProjectId);
            return View(assignTask);
        }

        // GET: AssignTasks/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            AssignTask assignTask = db.AssignTasks.Find(id);
            if (assignTask == null)
            {
                return HttpNotFound();
            }
            return View(assignTask);
        }

        // POST: AssignTasks/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AssignTask assignTask = db.AssignTasks.Find(id);
            db.AssignTasks.Remove(assignTask);
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
