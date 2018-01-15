﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using IS.Sess;
using IS.uni;
using IS.fitframework;
using IS.Config;
using Newtonsoft.Json;
using IS.Lang;

namespace nerp.Controllers
{
 
    public class ContentTypeController : Controller
    {
        // GET: ContentType
        readonly session _ses = new session();
        
        public JsonResult GetList(int page, int pageSize)
        {
            List<CONTENTTYPE_OBJ> data;
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
            CONTENTTYPE_BUS bus = new CONTENTTYPE_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            int countpage;
            //order by theorder, with pagesize and the page
            data = bus.getAllBy2("THEORDER", pageSize, page, out countpage, lipa.ToArray());
            // tất cả các bản ghi
            List<CONTENTTYPE_OBJ> totalData = bus.getAllBy2("THEORDER", lipa.ToArray());
            int totalItem = totalData.Count();
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            int startpage = (page - 1) * pageSize;
            //Trả về client
            var a = JsonConvert.SerializeObject(data);
            return Json(new
            {
                data = data,//Danh sách
                data2 = a,
                totalItem = totalItem,//số lượng bản ghi
                totalPage = countpage,
                startindex = startpage,//bắt đầu số trang
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult CheckCodeViewExit(string code, string codeview)
        {
            int ret;
            CONTENTTYPE_BUS bus = new CONTENTTYPE_BUS();
            CONTENTTYPE_OBJ obj = null;
            if (!string.IsNullOrEmpty(code))
            {
                //check for update
                obj = bus.GetByKey(new fieldpara("CODEVIEW", codeview, 0),
                                           new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));

                if (obj == null)
                {
                    //change codeview
                    ret = 1;
                }
                else
                {
                    //change other feature,not codeview 
                    ret = (code == obj.CODE) ? 1 : -1;
                }

            }
            else
            {

                obj = bus.GetByKey(new fieldpara("CODEVIEW", codeview, 0),
                                           new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                ret = (obj == null) ? 1 : -1;
            }
            bus.CloseConnection();
            return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult Update(CONTENTTYPE_OBJ obj)
        {
            
            CONTENTTYPE_BUS bus =new CONTENTTYPE_BUS();
            //kiểm tra tồn tại cho trường hợp sửa
            CONTENTTYPE_OBJ objTemp;
            int ret = 0;
            int add = 0;

            objTemp = !string.IsNullOrEmpty(obj.CODE) ? bus.GetByID(new CONTENTTYPE_OBJ.BusinessObjectID(obj.CODE)) : new CONTENTTYPE_OBJ();

            if (ret < 0)
            {
                //đóng kết nối trước khi trả về
                bus.CloseConnection();
                //ban ghi sửa đã bị xóa
                return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);

            }
            //hết kiểm tra tồn tại bản ghi
            objTemp.EDITTIME = DateTime.Now;//Thời điểm sủa bản ghi
            objTemp.EDITUSER = _ses.loginCode;//Người sửa bản ghi
            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.LOCK = obj.LOCK;
            objTemp.NOTE = obj.NOTE;
            objTemp.LANG = _ses.getLang();
            objTemp.THEORDER = obj.THEORDER;
            objTemp.UNIVERSITYCODE = _ses.gUNIVERSITYCODE;
         
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

            if (ret < 0)
            {
                bus.RollbackTransaction();
            }
            else
            {
                bus.CommitTransaction();
            }
            bus.CloseConnection();
            return Json(new
            {
                ret = ret,
                obj = objTemp
            }, JsonRequestBehavior.AllowGet);

        }

        public JsonResult Delete(List<string> code)
        {
            var ret = 0;
            var error = false;
            if (code != null)
            {
                var bus = new CONTENTTYPE_BUS();
                for (var i = 0; i < code.Count; i++)
                {
                    if (code[i] != null)
                    {
                        var item = bus.GetByID(new CONTENTTYPE_OBJ.BusinessObjectID(code[i]));
                        if (item == null) { ret = -1; error = true; continue; }
                        if (item.UNIVERSITYCODE != _ses.gUNIVERSITYCODE) { ret = -4; }
                        if (ret >= 0)
                        {
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

            ret = error ? -1 : 0;
            return Json(new
            {
                ret = ret
            }, JsonRequestBehavior.AllowGet);
        }

        public CONTENTTYPE_OBJ GetById(string code)
        {
            CONTENTTYPE_BUS bus = new CONTENTTYPE_BUS();
            var obj = bus.GetByID(new CONTENTTYPE_OBJ.BusinessObjectID(code));
            return obj;
        }

        public JsonResult GetByIdJson(string code)
        {
            var ret = 0;
            var obj = GetById(code);
            if (obj == null)
                ret = -1;
            return Json(new {ret = ret, data = obj}, JsonRequestBehavior.AllowGet);

        }
        public JsonResult getAllSearch(string code, string codetype, string name, string nametype, string note, string notetype)
        {
            List<CONTENTTYPE_OBJ> li = null;

            //Khai báo lấy dữ liệu
            CONTENTTYPE_BUS bus = new CONTENTTYPE_BUS();
            List<fieldpara> lipa = new List<fieldpara>();

            //lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            //lipa.Add(new fieldpara("THETYPE", codetype));
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
            li = bus.getAllBy2(" THEORDER ", lipa.ToArray());
            bus.CloseConnection();
            //li = li.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Json(new
            {
                lst = li,//Danh sách
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }
        public JsonResult GetAll()
        {
            var ret = -1;
            List<CONTENTTYPE_OBJ> li = null;
            //Khai báo lấy dữ liệu
            CONTENTTYPE_BUS bus = new CONTENTTYPE_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            //order by theorder, with pagesize and the page
            li = bus.getAllBy2("NAME", lipa.ToArray());
            if (li.Count >= 0)
                ret = 0;
            bus.CloseConnection();
            //li = li.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Json(new
            {
                lst = li,//Danh sách
                ret = ret//ok
            }, JsonRequestBehavior.AllowGet);
        }
    }
}