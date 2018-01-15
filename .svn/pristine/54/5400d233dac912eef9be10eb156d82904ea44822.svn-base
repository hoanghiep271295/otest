using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using IS.Sess;
using IS.uni;
using IS.basetype;
using IS.fitframework;
using IS.Config;
using Newtonsoft.Json;

namespace nerp.Controllers
{
    public class AdmingroupController : Controller
    {
        session ses = new session();
        /// <summary>
        /// Lấy toàn bộ danh sách
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <returns></returns>
        public JsonResult GetList(int page, int pageSize, string code, string codetype, string name, string nametype)
        {
            List<ADMINGROUP_OBJ> data = null;
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
            ADMINGROUP_BUS bus = new ADMINGROUP_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            if(!string.IsNullOrEmpty(code))
            {
                lipa.Add(new fieldpara("CODEVIEW", code, (int)searchType.LIKE));
            }
            if (!string.IsNullOrEmpty(name))
            {
                lipa.Add(new fieldpara("NAME", name, (int)searchType.LIKE));
            }
            int countpage = 0;
            int countrecord = 0;
            //order by theorder, with pagesize and the page
            data = bus.getAllBy2("NAME", pageSize, page, out countpage,out countrecord, lipa);
            // tất cả các bản ghi
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            int startpage = (page - 1) * pageSize;
            //Trả về client
            return Json(new
            {
                data = data,//Danh sách
                totalItem = countrecord,//số lượng bản ghi
                totalPage = countpage,
                startindex = startpage,//bắt đầu số trang
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Cập nhật cả trạng thái thêm mới
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="educationlevelcode"></param>
        /// <returns></returns>
        public JsonResult Update(ADMINGROUP_OBJ obj, string educationlevelcode)
        {
            ADMINGROUP_BUS bus = new ADMINGROUP_BUS();
            int ret = 0;
            int add = 0;
            ADMINGROUP_OBJ obj_temp = null;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                obj_temp = bus.GetByID(new ADMINGROUP_OBJ.BusinessObjectID(obj.CODE));
                if (obj_temp == null || obj_temp.UNIVERSITYCODE != ses.gUNIVERSITYCODE)
                {
                    ret = -4;
                }
            }
            else
            {
                obj_temp = new ADMINGROUP_OBJ();
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
            obj_temp.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
            obj_temp.NOTE = obj.NOTE;
            obj_temp.LOCK = obj.LOCK;
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                obj_temp.CODE = bus.genNextCode(obj);
                obj_temp.LOCKDATE = DateTime.Now;
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
            int pagecount = 0;
            int currentpage = 0;
            if (ret >= 0)
            {
                List<fieldpara> lipa = new List<fieldpara>();
                //Lọc đơn vị cấp trên; '' sẽ là không co đơn vị cấp trên
                if (!string.IsNullOrEmpty(educationlevelcode))
                {
                    lipa.Add(new fieldpara("EDUCATIONLEVELCODE", educationlevelcode, 0));
                }
                lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
                obj_temp._ID.CODE = obj_temp.CODE;
                ret = bus.checkPage(obj_temp._ID, "CODE", AppConfig.item4page(), out pagecount, out currentpage, lipa);
            }
            bus.CloseConnection();
            //some thing like that
            return Json(new { ret = ret, pagecount = pagecount, currentpage = currentpage, obj= obj_temp }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Xóa một danh sách các đối tượng được gửi lên
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult Delete(List<String> code)
        {
            var ret = 0;
            var error = false;
            if (code != null)
            {
                var bus = new ADMINGROUP_BUS();
                for (var i = 0; i < code.Count; i++)
                {
                    if (code[i] != null)
                    {
                        var item = bus.GetByID(new ADMINGROUP_OBJ.BusinessObjectID(code[i]));
                        if (item == null) { ret = -1; error = true; continue; }
                        if (item.UNIVERSITYCODE != ses.gUNIVERSITYCODE) { ret = -4; }
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
        /// <summary>
        /// Xóa một danh sách các đối tượng được gửi lên
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult DeletePriority(string list)
        {
            var ret = 0;
            List<ADMINGROUPPRIORITY_OBJ> listobj= JsonConvert.DeserializeObject<List<ADMINGROUPPRIORITY_OBJ>>(list);
            List<ADMINGROUPPRIORITY_OBJ.BusinessObjectID> li = new List<ADMINGROUPPRIORITY_OBJ.BusinessObjectID>();
            foreach(ADMINGROUPPRIORITY_OBJ obj in listobj)
            {
                li.Add(new ADMINGROUPPRIORITY_OBJ.BusinessObjectID(obj.OBJECTCODE, obj.THETYPE, obj.PRIORITYCODE, obj.FORMAN, obj.THECODE, obj.TABLENAME));
            }
            ADMINGROUPPRIORITY_BUS bus = new ADMINGROUPPRIORITY_BUS();
            ret = bus.DeletetMultiItems(li);
            bus.CloseConnection();
            //var error = false;
            //if (code != null)
            //{
            //    var bus = new ADMINGROUP_BUS();
            //    for (var i = 0; i < code.Count; i++)
            //    {
            //        if (code[i] != null)
            //        {
            //            var item = bus.GetByID(new ADMINGROUP_OBJ.BusinessObjectID(code[i]));
            //            if (item == null) { ret = -1; error = true; continue; }
            //            if (item.UNIVERSITYCODE != ses.gUNIVERSITYCODE) { ret = -4; }
            //            if (ret >= 0)
            //            {
            //                ret = bus.delete(item._ID);
            //            }
            //            if (!error && ret < 0)
            //            {
            //                error = true;
            //            }
            //        }
            //    }
            //    bus.CloseConnection();
            //}

            //ret = error ? -1 : 0;
            return Json(new
            {
                ret = ret
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Kiểm tra xem đã tồn tại
        /// </summary>
        /// <param name="code"></param>
        /// <param name="codeView"></param>
        /// <returns></returns>
        public JsonResult checkCodeViewExit(string code, string codeView)
        {
            int ret;
            ADMINGROUP_BUS bus = new ADMINGROUP_BUS();
            ADMINGROUP_OBJ.BusinessObjectID ID = null;
            if (code != "")
            {
                ID = new ADMINGROUP_OBJ.BusinessObjectID(code);
            }
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("CODEVIEW", codeView, 0));
            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            ret = bus.checkCode(ID, lipa.ToArray());
            bus.CloseConnection();
            return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);


        }
        /// <summary>
        /// Lấy danh sách các giáo viên trong nhom
        /// </summary>
        /// <param name="admingroupcode"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="code"></param>
        /// <param name="codetype"></param>
        /// <param name="name"></param>
        /// <param name="nametype"></param>
        /// <returns></returns>
        public JsonResult GetStaff(string admingroupcode, int page, int pageSize, string code, string codetype, string name, string nametype)
        {
            List<STAFF_OBJ> data = null;
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
            STAFF_BUS bus = new STAFF_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
//            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            //if (!string.IsNullOrEmpty(code))
            //{
            //    lipa.Add(new fieldpara("CODEVIEW", code, (int)searchType.LIKE));
            //}
            //if (!string.IsNullOrEmpty(name))
            //{
            //    lipa.Add(new fieldpara("NAME", name, (int)searchType.LIKE));
            //}
            int countpage = 0;
            int countrecord = 0;
            jointable admingroup = new jointable(typeof(STAFFADMINGROUP_OBJ), "OBJECTCODE", new fieldpara("ADMINGROUPCODE", admingroupcode));
            //order by theorder, with pagesize and the page
            data = bus.getAllBy2("NAME", pageSize, page, out countpage, out countrecord, lipa,admingroup);
            // tất cả các bản ghi
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            int startpage = (page - 1) * pageSize;
            //Trả về client
            return Json(new
            {
                data = data,//Danh sách
                totalItem = countrecord,//số lượng bản ghi
                totalPage = countpage,
                startindex = startpage,//bắt đầu số trang
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Lấy danh sách các giáo viên trong nhom
        /// </summary>
        /// <param name="admingroupcode"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="code"></param>
        /// <param name="codetype"></param>
        /// <param name="name"></param>
        /// <param name="nametype"></param>
        /// <returns></returns>
        public JsonResult GetPriority(string admingroupcode, int page, int pageSize, string code, string codetype, string name, string nametype)
        {
            List<ADMINGROUPPRIORITY_OBJ> data = null;
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
            ADMINGROUPPRIORITY_BUS bus = new ADMINGROUPPRIORITY_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            lipa.Add(new fieldpara("OBJECTCODE", admingroupcode, 0));
            //if (!string.IsNullOrEmpty(code))
            //{
            //    lipa.Add(new fieldpara("CODEVIEW", code, (int)searchType.LIKE));
            //}
            //if (!string.IsNullOrEmpty(name))
            //{
            //    lipa.Add(new fieldpara("NAME", name, (int)searchType.LIKE));
            //}
            int countpage = 0;
            int countrecord = 0;
            //jointable admingroup = new jointable(typeof(ADMINGROUPPRIORITY_OBJ), "PRIORITYCODE", new fieldpara("OBJECTCODE", admingroupcode));
            //order by theorder, with pagesize and the page
            data = bus.getAllBy2("SYSCOMPONENTCODE", pageSize, page, out countpage, out countrecord, lipa);
            // tất cả các bản ghi
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            int startpage = (page - 1) * pageSize;
            //Trả về client
            return Json(new
            {
                data = data,//Danh sách
                totalItem = countrecord,//số lượng bản ghi
                totalPage = countpage,
                startindex = startpage,//bắt đầu số trang
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Lấy danh sách các giáo viên trong nhom
        /// </summary>
        /// <param name="admingroupcode"></param>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="code"></param>
        /// <param name="codetype"></param>
        /// <param name="name"></param>
        /// <param name="nametype"></param>
        /// <returns></returns>
        public JsonResult GetPriorityUnlisted(string admingroupcode, int page, int pageSize, string code, string codetype, string name, string nametype)
        {
            List<PRIORITY_OBJ> data = null;
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
            PRIORITY_BUS bus = new PRIORITY_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            lipa.Add(new fieldpara("ADMINGROUPPRIORITY.PRIORITYCODE", null, 0));
            //if (!string.IsNullOrEmpty(code))
            //{
            //    lipa.Add(new fieldpara("CODEVIEW", code, (int)searchType.LIKE));
            //}
            //if (!string.IsNullOrEmpty(name))
            //{
            //    lipa.Add(new fieldpara("NAME", name, (int)searchType.LIKE));
            //}
            int countpage = 0;
            int countrecord = 0;
            jointable admingroup = new jointable(typeof(ADMINGROUPPRIORITY_OBJ),"CODE", "PRIORITYCODE",JOIN.LEFT, new fieldpara("OBJECTCODE", admingroupcode));
            //order by theorder, with pagesize and the page
            data = bus.getAllBy2("NAME", pageSize, page, out countpage, out countrecord, lipa,admingroup);
            // tất cả các bản ghi
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            int startpage = (page - 1) * pageSize;
            //Trả về client
            return Json(new
            {
                data = data,//Danh sách
                totalItem = countrecord,//số lượng bản ghi
                totalPage = countpage,
                startindex = startpage,//bắt đầu số trang
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Ghi nhận các bản ghi mới được đưa lên
        /// </summary>
        /// <param name="li"></param>
        /// <returns></returns>
        public JsonResult addpriority(string data)
        {
            ADMINGROUPPRIORITY_BUS bus = new ADMINGROUPPRIORITY_BUS();
            var model = JsonConvert.DeserializeObject<List<ADMINGROUPPRIORITY_OBJ>>(data);
            int ret = 0;
            foreach(ADMINGROUPPRIORITY_OBJ obj in model)
            {
                obj.THETYPE = "ADMINGROUPPRIORITY";
                obj.EDITTIME = DateTime.Now;
                obj.EDITUSER = ses.loginCode;
                obj.EXTENSIONCODE = "";
                obj.FORMAN = 0;
                obj.INHERIT = 1;
                obj.LOCK = 0;
                obj.TABLENAME = "DEPARTMENT";
                obj.THECODE = "";
                obj.UNIVERSITYCODE = ses.gUNIVERSITYCODE;
                obj.WHOIS = bus.encrypt(obj);
            }
            ret = bus.InsertIfNewMultiItems(model, null);
            bus.CloseConnection();
          
            return Json(new { ret = ret}, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// Lấy các nhóm phân quyền đẻ giáo viên thêm vào
        /// </summary>
        /// <param name="staffcode"></param>
        /// <returns></returns>
        public JsonResult GetAdmingroup(string staffcode)
        {
            List<STAFFADMINGROUP_OBJ> data = null;
            List<STAFFADMINGROUP_OBJ> choosen =  new List<STAFFADMINGROUP_OBJ>();

            //Khai báo lấy dữ liệu
            STAFFADMINGROUP_BUS bus = new STAFFADMINGROUP_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("objectcode", staffcode, 0));
            data = bus.getAllBy2("ADMINGROUPCODE.NAME", lipa.ToArray());
            bus.CloseConnection();
            foreach(STAFFADMINGROUP_OBJ obj in data)
            {
                choosen.Add(obj);
            }
            //lấy các nhóm
            ADMINGROUP_BUS bus_admingroup = new ADMINGROUP_BUS();
            lipa.Clear();
            jointable staffadmingroup = new jointable(typeof(STAFFADMINGROUP_OBJ),"CODE", "ADMINGROUPCODE", JOIN.LEFT, new fieldpara("OBJECTCODE", staffcode));
            List<jointable> li_joint = new List<jointable>();
            li_joint.Add(staffadmingroup);
            lipa.Add(new fieldpara("STAFFADMINGROUP.ADMINGROUPCODE", null));
            List<ADMINGROUP_OBJ> li_admingroup = bus_admingroup.getAllBy2("NAME", lipa, li_joint);
            bus_admingroup.CloseConnection();
            foreach(var obj in li_admingroup)
            {
                STAFFADMINGROUP_OBJ obj_temp = new STAFFADMINGROUP_OBJ();
                obj_temp._ADMINGROUPCODE = obj;
                data.Add(obj_temp);
            }
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            //Trả về client
            return Json(new
            {
                data = data,//Danh sách
                choosen=choosen,//Danh sach da chon
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }

        //public JsonResult GetAdmingroup(string staffcode)
        //{
        //    List<STAFFADMINGROUP_OBJ> data = null;

        //    //Khai báo lấy dữ liệu
        //    STAFFADMINGROUP_BUS bus = new STAFFADMINGROUP_BUS();
        //    List<fieldpara> lipa = new List<fieldpara>();
        //    lipa.Add(new fieldpara("objectcode", staffcode, 0));
        //    data = bus.getAllBy2("ADMINGROUPCODE.NAME", lipa.ToArray());
        //    bus.CloseConnection();
        //    //lấy các nhóm
        //    ADMINGROUP_BUS bus_admingroup = new ADMINGROUP_BUS();
        //    lipa.Clear();
        //    jointable staffadmingroup = new jointable(typeof(STAFFADMINGROUP_OBJ), "CODE", "ADMINGROUPCODE", JOIN.LEFT, new fieldpara("OBJECTCODE", staffcode));
        //    List<jointable> li_joint = new List<jointable>();
        //    li_joint.Add(staffadmingroup);
        //    lipa.Add(new fieldpara("STAFFADMINGROUP.ADMINGROUPCODE", null));
        //    List<ADMINGROUP_OBJ> li_admingroup = bus_admingroup.getAllBy2("NAME", lipa, li_joint);
        //    bus_admingroup.CloseConnection();
        //    foreach (var obj in li_admingroup)
        //    {
        //        STAFFADMINGROUP_OBJ obj_temp = new STAFFADMINGROUP_OBJ();
        //        obj_temp._ADMINGROUPCODE = obj;
        //        data.Add(obj_temp);
        //    }
        //    //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
        //    //Trả về client
        //    return Json(new
        //    {
        //        data = data,//Danh sách
        //        ret = 0//ok
        //    }, JsonRequestBehavior.AllowGet);
        //}
    }
}