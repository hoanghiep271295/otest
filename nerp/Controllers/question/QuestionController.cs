using IS.Config;
using IS.fitframework;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;

namespace nerp.Controllers.question
{
    public class QuestionController : Controller
    {
        private readonly session _ses = new session();

        // list file uploaded when new or edit
        public ActionResult Index(string id, string subid)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.code = string.IsNullOrEmpty(id) ? "" : id; //Mã môn học hiện tại
            defaultobject.contentcode = string.IsNullOrEmpty(subid) ? "" : subid; //Mã của phần chọn hiện tại
            defaultobject.thetype = _ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx =
            {
                "/Scripts/reactselect/prop-types.js"
                , "/Scripts/reactselect/react-input-autosize.js"
                , "/Scripts/reactselect/classname.js"
                , "/Scripts/reactselect/react-select.js"
                , "/Scripts/tinymce/js/tinymce/tinymce.min.js"
                , "/Scripts/tinymce/js/tinymce/jquery.tinymce.min.js"
                , "/Scripts/tinymce/js/tinymce/init-tinymce.js"
                , "/Jsx/_Shared/Tree.jsx"
                , "/Scripts/Ag-grid/ag-grid.js"
                , "/Jsx/_Shared/SearchDialog.jsx"
                , "/Jsx/_Shared/Combobox.jsx"
                , "/Jsx/_Shared/Combobox3.jsx"
                , "/jsx/_shared/AgGrid.jsx"
                , "/Jsx/_Shared/ButtonList.jsx"
                , "/Jsx/_Shared/ButtonList.jsx"
                , "/Jsx/_Shared/PopupSearch.jsx"
                , "/Scripts/Ag-grid/ag-grid.js"
                , "/Jsx/_Shared/AgGrid.jsx"
                , "/Jsx/_Shared/TabHeader.jsx" //Phụ trách hiển thị các tab
                , "/jsx/question/questiontype/GENPopup.jsx" //Hiển thị popup
                , "/jsx/question/questiontype/MSPopup.jsx" //Hiển thị popup
                //,"/jsx/question/questiontype/FIPopup.jsx" //Hiển thị popup
                , "/jsx/question/questiontype/GroupPopup.jsx" //Hiển thị popup

                , "/jsx/question/Qtype/FFQuestion.jsx" //Hiển thị popup
                , "/jsx/question/Qtype/RAQuestion.jsx" //Hiển thị popup
                , "/jsx/question/Qtype/COQuestion.jsx" //Hiển thị popup
                , "/jsx/question/Qtype/FGQuestion.jsx" //Hiển thị popup
                , "/jsx/question/Qtype/FIQuestion.jsx" //Hiển thị popup
                , "/jsx/question/Qtype/LAQuestion.jsx" //Hiển thị popup
                , "/jsx/question/Qtype/MCQuestion.jsx" //Hiển thị popup
                , "/jsx/question/Qtype/PAQuestion.jsx" //Hiển thị popup
                , "/jsx/question/Qtype/RWQuestion.jsx" //Hiển thị popup
                , "/jsx/question/Qtype/WRQuestion.jsx" //Hiển thị popup
                , "/jsx/question/QTypeAnswer/COAnswer.jsx" //Hiển thị popup
                , "/jsx/question/QTypeAnswer/FGAnswer.jsx" //Hiển thị popup
                , "/jsx/question/QTypeAnswer/RWAnswer.jsx" //Hiển thị popup
                , "/jsx/question/questionlist/popupqgroup.jsx" //Hiển thị popup
                , "/jsx/question/questionlist/listqgroup.jsx" //Hiển thị danh sách
                , "/jsx/question/questionlist/GENPopupQuestion.jsx" //Hiển thị popup
                , "/jsx/question/questionlist/ListQuestion.jsx" //Hiển thị danh sách
                , "/jsx/question/questionlist/PopupAnswer.jsx" //Hiển thị popup
                , "/jsx/question/questionlist/ListAnswer.jsx" //Hiển thị danh sách
                , "/jsx/Question/App/QuestionChildApp.jsx"
                , "/jsx/Question/App/QuestionApppopup.jsx"
                , "/jsx/Question/App/QuestionApplist.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex"); //Lấy index mặc định trong share
        }

