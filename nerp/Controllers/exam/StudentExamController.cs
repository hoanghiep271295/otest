﻿using IS.Config;
using IS.fitframework;
using IS.Lang;
using IS.Sess;
using IS.uni;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Dynamic;
using System.Web.Mvc;

namespace nerp.Controllers.exam
{
    public class StudentExamController : Controller
    {
        //Sinh viên thực hiện làm bài thi
        private readonly session _ses = new session();

        /// <summary>
        /// Hiển thị bài thi, bài thi , khi sinh viên vào thi sẽ gồm có mã sinh viên theo 
        /// </summary>
        /// <param name="id"></param>
        /// <param name="subid"></param>
        /// <returns></returns>
        public ActionResult Index(string id, string subid)
        {
            //Id is markcode, subid is examtimecode
            if (string.IsNullOrEmpty(id))
            {
                id = "1712220001";
            }
            if (string.IsNullOrEmpty(subid))
            {
                subid = "1712250004";
            }
            dynamic defaultobject = new ExpandoObject();
            defaultobject.markcode = id;
            defaultobject.examtimecode = subid;
            defaultobject.thetype = _ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            //string defaultvalue = "{\"markcode\":\"" + id + "\", \"examtimecode\":\"" + subid + "\"}";
            //ViewBag.defaultvalue = defaultvalue;
            string[] jsx =
            {
                "/Jsx/exam/studentexam/DragBack.jsx",
                "/Jsx/exam/studentexam/Drag.jsx",
                "/Jsx/exam/studentexam/LAQuestion.jsx",
                "/Jsx/exam/studentexam/RAQuestion.jsx",
                "/Jsx/exam/studentexam/MCQuestion.jsx",
                "/Jsx/exam/studentexam/Writing.jsx",
                "/Jsx/exam/studentexam/RWQuestion.jsx",
                "/Jsx/exam/studentexam/FGQuestion.jsx",
                "/Jsx/exam/studentexam/FFQuestion.jsx",
                "/Jsx/exam/studentexam/FIQuestion.jsx",
                "/Jsx/exam/studentexam/MSQuestion.jsx",
                "/Jsx/exam/studentexam/PAQuestion.jsx",
                "/Jsx/exam/studentexam/COQuestion.jsx",
                "/Jsx/exam/studentexam/App.jsx"
            };
            ViewBag.jsx = jsx;
            //Gán các thông tin về hiển thị cho view và cho client javascript thông qua ham getLangObject()
            string clientjson;
            dynamic objlang = Langresource.LangResource(AppConfig.langfilename, _ses.frontlang, "home-index3",
                out clientjson);
            ViewBag.langobj = objlang;
            ViewBag.langobjscript = clientjson;
            //trang quản trị là adminindex
            //trang sinh viên là studentindex
            return View("StudentIndex");
        }
        /// <summary>
        /// Index 2 for sortable
        /// </summary>
        /// <returns></returns>
        public ActionResult Index2()
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.markcode = "";
            defaultobject.examtimecode ="";
            defaultobject.thetype = _ses.loginType;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx =
          {
                "/Jsx/exam/Sortable.jsx"
            };
            ViewBag.jsx = jsx;
            return View("StudentIndex");
        }

