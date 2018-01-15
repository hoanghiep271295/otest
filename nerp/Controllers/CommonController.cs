using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Sess;
using IS.uni;
using IS.fitframework;
using IS.localcomm;
using System.IO;
namespace uni.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        session ses = new session();
        localcommonlib com = new localcommonlib();
//        public ActionResult Index()
//        {
////            uni.Models.CommonMessage obj = new Models.CommonMessage();
//            //obj.link = ses.targetpage;
//            //obj.message = ses.inform;
//            //obj.title = ses.title;
//            //obj.waiting = 1000;// ses.waitingtime;
//            //return View(obj);
//        }
        /// <summary>
        /// Hiển thị phần login hoặc yêu cầu login trong trang chính
        /// </summary>
        /// <returns></returns>
        public ActionResult Login()
        {
            bool isLoged = (!string.IsNullOrEmpty(ses.loginName));
            ViewBag.isloged = isLoged;
            if (isLoged)
            {
                ViewBag.loginImg = string.IsNullOrEmpty(ses.loginImg) ? "noimage.jpg" : ses.loginImg;
                ViewBag.staffname = ses.STAFF.NAME;
                ViewBag.staffdepartmentname = ses.STAFF.DEPARTMENTNAME;
                string img = ses.STAFF.IMG;
                if (string.IsNullOrEmpty(img))
                {
                    img = "/sysimage/logo.jpg";//default is the logo of department
                }
                ViewBag.staffima = img;
            }
            return PartialView();

        }


        public ActionResult Tabmenu()
        {

            if (ses.loginName == "")
            {
                Response.Redirect("/staff/login");
            }
            ViewBag.loginname = ses.loginFullName;
            //List<string> st = new List<string>();
            //st.Add("Menu1");
            //st.Add("Menu2");
            //st.Add("Menu3");
            //SYSMENU_BUS bus = new SYSMENU_BUS();
            //List<SYSMENU_OBJ> li = bus.getAdmin(ses.gUNIVERSITYCODE,ses.getFunctionList());
            //bus.CloseConnection();
            return View();
        }
        public ActionResult Menu()
        {
            SYSMENU_BUS bus = new SYSMENU_BUS();
            string functionlist = ses.getFunctionList();
            List<SYSMENU_OBJ> li = bus.getAdmin(ses.gUNIVERSITYCODE,functionlist);
            foreach (SYSMENU_OBJ obj in li)
            {
                if(string.IsNullOrEmpty(obj.ICON))
                {
                    obj.ICON = "fa-circle-o";
                }
            }
            bus.CloseConnection();
            return View(li);

        }
        public ActionResult MasterTitle()
        {
            ViewBag.title = "Hệ thống hỗ trợ dạy và học tiếng Nga";
            return View();

        }
        /// <summary>
        /// Lấy danh menu của sinh viên
        /// </summary>
        /// <returns></returns>
        public ActionResult Menustudent()
        {
            SYSMENU_BUS bus = new SYSMENU_BUS();
            List<SYSMENU_OBJ> li = bus.getStudent(ses.gUNIVERSITYCODE, ses.getFunctionList());
            bus.CloseConnection();
            return View(li);

        }
        public ActionResult TopMenu()
        {
            SYSMENU_BUS bus = new SYSMENU_BUS();
            List<SYSMENU_OBJ> li = bus.getAdminTop(ses.gUNIVERSITYCODE, ses.getFunctionList());
            bus.CloseConnection();
            return View(li);

        }

        //cho bản chạy ngoài
        //public ActionResult Menu()
        //{
        //    if (ses.loginName == "")
        //    {
        //        Response.Redirect("/staff/login");
        //    }
        //    //ViewBag.loginname = ses.loginFullName;
        //    //List<string> st = new List<string>();
        //    //st.Add("Menu1");
        //    //st.Add("Menu2");
        //    //st.Add("Menu3");
        //    SYSMENU_BUS bus = new SYSMENU_BUS();
        //    List<SYSMENU_OBJ> li = bus.getAdmin(ses.gUNIVERSITYCODE, ses.getFunctionList());
        //    bus.CloseConnection();
        //    return View(li);
        //}
        public ActionResult FontendMenu()
        {
            SYSMENU_BUS bus = new SYSMENU_BUS();
            List<SYSMENU_OBJ> li = bus.getAdmin(ses.gUNIVERSITYCODE, ses.getFunctionList());
            bus.CloseConnection();
            return View(li);
        }
        public ActionResult Header()
        {
            bool isLoged = (ses.isLogin()==0);
            ViewBag.isloged = isLoged;
            ViewBag.departmentname = ses.loginDepartmentName;
            ViewBag.loginname = ses.loginFullName;
            ViewBag.loginImg = string.IsNullOrEmpty(ses.loginImg) ? "Content/sysimage/noimage.png" : ses.loginImg;
            if (!System.IO.File.Exists(Server.MapPath("/") +  ViewBag.loginImg))
            {
                ViewBag.loginImg = "noimage.jpg";
            }
            return View();
        }
        public ActionResult Task()
        {
            bool isLoged = (ses.isLogin() == 0);
            ViewBag.isloged = isLoged;
            TASKNOTE_BUS bus = new TASKNOTE_BUS();
            List<TASKNOTE_OBJ> li = new List<TASKNOTE_OBJ>();
            if (isLoged)
            {
                int countpage=0;
                li=bus.getAllBy2("eventtime desc",10,1, out countpage, new fieldpara("staffcode", ses.loginCode, paraType.VARCHAR,(int)searchType.NONE,1,(int)combineType.OR) , new fieldpara("staffcode", "", paraType.VARCHAR, (int)searchType.NONE, 1, (int)combineType.OR));
                bus.CloseConnection();
            }
           
            ViewBag.list = li;
            return View();
        }
        public ActionResult Headerstudent()
        {
            bool isLoged = (!string.IsNullOrEmpty(ses.loginName));
            ViewBag.isloged = isLoged;

            ViewBag.loginname = ses.loginFullName;
            ViewBag.loginImg = string.IsNullOrEmpty(ses.loginImg) ? "noimage.jpg" : ses.loginImg;
            if (!System.IO.File.Exists(Server.MapPath("/") + "Files/" + ViewBag.loginImg))
            {
                ViewBag.loginImg = "noimage.jpg";
            }
            return View();
        }
        public ActionResult Header2()
        {
            ViewBag.loginname = ses.loginFullName;
            ViewBag.loginImg = string.IsNullOrEmpty(ses.loginImg) ? "noimage.jpg" : ses.loginImg;
            return View();
        }
        public ActionResult FontendHeader()
        {
            return View();
        }
        public ActionResult FontendFooter()
        {
            return View();
        }
        public ActionResult Footer()
        {
            return View();
        }
        public ActionResult RightConfig()
        {
            return View();
        }
        /// <summary>
        /// Hỗ trợ việc upload file từ client lên server
        /// </summary>
        /// <returns></returns>
        [HttpPost]
        public JsonResult post()
        {
            COMMONTOOL comto = new COMMONTOOL();
            string[] imgexts = { "BMP", "JPG", "PNG", "GIF", "JPEG", "TIF" };
            string[] docexts = { "PDF", "ZIP", "RAR", "7Z", "GZ", "GZIP" };
            string filename = "";
            string linkfile = "";
            string uploadedfilename = "";
            string ext = "";
            int ret = 0;
            string basepath = "";
            int type = 0;
            //must be logined
            if (ses.isLogin() != 0)
            {
                //ret = -1;
            }
            if (Request.Files.Count < 1)
            {
                ret = -2;
            }
            if (ret >= 0)
            {
                //only the first file
                uploadedfilename = Request.Files[0].FileName;
                ext = com.fileExtension(uploadedfilename);
                ext = ext.ToUpper();
                if (imgexts.Contains(ext))
                {
                    type = 1;
                }
                if (docexts.Contains(ext))
                {
                    type = 2;
                }
                if (type == 0)
                {
                    ret = -3;//Không thuộc kiểu file được chấp nhận
                }

            }
            //upload limmit
            if (ret >= 0)
            {
                if (type == 1 && Request.Files[0].ContentLength > 20 * 1048576)
                {
                    Request.Files[0].InputStream.Dispose();
                    ret = -5;
                }
                if (type == 2 && Request.Files[0].ContentLength > 40 * 1048576)
                {
                    Request.Files[0].InputStream.Dispose();
                    ret = -5;

                }
            }
            if (ret >= 0)
            {
                //tính đường dẫn file lưu
                basepath = Server.MapPath("/");
                if (type == 1)
                {
                    linkfile = string.Format("images/{0}/{1}/", DateTime.Now.Year, DateTime.Now.Month.ToString("00"));
                    basepath += linkfile;

                }
                else
                {
                    linkfile = string.Format("files/{0}/{1}/", DateTime.Now.Year, DateTime.Now.Month.ToString("00"));
                    basepath += linkfile;
                }
                com.createDirectory(basepath);
            }
            if (ret >= 0)
            {
                var fileContent = Request.Files[0];
                filename = com.checkFileName(basepath, fileContent.FileName);
                if (filename != "")
                {
                    linkfile = "/" + linkfile + filename;
                    var stream = fileContent.InputStream;
                    // and optionally write the file to disk
                    try
                    {
                        var fileStream = System.IO.File.Create(basepath + filename);
                        stream.CopyTo(fileStream);
                        stream.Close();
                        fileStream.Close();
                    }
                    catch (Exception ex)
                    {
                        ret = -4;
                    }

                }

            }
            if (ret >= 0)
            {
                ret = comto.UploadedFile(linkfile, uploadedfilename, "NEWS");
            }
            return Json(new { sussess = ret, filename = linkfile }, JsonRequestBehavior.AllowGet);
        }
        #region Các combo box chung

        /// <summary>
        /// Lấy danh sách các thuộc tính được phép cập nhật
        /// </summary>
        /// <param name="defaultvalue"></param>
        /// <param name="defaulttext"></param>
        /// <returns></returns>
        //public JsonResult StaffpropertylistComboB(string defaultvalue, string defaulttext)
        //{

        //    //Kiểm tra phân quyền
        //    List<STAFFPROPERTYLIST_OBJ> li = new List<STAFFPROPERTYLIST_OBJ>();
        //    if (ses.isLogin() < 0)
        //    {
        //        return Json(new { lst = li, ret = -1 }, JsonRequestBehavior.AllowGet);
        //    }
        //    //Lây dữ iệu
        //    STAFFPROPERTYLIST_BUS bus = new STAFFPROPERTYLIST_BUS();
        //    List<fieldpara> lipa = new List<fieldpara>();
        //    lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE));
        //    //lấy tất cả không cần phân trang; sáp xếp tăng dần theo thứ tự hiển thị
        //    li = bus.getAllBy2(" THEORDER ", lipa.ToArray()); //get all 
        //    STAFFPROPERTYLIST_OBJ obj = new STAFFPROPERTYLIST_OBJ();
        //    obj.CODE = defaultvalue;
        //    obj.THETYPE = defaultvalue;
        //    obj.NAME = defaulttext;
        //    li.Insert(0, obj);
        //    bus.CloseConnection();
        //    //Trả về cho client
        //    return Json(new { lst = li, ret = 0 }, JsonRequestBehavior.AllowGet);
        //}
        /// <summary>
        /// Lấy danh sách các thuộc tính được cập nhật
        /// </summary>
        /// <returns></returns>
        //public JsonResult StaffpropertylistCombo()
        //{
        //    return StaffpropertylistComboB("", "(Chọn kiểu thay đổi)");
        //}
        /// <summary>
        /// Lấy dữ liệu cho combo các giá trị bị thay đổi
        /// </summary>
        /// <param name="thetype"></param>
        /// <returns></returns>
        //public JsonResult Staffproperty(string thetype)
        //{

        //    if (thetype == "DEPARTMENT")
        //    {
        //        DepartmentController c = new DepartmentController();
        //        return c.listparent();
        //    }
        //    //Kiểm tra phân quyền
        //    List<STAFFPROPERTY_OBJ> li = new List<STAFFPROPERTY_OBJ>();
        //    if (ses.isLogin() < 0)
        //    {
        //        return Json(new { lstGroup = li, ret = -1 }, JsonRequestBehavior.AllowGet);
        //    }
        //    //Lây dữ iệu
        //    STAFFPROPERTY_BUS bus = new STAFFPROPERTY_BUS();
        //    List<fieldpara> lipa = new List<fieldpara>();
        //    lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE));
        //    lipa.Add(new fieldpara("THETYPE", thetype));
        //    //lấy tất cả không cần phân trang; sáp xếp tăng dần theo thứ tự hiển thị
        //    li = bus.getAllBy2(" THEORDER ", lipa.ToArray()); //get all 
        //    STAFFPROPERTY_OBJ obj = new STAFFPROPERTY_OBJ();
        //    obj.CODE = "";
        //    obj.THETYPE = "";
        //    obj.NAME = "(Chọn)";
        //    li.Insert(0, obj);
        //    bus.CloseConnection();
        //    //Trả về cho client
        //    return Json(new { lstGroup = li, ret = 0 }, JsonRequestBehavior.AllowGet);
        //}
        #endregion
    }
}