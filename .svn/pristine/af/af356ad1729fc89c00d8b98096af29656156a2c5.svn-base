using IS.fitframework;
using IS.Sess;
using IS.uni;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace nerp.Controllers.core
{
    public class ProvinceController : Controller
    {
        private readonly session _ses = new session();

        public ActionResult Index(string id)
        {
            //chọn mặc định một cái menu nào đó
            string defaultvalue = "{\"code\":\"" + id + "\", \"subcode\":\"345\", \"thedate\":\"2017-2-3\"}";
            ViewBag.defaultvalue = defaultvalue;
            string[] jsx = {
                "/Jsx/_Shared/Tree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/SearchDialog.jsx"
                ,"/Jsx/_Shared/Combobox.jsx"
                ,"/Jsx/_Shared/Combobox3.jsx"
                ,"/jsx/Core/Province/Provincepopup.jsx"
                ,"/jsx/_shared/AgGrid.jsx"
                ,"/Jsx/_Shared/ButtonList.jsx"
                ,"/jsx/Core/Province/Provincelist.jsx"
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

        public JsonResult GetAll()
        {
            //Khai báo lấy dữ liệu
            PROVINCE_BUS bus = new PROVINCE_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            { new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0)};
            //order by theorder, with pagesize and the page
            var li = bus.getAllBy2("NAME", lipa.ToArray());
            bus.CloseConnection();
            //District
            DISTRICT_BUS busDistrict = new DISTRICT_BUS();
            List<DISTRICT_OBJ> liDistrict = busDistrict.getAllBy2("NAME");
            busDistrict.CloseConnection();
            TOWN_BUS busTown = new TOWN_BUS();
            List<TOWN_OBJ> liTown = busTown.getAllBy2("NAME");
            busTown.CloseConnection();
            foreach (var objDistrict in liDistrict)
            {
                PROVINCE_OBJ objAp = new PROVINCE_OBJ
                {
                    CODE = objDistrict.CODE,
                    CODEVIEW = objDistrict.CODEVIEW,
                    NAME = objDistrict.NAME,
                    BEGINDATE = objDistrict.BEGINDATE,
                    ENDDATE = objDistrict.ENDDATE,
                    NOTE = objDistrict.NOTE,
                    LOCK = objDistrict.LOCK,
                    PARENTCODE = objDistrict.PARENTCODE,
                    THETYPE = objDistrict.THETYPE
                };
                li.Add(objAp);
            }
            foreach (var objTown in liTown)
            {
                PROVINCE_OBJ objAp = new PROVINCE_OBJ
                {
                    CODE = objTown.CODE,
                    CODEVIEW = objTown.CODEVIEW,
                    NAME = objTown.NAME,
                    BEGINDATE = objTown.BEGINDATE,
                    ENDDATE = objTown.ENDDATE,
                    NOTE = objTown.NOTE,
                    LOCK = objTown.LOCK,
                    PARENTCODE = objTown.PARENTCODE,
                    THETYPE = objTown.THETYPE
                };
                li.Add(objAp);
            }
            //li = li.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Json(new
            {
                lst = li,//Danh sách
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetSearch(string thetype, string parentcode, string name, string nametype, string note, string notetype)
        {
            if (string.IsNullOrEmpty(thetype))
            {
                List<PROVINCE_OBJ> liProvince = GetAllSearch(name, nametype, note, notetype);
                return Json(new { li = liProvince }, JsonRequestBehavior.AllowGet);
            }
            if (thetype.Equals("PROVINCE"))
            {
                List<DISTRICT_OBJ> liDistrict = new DistrictController().GetAllSearch(parentcode, name, nametype, note, notetype);
                return Json(new { li = liDistrict }, JsonRequestBehavior.AllowGet);
            }
            List<TOWN_OBJ> liTown = new TownController().GetAllSearch(parentcode, name, nametype, note, notetype);
            return Json(new { li = liTown }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="name"></param>
        /// <param name="nametype"></param>
        /// <param name="note"></param>
        /// <param name="notetype"></param>
        /// <returns></returns>
        public List<PROVINCE_OBJ> GetAllSearch(string name, string nametype, string note, string notetype)
        {
            //Khai báo lấy dữ liệu
            PROVINCE_BUS bus = new PROVINCE_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
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

        /// <summary>
        /// dùng để update dữ liệu cho bảng province, district, town
        /// </summary>
        /// <param name="obj">dữ liệu cần cập nhật</param>
        /// <param name="theType">
        /// "" hoặc null: update dữ liệu cho bảng province
        /// province: update dữ liệu cho bảng district
        /// district: update dữ liệu cho bảng town
        /// </param>
        /// <returns></returns>
        public JsonResult UpdateJson(PROVINCE_OBJ obj, string theType)
        {
            int ret;
            if (string.IsNullOrEmpty(theType))
            {
                ret = Update(obj);
            }
            else if (theType.Equals("PROVINCE"))
            {
                DISTRICT_OBJ districtObj = new DISTRICT_OBJ
                {
                    CODE = obj.CODE,
                    CODEVIEW = obj.CODEVIEW,
                    NAME = obj.NAME,
                    BEGINDATE = obj.BEGINDATE,
                    ENDDATE = obj.ENDDATE,
                    NOTE = obj.NOTE,
                    LOCK = obj.LOCK,
                    PARENTCODE = obj.PARENTCODE
                };
                ret = new DistrictController().Update(districtObj);
            }
            else
            {
                TOWN_OBJ townObj = new TOWN_OBJ
                {
                    CODE = obj.CODE,
                    CODEVIEW = obj.CODEVIEW,
                    NAME = obj.NAME,
                    BEGINDATE = obj.BEGINDATE,
                    ENDDATE = obj.ENDDATE,
                    NOTE = obj.NOTE,
                    LOCK = obj.LOCK,
                    PARENTCODE = obj.PARENTCODE
                };
                ret = new TownController().Update(townObj);
            }
            return Json(new {ret }, JsonRequestBehavior.AllowGet);
        }

        public int Update(PROVINCE_OBJ obj)
        {
            //if (ses.func("SUPADMIN") <= 0)
            //{
            //    return Json(new { sussess = -3 }, JsonRequestBehavior.AllowGet);

            //}
            PROVINCE_BUS bus = new PROVINCE_BUS();
            int ret;
            int add = 0;

            PROVINCE_OBJ objTemp;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                objTemp = bus.GetByID(new PROVINCE_OBJ.BusinessObjectID(obj.CODE));
                if (objTemp == null)
                {
                    ret = -4;
                    return ret;
                }
            }
            else
            {
                objTemp = new PROVINCE_OBJ();
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
            objTemp.THETYPE = "PROVINCE";
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

        /// <summary>
        /// dùng để xóa dữ liệu các bảng province, district, town
        /// </summary>
        /// <param name="code">danh sách code được chọn</param>
        /// <param name="theType">
        /// "" hoặc null: xóa dữ liệu cho bảng province
        /// province: xóa dữ liệu cho bảng district
        /// district: xóa dữ liệu cho bảng town
        /// </param>
        /// <returns></returns>
        public JsonResult DeleteJson(List<string> code, string theType)
        {
            int ret;
            if (string.IsNullOrEmpty(theType))
            {
                ret = Delete(code);
            }
            else if (theType.Equals("PROVINCE"))
                ret = new DistrictController().Delete(code);
            else
            {
                ret = new TownController().Delete(code);
            }
            return Json(new {ret }, JsonRequestBehavior.AllowGet);
        }

        public int Delete(List<string> code)
        {
            int ret = 0;
            PROVINCE_BUS bus = new PROVINCE_BUS();
            List<PROVINCE_OBJ.BusinessObjectID> liDel = new List<PROVINCE_OBJ.BusinessObjectID>();
            foreach (string item in code)
            {
                // kiểm cha có con ko, nếu có thì ko cho xóa
                var liDistrict = new DISTRICT_BUS().getAllBy2(new fieldpara("PARENTCODE", item));
                if (liDistrict.Count <= 0)
                    liDel.Add(new PROVINCE_OBJ.BusinessObjectID(item));
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