        /// <summary>
        /// preview 1 câu hỏi
        /// </summary>
        /// <param name="id">mã nhóm câu hỏi</param>
        /// <returns></returns>
        public ActionResult Preview(string id)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.code = id;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx =
            {
                "/Jsx/question/ManageQuestion/DragBack.jsx",
                "/Jsx/question/ManageQuestion/Drag.jsx",
                "/Jsx/question/ManageQuestion/FIQuestion.jsx",
                "/Jsx/question/ManageQuestion/PAQuestion.jsx",
                 "/Jsx/question/ManageQuestion/MSQuestion.jsx",
                "/Jsx/question/ManageQuestion/App.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex"); //Lấy index mặc định trong share
        }

        /// <summary>
        /// lấy chi tiết câu hỏi, câu trả lời theo nhóm câu hỏi
        /// </summary>
        /// <param name="questiongroupcode">mã nhóm câu hỏi</param>
        /// <returns></returns>
        public JsonResult GetById(string questiongroupcode)
        {
            var ret = 0;
            var numberQuestion = 0;
            List<QUESTION_OBJ> liQuestion = new List<QUESTION_OBJ>();
            List<ANSWER_OBJ> liAnswer = new List<ANSWER_OBJ>();
            QUESTIONGROUP_BUS bus = new QUESTIONGROUP_BUS();
            var obj = bus.GetByID(new QUESTIONGROUP_OBJ.BusinessObjectID(questiongroupcode));
            if (obj != null)
            {
                // lấy danh sách câu hỏi tương ứng
                QUESTION_BUS questionBus = new QUESTION_BUS();
                liQuestion = questionBus.getAllBy2("CODE",
                    new fieldpara("QUESTIONGROUPCODE", questiongroupcode, 0));
                if (liQuestion != null)
                {
                    // lấy danh sách câu trả lời
                    ANSWER_BUS answerBus = new ANSWER_BUS();
                    liAnswer = answerBus.getAllBy2("CODE",
                        new fieldpara("QUESTIONGROUPCODE", questiongroupcode, 0));
                    if (liAnswer == null)
                        ret = -3;
                    answerBus.CloseConnection();
                }
                else ret = -2;
                if (liQuestion != null)
                    numberQuestion = liQuestion.Count;
                questionBus.CloseConnection();
            }
            else ret = -1;

            bus.CloseConnection();
            var jsonResult = Json(new
            {
                numberQuestion, //so luong cau hoi
                ObjexamHallstudent = obj, //examhallstudent code
                liQuestiongroup = obj, //danh sach nhom cau hoi
                li_question = liQuestion, //danh sach cac cau hoi
                li_answer = liAnswer, //danh sach tat ca cac cau tra loi
                ret //ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        #region QuestionGroup

        public JsonResult CheckCodeViewExitQgroup(string code, string codeView)
        {
            int ret;
            QUESTIONGROUP_BUS bus = new QUESTIONGROUP_BUS();
            QUESTIONGROUP_OBJ obj;
            if (!string.IsNullOrEmpty(code))
            {
                //check for update
                obj = bus.GetByKey(new fieldpara("CODEVIEW", codeView, 0),
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
                obj = bus.GetByKey(new fieldpara("CODEVIEW", codeView, 0),
                    new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                ret = (obj == null) ? 1 : -1;
            }
            bus.CloseConnection();
            return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// get list QuestionGroup by subjectcontentcode
        /// </summary>
        /// <param name="subjectContentCode"></param>
        /// <param name="questiontypecode"></param>
        /// <returns></returns>
        public List<QUESTIONGROUP_OBJ> GetQGroupBySbjContent(string subjectContentCode, string questiontypecode)
        {
            QUESTIONGROUP_BUS bus = new QUESTIONGROUP_BUS();
            var data = bus.getAllBy2("NAME", new fieldpara("SUBJECTCONTENTCODE", subjectContentCode, 0),
                new fieldpara("QUESTIONTYPECODE", questiontypecode, 0)
            );
            bus.CloseConnection();
            return data;
        }

        public JsonResult GetListQgroup(string subjectcontentcode, string subjectcode, int page, int pageSize)
        {
            var ret = -10;
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
            QUESTIONGROUP_BUS bus = new QUESTIONGROUP_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("SUBJECTCONTENTCODE", subjectcontentcode, 0)
            };
            //here is subjectcontentcode

            //here is subbjectcode
            if (!string.IsNullOrEmpty(subjectcode))
            {
                lipa.Add(new fieldpara("SUBJECTCODE", subjectcode, 0));
            }
            // lipa.Add(new fieldpara("LOCK",0,0));
            int countpage;
            //order by theorder, with pagesize and the page
            var data = bus.getAllBy2("CODEVIEW", pageSize, page, out countpage, lipa.ToArray());
            // tất cả các bản ghi
            List<QUESTIONGROUP_OBJ> totalData = bus.getAllBy2("CODEVIEW", lipa.ToArray());
            int totalItem = totalData.Count;
            if (totalItem > 0) ret = 1;
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            int startpage = (page - 1) * pageSize;
            //Trả về client
            // var datastring = JsonConvert.SerializeObject(data);
            var jsonResult = Json(new
            {
                lst = data, //Danh sách
                totalPage = countpage,
                startindex = startpage, //bắt đầu số trang
                ret //ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [HttpPost]
        [ValidateInput(false)]
        public JsonResult UpdateQgroup(QUESTIONGROUP_OBJ obj)
        {
            QUESTIONTYPE_BUS busQuestiontype = new QUESTIONTYPE_BUS();
            QUESTIONTYPE_OBJ objQuestiontype =
                busQuestiontype.GetByID(new QUESTIONTYPE_OBJ.BusinessObjectID(obj.QUESTIONTYPECODE));
            busQuestiontype.CloseConnection();
            QUESTIONGROUP_BUS bus = new QUESTIONGROUP_BUS();
            int ret = 0;
            int add = 0;
            //kiểm tra tồn tại cho trường hợp sửa
            var objTemp = !string.IsNullOrEmpty(obj.CODE)
                ? bus.GetByID(new QUESTIONGROUP_OBJ.BusinessObjectID(obj.CODE))
                : new QUESTIONGROUP_OBJ();
            //Lỗi phần dưới đưa lên
            if (ret < 0 || objQuestiontype == null)
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
            objTemp.SUBJECTCODE = obj.SUBJECTCODE;
            objTemp.SUBJECTCONTENTCODE = obj.SUBJECTCONTENTCODE;
            objTemp.NOTE = obj.NOTE;
            objTemp.LOCK = obj.LOCK;
            objTemp.CONTENT = obj.CONTENT;
            objTemp.QUESTIONTYPECODE = obj.QUESTIONTYPECODE;
            objTemp.QUESTIONUSECODELIST = obj.QUESTIONUSECODELIST;
            objTemp.MARK = obj.MARK;
            List<string> listSourcePath = _ses.tSOURCEPATHSESSION;
            List<string> listDestinationPath = _ses.tDESTINATIONPATHSESSION;
            if (listDestinationPath != null)
            {
                for (int i = 0; i < listSourcePath.Count; i++)
                {
                    if (objTemp.CONTENT.Contains((listSourcePath[i])))
                        objTemp.CONTENT = objTemp.CONTENT.Replace(listSourcePath[i], listDestinationPath[i]);
                }
            }
            QUESTION_BUS busQuestion = new QUESTION_BUS();
            QUESTION_OBJ objQuestion = null;
            ANSWER_BUS busAnswer = new ANSWER_BUS();
            ANSWER_OBJ objAnser = null;

            //Dành cho danh sách các phương pháp sử dụng
            // obj_temp.THEORDER = obj.THEORDER;
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                objTemp.CODE = bus.genNextCode(obj);
                objTemp.LOCKDATE = DateTime.Now;
                //Sinh tự động các bản ghi theo yêu cầu
                switch (objQuestiontype.CODEVIEW)
                {
                    case "WR":
                        //Tự động sinh ra câu hỏi
                        objQuestion = new QUESTION_OBJ { QUESTIONGROUPCODE = objTemp.CODE };
                        objQuestion.CODE = busQuestion.genNextCode(objQuestion);
                        objQuestion.NAME = "Câu hỏi cho:" + objTemp.NAME;
                        objQuestion.MARK = objTemp.MARK;
                        //Tự động sinh ra câu tra lời
                        objAnser = new ANSWER_OBJ();
                        objAnser.CODE = busAnswer.genNextCode(objAnser);
                        objAnser.QUESTIONCODE = objQuestion.CODE;
                        objAnser.QUESTIONGROUPCODE = objTemp.CODE;
                        objAnser.CODEVIEW = "1";
                        objAnser.THEORDER = 1;
                        objAnser.NAME = objTemp.NAME;
                        objAnser.CONTENT = "";
                        objAnser.TRUEANSWER = 1;
                        break;
                    case "LA":
                        objQuestion = new QUESTION_OBJ { QUESTIONGROUPCODE = objTemp.CODE };
                        objQuestion.CODE = busQuestion.genNextCode(objQuestion);
                        objQuestion.NAME = "Câu hỏi cho:" + objTemp.NAME;
                        objQuestion.MARK = objTemp.MARK;
                        //Tự động sinh ra câu tra lời
                        objAnser = new ANSWER_OBJ();
                        objAnser.CODE = busAnswer.genNextCode(objAnser);
                        objAnser.QUESTIONCODE = objQuestion.CODE;
                        objAnser.QUESTIONGROUPCODE = objTemp.CODE;
                        objAnser.CODEVIEW = "1";
                        objAnser.THEORDER = 1;
                        objAnser.NAME = objTemp.NAME;
                        objAnser.CONTENT = "";
                        objAnser.TRUEANSWER = 1;
                        break;

                    //trường hợp câu hỏi tổng hợp cần sinh ra 3 câu trả lời là true/false/not given, nếu muốn biết được câu trả lời nào là đúng thì cần
                    case "MS":
                        //Tự động sinh ra câu hỏi
                        objQuestion = new QUESTION_OBJ { QUESTIONGROUPCODE = objTemp.CODE };
                        objQuestion.CODE = busQuestion.genNextCode(objQuestion);
                        objQuestion.NAME = "Câu hỏi cho:" + objTemp.NAME;
                        objQuestion.MARK = objTemp.MARK;
                        break;
                }
            }
            List<QUESTIONGROUPUSE_OBJ> liQuestiongroupuse = new List<QUESTIONGROUPUSE_OBJ>();
            QUESTIONGROUPUSE_BUS busQuestiongroupuse = new QUESTIONGROUPUSE_BUS();
            string[] listUse = obj.QUESTIONUSECODELIST.Split(',');
            foreach (var item in listUse)
            {
                QUESTIONGROUPUSE_OBJ objQuestiongroupuse = new QUESTIONGROUPUSE_OBJ
                {
                    LOCK = 0,
                    LOCKDATE = DateTime.Now,
                    QUESITONGROUPCODE = objTemp.CODE,
                    QUESTIONUSECODE = item
                };
                liQuestiongroupuse.Add(objQuestiongroupuse);
            }
            bus.BeginTransaction();
            busQuestiongroupuse.setConnection(bus);
            busAnswer.setConnection(bus);
            busQuestion.setConnection(bus);

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
                // ReSharper disable once PossiblyMistakenUseOfParamsMethod
                ret = busQuestiongroupuse.Delete(new fieldpara("QUESITONGROUPCODE", objTemp.CODE));
            }
            if (ret >= 0)
            {
                ret = busQuestiongroupuse.InsertMultiItems(liQuestiongroupuse);
            }
            //Cập nhật câu hỏi nếu nó được sinh tự động
            if (objQuestion != null && ret >= 0)
            {
                ret = busQuestion.Insert(objQuestion);
            }
            //Cập nhật answer nếu được sinh tự động
            if (objAnser != null && ret >= 0)
            {
                ret = busAnswer.Insert(objAnser);
            }

            if (ret >= 0)
            {
                _ses.tSOURCEPATHSESSION?.Clear();
                _ses.tDESTINATIONPATHSESSION?.Clear();
                bus.CommitTransaction();
            }
            else
            {
                bus.RollbackTransaction();
            }
            int pagecount = 0;
            int currentpage = 0;
            string questiongroup = JsonConvert.SerializeObject(objTemp);
            bus.CloseConnection();
            //some thing like that
            return Json(new { add, ret, questiongroup, pagecount, currentpage, obj = objTemp },
                JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// xóa danh sách các answer và question  mà trong đó các questiongroup được trả về để GetQuestionxóa,không cần thông báo, nếu có con thì không cho xóa, còn nếu không có thì xóa nó đi,thanks
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        public JsonResult DeleteQgroup(List<string> code)
        {
            int ans = -1;
            if (code != null)
            {
                var bus = new QUESTIONGROUP_BUS();
                foreach (string t in code)
                {
                    var ret = 0;
                    if (t != null)
                    {
                        var item = bus.GetByID(new QUESTIONGROUP_OBJ.BusinessObjectID(t));
                        if (item == null)
                        {
                            continue;
                        }
                        if (ret >= 0)
                        {
                            QUESTION_BUS busQuestion = new QUESTION_BUS();
                            //check children
                            ret = busQuestion.checkCode(null, new fieldpara("QUESTIONGROUPCODE", t));
                            busQuestion.CloseConnection();
                            //check children
                            if (ret > 0)
                            {
                                ANSWER_BUS busAnswer = new ANSWER_BUS();
                                ret = busAnswer.checkCode(null, new fieldpara("QUESTIONGROUPCODE", t));
                                busAnswer.CloseConnection();
                            }
                            //exist children
                            if (ret != 0)
                            {
                                ret = -1;
                            }
                        }
                        if (ret == 0)
                        {
                            ans = 1;
                            bus.delete(item._ID);
                        }
                    }
                }
                bus.CloseConnection();
            }
            return Json(new
            {
                ret = ans
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion QuestionGroup

        #region Question

        public JsonResult DeleteQuestion(List<string> code)
        {
            if (code != null)
            {
                var bus = new QUESTION_BUS();
                var busAnswer = new ANSWER_BUS();
                foreach (string t in code)
                {
                    var item = bus.GetByID(new QUESTION_OBJ.BusinessObjectID(t));

                    List<ANSWER_OBJ> lianswer = busAnswer.getAllBy(new fieldpara("QUESTIONCODE", t));

                    foreach (var itemAnswer in lianswer)
                    {
                        busAnswer.delete(itemAnswer._ID);
                    }

                    if (t != null)
                    {
                        bus.delete(item._ID);
                    }
                }
                busAnswer.CloseConnection();
                bus.CloseConnection();
            }

            return Json(new
            {
                ret = 0
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// get list question by questiongroup
        /// </summary>
        /// <param name="questionGroupCode"></param>
        /// <returns></returns>

        public List<QUESTION_OBJ> GetListQuesByQuesGroup(string questionGroupCode)
        {
            QUESTION_BUS bus = new QUESTION_BUS();
            var data = bus.getAllBy2("NAME", new fieldpara("QUESTIONGROUPCODE", questionGroupCode, 0));
            return data;
        }

        public JsonResult GetListQuestion(string groupcode, int page, int pageSize)
        {
            var ret = -1;
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
            QUESTION_BUS bus = new QUESTION_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("QUESTIONGROUPCODE", groupcode, 0)
            };
            int countpage;
            //order by theorder, with pagesize and the page
            List<QUESTION_OBJ> data = bus.getAllBy2("CODEVIEW", pageSize, page, out countpage, lipa.ToArray());
            // tất cả các bản ghi
            List<QUESTION_OBJ> totalData = bus.getAllBy2("CODEVIEW", lipa.ToArray());

            int totalItem = totalData.Count;
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            int startpage = (page - 1) * pageSize;
            //Trả về client
            var a = JsonConvert.SerializeObject(data);
            string firstquestion = "";
            if (data.Count != 0)
            {
                firstquestion = JsonConvert.SerializeObject(data[0]);
            }
            if (totalItem > 0) ret = 1;
            var jsonResult = Json(new
            {
                firstquestion,
                data, //Danh sách
                data2 = a,
                totalItem, //số lượng bản ghi
                totalPage = countpage,
                startindex = startpage, //bắt đầu số trang
                ret //ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// Lấy về danh sách và phần tử ở đầu
        /// </summary>
        /// <param name="groupcode"></param>
        /// <returns></returns>
        public JsonResult GetQuestion(string groupcode)
        {
            var ret = 0;
            //Khai báo lấy dữ liệu
            QUESTION_BUS bus = new QUESTION_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("QUESTIONGROUPCODE", groupcode, 0)
            };
            //order by theorder, with pagesize and the page
            List<QUESTION_OBJ> data = bus.getAllBy2("CODEVIEW", lipa.ToArray());
            QUESTION_OBJ firstquestion = null;
            if (data.Count > 0)
            {
                firstquestion = data[0];
            }
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)

            var jsonResult = Json(new
            {
                firstquestion,
                data, //Danh sách
                ret //ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        [ValidateInput(false)]
        public JsonResult UpdateQuestion(QUESTION_OBJ obj, string typeQuestion)
        {
            int ret = 0;

            int add = 0;
            QUESTION_OBJ objTemp;
            string codeAnswer = "";
            QUESTION_BUS bus = new QUESTION_BUS();
            ANSWER_BUS ansbus = new ANSWER_BUS();
            if (!string.IsNullOrEmpty(obj.CODE)) //edit
            {
                objTemp = bus.GetByID(new QUESTION_OBJ.BusinessObjectID(obj.CODE));
                if (typeQuestion == "CO")
                {
                    List<ANSWER_OBJ> libegin = ansbus.getAllBy2(" CODE ", new fieldpara("QUESTIONCODE", obj.CODE, 0)
                        , new fieldpara("QUESTIONGROUPCODE", obj.QUESTIONGROUPCODE, 0));
                    if (obj.ANSWERCODE != null)
                    {
                        foreach (ANSWER_OBJ item in libegin)
                        {
                            if (item.CODEVIEW.Split('_')[1] == obj.ANSWERCODE)
                            {
                                codeAnswer = item.CODE;
                                item.TRUEANSWER = 1;
                                item._ID.CODE = item.CODE;
                                ret = ansbus.update(item);
                            }
                            else
                            {
                                item.TRUEANSWER = 0;
                                item._ID.CODE = item.CODE;
                                ret = ansbus.update(item);
                            }
                        }
                    }
                }
            }
            else //add
            {
                objTemp = new QUESTION_OBJ();
            }
            if (ret < 0)
            {
                //đóng kết nối trước khi trả về
                bus.CloseConnection();
                //ban ghi sửa đã bị xóa
                return Json(new { ret }, JsonRequestBehavior.AllowGet);
            }
            //hết kiểm tra tồn tại bản ghi
            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.CONTENTIMG = obj.CONTENTIMG;
            objTemp.MARK = obj.MARK;
            objTemp.ORD = obj.ORD;
            objTemp.LOCK = obj.LOCK;
            objTemp.CONTENT = obj.CONTENT;
            objTemp.QUESTIONGROUPCODE = obj.QUESTIONGROUPCODE;
            //trong trường hợp là câu hỏi dạng CO thì cập nhật lại answercode bằng codeanswer không thì sẽ làm như bình thường objTemp.Answercode= obj.Answercode
            objTemp.ANSWERCODE = typeQuestion == "CO" ? codeAnswer : obj.ANSWERCODE;

            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                objTemp.CODE = bus.genNextCode(obj);
                if (typeQuestion == "CO")
                {
                    ANSWER_OBJ objAnser = new ANSWER_OBJ();
                    ANSWER_BUS busAnswer = new ANSWER_BUS();
                    string answerCode = busAnswer.genNextCode(objAnser);
                    List<ANSWER_OBJ> listAnswer = new List<ANSWER_OBJ>();
                    List<string> listContentAnswer = new List<string> { "TRUE", "FALSE", "NOT GIVEN" };
                    //Tự động sinh ra câu hỏi và là 3 đáp án true, false,
                    //Tự động sinh ra câu tra lời
                    for (int i = 0; i < listContentAnswer.Count; i++)
                    {
                        ANSWER_OBJ answer = new ANSWER_OBJ
                        {
                            CODE = answerCode
                        };
                        answerCode = busAnswer.GenNextCode(answer, answerCode);
                        answer.QUESTIONCODE = objTemp.CODE;
                        answer.QUESTIONGROUPCODE = obj.QUESTIONGROUPCODE;
                        answer.CODEVIEW = "CO_" + i;
                        answer.THEORDER = i + 1;
                        answer.NAME = "CO" + (i + 1);
                        answer.CONTENT = listContentAnswer[i];
                        if (int.Parse(obj.ANSWERCODE) == i)
                        {
                            objTemp.ANSWERCODE = answerCode;
                            answer.TRUEANSWER = 1;
                        }
                        else
                        {
                            answer.TRUEANSWER = 0;
                        }

                        listAnswer.Add(answer);
                    }
                    busAnswer.BeginTransaction();
                    ret = busAnswer.InsertMultiItems(listAnswer);
                    if (ret < 0)
                    {
                        busAnswer.RollbackTransaction();
                    }
                    else
                    {
                        busAnswer.CommitTransaction();
                    }
                    busAnswer.CloseConnection();
                }
            }
            if (add == 1 && ret >= 0)
            {
                ret = bus.insert(objTemp);
            }
            else
            {
                //gán _ID để xác định bản ghi sẽ được cập nhật
                objTemp._ID.CODE = obj.CODE;
                ret = bus.update(objTemp);
            }
            bus.CloseConnection();
            ansbus.CloseConnection();

            return Json(new
            {
                ret
            },
           JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Cập nhật dữ liệu cho những phần kéo thả, như FF, FI, FF
        /// FF: select option trên questiongroup 
        /// FI: kéo thả vào ô div
        /// FG : Điền từ vào ô trống
        /// Cả 3 dạng có 1 kiểu chung đó là khi bôi đen và cắt thì sẽ xuất hiện 1 câu hỏi và 1 câu trả lời tự sinh
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="questiontypeCodeView"></param>
        /// <param name="contentAnswer"></param>
        /// <returns></returns>
        [ValidateInput(false)]
        public JsonResult UpdateQuestionF(QUESTION_OBJ obj, string questiontypeCodeView,string contentAnswer)
        {
            QUESTION_BUS bus = new QUESTION_BUS();
            int ret;
            int add = 0;
            ANSWER_BUS busAnswer  =new ANSWER_BUS();
            ANSWER_OBJ objAnswer = new ANSWER_OBJ();
            //kiểm tra tồn tại cho trường hợp sửa
            var objTemp = !string.IsNullOrEmpty(obj.CODE) ? bus.GetByID(new QUESTION_OBJ.BusinessObjectID(obj.CODE)) : new QUESTION_OBJ();
            //hết kiểm tra tồn tại bản ghi
            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.CONTENTIMG = obj.CONTENTIMG;
            objTemp.MARK = obj.MARK;
            objTemp.ORD = obj.ORD;
            objTemp.LOCK = obj.LOCK;
            objTemp.CONTENT = obj.CONTENT;
            objTemp.QUESTIONGROUPCODE = obj.QUESTIONGROUPCODE;
            objTemp.ANSWERCODE = obj.ANSWERCODE;
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Sinh mã
                objTemp.CODE = bus.genNextCode(obj);
                objAnswer.CODE = busAnswer.genNextCode(objAnswer);
                objTemp.ANSWERCODE = objAnswer.CODE;

            }
            if (add == 1)
            {
                ret = bus.insert(objTemp);
                //chỉ cần thêm mới chứ không cần cập nhật answer 
                if (ret >= 0)
                {
                    objAnswer.QUESTIONCODE = objTemp.CODE;
                    objAnswer.QUESTIONGROUPCODE = obj.QUESTIONGROUPCODE;
                    objAnswer.CODEVIEW = "1";
                    objAnswer.THEORDER = 1;
                    objAnswer.NAME = objTemp.NAME;
                    objAnswer.CONTENT = contentAnswer;
                    objAnswer.TRUEANSWER = 1;
                    ret = busAnswer.insert(objAnswer);
                }
            }
            else
            {
                //gán _ID để xác định bản ghi sẽ được cập nhật
                objTemp._ID.CODE = obj.CODE;
                ret = bus.update(objTemp);
            }

            bus.CloseConnection();
            busAnswer.CloseConnection();
            return Json(new
            {
                code = objTemp.CODE,
                ret
            },
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult CheckCodeViewExitQuestion(string questiongroup, string code, string codeView)
        {
            int ret;
            QUESTION_BUS bus = new QUESTION_BUS();
            QUESTION_OBJ obj;
            if (!string.IsNullOrEmpty(code))
            {
                //check for update
                obj = bus.GetByKey(new fieldpara("CODEVIEW", codeView, 0),
                                    new fieldpara("QUESTIONGROUPCODE", questiongroup, 0),
                                     new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));

                if (obj == null)
                {
                    //change codeview
                    ret = 1;
                }
                else
                {
                    //change other feature,not codeview
                    ret = code == obj.CODE ? 1 : -1;
                }
            }
            else
            {
                obj = bus.GetByKey(new fieldpara("CODEVIEW", codeView, 0),
                                           new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                ret = obj == null ? 1 : -1;
            }
            bus.CloseConnection();
            return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
        }

        #endregion Question

        #region Answer

        [HttpPost]
        public JsonResult GetAnswerQuestionCo(string questionCode)
        {
            int ret;
            ANSWER_BUS busAnswer = new ANSWER_BUS();
            var listAnswerObjs = busAnswer.getAllBy2("THEORDER", new fieldpara("QUESTIONCODE", questionCode, 0));
            if (listAnswerObjs.Count > 0)
                ret = 1;
            else
            {
                ret = -1;
            }

            var jsonResult = Json(new
            {
                ret, //ok
                listAnswerObjs //danh sách check
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult GetListAnswer(string questioncode, string questiongroupcode, string questiontypecodeview)
        {
            //mặc định cho phần trang

            //Khai báo lấy dữ liệu
            ANSWER_BUS bus = new ANSWER_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            if (!string.IsNullOrEmpty(questioncode))
            {
                lipa.Add(new fieldpara("QUESTIONCODE", questioncode, 0));
            }
            if (!string.IsNullOrEmpty(questiongroupcode))
            {
                lipa.Add(new fieldpara("QUESTIONGROUPCODE", questiongroupcode, 0));
            }
            //order by theorder, with pagesize and the page
            var data = bus.getAllBy2("CODEVIEW", lipa.ToArray());
            //trường hợp multichoice

            // tất cả các bản ghi
            List<ANSWER_OBJ> totalData = bus.getAllBy2("CODEVIEW", lipa.ToArray());
            int totalItem = totalData.Count;
            bus.CloseConnection();
            //Trả về client
            var a = JsonConvert.SerializeObject(data);
            string answer = null;
            int quantiti = 0;
            if (data.Count != 0)
            {
                foreach (var item in data)
                {
                    if (item.TRUEANSWER == 1)
                    {
                        answer = item.CODE;
                        quantiti += 1;
                    }
                }
            }
            else
            {
                answer = "";
            }
            var jsonResult = Json(new
            {
                quantiti,
                answer,
                data,//Danh sách
                data2 = a,
                totalItem,//số lượng bản ghi
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult CheckCodeViewExitAnswer(string questiongroup, string question, string code, string codeView)
        {
            int ret;
            ANSWER_BUS bus = new ANSWER_BUS();
            ANSWER_OBJ obj;
            if (!string.IsNullOrEmpty(code))
            {
                //check for update
                obj = bus.GetByKey(new fieldpara("CODEVIEW", codeView, 0),
                                   new fieldpara("QUESTIONGROUPCODE", questiongroup, 0),
                                   new fieldpara("QUESTIONCODE", question, 0),
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
                obj = bus.GetByKey(new fieldpara("CODEVIEW", codeView, 0),
                                           new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                ret = (obj == null) ? 1 : -1;
            }
            bus.CloseConnection();
            return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
        }

        //        [HttpPost]
        [ValidateInput(false)]
        public JsonResult UpdateAnswer(ANSWER_OBJ obj)
        {
            ANSWER_BUS bus = new ANSWER_BUS();
            int ret = 0;
            int add = 0;
            //kiểm tra tồn tại cho trường hợp sửa

            var objTemp = !string.IsNullOrEmpty(obj.CODE) ? bus.GetByID(new ANSWER_OBJ.BusinessObjectID(obj.CODE)) : new ANSWER_OBJ();
            if (ret < 0)
            {
                //đóng kết nối trước khi trả về
                bus.CloseConnection();
                //ban ghi sửa đã bị xóa
                return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
            }

            //hết kiểm tra tồn tại bản ghi
            int quantiti;
            if (obj.TRUEANSWER == 0 && objTemp.TRUEANSWER == 1)
            {
                quantiti = 0;
            }
            else
            {
                quantiti = 1;
            }
            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.CONTENTIMG = obj.CONTENTIMG;
            objTemp.CONTENT = obj.CONTENT;
            objTemp.QUESTIONGROUPCODE = obj.QUESTIONGROUPCODE;
            objTemp.THEORDER = obj.THEORDER;
            objTemp.TRUEANSWER = obj.TRUEANSWER;

            // obj_temp.THEORDER = obj.THEORDER;
            //Kiểm tra tình trạng sửa hay là thêm mới
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //Thêm mới
                add = 1;
                //Chỉ gán lại khi thêm mới
                objTemp.QUESTIONCODE = obj.QUESTIONCODE;
                //Sinh mã
                objTemp.CODE = bus.genNextCode(obj);
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
            var answercode = objTemp.TRUEANSWER == 1 ? objTemp.CODE : "";
            bus.CloseConnection();
            //some thing like that
            return Json(new
            {
                quantiti,
                answercode,
                ret,
                pagecount,
                currentpage
            },
                JsonRequestBehavior.AllowGet);
        }

        public JsonResult DeleteAnswer(List<string> code)
        {
            var ret = 0;
            var error = false;
            if (code != null)
            {
                var bus = new ANSWER_BUS();
                foreach (string t in code)
                {
                    if (t != null)
                    {
                        var item = bus.GetByID(new ANSWER_OBJ.BusinessObjectID(t));
                        if (item == null)
                        {
                            ret = -1;
                            error = true;
                            continue;
                        }
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
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        #endregion Answer
    }
}