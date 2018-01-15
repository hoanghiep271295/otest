using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.UI.WebControls;
using System.Data;
using IS.localcomm;
using IS.fitframework;
using IS.Sess;
using System.Web;
using System.Web.UI;
using IS.basetype;
using System.Data.SqlClient;
using IS.Pool;
namespace IS.uni
{
    /// <summary>
    /// Các hàm chung có liên quan đến tương tác các đối tượng, và cơ sở dữ liệu; thường được sử dụng để khởi tạo các đối tượng chung có liên quan đến cơ sở dữ liệu như là combo box (dropdown list)
    /// </summary>
    public class COMMONTOOL
    {
        localcommonlib com = new localcommonlib();
        session ses = new session();
        #region log
        /// <summary>
        /// Ghi nhật bắt đầu session
        /// </summary>
        /// <returns></returns>
        public int logSession()
        {
            int ret = 0;
            LOGME_BUS bus = new LOGME_BUS();
            LOGME_OBJ obj = new LOGME_OBJ();
            obj.CODE = bus.GenNextCode(obj);
            ses.pSessionCode = obj.CODE;
            obj.ACTION = "SES";
            obj.CREATETIME = DateTime.Now;
            obj.ENDTIME = com.minDate();
            ret = bus.Insert(obj);
            bus.CloseConnection();
            return ret;
        }
        /// <summary>
        /// Ghi nhận kết thúc một session
        /// </summary>
        /// <returns></returns>
        public int logSessionOut()
        {
            int ret = 0;
            LOGME_OBJ obj = new LOGME_OBJ();
            LOGME_BUS bus = new LOGME_BUS();
            obj.CODE = ses.pSessionCode;
            obj._ID.CODE = obj.CODE;
            obj.ENDTIME = DateTime.Now;
            string[] fi = { "ENDTIME" };
            bus.Update(fi, obj);
            bus.CloseConnection();
            return ret;
        }
        /// <summary>
        /// Ghi nhận việc đăng nhập của một cá nhân
        /// </summary>
        /// <param name="p"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public int logLogin(HttpRequestBase p, string note)
        {
            int ret = 0;
            LOGME_BUS bus_logme = new LOGME_BUS();
            LOGME_OBJ obj_logme = new LOGME_OBJ();
            obj_logme.ACTION = "LOG";
            obj_logme.CODE = bus_logme.GenNextCode(obj_logme);
            obj_logme.CREATETIME = DateTime.Now;
            obj_logme.IP = com.getIp(p);
            obj_logme.NOTE = note;
            obj_logme.RECORDCODE = "";
            obj_logme.STAFFCODE = ses.loginCode;
            obj_logme.STAFFNAME = ses.loginName;
            obj_logme.TABLENAME = "STAFF";
            //            obj_logme.ENDTIME = com.minDate();
            obj_logme.COMPUTERNAME = com.getComputerName(p);
            obj_logme.WEBBROWSER = com.getWebBrowser(p);
            obj_logme.OS = com.getOS(p);
            obj_logme.URLSHORT = "";// p.Url.AbsoluteUri;
            obj_logme.SESSIONCODE = ses.pSessionCode;
            obj_logme.URLNAME = "";// p.RawUrl;
            ret = bus_logme.Insert(obj_logme);
            bus_logme.CloseConnection();
            //save
            ses.pLoginSession = obj_logme.CODE;
            return ret;
        }
        /// <summary>
        /// Ghi nhận việc đăng nhập của một cá nhân
        /// </summary>
        /// <param name="p"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public int logLogin(Page p, string note)
        {
            int ret = 0;
            LOGME_BUS bus_logme = new LOGME_BUS();
            LOGME_OBJ obj_logme = new LOGME_OBJ();
            obj_logme.ACTION = "LOG";
            obj_logme.CODE = bus_logme.GenNextCode(obj_logme);
            obj_logme.CREATETIME = DateTime.Now;
            obj_logme.IP = com.getIp(p);
            obj_logme.NOTE = note;
            obj_logme.RECORDCODE = "";
            obj_logme.STAFFCODE = ses.loginCode;
            obj_logme.STAFFNAME = ses.loginName;
            obj_logme.TABLENAME = "STAFF";
            //            obj_logme.ENDTIME = com.minDate();
            obj_logme.COMPUTERNAME = com.getComputerName(p);
            obj_logme.WEBBROWSER = com.getWebBrowser(p);
            obj_logme.OS = com.getOS(p);
            obj_logme.URLSHORT = "";// p.Url.AbsoluteUri;
            obj_logme.SESSIONCODE = ses.pSessionCode;
            obj_logme.URLNAME = "";// p.RawUrl;
            ret = bus_logme.Insert(obj_logme);
            bus_logme.CloseConnection();
            //save
            ses.pLoginSession = obj_logme.CODE;
            return ret;
        }
        /// <summary>
        /// Thoát đăng nhập
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int logLogout()
        {
            int ret = 0;
            LOGME_BUS bus_log = new LOGME_BUS();
            LOGME_OBJ obj_log = new LOGME_OBJ();
            obj_log.CODE = ses.pLoginSession;
            obj_log._ID.CODE = ses.pLoginSession;
            obj_log.ENDTIME = DateTime.Now;
            string[] fi = { "ENDTIME" };
            ret = bus_log.Update(fi, obj_log);
            bus_log.CloseConnection();
            ses.pLoginSession = "";//clear
            return ret;

        }
        /// <summary>
        /// Ghi nhận truy xuất một trang nào đó
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public int LogQuery(Page p)
        {

            return LogQuery(p, "Query page");
        }
        /// <summary>
        /// Ghi lại sử dụng có ghi chú
        /// </summary>
        /// <param name="p"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public int LogQuery(Page p, string note)
        {

            return logAction(p, "", "BRO", "", note);
        }
        /// <summary>
        /// Ghi nhật một cập nhật bất kỳ
        /// </summary>
        /// <param name="p">Trang hiện tại</param>
        /// <param name="tablename">Bảng có truy xuất</param>
        /// <param name="action">Hành vi tác động: EDI, DEL; ADD; VIE</param>
        /// <param name="code">Mã bản ghi bị tác động</param>
        /// <returns></returns>
        public int logAction(Page p, string tablename, string action, string code)
        {

            return logAction(p, tablename, action, code, "do action");
        }
        /// <summary>
        /// Ghi nhật ký tác vụ với ghi chú
        /// </summary>
        /// <param name="p"></param>
        /// <param name="tablename"></param>
        /// <param name="action"></param>
        /// <param name="code"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public int logAction(Page p, string tablename, string action, string code, string note)
        {
            int ret = 0;
            LOGME_BUS bus_logme = new LOGME_BUS();
            LOGME_OBJ obj_logme = new LOGME_OBJ();
            obj_logme.ACTION = action;
            obj_logme.CODE = bus_logme.GenNextCode(obj_logme);
            ses.pLoginSession = obj_logme.CODE;
            obj_logme.CREATETIME = DateTime.Now;
            obj_logme.IP = com.getIp(p);
            obj_logme.NOTE = note;
            obj_logme.RECORDCODE = code;
            obj_logme.STAFFCODE = ses.loginCode;
            obj_logme.STAFFNAME = ses.loginName;
            obj_logme.TABLENAME = tablename;
            //            obj_logme.ENDTIME = com.minDate();
            obj_logme.COMPUTERNAME = com.getComputerName(p);
            obj_logme.WEBBROWSER = com.getWebBrowser(p);
            obj_logme.OS = com.getOS(p);
            obj_logme.URLSHORT = p.Request.Url.AbsoluteUri;
            obj_logme.SESSIONCODE = ses.pSessionCode;
            obj_logme.URLNAME = p.Request.RawUrl;
            ret = bus_logme.Insert(obj_logme);
            bus_logme.CloseConnection();
            return ret;
        }
        /// <summary>
        /// Ghi nhận lỗi nảy sinh trên trang
        /// </summary>
        /// <param name="p"></param>
        /// <param name="func"></param>
        /// <param name="mes"></param>
        /// <param name="note"></param>
        /// <param name="tablename"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int logError(Page p, string func, string mes, string note, string tablename, string code)
        {
            int ret = 0;
            LOGERROR_BUS bus_logme = new LOGERROR_BUS();
            LOGERROR_OBJ obj_logme = new LOGERROR_OBJ();
            obj_logme.ACTION = "ERROR";
            obj_logme.CODE = bus_logme.GenNextCode(obj_logme);
            ses.pLoginSession = obj_logme.CODE;
            obj_logme.CREATETIME = DateTime.Now;
            obj_logme.IP = com.getIp(p);
            obj_logme.NOTE = note;
            obj_logme.RECORDCODE = code;
            obj_logme.STAFFCODE = ses.loginCode;
            obj_logme.STAFFNAME = ses.loginName;
            obj_logme.TABLENAME = tablename;
            //            obj_logme.ENDTIME = com.minDate();
            obj_logme.COMPUTERNAME = com.getComputerName(p);
            obj_logme.WEBBROWSER = com.getWebBrowser(p);
            obj_logme.OS = com.getOS(p);
            obj_logme.URLSHORT = p.Request.Url.AbsoluteUri;
            obj_logme.SESSIONCODE = ses.pSessionCode;
            obj_logme.URLNAME = p.Request.RawUrl;
            obj_logme.FUNC = func;
            obj_logme.MES = mes;
            ret = bus_logme.Insert(obj_logme);
            bus_logme.CloseConnection();
            return ret;
        }
        /// <summary>
        /// Nảy sinh lỗi trên trang
        /// </summary>
        /// <param name="p">Trang nảy sinh lỗi</param>
        /// <param name="func">Chức năng nảy sinh lỗi</param>
        /// <param name="mes">Thông điệp lỗi</param>
        /// <param name="note">Mô tả thêm về chức năng</param>
        /// <returns></returns>
        public int logError(Page p, string func, string mes, string note)
        {
            int ret = 0;
            LOGERROR_BUS bus_logme = new LOGERROR_BUS();
            LOGERROR_OBJ obj_logme = new LOGERROR_OBJ();
            obj_logme.ACTION = "ERROR";
            obj_logme.CODE = bus_logme.GenNextCode(obj_logme);
            ses.pLoginSession = obj_logme.CODE;
            obj_logme.CREATETIME = DateTime.Now;
            obj_logme.IP = com.getIp(p);
            obj_logme.NOTE = note;
            obj_logme.RECORDCODE = "";
            obj_logme.STAFFCODE = ses.loginCode;
            obj_logme.STAFFNAME = ses.loginName;
            obj_logme.TABLENAME = "";
            //            obj_logme.ENDTIME = com.minDate();
            obj_logme.COMPUTERNAME = com.getComputerName(p);
            obj_logme.WEBBROWSER = com.getWebBrowser(p);
            obj_logme.OS = com.getOS(p);
            obj_logme.URLSHORT = p.Request.Url.AbsoluteUri;
            obj_logme.SESSIONCODE = ses.pSessionCode;
            obj_logme.URLNAME = p.Request.RawUrl;
            obj_logme.FUNC = func;
            obj_logme.MES = mes;
            ret = bus_logme.Insert(obj_logme);
            bus_logme.CloseConnection();
            return ret;
        }
        /// <summary>
        /// Nhật ký thêm một bản ghi
        /// </summary>
        /// <param name="p">Trang hiện tại</param>
        /// <param name="tablename">Bảng có truy xuất</param>
        /// <param name="code">Mã bản ghi bị tác động</param>
        /// <returns></returns>
        public int logAdd(Page p, string tablename, string code)
        {

            return logAdd(p, tablename, code, "Add record");
        }
        /// <summary>
        /// Ghi thêm bản ghi có ghi chú
        /// </summary>
        /// <param name="p"></param>
        /// <param name="tablename"></param>
        /// <param name="code"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public int logAdd(Page p, string tablename, string code, string note)
        {
            return logAction(p, tablename, "ADD", code, note);
        }
        /// <summary>
        /// Nhật ký sửa một bản ghi
        /// </summary>
        /// <param name="p">Trang hiện tại</param>
        /// <param name="tablename">Bảng có truy xuất</param>
        /// <param name="code">Mã bản ghi bị tác động</param>
        /// <returns></returns>
        public int logEDIT(Page p, string tablename, string code)
        {
            return logEDIT(p, tablename, code, "Modify data");
        }
        /// <summary>
        /// Sửa bản ghi, có ghi chú
        /// </summary>
        /// <param name="p"></param>
        /// <param name="tablename"></param>
        /// <param name="code"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public int logEDIT(Page p, string tablename, string code, string note)
        {
            return logAction(p, tablename, "EDI", code, note);
        }
        /// <summary>
        /// Nhật ký xóa một bản ghi
        /// </summary>
        /// <param name="p">Trang hiện tại</param>
        /// <param name="tablename">Bảng có truy xuất</param>
        /// <param name="code">Mã bản ghi bị tác động</param>
        /// <returns></returns>
        public int logDELETE(Page p, string tablename, string code)
        {

            return logDELETE(p, tablename, code, "delete record");
        }
        /// <summary>
        /// Xóa bản ghi có ghi chú
        /// </summary>
        /// <param name="p"></param>
        /// <param name="tablename"></param>
        /// <param name="code"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public int logDELETE(Page p, string tablename, string code, string note)
        {
            return logAction(p, tablename, "DEL", code, note);
        }
        /// <summary>
        /// Nhật ký xem một bản ghi
        /// </summary>
        /// <param name="p">Trang hiện tại</param>
        /// <param name="tablename">Bảng có truy xuất</param>
        /// <param name="code">Mã bản ghi bị tác động</param>
        /// <returns></returns>
        public int logVIEW(Page p, string tablename, string code)
        {

            return logVIEW(p, tablename, code, "view record");
        }
        /// <summary>
        /// Xem có mô tả
        /// </summary>
        /// <param name="p"></param>
        /// <param name="tablename"></param>
        /// <param name="code"></param>
        /// <param name="note"></param>
        /// <returns></returns>
        public int logVIEW(Page p, string tablename, string code, string note)
        {
            return logAction(p, tablename, "VIE", code, note);
        }

        /// <summary>
        /// Ghi nhận một file được upload lên hệ thống
        /// </summary>
        /// <param name="linkfile"></param>
        /// <param name="note"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public int UploadedFile(string linkfile, string note, string type)
        {
            int ret = 0;
            THEFILE_BUS bus = new THEFILE_BUS();
            THEFILE_OBJ obj_file = new THEFILE_OBJ();

            obj_file.CODEVIEW = type;
            obj_file.EDITTIME = DateTime.Now;
            obj_file.EDITUSER = ses.loginCode;
            obj_file.LOCK = 0;
            obj_file.LOCKDATE = DateTime.Now;
            obj_file.NAME = linkfile;
            obj_file.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
            obj_file.NOTE = note;
            obj_file.CODE = bus.genNextCode(obj_file);
            ret = bus.insert(obj_file);
            bus.CloseConnection();
            return ret;

        }
        #endregion
    }
}
