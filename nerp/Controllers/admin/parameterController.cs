using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.uni;
using IS.fitframework;
using Microsoft.Ajax.Utilities;
using IS.Sess;
using IS.Config;
using IS.Pool;
namespace uni.Controllers
{
    public class ParameterController : Controller
    {
        session ses = new session();
       /// <summary>
       /// Lấy giá trị trong session của cá nhân hiện tại theo danh sách
       /// </summary>
       /// <param name="thetype">Kiểu menu được soạn thảo</param>
       /// <returns></returns>
        public JsonResult Get(string key)
       {
           string thevalue = ses.Get(key);
            return Json(new
            {
                lst = thevalue,//Danh sách
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Thiết lập lại giá trị theo key
        /// </summary>
        /// <param name="code">Mã của đối tượng cha</param>
        /// <returns></returns>
        public JsonResult Set(string key, string value)
        {
            int ret = 0;
            ret = ses.Set(key, value);
            return Json(new
            {
                ret = ret
            }, JsonRequestBehavior.AllowGet);
        }
   }
}