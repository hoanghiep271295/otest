using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml;
using System.Configuration;

namespace IS.Config
{
    public static class AppConfig//: System.Web.UI.Page
	{
        /// <summary>
        /// Kết nối đến cơ sở dữ liệu trong hệ thống, được quy định trong file .config tương ứng
        /// </summary>
        /// <returns></returns>
        public static string connectionString()
        {
            string con = ConfigurationSettings.AppSettings["connectionString"].ToString();
            
            return con;
        }
        /// <summary>
        /// Số phần tử trên một trang
        /// </summary>
        /// <returns></returns>
        public static int item4page()
        {
            string con = "10";
            if (ConfigurationSettings.AppSettings["item4page"] != null)
            { 
                con= ConfigurationSettings.AppSettings["item4page"].ToString();
            }
            int c;
            int.TryParse(con, out c);
            return c;
        }
        /// <summary>
        /// Số phần tử trên một trang dài
        /// </summary>
        /// <returns></returns>
        public static int item4pageLong()
        {
            string con = "10";
            if (ConfigurationSettings.AppSettings["item4pageLong"] != null)
            {
                con = ConfigurationSettings.AppSettings["item4pageLong"].ToString();
            }
            //string con = ConfigurationSettings.AppSettings["item4pageLong"].ToString();
            int c;
            int.TryParse(con, out c);
            return c;
        }
        /// <summary>
        /// Số phần tử trên một trang dành cho chức năng admin
        /// </summary>
        /// <returns></returns>
        public static int item4admin()
        {
            string con = "10";
            if (ConfigurationSettings.AppSettings["item4admin"] != null)
            {
                con = ConfigurationSettings.AppSettings["item4admin"].ToString();
            }
            int c;
            int.TryParse(con, out c);
            return c;
        }
        /// <summary>
        /// Mã của dự án
        /// </summary>
        /// <returns></returns>
        public static string AppCode()
        {
            return "NERP-FIT";
        }
        /// <summary>
        /// Waiting time in show dialog
        /// </summary>
        /// <returns></returns>
        public static int waitingTime()
        {
            return 2000;
        }
        /// <summary>
        /// số lượng bản ghi trên trang chính
        /// </summary>
        /// <returns></returns>
        public static int item4MainFront()
        {
            //string con = ConfigurationSettings.AppSettings["item4page"].ToString();
            //int c;
            //int.TryParse(con, out c);
            //return c;
            return 3;
        }
        /// <summary>
        /// Số bản ghi tối đa ở trên slide
        /// </summary>
        /// <returns></returns>
        public static int item4Slide()
        {
            //string con = ConfigurationSettings.AppSettings["item4page"].ToString();
            //int c;
            //int.TryParse(con, out c);
            //return c;
            return 6;
        }
        /// <summary>
        /// số bản ghi ở danh sách phải
        /// </summary>
        /// <returns></returns>
        public static int item4MoreHeadLine()
        {
            //string con = ConfigurationSettings.AppSettings["item4page"].ToString();
            //int c;
            //int.TryParse(con, out c);
            //return c;
            return 6;
        }
        public static int item4NewsGroup()
        {
            //string con = ConfigurationSettings.AppSettings["item4page"].ToString();
            //int c;
            //int.TryParse(con, out c);
            //return c;
            return 9;
        }
        public static string langfilename
        {
            get
            {
                string filename = "lang/totalLang.xml";
                if (ConfigurationSettings.AppSettings["langfilename"] != null)
                {
                    filename = ConfigurationSettings.AppSettings["langfilename"].ToString();
                }
                return baseDirectory + filename;
            }
        }
        public static string baseDirectory;

    }
}
