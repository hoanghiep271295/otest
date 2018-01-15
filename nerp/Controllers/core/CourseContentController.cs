﻿using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;
using IS.fitframework;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;

namespace nerp.Controllers.core
{
    public class CourseContentController : Controller
    {
        readonly session _ses = new session();
        // GET: CourseStudent
        public ActionResult Index(string id, string subid)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.defaulttab = id;
            defaultobject.thetype = _ses.loginType;
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
                , "/jsx/Core/CourseContent/Coursecontentlist.jsx"
                , "/jsx/Core/CourseContent/CoursecontentApp.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
        }
        public JsonResult GetList(string coursecode)
        {
            var ret = -1;
            List<COURSECONTENT_OBJ> li;
            COURSECONTENT_BUS bus = new COURSECONTENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>(); 
            lipa.Add(new fieldpara("COURSECODE", coursecode, 0));
            lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            li = bus.getAllBy2("THEORDER", lipa.ToArray());
            bus.CloseConnection();
            List<SUBJECTCONTENT_OBJ> listSubjectContent = null; // list subjectcontent tương ứng
            if (li != null)
                ret = 0;
            if (ret >= 0)
            {
                listSubjectContent = new List<SUBJECTCONTENT_OBJ>();
                SUBJECTCONTENT_BUS subjectcontentBus = new SUBJECTCONTENT_BUS();
                if (li != null)
                    foreach (var item in li)
                    {
                        var subjectContent =
                            subjectcontentBus.GetByID(new SUBJECTCONTENT_OBJ.BusinessObjectID(item.SUBJECTCONTENTCODE));
                        if (subjectContent != null)
                        {
                            subjectContent.NOTE = "";
                            listSubjectContent.Add(subjectContent);

                        }
                           
                    }
                subjectcontentBus.CloseConnection();
            }
            return Json(new {data = li, lst = listSubjectContent, ret}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(List<string> liSubjectContentCode, string coursecode, string subjectcode)
        {
            COURSECONTENT_BUS bus = new COURSECONTENT_BUS();
            int ret = 0;
            COURSECONTENT_OBJ objTemp = new COURSECONTENT_OBJ();
            List<COURSECONTENT_OBJ> li = new List<COURSECONTENT_OBJ>(); // danh sách sẽ insert vào csdl
            if (liSubjectContentCode == null || liSubjectContentCode.Count <= 0)
                ret = -1;
            else
            {
                string tempCode = bus.genNextCode(objTemp);
                foreach (var subjectcontentcode in liSubjectContentCode)
                {
                    objTemp = bus.GetByKey(new fieldpara("SUBJECTCONTENTCODE", subjectcontentcode, 0),
                                            new fieldpara("COURSECODE", coursecode, 0),
                                            new fieldpara("SUBJECTCODE", subjectcode, 0));
                    if (objTemp == null)
                    {
                        objTemp = new COURSECONTENT_OBJ {CODE = tempCode};
                        tempCode = bus.genNextCode(objTemp, tempCode);
                        //hết kiểm tra tồn tại bản ghi
                        objTemp.EDITTIME = DateTime.Now; //Thời điểm sủa bản ghi
                        objTemp.EDITUSER = _ses.loginCode; //Người sửa bản ghi
                        objTemp.SUBJECTCODE = subjectcode;
                        objTemp.UNIVERSITYCODE = _ses.gUNIVERSITYCODE;
                        objTemp.LOCK = 0;
                        objTemp.COURSECODE = coursecode;
                        objTemp.SUBJECTCONTENTCODE = subjectcontentcode;
                        objTemp.LANG = _ses.getLang();
                        objTemp.LOCKDATE = DateTime.Now;
                        li.Add(objTemp);
                    }
                }
            }
            bus.BeginTransaction();
            if (li.Count > 0)
            {
                ret = bus.InsertMultiItems(li);
                if (ret < 0)
                {
                    //Trong trường hợp nhiều thao tác, có một thao tác không thành công,
                    //hàm này được gọi để quay lại trạng thái trước khi thực hiện (bắt đầu từ khi gọi BeginTransaction()
                    bus.RollbackTransaction();
                }
                else
                {
                    //Sau khi thao tác dữ liệu thành công, hàm này được gọi để thực hiện ghi vào cơ sở dữ liệu
                    bus.CommitTransaction();
                }
            }
            bus.CloseConnection();
            //some thing like that
            return Json(new {ret}, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(List<string> liId, string coursecode)
        {
            var ret = 0;
            if (liId != null) {
                var bus = new COURSECONTENT_BUS();
                foreach (var id in liId)
                {
                    var item = bus.GetByKey(new fieldpara("SUBJECTCONTENTCODE", id, 0),
                        new fieldpara("COURSECODE", coursecode, 0),
                        new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                        if (item == null)
                        {
                            ret = -2;
                            continue;
                        }
                        if (item.UNIVERSITYCODE != _ses.gUNIVERSITYCODE)
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
                ret
            }, JsonRequestBehavior.AllowGet);

        }

    }

}