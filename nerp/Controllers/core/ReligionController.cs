﻿using IS.fitframework;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;

namespace nerp.Controllers.core
{
    public class ReligionController : Controller
    {
        private readonly session _ses = new session();

        public ActionResult Index(string id)
        {
            //chọn mặc định một cái menu nào đó
            dynamic defaultobject = new ExpandoObject();
            defaultobject.code = id;
            defaultobject.thetype = _ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx = {
                "/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/SearchDialog.jsx"
                ,"/Jsx/_Shared/Combobox.jsx"
                ,"/Jsx/_Shared/Combobox3.jsx"
                ,"/jsx/_shared/AgGrid.jsx"
                ,"/Jsx/_Shared/ButtonList.jsx"
                ,"/jsx/Core/Religion/Religionpopup.jsx"
                ,"/jsx/Core/Religion/Religionlist.jsx"
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
        }

        //public JsonResult getAll(string thetype)
        //{
        //    List<RELIGION_OBJ> li = null;
        //    //Khai báo lấy dữ liệu
        //    RELIGION_BUS bus = new RELIGION_BUS();

        //    //order by theorder, with pagesize and the page
        //    li = bus.getAllBy2(" NAME ");
        //    bus.CloseConnection();
        //    //li = li.Skip((page - 1) * pageSize).Take(pageSize).ToList();
        //    return Json(new
        //    {
        //        lst = li,//Danh sách
        //        ret = 0//ok
        //    }, JsonRequestBehavior.AllowGet);
        //}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="code"></param>
        /// <param name="codetype"></param>
        /// <param name="name"></param>
        /// <param name="nametype"></param>
        /// <param name="note"></param>
        /// <param name="notetype"></param>
        /// <returns></returns>
        public JsonResult GetAllSearch(string code, string codetype, string name, string nametype, string note, string notetype)
        {
            //Khai báo lấy dữ liệu
            RELIGION_BUS bus = new RELIGION_BUS();
            List<fieldpara> lipa = new List<fieldpara>();

            //lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            //lipa.Add(new fieldpara("THETYPE", thetype));
            //lipa.Add(new fieldpara("PARENTCODE", code));
            if (!string.IsNullOrEmpty(code))
            {
                lipa.Add(new fieldpara("CODEVIEW", code, (int)(codetype.ToUpper() == "TRUE" ? searchType.NONE : searchType.LIKE)));
            }
            if (!string.IsNullOrEmpty(name))
            {
                lipa.Add(new fieldpara("NAME", name, (int)(nametype.ToUpper() == "TRUE" ? searchType.NONE : searchType.LIKE)));
            }
            if (!string.IsNullOrEmpty(note))
            {
                lipa.Add(new fieldpara("NOTE", note, (int)(notetype.ToUpper() == "TRUE" ? searchType.NONE : searchType.LIKE)));
            }
            //order by theorder, with pagesize and the page
            var li = bus.getAllBy2(" NAME ", lipa.ToArray());
            bus.CloseConnection();
            //li = li.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Json(new
            {
                lst = li,//Danh sách
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(List<string> code)
        {
            int ret = 0;
            RELIGION_BUS bus = new RELIGION_BUS();
            List<RELIGION_OBJ.BusinessObjectID> liDel = new List<RELIGION_OBJ.BusinessObjectID>();
            foreach (string item in code)
            {
                liDel.Add(new RELIGION_OBJ.BusinessObjectID(item));
                ret = bus.checkCode(null, new fieldpara("parentcode", item));
            }
            //ok
            if (ret >= 0)
            {
                //SYSMENUPRIORITY_BUS bus_smp = new SYSMENUPRIORITY_BUS();
                //bus.BeginTransaction();
                //bus_smp.setConnection(bus);
                //foreach (SYSMENU_OBJ.BusinessObjectID obj in li_del)
                //{
                //    ret = bus_smp.Delete(new fieldpara("SYSMENUCODE", obj.CODE));
                //    if (ret < 0)
                //    {
                //        break;
                //    }
                //}
                //if (ret >= 0)
                //{
                //    ret = bus.DeletetMultiItems(li_del);
                //}

                ret = bus.DeletetMultiItems(liDel);
                if (ret >= 0)
                {
                    bus.CommitTransaction();
                }
                else
                {
                    bus.RollbackTransaction();
                }
            }

            bus.CloseConnection();

            return Json(new {ret }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(RELIGION_OBJ obj)
        {
          //  List<string> li_ref = new List<string>();// danh sach file sẽ được thêm vào
           // List<string> li_refd = new List<string>();// sanh sách file bị xoá đi
            //if (ses.func("SUPADMIN") <= 0)
            //{
            //    return Json(new { sussess = -3 }, JsonRequestBehavior.AllowGet);

            //}
            RELIGION_BUS bus = new RELIGION_BUS();
            int ret;
            int add = 0;

            RELIGION_OBJ objTemp;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                objTemp = bus.GetByID(new RELIGION_OBJ.BusinessObjectID(obj.CODE));
                if (objTemp == null)
                {
                    ret = -4;
                    //đóng kết nối trước khi trả về
                    bus.CloseConnection();
                    //ban ghi sửa đã bị xóa
                    return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                objTemp = new RELIGION_OBJ();
                //obj_temp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
            }

            //hết kiểm tra tồn tại bản ghi
            objTemp.EDITTIME = DateTime.Now;//Thời điểm sủa bản ghi
            objTemp.EDITUSER = _ses.loginCode;//Người sửa bản ghi

            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.NOTE = obj.NOTE;
            //  obj_temp.THEORDER = obj.THEORDER;
            //  obj_temp.PARENTCODE = obj.PARENTCODE;
            objTemp.LOCK = obj.LOCK;

            //if (obj_temp.PARENTCODE == null)
            //{
            //    obj_temp.PARENTCODE = "";
            //}
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                objTemp.CODE = bus.genNextCode(obj);
                objTemp.LOCK = 0;
                objTemp.LOCKDATE = DateTime.Now;
                //obj_temp.MODULECODE = "CORE";//for this
            }
            //if (string.IsNullOrEmpty(obj.EXTENSIONCODE))
            //{
            //    obj_temp.EXTENSIONCODE = obj_temp.CODE;
            //}
            //else
            //{
            //    obj_temp.EXTENSIONCODE = obj.EXTENSIONCODE + "." + obj_temp.CODE;
            //}

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

            if (ret >= 0)
            {
                bus.CommitTransaction();
            }
            else
            {
                bus.RollbackTransaction();
            }
            bus.CloseConnection();
            //some thing like that
            return Json(new {ret, obj = objTemp }, JsonRequestBehavior.AllowGet);
        }
    }
}