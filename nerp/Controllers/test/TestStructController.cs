﻿using IS.Config;
using IS.fitframework;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;

namespace nerp.Controllers.test
{
    public class TestStructController : Controller
    {
        private session ses = new session();
        // localcommonlib com = new localcommonlib();

        // GET: Researchstatus
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
                ,"/Jsx/_Shared/DropDownTree.jsx"
                 ,"/Scripts/Dropdowntree/dropdowntree.js"
                ,"/Jsx/_Shared/Tree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/AgGrid.jsx"
                ,"/Jsx/_Shared/TabHeader.jsx"
                , "/jsx/Core/TestStruct/Teststructlist.jsx"
                ,"/jsx/Core/TestStruct/Teststructpopup.jsx"
                , "/jsx/Core/TestStruct/Teststructdetaillist.jsx"
                ,"/jsx/Core/TestStruct/Teststructdetailpopup.jsx"
                 ,"/jsx/Core/TestStruct/Teststructcontentpopup.jsx"
                ,"/jsx/Core/TestStruct/TeststructApp.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
        }

        public JsonResult GetAllSearch(int page, int pageSize, string subjectcode, string code, bool codetype, string name, bool nametype,
                                    string note, bool notetype)
        {
            //mặc định cho phần trang
            if (pageSize == 0)
            {
                pageSize = AppConfig.item4page();
            }
            if (page < 1)
            {
                page = 1;
            }
            //Khai báo lấy dữ liệu
            TESTSTRUCT_BUS bus = new TESTSTRUCT_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("SUBJECTCODE", subjectcode, 0));
            if (!string.IsNullOrEmpty(code))
            {
                lipa.Add(codetype ? new fieldpara("CODEVIEW", code, 0) : new fieldpara("CODEVIEW", code, 1));
            }
            if (!string.IsNullOrEmpty(name))
            {
                lipa.Add(nametype ? new fieldpara("NAME", name, 0) : new fieldpara("NAME", name, 1));
            }
            if (!string.IsNullOrEmpty(note))
            {
                lipa.Add(notetype ? new fieldpara("NOTE", note, 0) : new fieldpara("NOTE", note, 1));
            }
            int countpage;
            int totalItem;
            //order by theorder, with pagesize and the page
            var data = bus.getAllBy2("NAME", pageSize, page, out countpage, out totalItem, lipa);
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            int startpage = (page - 1) * pageSize;
            return Json(new
            {
                lst = data,//Danh sách
                totalItem, // số lượng tất cả các bản ghi
                totalPage = countpage, // số lượng trang
                startindex = startpage,//bắt đầu số trang
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(List<String> code)
        {
            var ret = 0;
            var error = false;
            if (code != null)
            {
                var bus = new TESTSTRUCT_BUS();
                for (var i = 0; i < code.Count; i++)
                {
                    if (code[i] != null)
                    {
                        var item = bus.GetByID(new TESTSTRUCT_OBJ.BusinessObjectID(code[i]));
                        if (item == null) { ret = -1; error = true; continue; }
                        if (item.UNIVERSITYCODE != ses.gUNIVERSITYCODE) { ret = -4; }
                        if (ret >= 0)
                        {
                            TESTSTRUCTDETAIL_BUS bus2 = new TESTSTRUCTDETAIL_BUS();
                            List<fieldpara> lipa = new List<fieldpara>();
                            lipa.Add(new fieldpara("TESTSTRUCTCODE", code[i]));
                            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE));
                            ret = new EXAMTIME_BUS().checkCode(null, lipa.ToArray());
                            var ret2 = bus2.checkCode(null, lipa.ToArray());
                            TESTSTRUCTCONTENT_BUS bus3 = new TESTSTRUCTCONTENT_BUS();
                            var ret3 = bus3.checkCode(null, lipa.ToArray());
                            if (ret != 0 || ret2 != 0 || ret3 != 0)
                            {
                                ret = -2;
                            }
                            else
                                ret = bus.delete(item._ID);
                        }
                        if (!error && ret < 0)
                        {
                            error = true;
                        }
                    }
                }
                bus.CloseConnection();
            }

            //   ret = error ? -1 : 0;
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Cập nhật một bản ghi được gửi lên từ phía client
        /// </summary>
        public JsonResult Update(TESTSTRUCT_OBJ obj)
        {
            TESTSTRUCT_BUS bus = new TESTSTRUCT_BUS();
            int ret = 0;
            int add = 0;
            TESTSTRUCT_OBJ objTemp;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                objTemp = bus.GetByID(new TESTSTRUCT_OBJ.BusinessObjectID(obj.CODE));
            }
            else
            {
                objTemp = new TESTSTRUCT_OBJ();
            }
            if (ret < 0)
            {
                //đóng kết nối trước khi trả về
                bus.CloseConnection();
                //ban ghi sửa đã bị xóa
                return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
            }
            //hết kiểm tra tồn tại bản ghi
            objTemp.EDITTIME = DateTime.Now;//Thời điểm sủa bản ghi
            objTemp.EDITUSER = ses.loginCode;//Người sửa bản ghi
            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.SUBJECTCODE = obj.SUBJECTCODE;
            objTemp.NOTE = obj.NOTE;
            objTemp.LOCK = obj.LOCK;
            objTemp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                objTemp.CODE = bus.genNextCode(obj);
                objTemp.LOCKDATE = DateTime.Now;
            }
            if (add == 1)
            {
                ret = bus.insert(objTemp);
            }
            else
            {
                //gán _ID để xác định bản ghi sẽ được cập nhật
                objTemp._ID.CODE = obj.CODE;
                ret = bus.update(objTemp);
            }
            int pagecount = 0;
            int currentpage = 0;
            if (ret >= 0)
            {
                List<fieldpara> lipa = new List<fieldpara>();
                lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
                objTemp._ID.CODE = objTemp.CODE;
                ret = bus.checkPage(objTemp._ID, "CODE", AppConfig.item4page(), out pagecount, out currentpage, lipa);
            }
            bus.CloseConnection();
            //some thing like that
            return Json(new {ret, pagecount, currentpage }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckCodeViewExit(string code, string codeView)
        {
            int ret;
            TESTSTRUCT_BUS bus = new TESTSTRUCT_BUS();
            List<TESTSTRUCT_OBJ> li = bus.getAllBy2(new fieldpara("CODEVIEW", codeView, 0), new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            bus.CloseConnection();
            int count = li.Count;
            if (count == 0) ret = 0;
            else
            {
                if (code != "" && code == li[0].CODE) ret = 0;
                else ret = 1;
            }
            return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult UpdateTestStructDetail(TESTSTRUCTDETAIL_OBJ obj)
        {
            TESTSTRUCTDETAIL_BUS bus = new TESTSTRUCTDETAIL_BUS();
            int ret = 0;
            int add = 0;
            TESTSTRUCTDETAIL_OBJ objTemp;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                objTemp = bus.GetByID(new TESTSTRUCTDETAIL_OBJ.BusinessObjectID(obj.CODE));
            }
            else
            {
                objTemp = new TESTSTRUCTDETAIL_OBJ();
            }
            if (ret < 0)
            {
                //đóng kết nối trước khi trả về
                bus.CloseConnection();
                //ban ghi sửa đã bị xóa
                return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
            }
            //hết kiểm tra tồn tại bản ghi
            objTemp.SUBJECTCODE = obj.SUBJECTCODE;
            objTemp.SUBJECTCONTENTCODE = obj.SUBJECTCONTENTCODE;
            objTemp.TESTSTRUCTCODE = obj.TESTSTRUCTCODE;
            objTemp.AMOUNT = obj.AMOUNT;
            objTemp.TOTALMARK = obj.TOTALMARK;
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                objTemp.CODE = bus.genNextCode(obj);
            }
            if (add == 1)
            {
                ret = bus.insert(objTemp);
            }
            else
            {
                //gán _ID để xác định bản ghi sẽ được cập nhật
                objTemp._ID.CODE = obj.CODE;
                ret = bus.update(objTemp);
            }
            bus.CloseConnection();
            //some thing like that
            return Json(new {ret }, JsonRequestBehavior.AllowGet);
        }

        // lấy danh sách các đề thi
        public JsonResult GetAll(string subjectCode)
        {
            var ret = 0;
            //Lây dữ iệu
            TESTSTRUCT_BUS bus = new TESTSTRUCT_BUS();
            List<fieldpara> lipa = new List<fieldpara> {new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0)};
            //Lọc đơn vị cấp trên; '' sẽ là không co đơn vị cấp trên
            if (!string.IsNullOrEmpty(subjectCode))
                lipa.Add(new fieldpara("SUBJECTCODE", subjectCode, 0));
            //order by theorder, with pagesize and the page
            var liTestStruct = bus.getAllBy2("CODE ", lipa.ToArray());

            TESTSTRUCTCONTENT_BUS busTestStructContent = new TESTSTRUCTCONTENT_BUS();
            var liTestStructContent = busTestStructContent.getAllBy2("CODE", lipa.ToArray());
            // dữ liệu trả về là join giữa liTestStruct và liTestStructContent
            if (liTestStruct == null || liTestStructContent == null)
                ret = -1;
            if (ret >= 0)
            {
                if (liTestStruct != null)
                    foreach (var item in liTestStruct)
                    {
                        TESTSTRUCTCONTENT_OBJ objTemp = new TESTSTRUCTCONTENT_OBJ();
                        objTemp.CODE = item.CODE;
                        objTemp.SUBJECTCODE = item.SUBJECTCODE;
                        objTemp.NAME = item.NAME;
                        objTemp.PARENTCODE = "";
                        objTemp.TESTSTRUCTCODE = item.CODE;
                        objTemp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
                        if (liTestStructContent != null) //ko null thì add vào
                            liTestStructContent.Add(objTemp);
                    }
            }
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            //Trả về cho client
            return Json(new { data = liTestStructContent, liTestStruct, ret }, JsonRequestBehavior.AllowGet);
        }
    }
}