        /// <summary>
        /// Kiểm tra xem sinh viên đã đăng nhập hay chưa, từ đây quyết định sinh viên có được làm bài thi hay không
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public JsonResult IsLogin(string username, string password)
        {
            int ret;
            STUDENT_BUS bus = new STUDENT_BUS();
            STUDENT_OBJ obj = bus.GetByKey(new fieldpara("CODEVIEW", username, 0),
                new fieldpara("USERPASSWORD", password, 0));
            if (obj != null)
            {
                ret = 1;
            }
            else
            {
                ret = -1;
            }
            bus.CloseConnection();
            return Json(new
            {
                objStudent = obj,
                ret //ok
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Lây ra lấy ra mã sinh viên được chỉ định trong bảng điểm của một lớp môn học
        /// </summary>
        /// <param name="studentcode">mã sinh viên</param>
        /// <param name="coursecode">mã lớp môn học</param>
        /// <returns></returns>
        public JsonResult GetMarkCode(string studentcode, string coursecode)
        {
            MARK_BUS markbus = new MARK_BUS();
            MARK_OBJ obj = markbus.GetByKey(new fieldpara("STUDENTCODE", studentcode, 0),
                new fieldpara("COURSECODE", coursecode, 0));
            markbus.CloseConnection();
            var jsonResult = Json(new
            {
                obj, //Danh sách
                ret = 0 //ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        /// <summary>
        /// Lấy ra chi tiết của một bài thi dựa vào mã sinh viên trong bảng điểm lớp môn học và mã học kì
        /// </summary>
        /// <param name="markcode">mã sinh viên trong lớp môn học</param>
        /// <param name="examtimecode">mã học kì </param>
        /// <returns></returns>
        public JsonResult GetDetailExam(string markcode, string examtimecode)
        {
            if (string.IsNullOrEmpty(markcode))
            {
                markcode = "1708310001";
            }
            int ret = 0;
            int numberQuestion = 0;


            MARK_BUS markbus = new MARK_BUS();
            MARK_OBJ objmark = markbus.GetByID(new MARK_OBJ.BusinessObjectID(markcode));//markbus.GetByKey(new fieldpar("STUDENTCODE", _ses.loginCode, 0),new fieldpara("COURSECODE", courseCode, 0));
            markbus.CloseConnection();
            if (objmark == null)
            {
                ret = -7;
            }
            EXAMHALLSTUDENT_OBJ obj = new EXAMHALLSTUDENT_OBJ();
            if (ret >= 0)
            {
                EXAMHALLSTUDENT_BUS bus = new EXAMHALLSTUDENT_BUS();
                if (objmark != null)
                    obj = bus.GetByKey(new fieldpara("MARKCODE", objmark.CODE, 0),
                        new fieldpara("examtimecode", examtimecode));
                bus.CloseConnection();
            }
            //Lấy được một lần thi
            if (obj == null)
            {
                ret = -1;
            }
            EXAMFORM_BUS busExamform = new EXAMFORM_BUS();
            EXAMFORM_OBJ objExamform = null;
            //Lấy đề thi
            if (ret >= 0)
            {
                if (obj != null)
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
            List<QUESTION_OBJ> listQuestionreturn = new List<QUESTION_OBJ>();
            if (ret >= 0)
            {
                lijoin.Clear();
                if (objExamform != null)
                    lijoin.Add(new jointable(typeof(EXAMFORMDETAIL_OBJ), "QUESTIONGROUPCODE", "QUESTIONGROUPCODE",
                                                                        new fieldpara("examformcode", objExamform.CODE)));
                var liQuestion = busQuestion.getAllBy2("CODE", lipa, lijoin);
                if (liQuestion == null)
                {
                    ret = -5;
                }
                else
                {
                    foreach (var objQuestion in liQuestion)
                    {
                        QUESTION_OBJ objTemp = new QUESTION_OBJ();
                        objTemp.CODE = objQuestion.CODE;
                        objTemp.ANSWERCODE = null;
                        objTemp.CONTENT = objQuestion.CONTENT;
                        objTemp.QUESTIONGROUPCODE = objQuestion.QUESTIONGROUPCODE;
                        objTemp._QUESTIONGROUPCODE = objQuestion._QUESTIONGROUPCODE;
                        objTemp._ID = objQuestion._ID;
                        listQuestionreturn.Add(objTemp);
                    }
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
                    lijoin.Add((new jointable(typeof(EXAMFORMDETAIL_OBJ), "QUESTIONGROUPCODE", "QUESTIONGROUPCODE",
                        new fieldpara("examformcode", objExamform.CODE))));
                liAnswer = busAnswer.getAllBy2("CODE", lipa, lijoin);
                if (liAnswer == null)
                {
                    ret = -6;
                }
                busAnswer.CloseConnection();
            }
            //get list exam result in case student lost the internet
            EXAMRESULT_BUS busExamresult = new EXAMRESULT_BUS();
            List<EXAMRESULT_OBJ> liExamresult = new List<EXAMRESULT_OBJ>();
            if (ret >= 0)
            {
                if (obj != null)
                    liExamresult = busExamresult.getAllBy2(new fieldpara("examhallstudentcode", obj.CODE));
                busExamresult.CloseConnection();
            }
            var jsonResult = Json(new
            {
                numberQuestion,//so luong cau hoi
                ObjexamHallstudent = obj,//examhallstudent code
                ObjexamForm = objExamform,//examform
                liExamformDetail = liExamformdetail,//Danh sách examdetail
                liQuestiongroup,//danh sach nhom cau hoi
                li_question = listQuestionreturn,//danh sach cac cau hoi
                li_answer = liAnswer,//danh sach tat ca cac cau tra loi
                liExamresult,//danh sach tat ca cac dap an da tra loi cu sinh vien
                ret//ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        /// <summary>
        /// lấy chi tiết 1 đề thi
        /// </summary>
        /// <param name="examformcode">mã đề thi</param>
        /// <returns></returns>
        public JsonResult Preview(string examformcode)
        {
            int ret = 0;
            int numberQuestion = 0;
            EXAMFORM_BUS busExamform = new EXAMFORM_BUS();
            EXAMFORM_OBJ objExamform = busExamform.GetByID((new EXAMFORM_OBJ.BusinessObjectID(examformcode)));
            busExamform.CloseConnection();
            if (objExamform == null)
            {
                ret = -2;
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
            List<QUESTION_OBJ> listQuestionreturn = new List<QUESTION_OBJ>();
            if (ret >= 0)
            {
                lijoin.Clear();
                if (objExamform != null)
                    lijoin.Add(new jointable(typeof(EXAMFORMDETAIL_OBJ), "QUESTIONGROUPCODE", "QUESTIONGROUPCODE",
                                                                        new fieldpara("examformcode", objExamform.CODE)));
                var liQuestion = busQuestion.getAllBy2("CODE", lipa, lijoin);
                if (liQuestion == null)
                {
                    ret = -5;
                }
                else
                {
                    foreach (var objQuestion in liQuestion)
                    {
                        QUESTION_OBJ objTemp = new QUESTION_OBJ();
                        objTemp.CODE = objQuestion.CODE;
                        objTemp.ANSWERCODE = null;
                        objTemp.CONTENT = objQuestion.CONTENT;
                        objTemp.QUESTIONGROUPCODE = objQuestion.QUESTIONGROUPCODE;
                        objTemp._QUESTIONGROUPCODE = objQuestion._QUESTIONGROUPCODE;
                        objTemp._ID = objQuestion._ID;
                        listQuestionreturn.Add(objTemp);
                    }
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
                    lijoin.Add((new jointable(typeof(EXAMFORMDETAIL_OBJ), "QUESTIONGROUPCODE", "QUESTIONGROUPCODE",
                        new fieldpara("examformcode", objExamform.CODE))));
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
                ObjexamForm = objExamform,//examform
                liExamformDetail = liExamformdetail,//Danh sách examdetail
                liQuestiongroup,//danh sach nhom cau hoi
                li_question = listQuestionreturn,//danh sach cac cau hoi
                li_answer = liAnswer,//danh sach tat ca cac cau tra loi
                ret//ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
        public JsonResult ListQuestionGroupExam(string examformcode)
        {
            EXAMFORMDETAIL_BUS bus = new EXAMFORMDETAIL_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("EXAMFORMCODE", examformcode, 0)
            };
            // tất cả các bản ghi
            List<EXAMFORMDETAIL_OBJ> totalData = bus.getAllBy2("CODEVIEW", lipa.ToArray());
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)
            //Trả về client
            var data = JsonConvert.SerializeObject(totalData);
            var jsonResult = Json(new
            {
                data,//Danh sách
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult ListQuestionExam(string groupcode)
        {
            QUESTION_BUS bus = new QUESTION_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("QUESTIONGROUPCODE", groupcode, 0)
            };
            //order by theorder, with pagesize and the page
            List<QUESTION_OBJ> data = bus.getAllBy("CODEVIEW", lipa.ToArray());
            // tất cả các bản ghi
            List<QUESTION_OBJ> totalData = bus.getAllBy2("CODEVIEW", lipa.ToArray());

            int totalItem = totalData.Count;
            bus.CloseConnection();
            //Chỉ số đầu tiên của trang hiện tại (đã trừ -1)

            //Trả về client
            var a = JsonConvert.SerializeObject(data);
            string firstquestion = "";
            if (data.Count != 0)
            {
                firstquestion = JsonConvert.SerializeObject(data[0]);
            }
            var jsonResult = Json(new
            {
                firstquestion,
                data,//Danh sách
                data2 = a,
                totalItem,//số lượng bản ghi
                ret = 0//ok
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }

        public JsonResult GetAnswerQuestionFf(string questioncode)
        {
            List<fieldpara> li =new List<fieldpara>();
            
            List<ANSWER_OBJ> listAnswerObjs = new List<ANSWER_OBJ>();
           ANSWER_BUS bus =new ANSWER_BUS();
            listAnswerObjs = bus.getAllBy2("CODE", new fieldpara("QUESTIONCODE", questioncode,0));
            var jsonResult = Json(new
            {
                listAnswerObjs
            }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;
            return jsonResult;
        }
    }
}