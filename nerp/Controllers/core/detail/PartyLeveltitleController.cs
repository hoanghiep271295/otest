using IS.Config;
using IS.fitframework;
using IS.Sess;
using IS.uni;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace nerp.Controllers.core
{
    public class PartyLeveltitleController : Controller
    {
        session ses = new session();

        public JsonResult getAll(string thetype)
        {
            List<PARTYLEVELTITLE_OBJ> li = null;
            PARTYLEVELTITLE_BUS bus = new PARTYLEVELTITLE_BUS();
            List<fieldpara> lipa = new List<fieldpara>();

            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            //lipa.Add(new fieldpara("THETYPE", thetype));
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
            List<PARTYLEVELTITLE_OBJ> li = null;
            PARTYLEVELTITLE_BUS bus = new PARTYLEVELTITLE_BUS();
            List<fieldpara> lipa = new List<fieldpara>();

            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            if (!string.IsNullOrEmpty(code))
            {
                lipa.Add(new fieldpara("CODEVIEW", name, (int)(thetype.ToUpper() == "TRUE" ? searchType.NONE : searchType.LIKE)));
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

        public JsonResult delete(List<string> code)
        {
            int ret = 0;
            PARTYLEVELTITLE_BUS bus = new PARTYLEVELTITLE_BUS();
            List<PARTYLEVELTITLE_OBJ.BusinessObjectID> li_del = new List<PARTYLEVELTITLE_OBJ.BusinessObjectID>();
            foreach (string item in code)
            {
                li_del.Add(new PARTYLEVELTITLE_OBJ.BusinessObjectID(item));
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

        public JsonResult update(PARTYLEVELTITLE_OBJ obj)
        {
            List<string> li_ref = new List<string>();// danh sach file sẽ được thêm vào
            List<string> li_refd = new List<string>();// sanh sách file bị xoá đi
            //if (ses.func("SUPADMIN") <= 0)
            //{
            //    return Json(new { sussess = -3 }, JsonRequestBehavior.AllowGet);

            //}
            PARTYLEVELTITLE_BUS bus = new PARTYLEVELTITLE_BUS();
            int ret = 0;
            int add = 0;

            PARTYLEVELTITLE_OBJ obj_temp = null;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                obj_temp = bus.GetByID(new PARTYLEVELTITLE_OBJ.BusinessObjectID(obj.CODE));
                if (obj_temp == null )
                {
                    ret = -4;
                }
            }
            else
            {
                obj_temp = new PARTYLEVELTITLE_OBJ();
                //obj_temp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
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
            obj_temp.THEORDER = obj.THEORDER;
            obj_temp.COMPARELEVEL = obj.COMPARELEVEL;
            //  obj_temp.PARENTCODE = obj.PARENTCODE;
            obj_temp.LOCK = obj.LOCK;
            
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
                obj_temp.CODE = bus.genNextCode(obj);
                obj_temp.LOCK = 0;
                obj_temp.LOCKDATE = DateTime.Now;
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
            return Json(new { ret = ret,  obj = obj_temp }, JsonRequestBehavior.AllowGet);
        }


    }
}

