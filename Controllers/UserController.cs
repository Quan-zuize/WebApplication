using System.Web.Mvc;
using WebApplication2.Models;

namespace WebApplication2.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        // GET: User/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: User/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: User/Create
        [HttpPost]
        public ActionResult Create(User user)
        {
            //try
            //{
            //    // TODO: Add insert logic here
            //    int i = 1;
            //    string name = collection["userName"];
            //    string email = collection["userEmail"];
            //    String pass = collection["userPass"];
            //    List<User> users = new List<User>();
            //    User user = new User();
            //    user.UserID = i;
            //    user.UserName = name;
            //    user.UserEmail = email;
            //    user.UserPass = pass;
            //    users.Add(user);
            //    TempData["User"] = user;
            //    ViewBag.List = users;
            //    i++;
            //    return RedirectToAction("Index");
            //}
            //catch
            //{
            //    return View();
            //}
            return View("Details");
        }

        // GET: User/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: User/Edit/5
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

        // GET: User/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: User/Delete/5
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
