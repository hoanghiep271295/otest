using IS.Config;
using IS.fitframework;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;

namespace nerp.Controllers.exam
{
    public class ExamTimeController : Controller
    {
        private readonly session _ses = new session();

        // GET: Researchstatus
        public ActionResult Index(string id)
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
                ,"/jsx/_shared/DropdownTree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/AgGrid.jsx"
                ,"/Jsx/_Shared/TabHeader.jsx"
                , "/jsx/Core/Examtime/Examtimelist.jsx"
                ,"/jsx/Core/Examtime/Examtimepopup.jsx"
                 , "/jsx/Core/Examtime/Examhalllist.jsx"
                ,"/jsx/Core/Examtime/Examhallpopup.jsx"
                , "/jsx/Core/Examtime/Examhallstudentlist.jsx"
                 , "/jsx/Core/Examtime/Examhallstudentpopup.jsx"
                 , "/jsx/Core/Examtime/Examtimestudentlist.jsx"
                 , "/jsx/Core/Examtime/Examtimestudentpopup.jsx"
                , "/jsx/Core/Examtime/ExamtimeApp.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
        }
        public ActionResult Manage(string id)
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
                ,"/jsx/_shared/DropdownTree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/AgGrid.jsx"
                ,"/Jsx/_Shared/TabHeader.jsx"
                , "/jsx/Core/ManageExamtime/Examtimelist.jsx"
                 , "/jsx/Core/ManageExamtime/Examhalllist.jsx"
                ,"/jsx/Core/ManageExamtime/Examhallpopup.jsx"
                , "/jsx/Core/ManageExamtime/Examhallstudentlist.jsx"
                , "/jsx/Core/ManageExamtime/Examformlist.jsx"
                 , "/jsx/Core/ManageExamtime/Examhallstudentpopup.jsx"
                 , "/jsx/Core/ManageExamtime/Examtimestudentlist.jsx"
                , "/jsx/Core/ManageExamtime/ExamtimeApp.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
        }
        /// <summary>
        ///
        /// </summary>
        /// <param name="page"></param>
        /// <param name="pageSize"></param>
        /// <param name="subjectcode"></param>
        /// <param name="code"></param>
        /// <param name="codetype"></param>
        /// <param name="name"></param>
        /// <param name="nametype"></param>
        /// <param name="note"></param>
        /// <param name="notetype"></param>
        /// <param name="year"></param>
        /// <param name="parentcode"></param>
        /// <returns></returns>
        public JsonResult GetAllSearch(int page, int pageSize, string subjectcode, string code, bool codetype, string name, bool nametype,
                                    string note, bool notetype, string year, string parentcode = "DH")
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
            EXAMTIME_BUS bus = new EXAMTIME_BUS();
            List<fieldpara> lipa = new List<fieldpara> {new fieldpara("SUBJECTCODE", subjectcode, 0)};
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
            if (!string.IsNullOrEmpty(year))
            {
                lipa.Add(new fieldpara("YEAR", year, 0));
            }
            //Lọc đơn vị cấp trên; '' sẽ là không co đơn vị cấp trên
            if (!string.IsNullOrEmpty(parentcode))
            {
                lipa.Add(new fieldpara("EDUCATIONLEVELCODE", parentcode, 0));
            }
            lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            int countpage;
            int totalItem;
            //order by theorder, with pagesize and the page
            var li = bus.getAllBy2("NAME", pageSize, page, out countpage, out totalItem, lipa);
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            //Trả về client
            var a = JsonConvert.SerializeObject(li);
            return Json(new
            {
                lst = li,//Danh sách
                data2 = a,
                totalItem, // số lượng tất cả các bản ghi
                totalPage = countpage, // số lượng trang
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// lây danh sách tất cả các đợt thi của 1 môn học
        /// </summary>
        ///<param name="subjectcode">mã môn học</param>
        /// <returns></returns>
        public JsonResult GetBySubject(string subjectcode)
        {
            var ret = -1;
            EXAMTIME_BUS bus = new EXAMTIME_BUS();
            var data = bus.getAllBy2("CODE", new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0),
                                            new fieldpara("SUBJECTCODE", subjectcode, 0));
            if (data != null)
                ret = 0;
            bus.CloseConnection();
            return Json(new { lst = data, ret }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// get đợt thi theo mã
        /// </summary>
        /// <param name="id">mã đợt thi</param>
        /// <returns></returns>
        public JsonResult GetById(string id)
        {
            var ret = 0;
            EXAMTIME_BUS bus = new EXAMTIME_BUS();
            var data = bus.GetByID(new EXAMTIME_OBJ.BusinessObjectID(id));
            if (data == null)
                ret = -1;
            return Json(new { data, ret }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(List<string> code)
        {
            var ret = 0;
            var bus = new EXAMTIME_BUS();
            List<EXAMTIME_OBJ.BusinessObjectID> deletedata = new List<EXAMTIME_OBJ.BusinessObjectID>();
            List<fieldpara> lipa = new List<fieldpara>();
            if (code == null)
                ret = -1;
            else
            {
               
                foreach (string t in code)
                {
                    if (t != null)
                    {
                        var item = bus.GetByID(new EXAMTIME_OBJ.BusinessObjectID(t));
                        if (item != null)
                        {
                            lipa.Clear();
                            lipa.Add(new fieldpara("EXAMTIMECODE", t, 0));
                            lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                            ret = new EXAMHALL_BUS().checkCode(null, lipa.ToArray());
                            var ret1 = new EXAMHALLSTUDENT_BUS().checkCode(null, lipa.ToArray());
                            var ret2 = new EXAMFORM_BUS().checkCode(null, lipa.ToArray());
                            if (ret == 0 && ret1 == 0 && ret2 == 0)
                                deletedata.Add(item._ID);
                            else
                            {
                                ret = -3;
                                return Json(new
                                {
                                    ret
                                }, JsonRequestBehavior.AllowGet);
                            }
                            
                        }
                    }
                }
                
            }
            if (deletedata.Count > 0)
            {
                //mặc định khi vào danh sách này là xóa thành công nên ret= 1;
                //duyệt toàn bộ danh sách bản ghi để xóa
                bus.BeginTransaction();
                ret = bus.DeletetMultiItems(deletedata);
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
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Cập nhật một bản ghi được gửi lên từ phía client
        /// </summary>
        public JsonResult Update(EXAMTIME_OBJ obj, string parentcode = "DH")
        {
            EXAMTIME_BUS bus = new EXAMTIME_BUS();
            int ret;
            int add = 0;
            EXAMTIME_OBJ objTemp;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                objTemp = bus.GetByID(new EXAMTIME_OBJ.BusinessObjectID(obj.CODE));
                if (objTemp == null || objTemp.UNIVERSITYCODE != _ses.gUNIVERSITYCODE)
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
                objTemp = new EXAMTIME_OBJ();
            }

            //hết kiểm tra tồn tại bản ghi
            objTemp.EDITTIME = DateTime.Now;//Thời điểm sủa bản ghi
            objTemp.EDITUSER = _ses.loginCode;//Người sửa bản ghi
            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.EDUCATIONLEVELCODE = "DH";
            //obj_temp.EDUCATIONLEVELCODE = obj.EDUCATIONLEVELCODE;
            objTemp.SUBJECTCODE = obj.SUBJECTCODE;
            objTemp.UNIVERSITYCODE = _ses.gUNIVERSITYCODE;
            objTemp.NOTE = obj.NOTE;
            objTemp.LOCK = obj.LOCK;
            objTemp.YEAR = obj.YEAR;
            objTemp.TERM = obj.TERM;
            objTemp.MAXSTUDENTPERTEST = obj.MAXSTUDENTPERTEST;
            objTemp.QUESTIONUSE = obj.QUESTIONUSE;
            objTemp.STUDENTAMOUNTHALL = obj.STUDENTAMOUNTHALL;
            objTemp.STUDENTINBAG = obj.STUDENTINBAG;
            objTemp.TESTSTRUCTCODE = obj.TESTSTRUCTCODE;
            objTemp.TESTCOUNT = obj.TESTCOUNT;
            objTemp.WHOIS = bus.encrypt(objTemp);
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
                //Lọc đơn vị cấp trên; '' sẽ là không co đơn vị cấp trên
                if (!string.IsNullOrEmpty(parentcode))
                {
                    lipa.Add(new fieldpara("EDUCATIONLEVELCODE", parentcode, 0));
                }
                lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                objTemp._ID.CODE = objTemp.CODE;
                ret = bus.checkPage(objTemp._ID, "CODE", AppConfig.item4page(), out pagecount, out currentpage, lipa);
            }
            bus.CloseConnection();
            //some thing like that
            return Json(new { ret, pagecount, currentpage }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckCodeViewExit(string code, string codeView)
        {
            int ret;
            EXAMTIME_BUS bus = new EXAMTIME_BUS();
            List<EXAMTIME_OBJ> li = bus.getAllBy2(new fieldpara("CODEVIEW", codeView, 0), new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
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

        //public JsonResult GetStudentByExamtimeOld(int page, int pageSize, string examtimeCode)
        //{
        //    //mặc định cho phần trang
        //    if (pageSize == 0)
        //    {
        //        pageSize = AppConfig.item4page();
        //    }
        //    if (page < 1)
        //    {
        //        page = 1;
        //    }
        //    //Khai báo lấy dữ liệu
        //    EXAMHALLSTUDENT_BUS bus = new EXAMHALLSTUDENT_BUS();
        //    List<fieldpara> lipa = new List<fieldpara>
        //    {
        //        new fieldpara("EXAMTIMECODE", examtimeCode, 0),
        //        new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0)
        //    };
        //    int countpage;
        //    int totalItem;
        //    //order by theorder, with pagesize and the page
        //    var data = bus.getAllBy2("CODE", pageSize, page, out countpage, out totalItem, lipa);
        //    List<STUDENT_OBJ> liStudent = new List<STUDENT_OBJ>();
        //    STUDENT_BUS busStudent = new STUDENT_BUS();
        //    foreach (var item in data)
        //    {
        //        string markCode = item._MARKCODE.CODE;
        //        MARK_OBJ mark = new MARK_BUS().GetByID(new MARK_OBJ.BusinessObjectID(markCode));
        //        if (mark != null)
        //        {
        //            STUDENT_OBJ std = busStudent.GetByID(new STUDENT_OBJ.BusinessObjectID(mark._STUDENTCODE.CODE));
        //            if (std != null)
        //                liStudent.Add(std);
        //        }
        //    }
        //    bus.CloseConnection();
        //    //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
        //    int startpage = (page - 1) * pageSize;
        //    //Trả về client
        //    var a = JsonConvert.SerializeObject(liStudent);
        //    return Json(new
        //    {
        //        liExamHallStudent = data,
        //        liStudent,//Danh sách
        //        data2 = a,
        //        totalItem,//số lượng bản ghi
        //        totalPage = countpage,
        //        startindex = startpage,//bắt đầu số trang
        //        ret = 0//ok
        //    }, JsonRequestBehavior.AllowGet);
        //}
        /// <summary>
        /// lấy danh sách sinh viên trong đợt thi
        /// </summary>
        /// <param name="examtimeCode">mã đợt thi</param>
        /// <returns></returns>
        public JsonResult GetStudentByExamtime(string examtimeCode)
        {
            var ret = 0;
            List<STUDENT_OBJ> liStudent = new STUDENT_BUS().getByExamtime(examtimeCode);
            if (liStudent == null)
                ret = -1;
            return Json(new {ret = ret, lst = liStudent}, JsonRequestBehavior.AllowGet);

        }
        /// <summary>
        /// 
        /// lấy danh sách đợt thi của sinh viên
        /// </summary>
        /// <param name="markcode"></param>
        /// <param name="coursecode">mã lớp học</param>
        /// <returns></returns>
        public JsonResult GetByMarkCourse(string markcode, string coursecode)
        {
            EXAMHALLSTUDENT_BUS bus = new EXAMHALLSTUDENT_BUS();
            var data = bus.getAllBy2(new fieldpara("MARKCODE", markcode, 0),
                                    new fieldpara("COURSECODE", coursecode, 0),
                                    new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            string examtimecode = "";
            return Json(new { data, examtimecode }, JsonRequestBehavior.AllowGet);
        }
    }
}