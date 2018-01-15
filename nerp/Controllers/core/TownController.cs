using IS.fitframework;
using IS.Sess;
using IS.uni;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace nerp.Controllers.core
{
    public class TownController : Controller
    {
        private readonly session _ses = new session();

        public List<TOWN_OBJ> GetAllSearch(string parentcode, string name, string nametype, string note, string notetype)
        {
            //Khai báo lấy dữ liệu
            TOWN_BUS bus = new TOWN_BUS();
            List<fieldpara> lipa = new List<fieldpara> {new fieldpara("PARENTCODE", parentcode, 0)};
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
            return li;
        }

        public int Update(TOWN_OBJ obj)
        {
            //if (ses.func("SUPADMIN") <= 0)
            //{
            //    return Json(new { sussess = -3 }, JsonRequestBehavior.AllowGet);

            //}
            TOWN_BUS bus = new TOWN_BUS();
            int ret;
            int add = 0;

            TOWN_OBJ objTemp;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                objTemp = bus.GetByID(new TOWN_OBJ.BusinessObjectID(obj.CODE));
                if (objTemp == null)
                {
                    ret = -4;

                    bus.CloseConnection();
                    return ret;
                }
            }
            else
            {
                objTemp = new TOWN_OBJ();
            }
            //hết kiểm tra tồn tại bản ghi
            objTemp.EDITTIME = DateTime.Now;//Thời điểm sủa bản ghi
            objTemp.EDITUSER = _ses.loginCode;//Người sửa bản ghi

            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.NOTE = obj.NOTE;
            objTemp.PARENTCODE = obj.PARENTCODE;
            objTemp.LOCK = obj.LOCK;
            objTemp.BEGINDATE = obj.BEGINDATE;
            objTemp.ENDDATE = obj.ENDDATE;
            objTemp.THETYPE = "TOWN";
            if (objTemp.PARENTCODE == null)
            {
                objTemp.PARENTCODE = "";
            }
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
            return ret;
        }

        public int Delete(List<string> code)
        {
            int ret = 0;
            TOWN_BUS bus = new TOWN_BUS();
            List<TOWN_OBJ.BusinessObjectID> liDel = new List<TOWN_OBJ.BusinessObjectID>();
            foreach (string item in code)
            {
                liDel.Add(new TOWN_OBJ.BusinessObjectID(item));
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

            return ret;
        }
    }
}