using IS.fitframework;
using IS.localcomm;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web.Mvc;

namespace nerp.Controllers.core
{
    public class MarkController : Controller
    {
        // GET: Mark
        private readonly session _ses = new session();

        private localcommonlib com = new localcommonlib();

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
                ,"/Jsx/_Shared/DropDownTree.jsx"
                 ,"/Scripts/Dropdowntree/dropdowntree.js"
                ,"/Jsx/_Shared/Tree.jsx"
                ,"/Scripts/Ag-grid/ag-grid.js"
                ,"/Jsx/_Shared/AgGrid.jsx"
                ,"/Jsx/_Shared/TabHeader.jsx"
                //  ,"/jsx/Core/Mark/Coursestudied.jsx"
                ,"/jsx/Core/Mark/StudentList.jsx"
                 ,"/jsx/Core/Mark/MarkApp.jsx"
            };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share
        }

        /// <summary>
        /// get danh sách tất cả các sinh viên, trừ các sinh viên đã được thêm vào lớp học
        /// </summary>
        /// <param name="coursecode">mã lớp học</param>
        /// <param name="classcode">mã lớp</param>
        /// <returns></returns>
        public JsonResult GetAllStudent(string coursecode, string classcode)
        {
            // danh sách mã sinh viên đã tham gia vào course
            List<string> listStudentCode = new List<string>();
            MARK_BUS bus = new MARK_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            if (!string.IsNullOrEmpty(coursecode))
            {
                lipa.Add(new fieldpara("COURSECODE", coursecode, 0));
            }
            lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            lipa.Add(new fieldpara("EDUCATIONLEVELCODE", "DH", 0));
            List<MARK_OBJ> liStudentCourse = bus.getAllBy2("STUDENTCODE", lipa.ToArray());
            foreach (var studentcourse in liStudentCourse)
            {
                listStudentCode.Add(studentcourse.STUDENTCODE);
            }
            // danh sách tất cả các sinh viên
            STUDENT_BUS busStudent = new STUDENT_BUS();
            var liStudent = busStudent.getAllBy2("CODE", new fieldpara("CLASSCODE", classcode, 0),
                new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0),
                new fieldpara("EDUCATIONLEVELCODE", "DH", 0));
            var count = 0;
            if (listStudentCode.Count > 0)
            {
                for (int i = 0; i < liStudent.Count; i++)
                {
                    if (listStudentCode.Contains(liStudent[i].CODE))
                    {
                        liStudent.RemoveAt(i);
                        i--;
                    }
                }
            }
            var data = JsonConvert.SerializeObject(liStudent);
            busStudent.CloseConnection();
            bus.CloseConnection();
            return Json(new
            {
                data,//Danh sách
                count
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// danh sách tất cả các sinh viên đã được thêm vào lớp học
        /// </summary>
        /// <param name="coursecode">Mã lớp môn học</param>
        /// <returns></returns>
        public JsonResult GetStudentByCourse(string coursecode)
        {
            //khai báo lấy dữ liệu
            STUDENT_BUS bus = new STUDENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            List<jointable> lijoin = new List<jointable>();
            lijoin.Add(new jointable(typeof(MARK_OBJ), "CODE", "STUDENTCODE", new fieldpara("COURSECODE", coursecode, (int)searchType.NONE)));
            List<STUDENT_OBJ> liStudent = bus.getAllBy2("CODEVIEW", lipa, lijoin);
            bus.CloseConnection();
            //kiểm tra danh sách trả về có null hay không
            var ret = liStudent != null ? 1 : -1;
            return Json(new
            {
                ret,
                lst = liStudent
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// lấy mark theo mã sinh viên và mã khóa học
        /// </summary>
        /// <param name="coursecode"></param>
        /// <returns></returns>
        public JsonResult GetByStudentCourse(string coursecode)
        {
            string studentcode = _ses.loginCode;
            MARK_BUS bus = new MARK_BUS();
            var data = bus.GetByKey(new fieldpara("STUDENTCODE", studentcode, 0),
                                    new fieldpara("COURSECODE", coursecode, 0),
                                    new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            bus.CloseConnection();
            return Json(new { data }, JsonRequestBehavior.AllowGet);
        }

        ///// <summary>
        ///// chấm điểm cho 1 sinh viên
        ///// </summary>
        ///// <param name="examhallstudent"></param>
        ///// <returns></returns>
        public JsonResult GetMark(string examhallstudentcode)
        {
            // kiểm tra xem còn bản ghi examhallstudentcode này trên server ko
            EXAMHALLSTUDENT_BUS examhallstudentBus = new EXAMHALLSTUDENT_BUS();
            var examhallstudent =
                examhallstudentBus.GetByID(new EXAMHALLSTUDENT_OBJ.BusinessObjectID(examhallstudentcode));
            var ret = (examhallstudent == null) ? -1 : 0;
            if (ret >= 0)
            {
                // lấy kết quả thi của sinh viên này
                EXAMRESULT_BUS examresultBus = new EXAMRESULT_BUS();
                var examresult = examresultBus.getAllBy2("EXAMFORMDETAILCODE",
                    new fieldpara("EXAMHALLSTUDENTCODE", examhallstudentcode, 0));
                if (examresult != null && examresult.Count > 0)
                {
                    // lấy danh sách câu hỏi và câu trả lời của sinh viên, trừ các dạng câu hỏi: điền vào đoạn trống tự điền từ, viết lại câu, viết đoạn văn, nghe nói, viết
                    DataSet ds = new DataSet();
                    ret = examresultBus.getExamresult(ref ds, "examresult", examresult[0].EXAMHALLSTUDENTCODE);
                    List<EXAMRESULT_OBJ> liResult1 = new List<EXAMRESULT_OBJ>(); // danh sách câu hỏi kiểu trắc nghiệm
                    List<EXAMRESULT_OBJ> liResultFg = new List<EXAMRESULT_OBJ>();                // lấy danh sách câu hỏi dạng điền vào đoạn trống tự gõ từ
                    List<EXAMRESULT_OBJ> liResultRw = new List<EXAMRESULT_OBJ>();                // lấy danh sách câu hỏi dạng viết lại câu
                    if (ret >= 0)
                    {
                        foreach (DataRow r in ds.Tables["examresult"].Rows)
                        {
                            var objtemp = new EXAMRESULT_OBJ
                            {
                                EXAMFORMDETAILCODE = com.string4Row(r, "examformdetailcode", ""),
                                QUESTIONCODE = com.string4Row(r, "questioncode", ""),
                                ANSWERCODE = com.string4Row(r, "answercode", ""),
                                ANSWERTEXT = com.string4Row(r, "answertext", ""),
                                QUESTIONGROUPCODE = com.string4Row(r, "questiongroupcode", "")
                            };
                            string questiontype = com.string4Row(r, "questiontype", "");
                            // nếu thuộc 6 dạng này thì add vào result1
                            if (questiontype.Equals("MC") || questiontype.Equals("FI") || questiontype.Equals("CO") ||
                                questiontype.Equals("LA") || questiontype.Equals("PA") || questiontype.Equals("MS"))
                            {
                                liResult1.Add(objtemp);
                            }
                            // nếu là dạng điền vào đoạn trống thì add vào resulf FG
                            if (questiontype.Equals("FG"))
                            {
                                liResultFg.Add(objtemp);
                            }
                            // nếu là dạng điền vào đoạn trống thì add vào resulfRW
                            if (questiontype.Equals("RW"))
                            {
                                liResultRw.Add(objtemp);
                            }
                        }
                    }

                    // lấy danh sách câu hỏi và câu trả lời trong đề thi của sinh viên
                    var examformcode = examresult[0].EXAMFORMCODE;
                    ds = new DataSet();
                    ret = examresultBus.getExamform(ref ds, "examform", examformcode);
                    List<dynamic> liQuestion = new List<dynamic>();
                    if (ret >= 0)
                    {
                        foreach (DataRow r in ds.Tables["examform"].Rows)
                        {
                            dynamic question = new ExpandoObject();
                            question.QUESTIONCODE = com.string4Row(r, "code", ""); // mã câu hỏi
                            question.TRUEANSWER = com.string4Row(r, "trueanswer", ""); // đáp án đúng
                                                                                       //    question.MARK = com.string4Row(r, "mark", ""); // số điểm cho câu hỏi này
                            question.MARK = float.Parse(com.string4Row(r, "mark", ""), CultureInfo.InvariantCulture.NumberFormat);
                            question.CONTENT = com.string4Row(r, "content", ""); // nội dung câu hỏi, sử dụng trong trường hợp điền vào đoạn trống tự gõ từ, viết lại câu
                            liQuestion.Add(question);
                        }
                    }
                    // so sánh dạng trắc nghiệm, nếu đúng thì update lại điểm
                    List<EXAMRESULT_OBJ> dataUpdate = new List<EXAMRESULT_OBJ>();
                    List<fieldpara> lipa = new List<fieldpara>();
                    foreach (var item in liResult1)
                    {
                        foreach (var item2 in liQuestion)
                        {
                            if (item.QUESTIONCODE == item2.QUESTIONCODE && item.ANSWERCODE == item2.TRUEANSWER)
                            {
                                item.EXAMHALLSTUDENTCODE = examhallstudentcode;
                                item.EXAMFORMCODE = examformcode;
                                lipa.Clear();
                                lipa.Add(new fieldpara("EXAMHALLSTUDENTCODE", examhallstudentcode, 0));
                                lipa.Add(new fieldpara("EXAMFORMDETAILCODE", item.EXAMFORMDETAILCODE, 0));
                                lipa.Add(new fieldpara("QUESTIONCODE", item.QUESTIONCODE, 0));
                                lipa.Add(new fieldpara("QUESTIONGROUPCODE", item.QUESTIONGROUPCODE, 0));
                                var obj = examresultBus.GetByKey(lipa.ToArray());
                                if (obj != null)
                                {
                                    obj.MARK = 1;
                                    if (item2.MARK > 0)
                                        obj.MARK = item2.MARK;
                                    dataUpdate.Add(obj);
                                }
                                else ret = -1;
                            }
                        }
                    }
                    // so sánh dạng điền vào chỗ trống tự gõ từ
                    foreach (var item in liResultFg)
                    {
                        foreach (var item2 in liQuestion)
                        {
                            if (item.QUESTIONCODE == item2.QUESTIONCODE)
                            {
                                // so sánh câu trả lời của sinh viên có khớp với đáp án hay không
                                string answer = item.ANSWERTEXT; // Câu trả lời của sinh viên
                                string trueanswer = item2.CONTENT; // Nội dung câu trả lời
                                answer = answer.Trim();
                                // loại bỏ các kí tự html
                                trueanswer = StripHtml(trueanswer).Trim();
                                if (String.Compare(answer, trueanswer, StringComparison.OrdinalIgnoreCase) == 0)
                                {
                                    item.EXAMHALLSTUDENTCODE = examhallstudentcode;
                                    item.EXAMFORMCODE = examformcode;
                                    lipa.Clear();
                                    lipa.Add(new fieldpara("EXAMHALLSTUDENTCODE", examhallstudentcode, 0));
                                    lipa.Add(new fieldpara("EXAMFORMDETAILCODE", item.EXAMFORMDETAILCODE, 0));
                                    lipa.Add(new fieldpara("QUESTIONCODE", item.QUESTIONCODE, 0));
                                    lipa.Add(new fieldpara("QUESTIONGROUPCODE", item.QUESTIONGROUPCODE, 0));
                                    var obj = examresultBus.GetByKey(lipa.ToArray());
                                    if (obj != null)
                                    {
                                        obj.MARK = 1;
                                        if (item2.MARK > 0)
                                            obj.MARK = item2.MARK;
                                        dataUpdate.Add(obj);
                                    }
                                    else ret = -1;
                                }
                            }
                        }
                    }
                    // so sánh dạng viết lại câu
                    foreach (var item in liResultRw)
                    {
                        foreach (var item2 in liQuestion)
                        {
                            if (item.QUESTIONCODE == item2.QUESTIONCODE)
                            {
                                // so sánh câu trả lời của sinh viên có khớp với đáp án hay không
                                string answer = item.ANSWERTEXT; // Câu trả lời của sinh viên
                                string trueanswer = item2.CONTENT; // Nội dung câu trả lời
                                answer = answer.Trim();
                                // loại bỏ các kí tự html
                                trueanswer = StripHtml(trueanswer).Trim();
                                // regex về dạng chuẩn
                                answer = RegexAnswer(answer);
                                if (String.Compare(answer, trueanswer, StringComparison.OrdinalIgnoreCase) == 0)
                                {
                                    item.EXAMHALLSTUDENTCODE = examhallstudentcode;
                                    item.EXAMFORMCODE = examformcode;
                                    lipa.Clear();
                                    lipa.Add(new fieldpara("EXAMHALLSTUDENTCODE", examhallstudentcode, 0));
                                    lipa.Add(new fieldpara("EXAMFORMDETAILCODE", item.EXAMFORMDETAILCODE, 0));
                                    lipa.Add(new fieldpara("QUESTIONCODE", item.QUESTIONCODE, 0));
                                    lipa.Add(new fieldpara("QUESTIONGROUPCODE", item.QUESTIONGROUPCODE, 0));
                                    var obj = examresultBus.GetByKey(lipa.ToArray());
                                    if (obj != null)
                                    {
                                        obj.MARK = 1;
                                        if (item2.MARK > 0)
                                            obj.MARK = item2.MARK;
                                        dataUpdate.Add(obj);
                                    }
                                    else ret = -1;
                                }
                            }
                        }
                    }
                    if (dataUpdate.Count > 0)
                    {
                        //mặc định khi vào danh sách này là xóa thành công nên ret= 1;
                        //duyệt toàn bộ danh sách bản ghi để xóa
                        examresultBus.BeginTransaction();
                        ret = examresultBus.UpdateMultiItems(dataUpdate);
                        if (ret < 0)
                        {
                            //Trong trường hợp nhiều thao tác, có một thao tác không thành công,
                            //hàm này được gọi để quay lại trạng thái trước khi thực hiện (bắt đầu từ khi gọi BeginTransaction()
                            examresultBus.RollbackTransaction();
                        }
                        else
                        {
                            //Sau khi thao tác dữ liệu thành công, hàm này được gọi để thực hiện ghi vào cơ sở dữ liệu
                            examresultBus.CommitTransaction();
                        }
                    }
                    return Json(new
                    {
                        ret
                    }, JsonRequestBehavior.AllowGet);
                }
            }
            examhallstudentBus.CloseConnection();
            return Json(new { }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// loại bỏ các kí tự html
        /// </summary>
        /// <param name="input">chuỗi cần replace</param>
        /// <returns></returns>
        public static string StripHtml(string input)
        {
            return Regex.Replace(input, "<.*?>", String.Empty);
        }

        public string RegexAnswer(string s)
        {
            char[] arrChar = { '?', '.','!', ',' };
    //     s = "What    your     Name    ?? ?  My name is    Hoa    , I'm 20 years old   .......   Oh my     god!!!!!!";
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options); // loại bỏ dấu cách
            foreach (var c in arrChar)
            {
                regex = new Regex("["+ c+"]{1,}[ ]{0,}["+c+"]{1,}", options);
                s = regex.Replace(s, c.ToString());
                // ví dụ: how???   ??? -> how?
            }
            // loại bỏ dấu cách liền trước dấu ?,.!, thêm dấu cách vào đằng sau
            // [ ]{1,}[?] vd: how    ?abc -> how? abc
            foreach (var c in arrChar)
            {
                regex = new Regex("[ ]{1,}[" + c + "]{1,}", options);
                s = regex.Replace(s, c.ToString() + " ");
            }
            // cắt dấu cách 2 đầu
            s = s.Trim();
            return s;
        }
    }
}