using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Sess;
using IS.localcomm;
namespace nerp.Controllers
{
    public class TinyMceController : Controller
    {
        session ses = new session();
        localcommonlib com = new localcommonlib();
        // GET: TinyMce
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateInput(false)]
        public ActionResult Index(string data)
        {
            var message = "Hello " + data;
            return Content(message);
        }


        public JsonResult TinyMceUpload()
        {
            
            var ret = 0;
            const int megabyte = 1024 * 1024;
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files[0];
            var extension = Path.GetExtension(file.FileName.ToLowerInvariant());
            string[] extensions = { ".gif", ".jpg", ".png", ".svg", ".webp", ".mp3", ".mp4" };
            if (!extensions.Contains(extension))
            {
                ret = -1;
            //    throw new InvalidOperationException("Invalid file extension.");
            }
            var fileN = Path.GetFileName(file.FileName);
            // var fileName = Guid.NewGuid() + extension;
            var fileName = DateTime.Now.ToString("ddMMyyyy_HHmmss") + extension;
            int year, month, day;
            year = DateTime.Now.Year;
            month = DateTime.Now.Month;
            day = DateTime.Now.Day;
            var targetFolder = Server.MapPath(string.Format("~/ContentQuestion/{0}/{1}/{2}", year, month, day));

            if (!Directory.Exists(targetFolder))
            {
                Directory.CreateDirectory(targetFolder);
            }
            var realfilename = com.checkFileName(targetFolder, file.FileName);
            var path = Path.Combine(targetFolder, realfilename);
            file.SaveAs(path);
            var location = Path.Combine(string.Format("/ContentQuestion/{0}/{1}/{2}",year, month, day), realfilename).Replace('\\', '/');
            if (ses.tSOURCEPATHSESSION == null)
                ses.tSOURCEPATHSESSION = new List<string>();
            ses.tSOURCEPATHSESSION.Add(files.AllKeys[0]);
            if (ses.tDESTINATIONPATHSESSION == null)
                ses.tDESTINATIONPATHSESSION = new List<string>();
            ses.tDESTINATIONPATHSESSION.Add(location);
            return Json(new { location = location, ret = ret }, JsonRequestBehavior.AllowGet);
        }
        [HttpPost, ValidateInput(false)]
        public JsonResult DeleteFile(string contentTiny)
        {

            var ret = 0;
            if (ses.tSOURCEPATHSESSION != null)
            {
                ret = 1;
                for (int i = 0; i < ses.tSOURCEPATHSESSION.Count; i++)
                {
                    if (ses.tSOURCEPATHSESSION[i] != "file")
                    {
                        var targetFolder = AppDomain.CurrentDomain.BaseDirectory;
                        var path = (targetFolder + ses.tDESTINATIONPATHSESSION[i]).Replace('\\', '/');
                        if (!contentTiny.Contains(ses.tSOURCEPATHSESSION[i].Substring(1)) && !contentTiny.Contains(ses.tDESTINATIONPATHSESSION[i].Substring(1)))

                            System.IO.File.Delete(path);
                    }
                }
            }
            else ret = 0;
            
            return Json(new {ret = ret }, JsonRequestBehavior.AllowGet);
        }
    }
}
