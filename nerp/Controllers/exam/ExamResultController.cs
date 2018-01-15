﻿using IS.fitframework;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Mvc;

namespace nerp.Controllers.exam
{
    public class ExamResultController : Controller
    {
        // GET: ExamResult
        private readonly session _ses = new session();
        /// <summary>
        /// </summary>
        /// <param name="subid">examtimecode</param>
        /// <returns></returns>
        public ActionResult Index(string subid)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.defaulttab = subid;
            defaultobject.thetype = _ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            //subid is examtimecode
            string[] jsx = {
                "/Jsx/exam/examResult/PAAnswer.jsx",
                "/Jsx/exam/examResult/LAAnswer.jsx",
                "/Jsx/exam/examResult/RAAnswer.jsx",
                "/Jsx/exam/examResult/FGAnswer.jsx",
                "/Jsx/exam/examResult/FIAnswer.jsx",
                "/Jsx/exam/examResult/FFAnswer.jsx",
                "/Jsx/exam/examResult/RAAnswer.jsx",
                "/Jsx/exam/examResult/COAnswer.jsx",
                "/Jsx/exam/examResult/MCAnswer.jsx",
                "/Jsx/exam/examResult/RWAnswer.jsx",
                "/Jsx/exam/examResult/MSAnswer.jsx",
                "/Jsx/exam/examResult/WRAnswer.jsx",
                "/Jsx/exam/examResult/ExamResult.jsx"
            };
            ViewBag.jsx = jsx;
            //Mặc định luôn lấy view của Index 3 để hiển thị cho phần quản trị
            return View("StudentIndex");
        }
        public string RegexString(string str)
        {
            RegexOptions options = RegexOptions.None;
            Regex regex = new Regex("[ ]{2,}", options);
            //loai bo space dau va cuoi 1 chuoi
            str = str.Trim();
            //loai bo tat ca mulitple space trong chuoi
            str = regex.Replace(str, " ");

            //loai bo tat ca cac dau cach truoc dau phay
            str = Regex.Replace(str, " *,", ",");

            //thay the sau dau phay la dau cach(space)
            str = Regex.Replace(str, @"(?<=,)(?!\s)", " ");

            //muon loai bo di tat ca cac khoang trang
            str = Regex.Replace(str, @"(\s+\.)", ".");

            //thay the sau dau cham la dau cach(space)
            str = Regex.Replace(str, @"(?<=\.)(?!\s)", " ");
            return str;
        }
        /// <summary>
        /// Upload các file nghe tại đây
        /// </summary>
        /// <returns></returns>

