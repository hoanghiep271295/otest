﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Net.Mime;
using System.Web.Mvc;
using IS.Config;
using IS.fitframework;
using IS.Sess;
using IS.uni;
using mtarms._2.u.Controllers;
using nerp.Controllers.exam;
using Newtonsoft.Json;

namespace nerp.Controllers.core
{
    public class CourseStudiedController : Controller
    {
        session ses = new session();
        public ActionResult Index(string id)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.defaulttab = id;
            defaultobject.thetype = ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);


            string[] jsx = {
                "/Scripts/reactselect/prop-types.js"
                ,"/Scripts/reactselect/react-input-autosize.js"
                ,"/Scripts/reactselect/classname.js"
                ,"/Scripts/reactselect/react-select.js"
                , "/Jsx/_Shared/ButtonList.jsx"
                ,"/Jsx/_Shared/PopupSearch.jsx"
                ,"/Jsx/_Shared/Combobox.jsx"
                ,"/Jsx/_Shared/Tree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/AgGrid.jsx"
                ,"/Jsx/_Shared/TabHeader.jsx"
                , "/jsx/Core/CourseStudied/Coursestudiedlist.jsx"
                , "/jsx/Core/CourseStudied/CoursestudiedApp.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
        }
        public JsonResult GetListStudied(string subjectcode, string coursecode)
        {
            COURSESTUDIED_BUS bus = new COURSESTUDIED_BUS();
            List<string> listStudiedCode = new List<string>();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("COURSECODE", coursecode, 0));
            if (!string.IsNullOrEmpty(subjectcode)) // có cái này hay ko ko quan trọng lắm
                lipa.Add(new fieldpara("SUBJECTCODE", subjectcode, 0));
            var data = bus.getAllBy2("CODE", lipa.ToArray());
            foreach (var item in data)
            {
                listStudiedCode.Add(item.SUBJECTCONTENTCODE);
            }
            return Json(new { data = data, listStudiedCode = listStudiedCode }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(List<string> liSubjectContentCode, string coursecode, string subjectcode, List<string> liContentTypeCode)
        {
            COURSESTUDIED_BUS bus = new COURSESTUDIED_BUS();
            int ret = 0, ret1 = 0, ret2 = 0;
            COURSESTUDIED_OBJ obj_temp = null;

            if (liSubjectContentCode == null || liSubjectContentCode.Count <= 0)
                ret = -1;
            else
            {
                for (int i=0; i< liSubjectContentCode.Count; i++)
                {
                    var subjectcontentcode = liSubjectContentCode[i];
                    obj_temp = bus.GetByKey(new fieldpara("SUBJECTCONTENTCODE", subjectcontentcode, 0),
                                            new fieldpara("COURSECODE", coursecode, 0));
                    if (obj_temp == null)
                    {
                        obj_temp = new COURSESTUDIED_OBJ();
                        //hết kiểm tra tồn tại bản ghi
                        obj_temp.EDITTIME = DateTime.Now; //Thời điểm sủa bản ghi
                        obj_temp.EDITUSER = ses.loginCode; //Người sửa bản ghi
                        obj_temp.SUBJECTCODE = subjectcode;
                        obj_temp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
                        obj_temp.LOCK = 0;
                        obj_temp.COURSECODE = coursecode;
                        obj_temp.SUBJECTCONTENTCODE = subjectcontentcode;
                    //    obj_temp.LANG = ses.getLang();
                        //Kiểm tra tình trạng sửa hay là thêm mới
                        obj_temp.CODE = bus.genNextCode(obj_temp);
                        obj_temp.LOCKDATE = DateTime.Now;
                        ret = bus.insert(obj_temp);
                        // nếu là bài kiểm tra thì sinh phòng thi và đề thi
                        // check xem có phải là bài kiểm tra hay ko
                        CONTENTTYPE_OBJ contentType = null;//new CONTENTTYPE_OBJ();
                        if (!string.IsNullOrEmpty(liContentTypeCode[i]))
                        {
                            CONTENTTYPE_BUS busContentType = new CONTENTTYPE_BUS();
                            contentType =busContentType.GetByID(new CONTENTTYPE_OBJ.BusinessObjectID(liContentTypeCode[i]));
                            busContentType.CloseConnection();
                        }
                        var contentTypeCode = "";
                        if (contentType != null)
                            contentTypeCode = contentType.CODEVIEW;
//Nội dung học lý thuyết: LT - Nội dung hiển thị nếu có(NOTE != null, '') thì hiển thị (Ms Cúc)
//Nội dung là bài tập: BT - Nội dung hiển thị là bài tập (mr Uyên)
//Nội dung là kiểm tra cuối giai đoạn: KT - Kiểm tra kết thúc giai đoạn (Mr Uyên)
//Nội dung là thi kết thúc môn: TH - Thi kết thúc môn (Mr Cúc)

                        if (contentTypeCode == "KT" || contentTypeCode == "BT" || contentTypeCode == "TH")
                        {
                            //Mỗi code sẽ tự động thêm vào trong subjectcontenttest một bản ghi
                            //sinh ra examhallstudent
                            //sinh ra examhall - giả
                            //sinh ra examform 
                            //sinh ra examform detail
                            //
                            ExamFormController con = new ExamFormController();
                            //Tiến hành sinh đề cho cấu trúc này, và sinh viên cho phần đó

                            // lấy đợt thi và mã cấu trúc đề thi thông qua subjectcontenttest
                            List<string> result = new SubjectContentTestController().GetBySubjectContent(subjectcontentcode);
                            var examTimeCode = result[0];
                            var testStructCode = result[1];
                            ret = con.ProcessExamFormAuto(examTimeCode, coursecode, 1);
                            //// tạo phòng thi
                            //ret1 = new ExamHallStudentController().CreateExamHallStudent(examTimeCode);// , examhallstudent, examhall
                            //ArrayList resArrayList = new ExamFormController().CreateExamForm(examTimeCode, testStructCode);//cập nhật vào examform, examformdetail
                            //ret2 = (int)resArrayList[0];

                        }
                    } else
                    {
                        obj_temp.LOCK = 1;
                        ret = bus.update(obj_temp);
                       
                    }
                }
            }
            bus.CloseConnection();
            //some thing like that
            return Json(new { ret = ret, ret1 = ret1, ret2 = ret2 }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(List<string> liId)
        {
            var ret = 0;
            if (liId != null)
            {
                var bus = new COURSESTUDIED_BUS();
                foreach (var id in liId)
                {
                    var item = bus.GetByID(new COURSESTUDIED_OBJ.BusinessObjectID(id));
                    if (item == null)
                    {
                        ret = -2;
                        continue;
                    }
                    if (item.UNIVERSITYCODE != ses.gUNIVERSITYCODE)
                    {
                        ret = -4;
                    }
                    if (ret >= 0)
                    {
                        ret = bus.delete(item._ID);
                    }

                }
                bus.CloseConnection();
            }
            return Json(new
            {
                ret = ret
            }, JsonRequestBehavior.AllowGet);

        }
    }
}