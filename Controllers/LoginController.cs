using System;
using System.Collections;
using System.Data;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            ArrayList cultureNameList = new ArrayList();
            CultureInfo[] cInfo = CultureInfo.GetCultures(CultureTypes.AllCultures);
            foreach (CultureInfo cultures in cInfo)
            {
                cultureNameList.Add(String.Format("Culture Name {0}: Display Name {1}",
                    cultures.Name, cultures.DisplayName));

            }
            ViewBag.List = cultureNameList;
            ViewBag.Mes = TempData["Mes"];
            return View();
        }
        public ActionResult Create(string user, string pass)
        {
            try
            {
                var uName = user;
                var uPass = pass;

                SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=TestSecurity;Integrated Security=True");
                string sql = "select * from Users where UserName = '" + uName + "' and UserPass = '" + uPass + "'";

                //String sql = "select * from User_Table where username = @username and userpass = @userpass";
                //exec = new SqlCommand(sql, con);
                //con.Open();
                //exec.Parameters.AddWithValue("@username", uName);
                //exec.Parameters.AddWithValue("@userpass", uPass);

                con.Open();
                SqlDataAdapter adapter = new SqlDataAdapter(sql, con);
                DataTable dt = new DataTable();
                adapter.Fill(dt);
                if (uName == null || uPass == null)
                {
                    return View();
                }
                if (dt.Rows.Count > 0)
                {
                    TempData["AlertType"] = "alert-success";
                    TempData["Mes"] = "Đăng nhập thành công";
                    //return RedirectToAction("Index");
                }
                else
                {
                    TempData["AlertType"] = "alert-warning";
                    TempData["Mes"] = "Đăng nhập không thành công";
                    //return RedirectToAction("Index");
                }
                con.Close();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}