        public JsonResult UploadBlob()
        {
            var ret = 0;
            const int megabyte = 1024 * 1024;
            HttpFileCollectionBase files = Request.Files;
            HttpPostedFileBase file = files[0];
            if (file != null)
            {
                var extension = Path.GetExtension(file.FileName.ToLowerInvariant());
                string[] extensions = { ".gif", ".jpg", ".png", ".svg", ".webp", ".mp3", ".mp4", ".wav", ".ogg" };
                if (!extensions.Contains(extension))
                {
                    ret = -1;
                    //    throw new InvalidOperationException("Invalid file extension.");
                }
                if (file.ContentLength > 30 * megabyte)
                {
                    ret = -2;
                    //  throw new InvalidOperationException("File size limit exceeded.");
                }
                // var fileName = Guid.NewGuid() + extension;
                var fileName = DateTime.Now.ToString("ddMMyyyy_HHmmss") + extension;
                var targetFolder = Server.MapPath("~/Content/recordExam/");
                var path = Path.Combine(targetFolder, fileName);

                file.SaveAs(path);
                var location = Path.Combine("/Content/recordExam", fileName).Replace('\\', '/');
                if (_ses.tSOURCEPATHSESSION == null)
                    _ses.tSOURCEPATHSESSION = new List<string>();
                _ses.tSOURCEPATHSESSION.Add(file.FileName);//(files.AllKeys[0]);
                if (_ses.tDESTINATIONPATHSESSION == null)
                    _ses.tDESTINATIONPATHSESSION = new List<string>();
                _ses.tDESTINATIONPATHSESSION.Add(location);
                return Json(new { location, ret }, JsonRequestBehavior.AllowGet);
            }
            return Json(new { ret }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Kiểm tra chuyển từ dạng code sang codeview để kiểm tra loại phù hợp
        /// </summary>
        /// <param name="li"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        private string getCodeview(List<QUESTIONTYPE_OBJ> li, string code)
        {
            code = code.ToUpper();
            string v = code;
            foreach (QUESTIONTYPE_OBJ obj in li)
            {
                if (obj.CODE.ToUpper() == code)
                {
                    v = obj.CODEVIEW.ToUpper().Trim();
                }
            }
            return v;
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="listobj">danh sach cac cau tra loi </param>
        /// <param name="examform">de thi</param>
        /// <param name="listexamformdetail">ma phan thi</param>
        /// <param name="examhallstudentcode"></param>
        /// <returns></returns>
        [HttpPost]
        public JsonResult UpdateExamResult(List<QuestionAnswer> listobj, EXAMFORM_OBJ examform, List<EXAMFORMDETAIL_OBJ> listexamformdetail, string examhallstudentcode)
        {
            //bài thi của sinh viên sẽ đưa lên gồm có : mã câu hỏi,mã câu trả lời, nội dung câu trả lời
            // examformcode: mã đề thi , examformdetailcode: mã phần thi
            // answerfile: link file muốn lưu trên server cho bài thi nói
            ////list answer, QuestionAnswer {MaCauHoi,MaXTL}
            var ret = 0;
            int add = 0;
            QUESTIONTYPE_BUS busQuestiontype = new QUESTIONTYPE_BUS();
            List<QUESTIONTYPE_OBJ> liQuestiontype = busQuestiontype.getAllBy2();
            busQuestiontype.CloseConnection();
            //  list question answer
            //   List<QuestionAnswer> listStudentAnswer = JsonConvert.DeserializeObject<List<QuestionAnswer>>(listobj);
            List<QuestionAnswer> listStudentAnswer = listobj;
            if (listStudentAnswer.Count <= 0)
            {
                ret = -1;
            }
            //list EXAMFORMDETAIL_OBJ
            //  List<EXAMFORMDETAIL_OBJ> listEXamDetail = JsonConvert.DeserializeObject<List<EXAMFORMDETAIL_OBJ>>(listexamformdetail);
            List<EXAMFORMDETAIL_OBJ> listEXamDetail = listexamformdetail;
            if (listEXamDetail.Count <= 0)
            {
                ret = -2;
            }
            // list examform
            //  string exCode = examformcode;
            //   EXAMFORM_OBJ objExForm = JsonConvert.DeserializeObject<EXAMFORM_OBJ>(exCode);
            EXAMFORM_OBJ objExForm = examform;
            //examhallstudentcode
            string exHallcode = examhallstudentcode;
            //object examresult
            EXAMRESULT_BUS bus = new EXAMRESULT_BUS();
            QUESTION_BUS busQuestion = new QUESTION_BUS();
            // QUESTIONGROUP_BUS busQGroup = new QUESTIONGROUP_BUS();
            //   duyet trong list examformdetail
            foreach (var item in listEXamDetail)
            {
                //lay danh sach question theo tung questiongroup trong examformdetail
                List<QUESTION_OBJ> liQuestion = busQuestion.getAllBy2("CODE", new fieldpara("QUESTIONGROUPCODE", item.QUESTIONGROUPCODE));
                //duyet trong list question
                foreach (var question in liQuestion)
                {
                    //duyet trong danh sach cau tra loi cua sinh vien de dua ra la cau hoi nay la cap nhat hay them moi
                    foreach (var answer in listStudentAnswer)
                    {
                        //kiem tra su ton tai cua cau hoi
                        if (answer.MaCauHoi == question.CODE)
                        {
                            //question group to determinecasse   writing
                            var objTemp = bus.GetByID(new EXAMRESULT_OBJ.BusinessObjectID(exHallcode, item.CODE, question.CODE));
                            //chua co thi tuc la them moi
                            if (objTemp == null)
                            {
                                add = 1;
                                objTemp = new EXAMRESULT_OBJ();
                            }
                            objTemp.EXAMHALLSTUDENTCODE = exHallcode;
                            objTemp.EXAMFORMDETAILCODE = item.CODE;
                            objTemp.EXAMFORMCODE = objExForm.CODE;
                            objTemp.QUESTIONCODE = question.CODE;
                            objTemp.QUESTIONGROUPCODE = item.QUESTIONGROUPCODE;
                            switch (getCodeview(liQuestiontype, item.TESTSTRUCTDETAILCODE)) // thực chất là  item._QUESTIONGROUPCODE.QUESTIONTYPECODE nhưng do ko gửi được _QUESTIONGROUPCODE lên, do đó gán tạm TESTSTRUCTDETAILCODE = (item._QUESTIONGROUPCODE.QUESTIONTYPECODE)
                            {
                                //multichoice
                                //1
                                case "MC"://"1707130001":
                                    objTemp.ANSWERCODE = answer.MaCauTL;
                                    objTemp.ANSWERTEXT = "";
                                    break;
                                //single choice  case
                                //2
                                case "MS":
                                    objTemp.ANSWERCODE = answer.MaCauTL;
                                    objTemp.ANSWERTEXT = "";
                                    break;
                                //case CO, true,false,not given
                                //3
                                case "CO":
                                    objTemp.ANSWERCODE = answer.MaCauTL;
                                    objTemp.ANSWERTEXT = "";
                                    break;
                                //write
                                //4
                                case "WR":// "1707130007":
                                    objTemp.ANSWERCODE = "";
                                    objTemp.ANSWERTEXT = answer.MaCauTL;
                                    break;
                                //rewrite
                                //5
                                case "RW":// "1707130004":
                                    objTemp.ANSWERCODE = "";
                                    objTemp.ANSWERTEXT = answer.MaCauTL;
                                    break;
                                //NGHE NOI
                                //6
                                case "LA":// "1708300007": //LA
                                    objTemp.ANSWERFILE = GetName(answer.MaCauTL);
                                    break;
                                //trường hợp điền từ vào ô trống
                                //7
                                case "FG":
                                    objTemp.ANSWERCODE = "";
                                    objTemp.ANSWERTEXT = answer.MaCauTL;
                                    break;
                                //TRUONG HOP KEO THA VAO O TRONG
                                //8
                                case "FI":
                                    objTemp.ANSWERCODE = answer.MaCauTL;
                                    objTemp.ANSWERTEXT = "";
                                    break;
                                // Keo tha vao o trong 
                                //9
                                case "FF":
                                    objTemp.ANSWERCODE = answer.MaCauTL;
                                    objTemp.ANSWERTEXT = "";
                                    break;
                                    //cau hoi ghep doi
                                    //10
                                case "PA":
                                    objTemp.ANSWERCODE = answer.MaCauTL;
                                    objTemp.ANSWERTEXT = "";
                                    break;
                                    //dạng câu hỏi sắp xếp lại câu 
                                    //11
                                case "RA":
                                    objTemp.ANSWERTEXT = answer.MaCauTL;
                                    objTemp.ANSWERCODE = "";
                                    break;
                                default:
                                    objTemp.ANSWERCODE = "";
                                    objTemp.ANSWERTEXT = "";
                                    break;
                            }
                            objTemp.LOCK = objExForm.LOCK;
                            objTemp.LOCKDATE = DateTime.Now;
                            objTemp.MARK = 0;
                            if (add > 0)
                            {
                                ret = bus.insert(objTemp);
                            }
                            else
                            {
                                objTemp._ID.QUESTIONCODE = question.CODE;
                                objTemp._ID.EXAMFORMDETAILCODE = item.CODE;
                                objTemp._ID.EXAMHALLSTUDENTCODE = exHallcode;
                                ret = bus.update(objTemp);
                            }
                        }
                    }
                }
            }
            if (ret >= 0)
            {
                _ses.tSOURCEPATHSESSION?.Clear();
                _ses.tDESTINATIONPATHSESSION?.Clear();
            }
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lấy tên file
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public string GetName(string name)
        {
            string st = "";
            int i;
            if (_ses.tSOURCEPATHSESSION == null)
            {
                return st;
            }
            for (i = 0; i < _ses.tSOURCEPATHSESSION.Count; i++)
            {
                if (_ses.tSOURCEPATHSESSION[i].ToUpper() == name.ToUpper())
                {
                    st = _ses.tDESTINATIONPATHSESSION[i];
                }
            }
            return st;
        }

        /// <summary>
        /// lấy kết quả bài thi dựa trên mark code
        /// </summary>
        /// <param name="markcode"></param>
        /// <returns></returns>
        /// show questiongroup
        /// show question
        /// show answer
        /// put data//hide other answer
        public JsonResult ShowData(string markcode)
        {
            var ret = -1;

            int numberQuestion = 0;
            //dựa vào mã sinh viên thuộc lớp môn học nào sẽ xác định mã sinh bài thi của phòng nào đó cho môn học đó
            EXAMHALLSTUDENT_BUS bus = new EXAMHALLSTUDENT_BUS();
            EXAMHALLSTUDENT_OBJ obj = bus.GetByKey(new fieldpara("MARKCODE", markcode, 0));
            bus.CloseConnection();
            //bài kiểm tra
            EXAMFORM_BUS busExamform = new EXAMFORM_BUS();
            EXAMFORM_OBJ objExamform = null;
            if (ret >= 0)
            {
                objExamform = busExamform.GetByID((new EXAMFORM_OBJ.BusinessObjectID(obj.EXAMFORMCODE)));
                busExamform.CloseConnection();
                if (objExamform == null)
                {
                    ret = -2;
                }
            }
            //Danh sachs cau truc
            EXAMFORMDETAIL_BUS busExamformdetail = new EXAMFORMDETAIL_BUS();
            List<EXAMFORMDETAIL_OBJ> liExamformdetail = new List<EXAMFORMDETAIL_OBJ>();
            if (ret >= 0)
            {
                if (objExamform != null)
                    liExamformdetail = busExamformdetail.getAllBy2("THEORDER", new fieldpara("EXAMFORMCODE", objExamform.CODE));
                busExamformdetail.CloseConnection();
                if (liExamformdetail == null)
                {
                    ret = -3;
                }
            }
            List<fieldpara> lipa = new List<fieldpara>();
            List<jointable> lijoin = new List<jointable>();
            //Lay danh sach cac nhom cau hoi
            QUESTIONGROUP_BUS busQuestiongroup = new QUESTIONGROUP_BUS();
            List<QUESTIONGROUP_OBJ> liQuestiongroup = new List<QUESTIONGROUP_OBJ>();

            if (ret >= 0)
            {
                if (objExamform != null)
                    lijoin.Add(new jointable(typeof(EXAMFORMDETAIL_OBJ), "CODE", "QUESTIONGROUPCODE", new fieldpara("EXAMFORMCODE", objExamform.CODE)));
                liQuestiongroup = busQuestiongroup.getAllBy2("CODE", lipa, lijoin);
                if (liQuestiongroup == null)
                {
                    ret = -4;
                }
                busQuestiongroup.CloseConnection();
            }
            //Lay danh sach cau hoi
            QUESTION_BUS busQuestion = new QUESTION_BUS();
            List<QUESTION_OBJ> liQuestion = new List<QUESTION_OBJ>();
            if (ret >= 0)
            {
                lijoin.Clear();
                if (objExamform != null)
                {
                    lijoin.Add(new jointable(typeof(EXAMFORMDETAIL_OBJ), "QUESTIONGROUPCODE", "QUESTIONGROUPCODE",
                               new fieldpara("examformcode", objExamform.CODE)));
                }

                liQuestion = busQuestion.getAllBy2("CODE", lipa, lijoin);

                if (liQuestion == null)
                {
                    ret = -5;
                }
                else
                {
                    numberQuestion = liQuestion.Count;
                }
                busQuestion.CloseConnection();
            }
            //Lay danh danh cac dap an
            ANSWER_BUS busAnswer = new ANSWER_BUS();
            List<ANSWER_OBJ> liAnswer = new List<ANSWER_OBJ>();
            if (ret >= 0)
            {
                lijoin.Clear();
                if (objExamform != null)
                    lijoin.Add((new jointable(typeof(EXAMFORMDETAIL_OBJ), "QUESTIONGROUPCODE", "QUESTIONGROUPCODE", new fieldpara("examformcode", objExamform.CODE))));
                liAnswer = busAnswer.getAllBy2("CODE", lipa, lijoin);
                if (liAnswer == null)
                {
                    ret = -6;
                }
                busAnswer.CloseConnection();
            }

            var jsonResult = Json(new
            {
                numberQuestion,//so luong cau hoi
                ObjexamHallstudent = obj,//examhallstudent code
                ObjexamForm = objExamform,//examform
                liExamformDetail = liExamformdetail,//Danh sách   examdetail
                liQuestiongroup,
                li_question = liQuestion,
                li_answer = liAnswer,
                ret//ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// logic: truyền vào coursecode và examtimecode
        /// từ coursecode và examtimecode -> tìm được examhallstudent tương ứng -> lấy ra được examformcode chính là đề thi mà sinh viên đó làm
        /// lấy ra danh sách các nhóm câu hỏi của đề thi đấy (dữ liệu trong bảng examformdetail)
        /// lấy danh sách các câu hỏi
        /// </summary>
        /// <param name="coursecode">mã lớp môn học</param>
        /// <param name="examtimecode"></param>
        /// <returns></returns>
        public JsonResult ShowExamResult(string coursecode, string examtimecode)
        {
            if (string.IsNullOrEmpty(coursecode))
                coursecode = "1708310001";
            if (string.IsNullOrEmpty(examtimecode))
                examtimecode = "1712250004";
            var ret = 0;
            string studentcode = "";
            List<QUESTION_OBJ> liQuestion = null;
            List<ANSWER_OBJ> liAnswer = null;
            List<EXAMRESULT_OBJ> liExamresult = null;
            EXAMFORM_OBJ objExamform = null;
            List<EXAMFORMDETAIL_OBJ> liExamformdetail = null;
            List<QUESTIONGROUP_OBJ> liQuestiongroup = null;
            int numberQuestion = 0; // số câu hỏi
            EXAMHALLSTUDENT_OBJ examhallstudentObj = new EXAMHALLSTUDENT_OBJ();
            if (_ses.loginType.Equals("STUDENT"))
            {
                studentcode = _ses.loginCode;
            }
            else
            {
                ret = -1;
            }
            if (ret >= 0)
            {
                List<fieldpara> lipa = new List<fieldpara>();
                // get mark
                MARK_BUS markBus = new MARK_BUS();
                lipa.Add(new fieldpara("STUDENTCODE", studentcode, 0));
                lipa.Add(new fieldpara("COURSECODE", coursecode, 0));
                lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                var mark = markBus.GetByKey(lipa.ToArray());
                markBus.CloseConnection();
                if (mark != null)
                {
                    EXAMHALLSTUDENT_BUS bus = new EXAMHALLSTUDENT_BUS();
                    examhallstudentObj = bus.GetByKey(new fieldpara("MARKCODE", mark.CODE, 0),
                        new fieldpara("EXAMTIMECODE", examtimecode));
                    bus.CloseConnection();
                    if (examhallstudentObj != null)
                    {
                        // lấy đề thi
                        EXAMFORM_BUS busExamform = new EXAMFORM_BUS();
                        objExamform = busExamform.GetByID((new EXAMFORM_OBJ.BusinessObjectID(examhallstudentObj.EXAMFORMCODE)));
                        busExamform.CloseConnection();
                        if (objExamform != null)
                        {
                            // lấy danh sách chi tiết đề thi
                            EXAMFORMDETAIL_BUS busExamformdetail = new EXAMFORMDETAIL_BUS();
                            liExamformdetail = busExamformdetail.getAllBy2("THEORDER", new fieldpara("EXAMFORMCODE", objExamform.CODE));
                            busExamformdetail.CloseConnection();
                            if (liExamformdetail != null)
                            {
                                lipa = new List<fieldpara>();
                                List<jointable> lijoin = new List<jointable>();
                                //Lay danh sach cac nhom cau hoi
                                QUESTIONGROUP_BUS busQuestiongroup = new QUESTIONGROUP_BUS();
                                lijoin.Add(new jointable(typeof(EXAMFORMDETAIL_OBJ), "CODE", "QUESTIONGROUPCODE",
                                    new fieldpara("EXAMFORMCODE", objExamform.CODE)));
                                liQuestiongroup = busQuestiongroup.getAllBy2("CODE", lipa, lijoin);
                                busQuestiongroup.CloseConnection();
                                if (liQuestiongroup != null)
                                {
                                    //Lay danh sach cau hoi
                                    QUESTION_BUS busQuestion = new QUESTION_BUS();
                                    lijoin.Clear();
                                    lijoin.Add(new jointable(typeof(EXAMFORMDETAIL_OBJ), "QUESTIONGROUPCODE",
                                        "QUESTIONGROUPCODE", new fieldpara("examformcode", objExamform.CODE)));
                                    liQuestion = busQuestion.getAllBy2("CODE", lipa, lijoin);
                                    numberQuestion = liQuestion.Count;
                                    busQuestion.CloseConnection();
                                    // lấy danh sách các câu trả lời
                                    lijoin.Clear();
                                    ANSWER_BUS busAnswer = new ANSWER_BUS();
                                    lijoin.Add(new jointable(typeof(EXAMFORMDETAIL_OBJ), "QUESTIONGROUPCODE",
                                        "QUESTIONGROUPCODE", new fieldpara("examformcode", objExamform.CODE)));
                                    liAnswer = busAnswer.getAllBy2("CODE", lipa, lijoin);
                                    busAnswer.CloseConnection();
                                    // lấy danh sách kết quả thi của sinh vên đó
                                    EXAMRESULT_BUS busExamresult = new EXAMRESULT_BUS();
                                    liExamresult = busExamresult.getAllBy2(new fieldpara("examhallstudentcode",
                                            examhallstudentObj.CODE));
                                    busExamresult.CloseConnection();
                                    if (liAnswer == null || liExamresult == null)
                                        ret = -7;
                                }
                                else ret = -6;
                            }
                            else ret = -5;
                        }
                        else ret = -4;
                    }
                    else ret = -3;
                }
                else ret = -2;
            }
            else ret = -1;
            var jsonResult = Json(new
            {
                numberQuestion,//so luong cau hoi
                ObjexamHallstudent = examhallstudentObj,//examhallstudent code
                ObjexamForm = objExamform,//examform
                liExamformDetail = liExamformdetail,//Danh sách examdetail
                liQuestiongroup,
                li_question = liQuestion,
                li_answer = liAnswer,
                li_examresult = liExamresult,//danh sách đáp án
                ret
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// lấy danh sách kết quả thi trong 1 course của 1 sinh viên
        /// </summary>
        /// <param name="markcode"></param>
        /// <param name="coursecode">mã lớp môn học</param>
        /// <returns></returns>
        public JsonResult GetResult(string markcode, string coursecode)
        {
            //
            List<Exam> liExam = new List<Exam>();
            // lấy danh sách các lần thi của sinh viên trong 1 lớp học
            EXAMHALLSTUDENT_BUS bus = new EXAMHALLSTUDENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("MARKCODE", markcode, 0),
                new fieldpara("COURSECODE", coursecode, 0),
                new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0)
            };
            var liExamHallStudent = bus.getAllBy2("CODE", lipa.ToArray());
            // lấy điểm cụ thể của từng đợt thi
            if (liExamHallStudent != null)
            {
                EXAMRESULT_BUS examresultBus = new EXAMRESULT_BUS();

                foreach (var item in liExamHallStudent)
                {
                    Exam exam = new Exam
                    {
                        ExamHallStudentCode = item.CODE
                    };
                    // lấy tên đợt thi
                    string examTimeName = item._EXAMTIMECODE.NAME;
                    exam.Name = examTimeName;
                    // danh sách các câu hỏi và điểm trong bài thi
                    List<Question> liQuestion = new List<Question>();
                    var liExamReSult = examresultBus.getAllBy2("QUESTIONCODE",
                        new fieldpara("EXAMHALLSTUDENTCODE", item.CODE, 0));

                    for (int i = 0; i < liExamReSult.Count - 1; i++)
                    {
                        double totalMark = 0;
                        var questiongroupcode = liExamReSult[i].QUESTIONGROUPCODE;
                        string questionName = liExamReSult[i]._QUESTIONGROUPCODE.NAME;
                        if (!string.IsNullOrEmpty(questiongroupcode))
                        {
                            totalMark += liExamReSult[i].MARK;
                            liExamReSult[i].QUESTIONGROUPCODE = "";

                            for (int j = i + 1; j < liExamReSult.Count; j++)
                            {
                                if (liExamReSult[j].QUESTIONGROUPCODE == questiongroupcode)
                                {
                                    totalMark += liExamReSult[j].MARK;
                                    liExamReSult[j].QUESTIONGROUPCODE = "";
                                }
                            }
                        }
                        if (!string.IsNullOrEmpty(questiongroupcode))
                        {
                            Question question = new Question
                            {
                                QuestionGroupCode = questiongroupcode,
                                Mark = totalMark,
                                Name = questionName
                            };
                            liQuestion.Add(question);
                        }
                    }
                    exam.ListQuestion = liQuestion;
                    liExam.Add(exam);
                    examresultBus.CloseConnection();
                }
            }

            bus.CloseConnection();
            return Json(new { data = liExam }, JsonRequestBehavior.AllowGet);
        }
    }

    public class QuestionAnswer
    {
        public string MaCauHoi { get; set; }
        public string MaCauTL { get; set; }
        public string TYPE { get; set; }
     //   public string Answertext { get; set; }
    }

    public class Question
    {
        public string Name { get; set; }
        public string QuestionGroupCode { get; set; }
        public double Mark { get; set; }
    }

    public class Exam
    {
        public string Name { get; set; }
        public string ExamHallStudentCode { get; set; }
        public List<Question> ListQuestion { get; set; }
    }
}