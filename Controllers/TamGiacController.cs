using System.Data.SqlClient;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class TamGiacController : Controller
    {
        // GET: TamGiac
        public ActionResult Index()
        {
            return View();
        }
        public JsonResult insertdata(string canh1, string canh2, string canh3)
        {
            float a = float.Parse(canh1);
            float b = float.Parse(canh2);
            float c = float.Parse(canh3);
            SqlConnection con = new SqlConnection(@"Data Source=DESKTOP-F1EG3ID\SQLEXPRESS;Initial Catalog=Test;Integrated Security=True");
            SqlCommand cmd = new SqlCommand("insert into TamGiac values(@canh1, @canh2,@canh3)", con);
            cmd.Parameters.AddWithValue("@canh1", a);
            cmd.Parameters.AddWithValue("@canh2", b);
            cmd.Parameters.AddWithValue("@canh3", c);
            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();
            return Json("Đây là tam giác \n Và insert thành công", JsonRequestBehavior.AllowGet);
        }
    }
}