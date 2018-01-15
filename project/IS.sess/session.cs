﻿using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections.Generic;
using System.Linq;
using IS.basetype;
/// <summary>
/// Summary description for lang
/// </summary>
namespace IS.Sess
{
  
    /// <summary>
    /// manage all sesion information
    /// </summary>

    public class session : System.Web.UI.Page
    {
        public session()
        {
            //
            // TODO: Add constructor logic here
            //
        }
        #region thiết lập thông số cho cá nhân
        /// <summary>
        /// Danh sách các mã đối tượng được phép tương tác với người đăng nhập hiện tại với phiên
        /// </summary>
        private string[] key = { "DEPARTMENTCODE", "PARTYDEPARTMENTCODE", "CHANGEPASS", "PROVINCECODE", "DISTRICTCODE", "CURRENTPAGECODE", "EDUCATIONLEVELCODE", "GRADECODE", "CLASSCODE", "STUDENTCODE", "SUBJECTCODE", "COURSECODE", "EXAMTIMECODE", "SUBJECTCONTENTCODE" };
        /// <summary>
        /// Lấy mã cá nhân thông qua mã key, được dùng các hàm được kiểm soát, trong lập trình không khuyến khích sử dụng hàm này mà sử dụng các biến tương đương ở dưới có tham số p*
        /// </summary>
        /// <param name="thekey"></param>
        /// <returns></returns>
        public string Get(string thekey)
        {
            thekey = thekey.ToUpper();
            if (key.Contains(thekey))
            {
                if (string.IsNullOrEmpty((string)Context.Session["p_EXAMTIMECODE"]))
                {
                    return "";
                }
                else
                {
                    Context.Session["p_"+thekey].ToString().Trim();

                }
            }
            return "";
        }
        /// <summary>
        /// Thiết lập giá trị thông qua key, không khuyến nghị sử dụng hàm này mà sử dụng các biến p* ở dưới
        /// </summary>
        /// <param name="thekey"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public int Set(string thekey, string value)
        {
            thekey = thekey.ToUpper();
            int ret = -1;
            if (key.Contains(thekey))
            {
                Context.Session["p_"+ thekey] = value;
                ret = 0;
            }
            return ret;
        }
        #endregion
        #region goto page
        /// <summary>
        /// Set information to go to
        /// </summary>
        /// <param name="ppage"></param>
        /// <param name="title"></param>
        /// <param name="pinform"></param>
        /// <param name="waitingtime"></param>
        public void gotoPage(string ppage, string title, string pinform, int waitingtime = 0)
        {
            this.targetpage = ppage;
            this.inform = pinform;
            this.title = title;
            this.waitingtime = waitingtime;
            HttpContext.Current.Response.Redirect("/home/warning");
        }
        public string inform
        {
            set
            {
                Context.Session["inform"] = value;
            }
            get
            {
                if (Context.Session["inform"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["inform"].ToString();
                }
            }
        }
        public string title
        {
            set
            {
                Context.Session["title"] = value;
            }
            get
            {
                if (Context.Session["title"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["title"].ToString();
                }
            }
        }
        public string targetpage
        {
            set
            {
                Context.Session["targetpage"] = value;
            }
            get
            {
                if (Context.Session["targetpage"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["targetpage"].ToString();
                }
            }
        }
        public int waitingtime
        {
            set
            {
                Context.Session["waitingtime"] = value;
            }
            get
            {
                if (Context.Session["waitingtime"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)Context.Session["waitingtime"];
                }
            }
        }
        #endregion
        #region 4 error moving page
        public void gotoPage(string ppage, string pinform)
        {
            this.targetpage = ppage;
            this.inform = pinform;
            this.title = "Thông báo";
            this.waitingtime = 3000;
            HttpContext.Current.Response.Redirect("/home/warning");
        }

        public string lastPage
        {
            set
            {
                Context.Session["lastpage"] = value;
            }
            get
            {
                if (Context.Session["lastpage"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["lastpage"].ToString();
                }
            }
        }
        #endregion
        #region 4 login
        /// <summary>
        /// Thực hiện ghi nhận login vào trong biến tạm thời để xử lý về sau
        /// </summary>
        /// <param name="staff"></param>
        /// <param name="li"></param>
        /// <returns></returns>
        public int login(STAFF_INFO staff, List<STAFFPRIORITY> li)
        {
            Context.Session["STAFF_INFO"] = staff;
            Context.Session["STAFF_PRIORITY"] = li;
            Context.Session["g_UNIVERSITYCODE"] = staff.UNIVERSITYCODE;
            return 0;
        }

        /// <summary>
        /// Remove login information
        /// </summary>
        /// <returns></returns>
        public int logout()
        {
            Context.Session["STAFF_INFO"] = null;
            Context.Session["STAFF_PRIORITY"] = null;
            return 0;
        }
        /// <summary>
        /// Check the login status, 0 is logined
        /// </summary>
        /// <returns>-1: not yet, 0 is logged</returns>
        public int isLogin()
        {
            if (Context.Session["STAFF_INFO"] == null)
            {
                return -1;
            }
            STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
            if (staff.CODE == "")
            {
                return -1;
            }
            return 0;
        }
        #endregion
        #region login and logined information
        /// <summary>
        /// Mã đăng nhập
        /// </summary>
        public string loginCode
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.CODE;
            }
        }
        /// <summary>
        /// Tên đăng nhập - username
        /// </summary>
        public string loginName
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.CODEVIEW;
            }
        }
        /// <summary>
        /// get the login full name
        /// </summary>
        public string loginFullName
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.NAME;
            }

        }
        /// <summary>
        /// ảnh của người đăng nhập hiện tại
        /// </summary>
        public string loginImg
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.IMG;
            }
 
        }

        /// <summary>
        /// Thời điểm đăng nhập
        /// </summary>
        public DateTime loginTime
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return new DateTime(1900, 1, 1);
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.LOGTIME;
            }
 
        }
        /// <summary>
        /// Đơn vị quản lý của người đăng nhập
        /// </summary>
        public string loginDepartment
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.DEPARTMENTCODE;
            }
            //set
            //{
            //    if (Context.Session["STAFF_INFO"] != null)
            //    {
            //        STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
            //        staff.NAME = value;
            //        Context.Session["STAFF_INFO"] = staff;
            //    }
            //}
        }
        /// <summary>
        /// Tên của đơn vị đang đăng nhập
        /// </summary>
        public string loginDepartmentName
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.DEPARTMENTNAME;
            }
            //set
            //{
            //    if (Context.Session["STAFF_INFO"] != null)
            //    {
            //        STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
            //        staff.NAME = value;
            //        Context.Session["STAFF_INFO"] = staff;
            //    }
            //}
        }
        /// <summary>
        /// Thông tin về đơn vị tham gia nghiên cứu của giáo viên
        /// </summary>

        /// <summary>
        /// Type of login; LECTURER, ADMIN, STUDENT 
        /// </summary>
        public string loginType
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.TYPE;
            }
            //set
            //{
            //    if (Context.Session["STAFF_INFO"] != null)
            //    {
            //        STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
            //        staff.NAME = value;
            //        Context.Session["STAFF_INFO"] = staff;
            //    }
            //}
        }
        /// <summary>
        /// Chức vụ 
        /// </summary>
        public string loginLeveltitlecode
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.LEVELTITLECODE;
            }
            //set
            //{
            //    if (Context.Session["STAFF_INFO"] != null)
            //    {
            //        STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
            //        staff.NAME = value;
            //        Context.Session["STAFF_INFO"] = staff;
            //    }
            //}
        }
        /// <summary>
        /// Quân hàm
        /// </summary>
        public string loginArmyrankcode
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.LEVELTITLECODE;
            }
            //set
            //{
            //    if (Context.Session["STAFF_INFO"] != null)
            //    {
            //        STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
            //        staff.NAME = value;
            //        Context.Session["STAFF_INFO"] = staff;
            //    }
            //}
        }
        /// <summary>
        /// Học vị
        /// </summary>
        public string loginDegreecode
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.DEGREECODE;
            }

        }
        /// <summary>
        /// học hàm
        /// </summary>
        public string loginAcademictitlecode
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return "";
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff.DEGREECODE;
            }

        }
        /// <summary>
        /// Nhân viên đang đăng nhập
        /// </summary>
        public STAFF_INFO STAFF
        {
            get
            {
                if (Context.Session["STAFF_INFO"] == null)
                    return null;
                STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                return staff;
            }
            set
            {
                if (Context.Session["STAFF_INFO"] != null)
                {
                    STAFF_INFO staff = (STAFF_INFO)Context.Session["STAFF_INFO"];
                    Context.Session["STAFF_INFO"] = value;
                }
            }
        }


        /// <summary>
        /// Get priority of login man with //old version; this is check on the function without detail - call funcEx to get detail information
        /// </summary>
        /// <param name="funcCode"> the code want to check</param>
        /// <returns>0: no permit, then the permition</returns>
        public int func(string funcCode)
        {
            int code = 0;
            if (Context.Session["STAFF_PRIORITY"] == null)
            {
                return 0;
            }
            if (Context.Session["STAFF_PRIORITY"].ToString() == "")
            {
                return 0;
            }
            
            List<STAFFPRIORITY> li = (List<STAFFPRIORITY>)Context.Session["STAFF_PRIORITY"];
            funcCode = funcCode.ToUpper().Trim();
            foreach (STAFFPRIORITY obj in li)
            {
                if (obj.PRIORITYCODE.ToUpper() == funcCode)
                {
                    code = code|obj.FUNC;
                }
            }

            return code;
        }
        /// <summary>
        /// Locate the STAFFPRIORITY according to funcCode of this staff
        /// </summary>
        /// <param name="funcCode">Danh sách các quyền thỏa mãn của người dùng</param>
        /// <returns></returns>
        public List<STAFFPRIORITY> funcEx(string funcCode)
        {
            if (Context.Session["STAFF_PRIORITY"] == null)
            {
                return null;
            }
            if (Context.Session["STAFF_PRIORITY"].ToString() == "")
            {
                return null;
            }
            List< STAFFPRIORITY> objhere = new List<STAFFPRIORITY>();
            List<STAFFPRIORITY> li = (List<STAFFPRIORITY>)Context.Session["STAFF_PRIORITY"];
            funcCode = funcCode.ToUpper().Trim();
            foreach (STAFFPRIORITY obj in li)
            {
                if (obj.PRIORITYCODE.ToUpper() == funcCode)
                {
                    objhere.Add(obj);
                }
            }

            return objhere;
        }
        /// <summary>
        /// Trả về danh sách các phân quyền mà giáo viên này có với mã đã được đưa vào để kiểm tra
        /// </summary>
        /// <param name="funcCode"></param>
        /// <returns></returns>
        public List< STAFFPRIORITY > funcList(string funcCode)
        {
            List<STAFFPRIORITY> ret = new List<STAFFPRIORITY>();
            if (Context.Session["STAFF_PRIORITY"] == null)
            {
                return ret;
            }
            if (Context.Session["STAFF_PRIORITY"].ToString() == "")
            {
                return ret;
            }
            STAFFPRIORITY objhere = null;
            List<STAFFPRIORITY> li = (List<STAFFPRIORITY>)Context.Session["STAFF_PRIORITY"];
            funcCode = funcCode.ToUpper().Trim();
            foreach (STAFFPRIORITY obj in li)
            {
                if (obj.PRIORITYCODE.ToUpper() == funcCode)
                {
                    ret.Add(obj);
                }
            }

            return ret;
        }
        /// <summary>
        /// return all permission list from login user, with ,'' according to in list of sql statements
        /// </summary>
        /// <returns></returns>
        public string getFunctionList() //for menu
        {
            string sret = "'EVERYONE'";//cho tất cả
            if(isLogin()>=0)
            {
                sret += ",'USER'";//Cho người dùng đã đăng nhập
            }
            else
            {
                sret += ",'UNUSER'";
            }
            if (Context.Session["STAFF_PRIORITY"] == null)
                return sret;
            List<STAFFPRIORITY> li = (List<STAFFPRIORITY>)Context.Session["STAFF_PRIORITY"];
            foreach (STAFFPRIORITY obj in li)
            {
                sret += ",'" + obj.PRIORITYCODE.Replace("'", "''") + "'";
            }
            return sret;
        }
        #endregion
        

        /// <summary>
        /// Trang hiện tại
        /// </summary>
        public string currentPage
        {
            get {
                if (Context.Session["curURL"] == null || Context.Session["curURL"].ToString() == "")
                {
                    return "~/home";
                }
                return Context.Session["curURL"].ToString();
            }
            set {
                Context.Session["curURL"] = value;
            }
            
        }


        #region Login fail and gen security image
        /// <summary>
        /// Xóa trạng thái đếm lần đăng nhập không thành công
        /// </summary>
        /// <returns></returns>
        public int clearLoginFail()
        {
            Context.Session["countFail"] = 0;
            return 0;
        }
        /// <summary>
        /// Tăng số lên đăng nhập không thành công
        /// </summary>
        /// <returns></returns>
        public int loginFail()
        {
            if (Context.Session["countFail"] == null)
            {
                Context.Session["countFail"] = 1;
                return 1;
            }
            else
            {
                Context.Session["countFail"] = (int)Context.Session["countFail"] + 1;
                return (int)Context.Session["countFail"];
            }
        }
        /// <summary>
        /// Lấy số lần đăng nhập không thành công
        /// </summary>
        public int loginFailCount
        {
            get {
                if (Context.Session["countFail"] == null)
                {
                    return 0;
                }
                else
                {
                    return (int)Context.Session["countFail"];
                }
            }
        }
        /// <summary>
        /// try to gen the security code and save it to session to use later
        /// </summary>
        /// <returns>security code generated</returns>
        public string genSecurityCode()
        {
            int code, i;
            char c;

            Random a = new Random();
            string cur = "";
            for (i = 0; i < 6; i++)
            {
                code = a.Next(35);
                if (code < 10)
                {
                    c = (char)(48 + code);
                }
                else
                {
                    c = (char)(55 + code);
                }
                cur = cur + c;
            }
            Context.Session["securityCode"] = cur;
            return cur;
        }
        /// <summary>
        /// Lấy mã ngẫu nhiên hiện tại
        /// </summary>
        public string securityCode
        {
            get
            {
                if (Context.Session["securityCode"] == null)
                {
                    return "";
                }
                return Context.Session["securityCode"].ToString();

            }
        }
     
        #endregion
        #region for admin configuration; ex. the number of rows in admin grid
        //for admin 
        /// <summary>
        /// Get the number items perpage
        /// </summary>
        /// <returns>number of items per page depend on web.config, default 20</returns>
        public int getItem4Page()
        {
            string items = "";
            int ret = 0;
            try
            {
                items = ConfigurationSettings.AppSettings["item4page"].ToString();
            }
            catch (Exception ex)
            {
                items = "20";
            }
            int.TryParse(items, out ret);
            if (ret == 0)
                ret = 20;
            return ret;
        }
        /// <summary>
        /// Get the number items perpage
        /// </summary>
        /// <returns>number of items per page depend on web.config, default 20</returns>
        public int getItem4PageLong()
        {

            string items = "";
            int ret = 0;
            try
            {
                items = ConfigurationSettings.AppSettings["item4pageLong"].ToString();
            }
            catch (Exception ex)
            {
                items = "20";
            }
            int.TryParse(items, out ret);
            if (ret == 0)
                ret = 20;
            return ret;
        }

        #endregion

        #region Tham số dành riêng cho cá nhân (save to database - personal)

        /// <summary>
        /// current department for the staff
        /// </summary>
        public string pDEPARTMENTCODE
        {
            get
            {
                if (Context.Session["p_DEPARTMENTCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_DEPARTMENTCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_DEPARTMENTCODE"] = value;
            }
        }
        /// <summary>
        /// current party department for the staff
        /// </summary>
        public string pPARTYDEPARTMENTCODE
        {
            get
            {
                if (Context.Session["p_PARTYDEPARTMENTCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_PARTYDEPARTMENTCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_PARTYDEPARTMENTCODE"] = value;
            }
        }
        /// <summary>
        /// this parameter based on login status
        /// </summary>
        public string pCHANGEPASS
        {
            get
            {
                if (Context.Session["p_CHANGEPASS"] == null)
                {
                    return "0";
                }
                else
                    return Context.Session["p_CHANGEPASS"].ToString().Trim();
            }
            set
            {
                Context.Session["p_CHANGEPASS"] = value;
            }
        }


        /// <summary>
        /// this parameter based on login status
        /// </summary>
        public string pPROVINCECODE
        {
            get
            {
                if (Context.Session["p_PROVINCECODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_PROVINCECODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_PROVINCECODE"] = value;
            }
        }
        /// <summary>
        /// this parameter based on login status
        /// </summary>
        public string pDISTRICTCODE
        {
            get
            {
                if (Context.Session["p_DISTRICTCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_DISTRICTCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_DISTRICTCODE"] = value;
            }
        }
        /// <summary>
        /// Cấp học
        /// </summary>
        public string pEDUCATIONLEVELCODE
        {
            get
            {
                if (Context.Session["p_EDUCATIONLEVELCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_EDUCATIONLEVELCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_EDUCATIONLEVELCODE"] = value;
            }
        }
        /// <summary>
        /// Mã khóa học
        /// </summary>
        public string pGRADECODE
        {
            get
            {
                if (Context.Session["p_GRADECODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_GRADECODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_GRADECODE"] = value;
            }
        }
        /// <summary>
        /// Lớp môn học hiện tại
        /// </summary>
        public string pCLASSCODE
        {
            get
            {
                if (Context.Session["p_CLASSCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_CLASSCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_CLASSCODE"] = value;
            }
        }
        /// <summary>
        /// Sinh viên đang tương tác hiện tại
        /// </summary>
        public string pSTUDENTCODE
        {
            get
            {
                if (Context.Session["p_STUDENTCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_STUDENTCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_STUDENTCODE"] = value;
            }
        }
        /// <summary>
        /// Mã môn học đang tương tác hiện tại
        /// </summary>
        public string pSUBJECTCODE
        {
            get
            {
                if (Context.Session["p_SUBJECTCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_SUBJECTCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_SUBJECTCODE"] = value;
            }
        }
        /// <summary>
        /// Lớp môn học đang tương tác hiện tại
        /// </summary>
        public string pCOURSECODE
        {
            get
            {
                if (Context.Session["p_COURSECODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_COURSECODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_COURSECODE"] = value;
            }
        }
        /// <summary>
        /// Mã của đợt thi đan tương tác
        /// </summary>
        public string pEXAMTIMECODE
        {
            get
            {
                if (Context.Session["p_EXAMTIMECODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_EXAMTIMECODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_EXAMTIMECODE"] = value;
            }
        }
        /// <summary>
        /// Mã nội dung môn học đang tương tác
        /// </summary>
        public string pSUBJECTCONTENTCODE
        {
            get
            {
                if (Context.Session["p_SUBJECTCONTENTCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_SUBJECTCONTENTCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_SUBJECTCONTENTCODE"] = value;
            }
        }
        /// <summary>
        /// Get curent page code for insert and update refresh problem
        /// </summary>
        public string pCURRENTPAGECODE
        {
            get
            {
                if (Context.Session["p_CURRENTPAGECODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_CURRENTPAGECODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_CURRENTPAGECODE"] = value;
            }
        }
        /// <summary>
        /// lastest contentcode of user 
        /// </summary>

        public string PContentcode
        { 
            get
            {
                if (Context.Session["p_CURRENTCONTENTCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_CURRENTCONTENTCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_CURRENTCONTENTCODE"] = value;
            }
        }
        /// <summary>
        /// lastest subjectcode  of user 
        /// </summary>
        public string PSubjectCode
        {
            get
            {
                if (Context.Session["p_CURRENTSUBJECTCODE"] == null)
                {
                    return "";
                }
                else
                    return Context.Session["p_CURRENTSUBJECTCODE"].ToString().Trim();
            }
            set
            {
                Context.Session["p_CURRENTSUBJECTCODE"] = value;
            }
        }

        /// <summary>
        /// Do the gen CURRENTPAGECODE and set to sesion CURRENTPAGECODE
        /// </summary>
        /// <returns></returns>
        public string pGenCURRENTPAGECODE()
        {
            string code = DateTime.Now.ToString("yyyy.MM.dd.HH.mm.ss.fff");
            pCURRENTPAGECODE = code;
            return code;
        }
        /// <summary>
        /// Get current session ID in database
        /// </summary>
        public string pSessionCode
        {
            get
            {
                if (Context.Session["p_SESSIONCODE"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["p_SESSIONCODE"].ToString();
                }
            }
            set
            {
                Context.Session["p_SESSIONCODE"] = value;
            }
        }
        /// <summary>
        /// current login sesion
        /// </summary>
        public string pLoginSession
        {
            get
            {
                if (Context.Session["p_LOGINSESSION"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["p_LOGINSESSION"].ToString();
                }
            }
            set
            {
                Context.Session["p_LOGINSESSION"] = value;
            }

        }
        #endregion

        #region Các tham số toàn cục

        /// <summary>
        /// title of university; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
        /// </summary>
        public string gTITLE
        {
            get
            {
                if (Context.Session["g_TITLE"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["g_TITLE"].ToString();
                }
            }
            set
            {
                Context.Session["g_TITLE"] = value;
            }
        }
        /// <summary>
        /// rector of university; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
        /// </summary>
        public string gRECTOR
        {
            get
            {
                if (Context.Session["g_RECTOR"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["g_RECTOR"].ToString();
                }
            }
            set
            {
                Context.Session["g_RECTOR"] = value;
            }
        }
        /// <summary>
        /// header of education department; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
        /// </summary>
        public string gHEADEDU
        {
            get
            {
                if (Context.Session["g_HEADEDU"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["g_HEADEDU"].ToString();
                }
            }
            set
            {
                Context.Session["g_HEADEDU"] = value;
            }
        }
        /// <summary>
        /// header of education department; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
        /// </summary>
        public string gDEAN
        {
            get
            {
                if (Context.Session["g_DEAN"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["g_DEAN"].ToString();
                }
            }
            set
            {
                Context.Session["g_DEAN"] = value;
            }
        }        /// <summary>
                 /// university ; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
                 /// </summary>
        public string gUNIT1
        {
            get
            {
                if (Context.Session["g_UNIT1"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["g_UNIT1"].ToString();
                }
            }
            set
            {
                Context.Session["g_UNIT1"] = value;
            }
        }
        /// <summary>
        /// education department; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
        /// </summary>
        public string gUNIT2
        {
            get
            {
                if (Context.Session["g_UNIT2"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["g_UNIT2"].ToString();
                }
            }
            set
            {
                Context.Session["g_UNIT2"] = value;
            }
        }
        /// <summary>
        /// Phân hệ; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
        /// </summary>
        public string gBRANCH
        {
            get
            {
                if (Context.Session["g_BRANCH"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["g_BRANCH"].ToString();
                }
            }
            set
            {
                Context.Session["g_BRANCH"] = value;
            }
        }
        /// <summary>
        /// Phân hệ; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
        /// </summary>
        public string gBRANCHCODE
        {
            get
            {
                if (Context.Session["g_BRANCHCODE"] == null)
                {
                    return "";
                }
                else
                {
                    return Context.Session["g_BRANCHCODE"].ToString();
                }
            }
            set
            {
                Context.Session["g_BRANCHCODE"] = value;
            }
        }
        /// <summary>
        /// Number of rest day at the weekend; 1: only sunday, 2: saturday and sunday; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
        /// </summary>
        public int gWEEKEND
        {
            get
            {
                if (Context.Session["g_WEEKEND"] == null)
                {
                    return 2;
                }
                else
                {
                    int ret;
                    int.TryParse(Context.Session["g_WEEKEND"].ToString(), out ret);
                    return ret;
                }
            }
            set
            {
                Context.Session["g_WEEKEND"] = value.ToString();
            }
        }

  
        /// <summary>
        /// the min Number of students in a course; in backend it is load automatically when loging; in front end before using it, the function systemparameter.loadParameter must be called
        /// </summary>
        public int gVERSION
        {
            get
            {
                if (Context.Session["g_VERSION"] == null)
                {
                    return 1;
                }
                else
                {
                    int ret;
                    int.TryParse(Context.Session["g_VERSION"].ToString(), out ret);
                    return ret;
                }
            }
            set
            {
                Context.Session["g_VERSION"] = value.ToString();
            }
        }

        /// <summary>
        /// The end day of term2; return DateTime.MinValue when it is null
        /// </summary>
        public int gWORKINGYEAR
        {
            get
            {
                if (Context.Session["g_WORKINGYEAR"] == null)
                {
                    return 2015;
                }
                else
                {
                    int v;
                    v = (int)Context.Session["g_WORKINGYEAR"];
                    return v;
                }
            }
            set
            {
                Context.Session["g_WORKINGYEAR"] = value;
            }
        }
        public string gUNIVERSITYCODE
        {
            get
            {
                if (Context.Session["g_UNIVERSITYCODE"] == null)
                {
                    return "HVKTQS";
                }
                else
                {
                    return Context.Session["g_UNIVERSITYCODE"].ToString();
                }
            }
            set
            {
                Context.Session["g_UNIVERSITYCODE"] = value;
            }
        }
        #endregion


        #region Nội dung về các đối tượng tạm thời
        /// <summary>
        /// lưu các đối tượng bảng tạm thời trong hệ thống
        /// </summary>
        public DataTable tTEMPDATATABLE
        {
            get
            {
                if (Context.Session["g_TEMPDATATABLE"] == null)
                {
                    return null;
                }
                else
                {
                    return (DataTable)Context.Session["g_TEMPDATATABLE"];
                }
            }
            set
            {
                Context.Session["g_TEMPDATATABLE"] = value;
            }
        }

        #endregion
        /// <summary>
        /// Get the current language of the web
        /// </summary>
        /// <returns>language code, vn, en, ...</returns>
        public string getLang()
        {

            string lang = "";

            if ((Context.Session["lang"] != null))
            {
                lang = Context.Session["lang"].ToString();
            }
            else
            {
                lang = ConfigurationSettings.AppSettings["lang"].ToString();
                Context.Session["lang"] = lang;
            }
            if (Context.Request.QueryString["lang"] != null)
            {
                lang = Context.Request.QueryString["lang"].ToString();
                Context.Session["lang"] = lang;
            }
            return lang;
        }
        /// <summary>
        /// Ngôn ngữ hiện tại của hệ thống cho phần hiển thị
        /// </summary>
        public string frontlang
        {
            get
            {
                string lang = "";

                if ((Context.Session["lang"] != null))
                {
                    lang = Context.Session["lang"].ToString();
                }
                else
                {
                    lang = ConfigurationSettings.AppSettings["lang"].ToString();
                    Context.Session["lang"] = lang;
                }
                if (Context.Request.QueryString["lang"] != null)
                {
                    lang = Context.Request.QueryString["lang"].ToString();
                    Context.Session["lang"] = lang;
                }
                return lang;
            }
            set
            {
                Context.Session["lang"] = value;
            }

        }
        public string getLangFront()
        {

            string lang = "";

            if ((Context.Session["langfront"] != null))
            {
                lang = Context.Session["langfront"].ToString();
            }
            else
            {
                if (ConfigurationSettings.AppSettings["langfront"] != null)
                {
                    lang = ConfigurationSettings.AppSettings["langfront"].ToString();
                    Context.Session["langfront"] = lang;
                }
                else
                {
                    Context.Session["langfront"] = "en";
                }
            }
            if (Context.Request.QueryString["langfront"] != null)
            {
                lang = Context.Request.QueryString["langfront"].ToString();
                Context.Session["langfront"] = lang;
            }
            return lang;
        }


        public List<string> tSOURCEPATHSESSION
        {
            get
            {
                if (Context.Session["t_SOURCEPATHSESSION"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<string>)Context.Session["t_SOURCEPATHSESSION"];
                }
            }
            set
            {
                Context.Session["t_SOURCEPATHSESSION"] = value;
            }

        }
        public List<string> tDESTINATIONPATHSESSION
        {
            get
            {
                if (Context.Session["t_DESTINATIONPATHSESSION"] == null)
                {
                    return null;
                }
                else
                {
                    return (List<string>)Context.Session["t_DESTINATIONPATHSESSION"];
                }
            }
            set
            {
                Context.Session["t_DESTINATIONPATHSESSION"] = value;
            }

        }
    }
}