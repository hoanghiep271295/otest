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
using System.Dynamic;
using Newtonsoft.Json;

namespace uni.Controllers
{
    public class StaffListController : Controller
    {
        session ses = new session();
        public ActionResult Index(string id)
        {
            //chọn mặc định một cái menu nào đó
            dynamic defaultobject = new ExpandoObject();
            defaultobject.code = id;
            defaultobject.thetype = ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);

            string[] jsx = {
                "/Jsx/_Shared/Tree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/SearchDialog.jsx"
                ,"/Jsx/_Shared/Combobox.jsx"
                ,"/Jsx/_Shared/Combobox3.jsx"
                ,"/jsx/_shared/AgGrid.jsx"
                ,"/Jsx/_Shared/ButtonList.jsx"
                ,"/jsx/Core/Staff/Stafflist2.jsx"
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
            //Đến trang thông báo khi không có phân quyền sử dụng chức năng này
            //if (ses.func("SUPADMIN") <= 0)
            //{
            //    ses.gotoPage("/staff/login", "Thông báo", "Không có quyền thực hiện chức năng", 3000);
            //    return Redirect("/common/index");
            //}
            //Gán dữ liệu mặc định cho phần chọn 
            //if (string.IsNullOrEmpty(id))
            //{
            //    id = "";
            //}
            //ViewBag.thetype = "FRONTEND";
            //ViewBag.id = id;
            //ViewBag.jsx = "~/Jsx/Sysmenu/Sysmennu.jsx";
            //return View();
        }

        public JsonResult getAll(string thetype)
        {
            List<DEPARTMENT_OBJ> li = null;
            //Khai báo lấy dữ liệu
            DEPARTMENT_BUS bus = new DEPARTMENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>();

            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            lipa.Add(new fieldpara("THETYPE", thetype));
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

        public JsonResult getAllSearch(string code, string thetype, string name, string nametype, string note, string notetype)
        {
            List<STAFF_OBJ> li = null;

            //Khai báo lấy dữ liệu
            STAFF_BUS bus = new STAFF_BUS();
            List<fieldpara> lipa = new List<fieldpara>();

            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            //lipa.Add(new fieldpara("THETYPE", thetype));
            lipa.Add(new fieldpara("DEPARTMENTCODE", code));
            if (!string.IsNullOrEmpty(name))
            {
                lipa.Add(new fieldpara("NAME", name, (int)(nametype.ToUpper() == "TRUE" ? searchType.NONE : searchType.LIKE)));
            }
            if (!string.IsNullOrEmpty(note))
            {
                lipa.Add(new fieldpara("NOTE", note, (int)(notetype.ToUpper() == "TRUE" ? searchType.NONE : searchType.LIKE)));
            }
            //order by theorder, with pagesize and the page
            //li = bus.getAllBy2("THEORDER ", lipa.ToArray());
            li = bus.getAllBy2("CODEVIEW ", lipa.ToArray());
            bus.CloseConnection();
            //li = li.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Json(new
            {
                lst = li,//Danh sách
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult delete(List<string> code)
        {
            int ret = 0;
            STAFF_BUS bus = new STAFF_BUS();
            List<STAFF_OBJ.BusinessObjectID> li_del = new List<STAFF_OBJ.BusinessObjectID>();
            foreach (string item in code)
            {
                li_del.Add(new STAFF_OBJ.BusinessObjectID(item));
                ret = bus.checkCode(null, new fieldpara("parentcode", item));
                if (ret > 0)
                {
                    ret = -2;
                    break;
                }
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

                ret = bus.DeletetMultiItems(li_del);
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

            return Json(new { ret = ret }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult update(STAFF_OBJ obj)
        {
            List<string> li_ref = new List<string>();// danh sach file sẽ được thêm vào
            List<string> li_refd = new List<string>();// sanh sách file bị xoá đi
            //if (ses.func("SUPADMIN") <= 0)
            //{
            //    return Json(new { sussess = -3 }, JsonRequestBehavior.AllowGet);

            //}
            STAFF_BUS bus = new STAFF_BUS();
            int ret = 0;
            int add = 0;

            STAFF_OBJ obj_temp = null;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                obj_temp = bus.GetByID(new STAFF_OBJ.BusinessObjectID(obj.CODE));
                if (obj_temp == null || obj_temp.UNIVERSITYCODE != ses.gUNIVERSITYCODE)
                {
                    ret = -4;
                }
            }
            else
            {
                obj_temp = new STAFF_OBJ();
                obj_temp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
            }

            if (ret < 0)
            {
                //đóng kết nối trước khi trả về
                bus.CloseConnection();
                //ban ghi sửa đã bị xóa
                return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);

            }
            //hết kiểm tra tồn tại bản ghi
            obj_temp.EDITTIME = DateTime.Now;//Thời điểm sủa bản ghi
            obj_temp.EDITUSER = ses.loginCode;//Người sửa bản ghi

            obj_temp.CODEVIEW = obj.CODEVIEW;
            obj_temp.NAME = obj.NAME;
            obj_temp.NOTE = obj.NOTE;
            obj_temp.DEPARTMENTCODE = obj.DEPARTMENTCODE;
            obj_temp.BIRTHDAY = obj.BIRTHDAY;

            if (obj_temp.DEPARTMENTCODE == null)
            {
                obj_temp.DEPARTMENTCODE = "";
            }
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                obj_temp.CODE = bus.genNextCode(obj);
                obj_temp.LOCK = 0;
                obj_temp.LOCKDATE = DateTime.Now;
                //obj_temp.MODULECODE = "CORE";//for this
            }
                       
            if (add == 1)
            {
                ret = bus.insert(obj_temp);
            }
            else
            {
                //gán _ID để xác định bản ghi sẽ được cập nhật
                obj_temp._ID.CODE = obj.CODE;
                ret = bus.update(obj_temp);
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
            return Json(new { ret = ret, CODE = obj_temp.CODE }, JsonRequestBehavior.AllowGet);
        }
                     

    }
}