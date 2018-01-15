﻿using IS.Config;
using IS.fitframework;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;

namespace nerp.Controllers.core
{
    public class SubjectContentController : Controller
    {
        // GET: SubjectContent
        private readonly session _ses = new session();

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
                ,"/Jsx/_Shared/Tree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/SearchDialog.jsx"
                ,"/Jsx/_Shared/Combobox.jsx"
                ,"/Jsx/_Shared/Combobox3.jsx"
                ,"/jsx/Core/SubjectContent/Subjectcontentpopup.jsx"
                ,"/jsx/_shared/AgGrid.jsx"
                ,"/Jsx/_Shared/ButtonList.jsx"
                ,"/jsx/Core/SubjectContent/Subjectcontentlist.jsx"
                , "/Scripts/tinymce/js/tinymce/init-tinymce.js"
                ,"/Scripts/tinymce/js/tinymce/tinymce.min.js"
                ,"/Scripts/tinymce/js/tinymce/jquery.tinymce.min.js"
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
        }
        /// <summary>
        ///Xem nội dung của một bài học
        /// </summary>
        /// <param name="id"> subjectcontentcode</param>
        /// <returns></returns>
        public ActionResult Preview(string id)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.code = id;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx = {
                "/jsx/Core/SubjectContent/Preview.jsx"
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
        /// <param name="parentcode"></param>
        /// <param name="code"></param>
        /// <param name="codetype"></param>
        /// <param name="name"></param>
        /// <param name="nametype"></param>
        /// <param name="note"></param>
        /// <param name="notetype"></param>
        /// <returns></returns>
        public JsonResult GetAllSearch(int page, int pageSize, string subjectcode, string parentcode, string code, bool codetype, string name, bool nametype,
                                    string note, bool notetype)
        {
            var ret = 0;
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
            SUBJECTCONTENT_BUS bus = new SUBJECTCONTENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("SUBJECTCODE", subjectcode, 0),
                new fieldpara("PARENTCODE", parentcode, 0)
            };



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
            lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            //   lipa.Add(new fieldpara("LOCK", 0, 0));
            int countpage;
            int totalItem;
            //order by theorder, with pagesize and the page
            var data = bus.getAllBy2("THEORDER", pageSize, page, out countpage, out totalItem, lipa);
            ret = data == null ? -1 : 0;
            //Trả về cho client
            var groupquestion = "";
            var question = "";
            int startpage = 0; // //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            if (ret >= 0)
            {
                foreach (var item in data)
                {
                    item.NOTE = "";
                }
                //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
                 startpage = (page - 1) * pageSize;
                //get first questiongroup
                // string codefistSubcon = data.Count != 0 ? data[0].CODE : "";
                //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
                
                if (data.Count != 0)
                {
                    QUESTIONGROUP_BUS busgroup = new QUESTIONGROUP_BUS();
                    List<QUESTIONGROUP_OBJ> li = busgroup.getAllBy2("CODEVIEW",
                          new fieldpara("SUBJECTCODE", subjectcode, 0),
                          new fieldpara("SUBJECTCONTENTCODE", data[0].CODE, 0));
                    if (li.Count > 0)
                    {
                        groupquestion = li.Count != 0 ? JsonConvert.SerializeObject(li[0]) : "";
                    }
                    if (li.Count != 0)
                    {
                        QUESTION_BUS busquestion = new QUESTION_BUS();
                        List<QUESTION_OBJ> liquestion = busquestion.getAllBy2("CODEVIEW",
                              new fieldpara("QUESTIONGROUPCODE", li[0].CODE, 0));
                        if (liquestion.Count > 0)
                        {
                            question = liquestion.Count != 0 ? JsonConvert.SerializeObject(liquestion[0]) : "";
                        }
                    }
                }
            }
           
            bus.CloseConnection();
            
            return Json(new
            {
                question,
                groupquestion,
                data, //Danh sách
                lst = data,
                totalItem, //số lượng bản ghi
                totalPage = countpage,
                startindex = startpage, //bắt đầu số trang
                ret = ret //ok
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetAll(string subjectcode)
        {
            //Khai báo lấy dữ liệu
            SUBJECTCONTENT_BUS bus = new SUBJECTCONTENT_BUS();

            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("SUBJECTCODE", subjectcode, 0),
                new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0)
            };
            //  if (!String.IsNullOrEmpty(subjectcode))
            //order by theorder, with pagesize and the page
            var data = bus.getAllBy2("THEORDER", lipa.ToArray());
            foreach (var item in data)
            {
                item.NOTE = "";
            }
            bus.CloseConnection();
            var ret = 1;
            //Trả về client
            var a = JsonConvert.SerializeObject(data);
            return Json(new
            {
                lst = data, //Danh sách
                data2 = a,
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetByCode(string code)
        {
            var ret = -1;
            var contenttype = -1;
            SUBJECTCONTENT_BUS bus = new SUBJECTCONTENT_BUS();
            var data = bus.GetByID(new SUBJECTCONTENT_OBJ.BusinessObjectID(code));
            SUBJECTCONTENTTEST_OBJ subcontenttest = new SUBJECTCONTENTTEST_OBJ();
            // kiểm tra có phải là bài kiểm tra hay ko
            // nếu có thì trả về subjectcontenttest
            if (data != null)
            {
                ret = 0;
                if (data.CONTENTTYPE.Equals("BT") || data.CONTENTTYPE.Equals("KT") || data.CONTENTTYPE.Equals("TH"))
                {
                    contenttype = 1;
                    subcontenttest = new SUBJECTCONTENTTEST_BUS().GetByKey(new fieldpara("SUBJECTCONTENTCODE", data.CODE, 0));
                    if (subcontenttest == null)
                        ret = -2;
                }
            }
                
            return Json(new {ret,contenttype, data, subcontenttest }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckCodeViewExit(string code, string codeview)
        {
            int ret;
            SUBJECTCONTENT_BUS bus = new SUBJECTCONTENT_BUS();
            SUBJECTCONTENT_OBJ obj;
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

        [ValidateInput(false)]
        
        public JsonResult Update(SUBJECTCONTENT_OBJ obj, string EXAMTIMECODE)
        {
            SUBJECTCONTENT_BUS bus = new SUBJECTCONTENT_BUS();
            //kiểm tra tồn tại cho trường hợp sửa
            int ret = 0;
            int add = 0;
            //Đề nghị viết đầy đủ cho rõ nghĩa hơn, dễ debug không nên quá tiết kiệm
            var objTemp = !string.IsNullOrEmpty(obj.CODE)
                ? bus.GetByID(new SUBJECTCONTENT_OBJ.BusinessObjectID(obj.CODE))
                : new SUBJECTCONTENT_OBJ();


            if (ret < 0)
            {
                //đóng kết nối trước khi trả về
                bus.CloseConnection();
                //ban ghi sửa đã bị xóa
                return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
            }
            //hết kiểm tra tồn tại bản ghi
            objTemp.EDITTIME = DateTime.Now; //Thời điểm sủa bản ghi
            objTemp.EDITUSER = _ses.loginCode; //Người sửa bản ghi
            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.LOCK = obj.LOCK;
            objTemp.NOTE = obj.NOTE;
            objTemp.THEORDER = obj.THEORDER;
            objTemp.PARENTCODE = obj.PARENTCODE;
            if (obj.PARENTCODE == null)
                objTemp.PARENTCODE = "";
            objTemp.CONTENTTYPE = obj.CONTENTTYPE;
            objTemp.SUBJECTCODE = obj.SUBJECTCODE;
            objTemp.UNIVERSITYCODE = _ses.gUNIVERSITYCODE;

            objTemp.LANG = _ses.getLang();
            List<string> listSourcePath = _ses.tSOURCEPATHSESSION;
            List<string> listDestinationPath = _ses.tDESTINATIONPATHSESSION;
            if (objTemp.NOTE != null && listDestinationPath != null)
            {
                for (int i = 0; i < listSourcePath.Count; i++)
                {
                    if (objTemp.NOTE.Contains((listSourcePath[i])))
                        objTemp.NOTE = objTemp.NOTE.Replace(listSourcePath[i], listDestinationPath[i]);
                }
            }
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                objTemp.CODE = bus.genNextCode(obj);

                objTemp.LOCKDATE = DateTime.Now;
            }
            //Thêm hoặc sửa lại bản ghi SubjectContentTest
            CONTENTTYPE_BUS busContentType= new CONTENTTYPE_BUS();
            CONTENTTYPE_OBJ objContentType =busContentType.GetByID(new CONTENTTYPE_OBJ.BusinessObjectID(objTemp.CONTENTTYPE));
            busContentType.CloseConnection();
            if (objContentType == null)
            {
                ret = -5;
            }

            SUBJECTCONTENTTEST_BUS busSubjectContentTest = new SUBJECTCONTENTTEST_BUS();
            SUBJECTCONTENTTEST_OBJ objSubjectContentTest = null;
            if (ret >= 0)
            {
                if (objContentType.CODEVIEW == "BT" || objContentType.CODEVIEW == "KT" ||
                    objContentType.CODEVIEW == "TH")
                {
                    objSubjectContentTest = new SUBJECTCONTENTTEST_OBJ();
                    objSubjectContentTest.NAME = objTemp.NAME;
                    objSubjectContentTest.EDITTIME = DateTime.Now;
                    objSubjectContentTest.EDITUSER = _ses.loginCode;
                    objSubjectContentTest.EXAMTIMECODE = EXAMTIMECODE;
                    objSubjectContentTest.EXAMFORMCODE = ""; //Chưa chọn sẵn sẽ sinh sau
                    objSubjectContentTest.LOCK = 0;
                    objSubjectContentTest.NOTE = objTemp.NOTE;
                    objSubjectContentTest.SUBJECTCONTENTCODE = objTemp.CODE;
                    objSubjectContentTest.UNIVERSITYCODE = _ses.gUNIVERSITYCODE;
                    CONTENTTYPEQUESTIONUSE_BUS busContenttypequestionuse = new CONTENTTYPEQUESTIONUSE_BUS();
                    CONTENTTYPEQUESTIONUSE_OBJ objContenttypequestionuse =
                        busContenttypequestionuse.GetByKey(new fieldpara("CONTENTTYPECODE", objContentType.CODE));
                    busContenttypequestionuse.CloseConnection();
                    if (objContenttypequestionuse != null)
                    {
                        objSubjectContentTest.QUESTIONUSECODE = objContenttypequestionuse.QUESTIONUSECODE;
                    }
                    else
                    {
                        ret = -6;

                    }
                    //objTemp.CONTENTTYPE
                }
            }
            bus.BeginTransaction();
            busSubjectContentTest.setConnection(bus);
            if (ret >= 0)
            {
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
            }
            if (ret >= 0)
            {
                if (add != 1 && objSubjectContentTest!=null)
                {
                    ret = busSubjectContentTest.Delete(new fieldpara("SUBJECTCONTENTCODE", objTemp.CODE));
                }
                if (ret >= 0 && objSubjectContentTest!=null)
                {
                    ret = busSubjectContentTest.Insert(objSubjectContentTest);
                }
            }
            if (ret < 0)
            {
                bus.RollbackTransaction();
            }
            else
            {
                if (_ses.tSOURCEPATHSESSION != null)
                {
                    _ses.tSOURCEPATHSESSION.Clear();
                    _ses.tDESTINATIONPATHSESSION.Clear();
                }
                bus.CommitTransaction();
            }
            bus.CloseConnection();
            return Json(new
            {
                node = objTemp, ret,
                code = objTemp.CODE
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Delete(List<string> code)
        {
          //cho phep xoa hay khong
            //ret= -2 ;//sử dụng trong trường hợp xóa đơn một bản ghi có tham chiếu
            // ret= 0 : không có gì để xóa
            //ret = 1: //xóa thành công
            //ret= -3 : Bản ghi hiện tại không còn trong hệ thống, truy cập trái phép
            SUBJECTCONTENT_BUS subjectcontentBus = new SUBJECTCONTENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            COURSECONTENT_BUS coursecontentBus = new COURSECONTENT_BUS();
            var ret = 0;
            List<SUBJECTCONTENT_OBJ.BusinessObjectID> deleteList = new List<SUBJECTCONTENT_OBJ.BusinessObjectID>();

            foreach (string item in code)
            {
                var subjectcontent = subjectcontentBus.GetByID(new SUBJECTCONTENT_OBJ.BusinessObjectID(item));
                //check xem course co ton tai ban ghi phu thuoc nao khong
                if (subjectcontent == null)
                {
                    ret = -3;
                    return Json(new
                    {
                        ret
                    }, JsonRequestBehavior.AllowGet);
                }
                //kiểm tra xem có bản ghi con hay không
                //checkcode sẽ trả về là 0 nếu không có con
                // nhiều hơn 0 tức là tồn tại bản ghi con
                // nhỏ hơn 0 tức là lỗi hệ thống
                lipa.Clear();
                lipa.Add(new fieldpara("PARENTCODE", item, 0));
                lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                var childrent = subjectcontentBus.checkCode(null, new fieldpara("PARENTCODE", item, 0)); // kiểm tra xem có bản ghi con hay ko
                lipa.Clear();
                lipa.Add(new fieldpara("SUBJECTCONTENTCODE", item, 0));
                lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                var coursecontent = coursecontentBus.checkCode(null, lipa.ToArray()); // kiểm tra có bản ghi nào phụ thuộc vào nó hay ko
                //cho phép xóa thì nhét vào list xóa không thì không cho phép xóa nhưng cũng không cần thông báo
                //vì có trường hợp xóa nhiều bản ghi và chỉ xóa 1 bản ghi nên cần xác định rõ trước khi xóa một bản ghi cha nào đó thì có tồn tại liên kết đến bản ghi con hay không
                //bad request
                if (childrent < 0 || coursecontent < 0)
                {
                    ret = -3;
                    return Json(new
                    {
                        ret
                    }, JsonRequestBehavior.AllowGet);
                }
                //add to delete list
                if (childrent == 0 && coursecontent == 0)
                {
                    deleteList.Add(subjectcontent._ID);
                }
            }
            //nếu phần tử nằm trong danh sách xóa có thì sẽ phải xóa
            //xóa 1 bản ghi và trong trường hợp muốn xóa đơn lẻ
            //mà bản ghi đưa vào không có ràng buộc bản ghi con
            //có 1 bản ghi và bản ghi đó không được phép xóa
            if (code.Count == 1 && deleteList.Count < 1)
            {
                ret = -2;
            }
            //còn đây là trường hợp xóa nhiều, cứ thông báo là xóa thành công là xong
            //mặc dù còn có các bản ghi không được xóa còn có tham chiếu nhưng không nên thông báo quá chi tiết
            if (deleteList.Count >= 1)
            {
                //mặc định khi vào danh sách này là xóa thành công nên ret= 1;
                //duyệt toàn bộ danh sách bản ghi để xóa
                subjectcontentBus.BeginTransaction();
                ret = subjectcontentBus.DeletetMultiItems(deleteList);
                if (ret < 0)
                {
                    //Trong trường hợp nhiều thao tác, có một thao tác không thành công,
                    //hàm này được gọi để quay lại trạng thái trước khi thực hiện (bắt đầu từ khi gọi BeginTransaction()
                    subjectcontentBus.RollbackTransaction();
                }
                else
                {
                    //Sau khi thao tác dữ liệu thành công, hàm này được gọi để thực hiện ghi vào cơ sở dữ liệu
                    subjectcontentBus.CommitTransaction();
                }
            }

            coursecontentBus.CloseConnection();
            subjectcontentBus.CloseConnection();
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Listcombo(string subjectcode)
        {
            var ret = -1;
            //Lây dữ iệu
            SUBJECTCONTENT_BUS bus = new SUBJECTCONTENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("LOCK", 0, 0),
                new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0)
            };
            //Lọc đơn vị cấp trên; '' sẽ là không co đơn vị cấp trên
            if (subjectcode != "")
            {
                lipa.Add(new fieldpara("SUBJECTCODE", subjectcode, 1));
            }
            //order by theorder, with pagesize and the page
            var li = bus.getAllBy2(" NAME ", lipa.ToArray());
            if (li != null)
            {
                ret = 0;
                foreach (var item in li)
                {
                    item.NOTE = "";
                }
            }

            bus.CloseConnection();
            //get first

            //   string codefistSubcon = li.Count != 0 ? li[0].CODE : "";
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            //Trả về cho client
            return Json(new
            {
                //   codefistSubcon= codefistSubcon,
                data = li,
                ret
            },
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetById(string id)
        {
            SUBJECTCONTENT_OBJ obj = null;
            if (!string.IsNullOrEmpty(id))
            {
                SUBJECTCONTENT_BUS bus = new SUBJECTCONTENT_BUS();
                obj = bus.GetByID(new SUBJECTCONTENT_OBJ.BusinessObjectID(id));
            }
            return Json(new { data = obj }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// lấy danh sách các subjectcontent trực tiếp của parentcode
        /// </summary>
        /// <param name="parentCode">mã subjectcontent cha</param>
        /// <returns></returns>
        public JsonResult GetListSub(string parentCode)
        {
            SUBJECTCONTENT_BUS bus = new SUBJECTCONTENT_BUS();
            var li = bus.getAllBy2("CODE", new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0),
                                                new fieldpara("PARENTCODE", parentCode, 0));
            return Json(new { data = li }, JsonRequestBehavior.AllowGet);
        }
    }
}