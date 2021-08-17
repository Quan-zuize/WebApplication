using System.IO;
using System.Web;
using System.Web.Mvc;

namespace WebApplication2.Controllers
{
    public class UploadController : Controller
    {
        // GET: Upload
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult UploadFile(HttpPostedFileBase file)
        {
            try
            {
                if (file.ContentLength > 0)
                {
                    string _FileName = Path.GetFileName(file.FileName);

                    string _path = Path.Combine(Server.MapPath("~/UploadedFiles"), _FileName);

                    file.SaveAs(_path);

                    int fileImgSize = file.ContentLength;
                    //int fileDocxSize = file.ContentLength;

                    string fileImgType = file.ContentType;
                    //String fileDocxType = file.ContentType;

                    ViewBag.Message = "File Uploaded Successfully!!";

                    ViewPicture(_path, fileImgSize, fileImgType);
                }
                return View("ViewPicture");
            }
            catch
            {
                ViewBag.Message = "File upload failed!!";
                return View();
            }
        }

        public ActionResult ViewPicture(string _path, int fileImgSize, string fileImgType)
        {
            string filename = _path;
            //string filename2 = docxpath;

            FileInfo fi = new FileInfo(filename);
            //FileInfo fi2 = new FileInfo(filename2);

            //img
            string justFileName = fi.Name;
            ViewBag.Message = justFileName;

            ViewBag.Message1 = fileImgSize;
            ViewBag.Message2 = fileImgType;


            //docx
            //string justFileName2 = fi2.Name;
            //ViewBag.Message2 = justFileName2;
            ///////////////////////////////////////////////////////

            //@ViewBag.Message = _path;
            //@ViewBag.Message1 = fileImgSize;
            //@ViewBag.Message2 = fileImgType;
            return View();
        }
    }
}
