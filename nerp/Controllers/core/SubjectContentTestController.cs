using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Sess;
using IS.uni;
using IS.fitframework;
using IS.Config;
using Newtonsoft.Json;
using System.Web.Script.Serialization;
using IS.Lang;

namespace mtarms._2.u.Controllers
{
    public class SubjectContentTestController : Controller
    {
        session ses = new session();
        /// <summary>
        /// thực hiện insert và update
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public JsonResult Update(SUBJECTCONTENTTEST_OBJ obj)
        {

            SUBJECTCONTENTTEST_BUS bus = new SUBJECTCONTENTTEST_BUS();
            //kiểm tra tồn tại cho trường hợp sửa
            int ret = 0;
            int add = 0;
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("SUBJECTCONTENTCODE", obj.SUBJECTCONTENTCODE, 0));
            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            var objTemp = bus.GetByKey(lipa.ToArray());
            if (objTemp == null)
            {
                objTemp = new SUBJECTCONTENTTEST_OBJ();
                add = 1;
            }  
            //hết kiểm tra tồn tại bản ghi
            objTemp.EDITTIME = DateTime.Now; //Thời điểm sủa bản ghi
            objTemp.EDITUSER = ses.loginCode; //Người sửa bản ghi
            objTemp.NAME = obj.NAME;
            objTemp.LOCK = obj.LOCK;
            objTemp.NOTE = obj.NOTE;
            objTemp.THEORDER = obj.THEORDER;
            objTemp.SUBJECTCONTENTCODE = obj.SUBJECTCONTENTCODE;
            objTemp.EXAMTIMECODE = obj.EXAMTIMECODE;
            objTemp.EXAMFORMCODE = obj.EXAMFORMCODE;
            objTemp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
            objTemp.QUESTIONUSECODE = obj.QUESTIONUSECODE;
            objTemp.LANG = ses.getLang();
            if (add == 1)
            {
                ret = bus.insert(objTemp);
            }
            else
            {
                ret = bus.update(objTemp);
            }
            bus.CloseConnection();
            return Json(new
            {
                ret = ret
            }, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// update examformcode sau khi chọn subjectcontent là bài học được học
        /// </summary>
        /// <param name="examformcode"></param>
        /// <returns></returns>
        public JsonResult Update2(string subjectContentCode, string examTimeCode, string examFormCode)
        {
            var ret = 0;
            SUBJECTCONTENTTEST_BUS bus = new SUBJECTCONTENTTEST_BUS();
            var obj = bus.GetByKey(new fieldpara("SUBJECTCONTENTCODE", subjectContentCode, 0),
                new fieldpara("EXAMTIMECODE", examTimeCode, 0),
                new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            if (obj == null)
                ret = -1;
            else
            {
                obj.EXAMFORMCODE = examFormCode;
                ret = bus.Update(obj);
            }
            return Json(new {ret = ret}, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// lấy subjectcontenttest theo subjectcontent
        /// </summary>
        /// <param name="subjectcontentcode">mã bài học</param>
        /// <returns></returns>
        public List<string> GetBySubjectContent(string subjectcontentcode)
        {
            List<string> result = new List<string>();
            SUBJECTCONTENTTEST_BUS bus = new SUBJECTCONTENTTEST_BUS();
            var data = bus.GetByKey(new fieldpara("SUBJECTCONTENTCODE", subjectcontentcode, 0));
            var examtimecode = "";
            var teststructcode = "";
            if (data != null)
            {
                teststructcode = data._EXAMTIMECODE.TESTSTRUCTCODE;
                examtimecode = data.EXAMTIMECODE;
            }      
            bus.CloseConnection();
            result.Add(examtimecode);
            result.Add(teststructcode);
            return result;
        }

        public JsonResult GetBySubjectContentJson(string subjectcontentcode)
        {
            var ret = -1;
            List<string> result = GetBySubjectContent(subjectcontentcode);
            if (result.Count > 0)
                ret = 0;
            return Json(new {ret = ret, examtimecode = result[0], teststructcode = result[1]}, JsonRequestBehavior.AllowGet);


        }
    }
}