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
    public class LevelTitleController : Controller
    {
        session ses = new session();
        public ActionResult Index(string id)
        {
            //chọn mặc định một cái menu nào đó
            string defaultvalue = "{\"code\":\"" + id+ "\", \"subcode\":\"345\", \"thedate\":\"2017-2-3\"}";
            ViewBag.defaultvalue = defaultvalue;
            string[] jsx = {
                "/Jsx/_Shared/Tree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/SearchDialog.jsx"
                ,"/Jsx/_Shared/Combobox.jsx"
                ,"/Jsx/_Shared/Combobox3.jsx"
                ,"/jsx/Core/Leveltitle/Leveltitlepopup.jsx"
                ,"/jsx/_shared/AgGrid.jsx"
                ,"/Jsx/_Shared/ButtonList.jsx"
                ,"/jsx/Core/Leveltitle/Leveltitlelist.jsx"
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
            List<LEVELTITLE_OBJ> li = null;
            LEVELTITLE_BUS bus = new LEVELTITLE_BUS();
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
            List<LEVELTITLE_OBJ> li = null;
            LEVELTITLE_BUS bus = new LEVELTITLE_BUS();
            List<fieldpara> lipa = new List<fieldpara>();

            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            //lipa.Add(new fieldpara("THETYPE", thetype));
            //lipa.Add(new fieldpara("PARENTCODE", code));
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
            LEVELTITLE_BUS bus = new LEVELTITLE_BUS();
            List<LEVELTITLE_OBJ.BusinessObjectID> li_del = new List<LEVELTITLE_OBJ.BusinessObjectID>();
            foreach (string item in code)
            {
                li_del.Add(new LEVELTITLE_OBJ.BusinessObjectID(item));
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

        public JsonResult update(LEVELTITLE_OBJ obj)
        {
            List<string> li_ref = new List<string>();// danh sach file sẽ được thêm vào
            List<string> li_refd = new List<string>();// sanh sách file bị xoá đi
            //if (ses.func("SUPADMIN") <= 0)
            //{
            //    return Json(new { sussess = -3 }, JsonRequestBehavior.AllowGet);

            //}
            LEVELTITLE_BUS bus = new LEVELTITLE_BUS();
            int ret = 0;
            int add = 0;

            LEVELTITLE_OBJ obj_temp = null;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                obj_temp = bus.GetByID(new LEVELTITLE_OBJ.BusinessObjectID(obj.CODE));
                if (obj_temp == null )
                {
                    ret = -4;
                }
            }
            else
            {
                obj_temp = new LEVELTITLE_OBJ();
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





        public ActionResult BackEnd(string id, string thetype)
        {
            //Đến trang thông báo khi không có phân quyền sử dụng chức năng này
            if (ses.func("SUPADMIN") <= 0)
            {
                ses.gotoPage("/staff/login", "Thông báo", "Không có quyền thực hiện chức năng", 3000);
                return Redirect("/common/index");
            }
            //Gán dữ liệu mặc định cho phần chọn 
            if (string.IsNullOrEmpty(id))
            {
                id = "";
            }
            ViewBag.thetype = thetype;// "BACKEND";
            ViewBag.id = id;
            ViewBag.jsx = "~/Jsx/Core/Sysmenu/Sysmennu.jsx";
            return View();
        }
        public ActionResult Topmenu(string id)
        {
            //Đến trang thông báo khi không có phân quyền sử dụng chức năng này
            if (ses.func("SUPADMIN") <= 0)
            {
                ses.gotoPage("/staff/login", "Thông báo", "Không có quyền thực hiện chức năng", 3000);
                return Redirect("/common/index");
            }
            //Gán dữ liệu mặc định cho phần chọn 
            if (string.IsNullOrEmpty(id))
            {
                id = "";
            }
            ViewBag.thetype = "TOPMENU";
            ViewBag.id = id;
            ViewBag.jsx = "~/Jsx/Core/Sysmenu/Sysmennu.jsx";
            return View("Backend");
        }
       /// <summary>
       /// Lấy danh sách các menu, lấy toàn bộ
       /// </summary>
       /// <param name="thetype">Kiểu menu được soạn thảo</param>
       /// <returns></returns>
        public JsonResult getBackend(string thetype)
        {
            List<SYSMENU_OBJ> li = null;
//            string thetype = "BACKEND";
            //if (ses.func("SUPADMIN") <= 0)
            //{
            //    return Json(new
            //    {
            //        data = li,//Danh sách
            //        total = 0,//số lượng trang
            //        parent = "",//đơn vị cấp trên
            //        startindex = 1, //bắt đầu số trang
            //        ret = -1//error
            //    }, JsonRequestBehavior.AllowGet);

            //}

            //Khai báo lấy dữ liệu
            SYSMENU_BUS bus = new SYSMENU_BUS();
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
        /// <summary>
        /// Lấy danh sách các menu con trực tiếp của một đối tượng để hiển thị dạng bảng
        /// </summary>
        /// <param name="code">Mã của đối tượng cha</param>
        /// <returns></returns>
        public JsonResult getBackendList(string code, string thetype, string name, string nametype, string note, string notetype)
        {
            List<SYSMENU_OBJ> li = null;
            //string thetype = "BACKEND";
            //if (ses.func("SUPADMIN") <= 0)
            //{
            //    return Json(new
            //    {
            //        data = li,//Danh sách
            //        total = 0,//số lượng trang
            //        parent = "",//đơn vị cấp trên
            //        startindex = 1, //bắt đầu số trang
            //        ret = -1//error
            //    }, JsonRequestBehavior.AllowGet);

            //}

            //Khai báo lấy dữ liệu
            SYSMENU_BUS bus = new SYSMENU_BUS();
            List<fieldpara> lipa = new List<fieldpara>();

            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            lipa.Add(new fieldpara("THETYPE", thetype));
            lipa.Add(new fieldpara("PARENTCODE", code));
            if(!string.IsNullOrEmpty(name))
            {
                lipa.Add(new fieldpara("NAME", name, (int)(nametype.ToUpper()=="TRUE" ? searchType.NONE : searchType.LIKE)));
            }
            if (!string.IsNullOrEmpty(note))
            {
                lipa.Add(new fieldpara("NOTE", note, (int)(notetype.ToUpper() =="TRUE"? searchType.NONE : searchType.LIKE)));
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

        /// <summary>
        /// Hàm lấy dánh sách sysmenu theo các tham số truyền vào
        /// </summary>
        /// <param name="parentcode">PARENTCODE</param>
        /// <param name="keysearchCodeView">CODEVIEW chứa keysearchCodeView</param>
        /// <param name="keysearchName">NAME chứa keysearchName</param>
        /// <param name="page">trang hiện tại</param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult getlist(string thetype, string parentcode, string keysearchCodeView,
                                 string keysearchName, int page, int pageSize = 8)
        {
            List<SYSMENU_OBJ> li = null;
            if (ses.func("SUPADMIN") <= 0)
            {
                return Json(new
                {
                    data = li,//Danh sách
                    total = 0,//số lượng trang
                    parent = "",//đơn vị cấp trên
                    startindex = 1, //bắt đầu số trang
                    ret = -1//error
                }, JsonRequestBehavior.AllowGet);

            }
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
            SYSMENU_BUS bus = new SYSMENU_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            //Thêm điều kiện lọc theo codeview nếu có nhập
            if (keysearchCodeView != "")
            {
                lipa.Add(new fieldpara("CODEVIEW", keysearchCodeView, 1));//search on codeview
            }
            //Thêm phần điều kiện lọc theo tên nếu có nhập
            if (keysearchName != "")
            {
                lipa.Add(new fieldpara("NAME", keysearchName, 1));//search on name
            }
            //Lọc đơn vị cấp trên; '' sẽ là không co đơn vị cấp trên
            lipa.Add(new fieldpara("PARENTCODE", parentcode, 0));
            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            lipa.Add(new fieldpara("THETYPE", thetype));
            int countpage = 0;
            //order by theorder, with pagesize and the page
            li = bus.getAllBy2(" THEORDER ", pageSize, page, out countpage, lipa.ToArray());
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            int startpage = (page - 1) * pageSize;

            //var totalRow = li.Count;
            //li = li.Skip((page - 1) * pageSize).Take(pageSize).ToList();
            return Json(new
            {
                data = li,//Danh sách
                total = countpage,//số lượng trang
                parent = parentcode,//đơn vị cấp trên
                startindex = startpage,//bắt đầu số trang
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Hàm lấy danh sách parent để đổ vào dropdownlist
        /// </summary>
        /// <returns></returns>
        public JsonResult listparent(string thetype)
        {
            SYSMENU_BUS bus = new SYSMENU_BUS();
            List<SYSMENU_OBJ> resList = new List<SYSMENU_OBJ>();
            List<SYSMENU_OBJ> li = bus.getAllBy2("THEORDER", new fieldpara("THETYPE", thetype), new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE));
            List<SYSMENU_OBJ> liparent = li.Where(x => x.PARENTCODE == "").ToList();
            foreach (var item in liparent)
            {
                resList.Add(item);
                foreach (var itemChi in li)
                {
                    if (itemChi.PARENTCODE == item.CODE)
                    {
                        itemChi.NAME = "--------->" + itemChi.NAME;
                        resList.Add(itemChi);
                    }
                }
            }

            bus.CloseConnection();
            return Json(new { lstGroup = resList, ret = 0 }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Hàm xóa 1 SYSMENU
        /// </summary>
        /// <param name="id">Danh sách các CODE sẽ xóa gửi từ client lên</param>
        /// <returns></returns>
        

        /// <summary>
        /// Cập nhật bao gồm cả thêm mới và sửa, phụ thuộc vào obj.CODE được đưa lên
        /// </summary>
        /// <param name="obj">Dữ liệu được đưa lên từ client</param>
        /// <returns></returns>
        [HttpPost]
        [ValidateInput(true)]
        //public JsonResult update(SYSMENU_OBJ obj)
        //{
        //    List<string> li_ref = new List<string>();// danh sach file sẽ được thêm vào
        //    List<string> li_refd = new List<string>();// sanh sách file bị xoá đi
        //    //if (ses.func("SUPADMIN") <= 0)
        //    //{
        //    //    return Json(new { sussess = -3 }, JsonRequestBehavior.AllowGet);

        //    //}
        //    SYSMENU_BUS bus = new SYSMENU_BUS();
        //    int ret = 0;
        //    int add = 0;

        //    SYSMENU_OBJ obj_temp = null;
        //    //kiểm tra tồn tại cho trường hợp sửa
        //    if (!string.IsNullOrEmpty(obj.CODE))//edit
        //    {
        //        obj_temp = bus.GetByID(new SYSMENU_OBJ.BusinessObjectID(obj.CODE));
        //        if (obj_temp == null || obj_temp.UNIVERSITYCODE != ses.gUNIVERSITYCODE)
        //        {
        //            ret = -4;
        //        }
        //    }
        //    else
        //    {
        //        obj_temp = new SYSMENU_OBJ();
        //        obj_temp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
        //    }

        //    if (ret < 0)
        //    {
        //        //đóng kết nối trước khi trả về
        //        bus.CloseConnection();
        //        //ban ghi sửa đã bị xóa
        //        return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);

        //    }
        //    //hết kiểm tra tồn tại bản ghi
        //    obj_temp.EDITTIME = DateTime.Now;//Thời điểm sủa bản ghi
        //    obj_temp.EDITUSER = ses.loginCode;//Người sửa bản ghi

        //    obj_temp.CODEVIEW = obj.CODEVIEW;
        //    obj_temp.NAME = obj.NAME;
        //    obj_temp.NOTE = obj.NOTE;
        //    obj_temp.THEORDER = obj.THEORDER;
        //    obj_temp.PARENTCODE = obj.PARENTCODE;
        //    obj_temp.LINK = obj.LINK;
        //    obj_temp.ICON = obj.ICON;
        //    obj_temp.PRIORITYCODE = obj.PRIORITYCODE;
        //    obj_temp.LOCK = obj.LOCK;
        //    obj_temp.THETYPE = obj.THETYPE;

        //    if (obj_temp.PARENTCODE == null)
        //    {
        //        obj_temp.PARENTCODE = "";
        //    }
        //    //Kiểm tra tình trạng sửa hay là thêm mới
        //    if (string.IsNullOrEmpty(obj.CODE))
        //    {
        //        //Thêm mới
        //        add = 1;
        //        //Sinh mã
        //        obj_temp.CODE = bus.genNextCode(obj);
        //        obj_temp.LOCK = 0;
        //        obj_temp.LOCKDATE = DateTime.Now;
        //        //obj_temp.MODULECODE = "CORE";//for this
        //    }
        //    if (string.IsNullOrEmpty(obj.EXTENSIONCODE))
        //    {
        //        obj_temp.EXTENSIONCODE = obj_temp.CODE;
        //    }
        //    else
        //    {
        //        obj_temp.EXTENSIONCODE =obj.EXTENSIONCODE+"."+ obj_temp.CODE;
        //    }
        //    int pm = 0;
        //    List<SYSMENUPRIORITY_OBJ> lipri = null;
        //    if (!string.IsNullOrEmpty(obj.PRIORITYCODE))
        //    {
        //        string[] pris = obj.PRIORITYCODE.Split(',');
        //        lipri = new List<SYSMENUPRIORITY_OBJ>();
        //        foreach (string item in pris)
        //        {
        //            pm = 1;
        //            SYSMENUPRIORITY_OBJ objpri = new SYSMENUPRIORITY_OBJ();
        //            objpri.LOCK = 0;
        //            objpri.LOCKDATE = DateTime.Now;
        //            objpri.PRIORITYCODE = item;
        //            objpri.SYSMENUCODE = obj_temp.CODE;
        //            lipri.Add(objpri);
        //        }
        //    }
        //    SYSMENUPRIORITY_BUS bus_pri = new SYSMENUPRIORITY_BUS();
        //    bus.BeginTransaction();
        //    bus_pri.setConnection(bus);
        //    if (add == 1)
        //    {
        //        ret = bus.insert(obj_temp);
        //    }
        //    else
        //    {
        //        //gán _ID để xác định bản ghi sẽ được cập nhật
        //        obj_temp._ID.CODE = obj.CODE;
        //        ret = bus.update(obj_temp);
        //    }
        //    if (ret >= 0)
        //    {
        //        ret = bus_pri.Delete(new fieldpara("SYSMENUCODE", obj_temp.CODE));
        //    }
        //    if (pm == 1)
        //    {
        //        if (ret >= 0)
        //        {
        //            ret = bus_pri.insert(lipri.ToArray());
        //        }
        //    }
        //    //if (ret >= 0)
        //    //{
        //    //    //ghi nhan file đã được cập nhật mới
        //    //    ret = comto.RefFile(li_ref, li_refd, "SYSMENU", obj_temp.CODE, bus.getConnectionInfo());
        //    //}
        //    if (ret >= 0)
        //    {
        //        bus.CommitTransaction();

        //    }
        //    else
        //    {
        //        bus.RollbackTransaction();
        //    }
        //    bus.CloseConnection();
        //    //some thing like that
        //    return Json(new { ret = ret, CODE=obj_temp.CODE }, JsonRequestBehavior.AllowGet);
        //}

        //Autocomplete with NAME
        public JsonResult SearchName(string keysearch)
        {
            SYSMENU_BUS bus = new SYSMENU_BUS();
            List<SYSMENU_OBJ> li = bus.getAllBy2();
            bus.CloseConnection();
            var data = (from p in li
                        where p.NAME.ToLower().Contains(keysearch.ToLower())
                        select new { p.NAME }).Distinct();

            return this.Json(data, JsonRequestBehavior.AllowGet);

        }

        //Autocomplete with CODEVIEW
        public JsonResult SearchCodeView(string keysearch)
        {
            SYSMENU_BUS bus = new SYSMENU_BUS();
            List<SYSMENU_OBJ> li = bus.getAllBy2();
            bus.CloseConnection();
            var data = (from p in li
                        where p.CODEVIEW.ToLower().Contains(keysearch.ToLower())
                        select new { p.CODEVIEW }).Distinct();

            return this.Json(data, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// Get all menul for thecode
        /// </summary>
        /// <param name="thecode"></param>
        /// <returns></returns>
        public JsonResult listFront(string thecode)
        {
            List<SYSMENU_OBJ> li = null;
            //Khai báo lấy dữ liệu
            SYSMENU_BUS bus = new SYSMENU_BUS();
            li = bus.getFont(thecode);
            bus.CloseConnection();
            int ret = 0;
            if (li.Count < 1)
            {
                ret = -1;
            }
            SYSMENU_OBJ obj = new SYSMENU_OBJ();
            if (li.Count >= 1)
            {
                obj = li[0];
                li.RemoveAt(0);
            }
            return Json(new
            {
                lst = li,//Danh sách
                obj = obj,
                ret = ret//ok
            }, JsonRequestBehavior.AllowGet);
        }
    }
}

