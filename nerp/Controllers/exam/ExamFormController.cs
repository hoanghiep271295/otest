﻿using IS.Config;
using IS.fitframework;
using IS.Sess;
using IS.uni;
using nerp.Controllers.core;
using Newtonsoft.Json;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.CompilerServices;
using System.Web.Mvc;
using nerp.Controllers.question;

namespace nerp.Controllers.exam
{
    public class ExamFormController : Controller
    {
        // GET: ExamForm
        private readonly session _ses = new session();

        public JsonResult GetList(string examTimeCode)
        {
            var ret = 0;
            //Khai báo lấy dữ liệu
            EXAMFORM_BUS bus = new EXAMFORM_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("EXAMTIMECODE", examTimeCode, 0)
            };
            lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            //order by theorder, with pagesize and the page
            var li = bus.getAllBy2("NAME", lipa.ToArray());
            if (li == null)
                ret = -1;
            bus.CloseConnection();
            return Json(new
            {
                lst = li,//Danh sách
                ret = ret//ok
            }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// xem trước đề thi
        /// </summary>
        /// <param name="id">mã đề</param>
        /// <returns></returns>
        public ActionResult Preview(string id)
        {
            dynamic defaultobject = new ExpandoObject();
            defaultobject.code = id;
            ViewBag.defaultvalue = JsonConvert.SerializeObject(defaultobject);
            string[] jsx = {
                 "/Jsx/Core/ManageExamtime/PreviewExamForm/DragBack.jsx",
                "/Jsx/Core/ManageExamtime/PreviewExamForm/Drag.jsx",
                "/Jsx/Core/ManageExamtime/PreviewExamForm/FIQuestion.jsx",
                "/Jsx/Core/ManageExamtime/PreviewExamForm/PAQuestion.jsx",
                "/Jsx/Core/ManageExamtime/PreviewExamForm/App.jsx"
                };
            ViewBag.jsx = jsx;
            return View("Adminindex");//Lấy index mặc định trong share

        }
        public JsonResult Delete(List<string> listCode)
        {
            var ret = 0;
            if (listCode == null)
                ret = -1;
            else
            {
                var bus = new EXAMFORM_BUS();
                foreach (string t in listCode)
                {
                    if (t != null)
                    {
                        var item = bus.GetByID(new EXAMFORM_OBJ.BusinessObjectID(t));
                        if (item == null) { ret = -2; continue; }
                        if (ret >= 0)
                        {
                            ret = bus.delete(item._ID);
                        }
                    }
                }
                bus.CloseConnection();
            }
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        public JsonResult Update(EXAMFORM_OBJ obj)
        {
            EXAMFORM_BUS bus = new EXAMFORM_BUS();
            int ret;
            int add = 0;
            EXAMFORM_OBJ objTemp;
            //kiểm tra tồn tại cho trường hợp sửa
            if (!string.IsNullOrEmpty(obj.CODE))//edit
            {
                objTemp = bus.GetByID(new EXAMFORM_OBJ.BusinessObjectID(obj.CODE));
                if (objTemp == null)
                {
                    ret = -4;
                    bus.CloseConnection();
                    //ban ghi sửa đã bị xóa
                    return Json(new { sussess = ret }, JsonRequestBehavior.AllowGet);
                }
            }
            else
            {
                objTemp = new EXAMFORM_OBJ();
            }

            //hết kiểm tra tồn tại bản ghi
            objTemp.EDITTIME = DateTime.Now;//Thời điểm sủa bản ghi
            objTemp.EDITUSER = _ses.loginCode;//Người sửa bản ghi
            objTemp.CODEVIEW = obj.CODEVIEW;
            objTemp.NAME = obj.NAME;
            objTemp.SUBJECTCODE = obj.SUBJECTCODE;
            objTemp.EXAMTIMECODE = obj.EXAMTIMECODE;
            objTemp.NOTE = obj.NOTE;
            objTemp.TESTSTRUCTCODE = obj.TESTSTRUCTCODE;
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
                objTemp._ID.CODE = objTemp.CODE;
                ret = bus.checkPage(objTemp._ID, "CODE", AppConfig.item4page(), out pagecount, out currentpage);
            }
            bus.CloseConnection();
            //some thing like that
            return Json(new { ret, pagecount, currentpage }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Xóa toàn bộ examform và examformdetail theo examtimecode
        /// </summary>
        /// <param name="examTimeCode"></param>
        /// <returns></returns>
        public int DeleteAll(string examTimeCode)
        {
            var ret = 0;
            //get list examform
            EXAMFORM_BUS examformBus = new EXAMFORM_BUS();
            List<EXAMFORM_OBJ> liExamform = examformBus.getAllBy2("CODE", new fieldpara("EXAMTIMECODE", examTimeCode, 0));
            EXAMFORMDETAIL_BUS examDetailBus = new EXAMFORMDETAIL_BUS();
            foreach (var examform in liExamform)
            {
                var liExamFormDetail = examDetailBus.getAllBy2("CODE", new fieldpara("EXAMFORMCODE", examform.CODE, 0));
                foreach (var item in liExamFormDetail)
                {
                    ret = examDetailBus.delete(item._ID);
                    if (ret < 0)
                        return ret;
                }
                examformBus.delete(examform._ID);
                if (ret < 0)
                    return ret;
            }
            return ret;
        }

        /// <summary>
        /// tạo đề thi cho một đợt thi với cấu trúc đề thi cho trươcs. 
        /// create by cucpt
        /// </summary>
        /// <param name="examTimeCode"></param>
        /// <param name="testStructCode"></param>
        public ArrayList CreateExamForm(string examTimeCode, string testStructCode)
        {
            ArrayList result = new ArrayList();
            string code = "";
            // xóa toàn bộ đề thi cũ
            var ret = DeleteAll(examTimeCode);
            if (ret >= 0)
            {
                // get examtime
                EXAMTIME_BUS examTimeBus = new EXAMTIME_BUS();
                EXAMTIME_OBJ examtime = examTimeBus.GetByID(new EXAMTIME_OBJ.BusinessObjectID(examTimeCode));
                int testcount = examtime.TESTCOUNT; // số đề thi
                EXAMFORM_BUS bus = new EXAMFORM_BUS();
                for (int i = 0; i < testcount; i++)
                {
                    // tạo 1 đề thi mới. với mỗi đề thi, sinh ra cấu trúc đề thi tương ứng
                    EXAMFORM_OBJ obj = new EXAMFORM_OBJ
                    {
                        EXAMTIMECODE = examTimeCode,
                        SUBJECTCODE = examtime.SUBJECTCODE,
                        TESTSTRUCTCODE = testStructCode,
                        EDITTIME = DateTime.Now,
                        EDITUSER = _ses.loginCode,
                        LOCK = 0,
                        NAME = "Đề " + (i + 1) + " " + examtime.NAME
                    };
                    obj.CODE = bus.genNextCode(obj);
                    obj.CODEVIEW = obj.CODE;
                    code = obj.CODE;
                    obj.LOCKDATE = DateTime.Now;
                    ret = bus.insert(obj);
                    if (ret >= 0) // nếu tạo đề thành công thì đi tạo chi tiết đề
                        ret = CreateExamFormDetail(obj.CODE, testStructCode);
                    if (ret < 0)
                        break; // nếu tạo đề không thành công thì thoát luôn, báo lỗi cho người dùng
                }
            }
            // sau khi tạo đề thành công thì đi chia đề cho sinh viên
            if (ret >= 0)
                // chia đề thi
                ret = DevideExam(examTimeCode);
            result.Add(ret);
            result.Add(code);
            return result;
        }

        /// <summary>
        /// chia đề thi cho sinh viên
        /// </summary>
        /// <param name="examtimeCode"></param>
        public int DevideExam(string examtimeCode)
        {
            int ret = 0;
            if (!string.IsNullOrEmpty(examtimeCode))
            {
                //list examform by examtime
                EXAMFORM_BUS examformBus = new EXAMFORM_BUS();
                var liExamform = examformBus.getAllBy2("CODE", new fieldpara("EXAMTIMECODE", examtimeCode, 0));
                int examformAmount = liExamform.Count; // số đề thi
                                                       // list hall
                EXAMHALL_BUS examhallBus = new EXAMHALL_BUS();
                var liExamHall = examhallBus.getAllBy2("CODE", new fieldpara("EXAMTIMECODE", examtimeCode, 0));
                foreach (var examhall in liExamHall)
                {
                    // danh sách sinh viên của một phòng thi
                    EXAMHALLSTUDENT_BUS examhallstudentBus = new EXAMHALLSTUDENT_BUS();
                    var liExamStd = examhallstudentBus.getAllBy2("CODE", new fieldpara("EXAMHALLCODE", examhall.CODE, 0));

                    for (int j = 0; j < liExamform.Count; j++)
                    {
                        for (int i = 0; i < liExamStd.Count; i++)
                        {
                            if (i % examformAmount == j)
                            {
                                liExamStd[i].EXAMFORMCODE = liExamform[j].CODE;
                                ret = examhallstudentBus.Update(liExamStd[i]);
                                if (ret < 0)
                                    return ret;
                            }
                        }
                    }
                }
            }
            //  return ret;
            return ret;
        }
        /// <summary>
        /// tạo đề thi cho một đợt thi
        /// </summary>
        /// <param name="examTimeCode"></param>
        /// <param name="testStructCode"></param>
        /// <returns></returns>
        public JsonResult CreateExamFormJson(string examTimeCode, string testStructCode)
        {
            ArrayList result = CreateExamForm(examTimeCode, testStructCode);
            return Json(new { ret = result[0], CODE = result[1] }, JsonRequestBehavior.AllowGet);
            // lấy code trong trường hợp chọn bài cho học là các bài thi, kiểm tra.
            //Trả về code để insert vào bảng subjectcontenttest
        }

        /// <summary>
        /// sinh chi tiết đề thi
        /// </summary>
        /// <param name="examformCode">mã đề thi</param>
        /// <param name="testStructCode">mã cấu trúc đề thi</param>
        /// <returns></returns>
        public int CreateExamFormDetail(string examformCode, string testStructCode)
        {
            int ret = 0;
            Random rnd = new Random();
            // get list TestStructDetail by testStructCode
            var liTestStructDetail = new TestStructDetailController().getDetailByTestStruct(testStructCode);
            if (liTestStructDetail != null)
            {
                foreach (var testStructDetail in liTestStructDetail)
                {
                    int amountQues = testStructDetail.AMOUNT; // số câu hỏi
                                                              // double toTalMark = testStructDetail.TOTALMARK; // tổng số điểm
                    if (amountQues > 0) // nếu có câu hỏi trong cấu trúc đề thi
                    {
                        string subjectContentCode = testStructDetail.SUBJECTCONTENTCODE; // thuộc bài học nào
                        string questionTypeCode = testStructDetail.QUESTIONTYPECODE;
                        int countQues = 0; //tổng số câu hỏi đã lấy được
                                           // lấy ra các câu hỏi thuộc nội dung bài học và có loại câu hỏi theo cấu trúc đề quy định
                        List<QUESTIONGROUP_OBJ> liQuesGroup = new QuestionController().GetQGroupBySbjContent(subjectContentCode, questionTypeCode);
                        if (liQuesGroup != null && liQuesGroup.Count >= amountQues)
                        {
                            List<string> selectedQuesGroupCode = new List<string>(); // danh sách nhóm câu hỏi đã được chọn
                                                                                     //Random ra câu hỏi,
                                                                                     //random được câu nào thì remove câu đó khỏi danh sách ban đầu (ko bị random lại)
                            while (liQuesGroup.Count > 0 && countQues < amountQues)
                            {
                                int r = rnd.Next(0, liQuesGroup.Count);
                                QUESTIONGROUP_OBJ questionGroup = liQuesGroup[r];
                                selectedQuesGroupCode.Add(questionGroup.CODE);
                                liQuesGroup.RemoveAt(r);
                                countQues++;
                            }
                            // insert examformdetail
                            // chuẩn bị dữ liệu để insert
                            EXAMFORMDETAIL_BUS bus = new EXAMFORMDETAIL_BUS();
                            List<EXAMFORMDETAIL_OBJ> liExamformdetail = new List<EXAMFORMDETAIL_OBJ>();
                            EXAMFORMDETAIL_OBJ obj = new EXAMFORMDETAIL_OBJ();
                            string currentCode = bus.genNextCode(obj);
                            for (int i = 0; i < selectedQuesGroupCode.Count; i++)
                            {
                                obj = new EXAMFORMDETAIL_OBJ();
                                obj.EXAMFORMCODE = examformCode;
                                obj.QUESTIONGROUPCODE = selectedQuesGroupCode[i];
                                obj.TESTSTRUCTDETAILCODE = testStructDetail.CODE;
                                obj.THEORDER = i + 1;
                                obj.CODE = currentCode;
                                //Tính toán mã mới
                                currentCode = bus.genNextCode(obj, currentCode);
                                //Thêm vào danh sách chuẩn bị vào
                                liExamformdetail.Add(obj);
                            }
                            // insert
                            ret = bus.InsertMultiItems(liExamformdetail);
                        }
                        else
                        {
                            ret = -2; // list câu hỏi không đủ để sinh đề
                            break;
                        }

                    }
                    else ret = -3; // không có totalmark trong cấu trúc đề
                }
            }

            return ret;
        }

        public JsonResult CheckCodeViewExit(string code, string codeView)
        {
            int ret;
            EXAMFORM_BUS bus = new EXAMFORM_BUS();
            List<EXAMFORM_OBJ> li = bus.getAllBy2(new fieldpara("CODEVIEW", codeView, 0), new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
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

        int ProcessExamForm(string examformcode)
        {
            int ret = 0;
            return ret;
        }

        public int ProcessExamFormAuto(string examtimecode, string coursecode, int testcount)
        {
            int ret = 0;
            //Lấy được đợt thi
            EXAMTIME_BUS bus = new EXAMTIME_BUS();
            EXAMTIME_OBJ obj = bus.GetByID(new EXAMTIME_OBJ.BusinessObjectID(examtimecode));
            EXAMFORM_BUS busExamfom = new EXAMFORM_BUS();
            List<EXAMFORM_OBJ> liExamform = new List<EXAMFORM_OBJ>();
            bus.CloseConnection();
            if (obj == null)
            {
                ret = -1;
            }
            //Lấy được lớp học
            MARK_BUS busMark = new MARK_BUS();
            List<MARK_OBJ> liMark = busMark.getAllBy2(new fieldpara("COURSECODE", coursecode));
            busMark.CloseConnection();

            if (ret >= 0)
            {
                liExamform = CreateExamForm(obj, testcount, out ret);
            }
            EXAMFORMDETAIL_BUS busExamformdetail = new EXAMFORMDETAIL_BUS();
            EXAMFORMDETAIL_OBJ objExamformdetail = new EXAMFORMDETAIL_OBJ();
            List<EXAMFORMDETAIL_OBJ> liExamformdetail = new List<EXAMFORMDETAIL_OBJ>();
            //Danh sách cấu trúc đề
            TESTSTRUCTDETAIL_BUS busTeststructdetail = new TESTSTRUCTDETAIL_BUS();
            List<TESTSTRUCTDETAIL_OBJ> liTestStructDetail = busTeststructdetail.getByTestStruct(obj.TESTSTRUCTCODE, _ses.gUNIVERSITYCODE);
            busTeststructdetail.CloseConnection();

            string currentCode = busExamformdetail.genNextCode(objExamformdetail);
            if (ret >= 0)
            {
                foreach (EXAMFORM_OBJ objtem in liExamform)
                {
                    ret = CreateExamFormDetail(ref liExamformdetail, objtem, liTestStructDetail, ref currentCode);
                    if (ret < 0)
                    {
                        break;
                    }

                }
            }
            //Gán sinh viên vào danh sách đề
            List<EXAMHALLSTUDENT_OBJ> liExamhallstudent = new List<EXAMHALLSTUDENT_OBJ>();
            EXAMHALLSTUDENT_BUS busExamhallstudent = new EXAMHALLSTUDENT_BUS();
            EXAMHALLSTUDENT_OBJ objExamhallstudent = new EXAMHALLSTUDENT_OBJ();
            currentCode = busExamhallstudent.genNextCode(objExamhallstudent);
            int i = 0;
            //Thêm tất cả sinh viên
            foreach (MARK_OBJ objMar in liMark)
            {
                //Gán sinh viên vào examhall student
                objExamhallstudent = new EXAMHALLSTUDENT_OBJ();
                objExamhallstudent.CODE = currentCode;
                currentCode = busExamhallstudent.genNextCode(objExamhallstudent, currentCode);
                objExamhallstudent.COURSECODE = coursecode;
                objExamhallstudent.EDITTIME = DateTime.Now;
                objExamhallstudent.EDITUSER = _ses.loginCode;
                objExamhallstudent.EXAMFORMCODE = liExamform[i % testcount].CODE;
                objExamhallstudent.EXAMTIMECODE = examtimecode;
                i++;
                objExamhallstudent.EXAMHALLCODE = "";
                objExamhallstudent.MARKCODE = objMar.CODE;
                objExamhallstudent.UNIVERSITYCODE = _ses.gUNIVERSITYCODE;
                liExamhallstudent.Add(objExamhallstudent);

            }
            if (ret >= 0)
            {
                busExamfom.BeginTransaction();
                busExamformdetail.setConnection(busExamfom);
                busExamhallstudent.setConnection(busExamfom);
                ret = busExamfom.InsertMultiItems(liExamform);
                if (ret >= 0)
                {
                    ret = busExamformdetail.InsertMultiItems(liExamformdetail);
                }
                if (ret >= 0)
                {
                    ret = busExamhallstudent.InsertMultiItems(liExamhallstudent);
                }
                if (ret >= 0)
                {
                    busExamfom.CommitTransaction();
                }
                else
                {
                    busExamfom.RollbackTransaction();
                }
            }
            busExamfom.CloseConnection();
            return ret;
        }
        /// <summary>
        /// Tạo đề thi với đợt thi, với cấu trúc đề thi, số lượng đề thi theo quy định; Trả về danh sách đề thi
        /// Mr. Uyen viết
        /// </summary>
        /// <param name="examTimeCode"></param>
        /// <param name="testStructCode"></param>
        public List<EXAMFORM_OBJ> CreateExamForm(EXAMTIME_OBJ objExamtime, int testcount, out int ret)
        {
            List<EXAMFORM_OBJ> liExamform = new List<EXAMFORM_OBJ>();
            ret = 0;
            // get examtime
            EXAMFORM_BUS bus = new EXAMFORM_BUS();
            EXAMFORM_OBJ obj = new EXAMFORM_OBJ();
            string currentCode = bus.genNextCode(obj);//Mã đầu tiên
            for (int i = 0; i < testcount; i++)
            {
                // create examform
                obj = new EXAMFORM_OBJ
                {
                    EXAMTIMECODE = objExamtime.CODE,
                    SUBJECTCODE = objExamtime.SUBJECTCODE,
                    TESTSTRUCTCODE = objExamtime.TESTSTRUCTCODE,
                    EDITTIME = DateTime.Now,
                    EDITUSER = _ses.loginCode,
                    LOCK = 0,
                    NAME = objExamtime.NAME + "(" + (i + 1).ToString() + ")"
                };
                obj.CODE = currentCode;
                currentCode = bus.genNextCode(obj, currentCode);
                obj.CODEVIEW = (i + 1).ToString();
                obj.LOCKDATE = DateTime.Now;
                liExamform.Add(obj);
            }
            //            ret = bus.InsertMultiItems(liExamform);
            bus.CloseConnection();
            return liExamform;
        }
        /// <summary>
        /// sinh chi tiết đề thi
        /// </summary>
        /// <param name="examformCode">mã đề thi</param>
        /// <param name="testStructCode"></param>
        /// <returns></returns>
        public int CreateExamFormDetail(ref List<EXAMFORMDETAIL_OBJ> liExamformdetail, EXAMFORM_OBJ objExamform, List<TESTSTRUCTDETAIL_OBJ> liTestStructDetail, ref string currentCode)
        {
            int ret = 0;
            Random rnd = new Random();

            EXAMFORMDETAIL_BUS bus = new EXAMFORMDETAIL_BUS();
            EXAMFORMDETAIL_OBJ obj = new EXAMFORMDETAIL_OBJ();
            //            List<EXAMFORMDETAIL_OBJ> liExamformdetail = new List<EXAMFORMDETAIL_OBJ>();
            //Chuẩn bị các mã
            //string currentCode = bus.genNextCode(obj);

            foreach (var testStructDetail in liTestStructDetail)
            {
                int amountQues = testStructDetail.AMOUNT; // số câu hỏi
                                                          // double toTalMark = testStructDetail.TOTALMARK; // tổng số điểm
                if (amountQues > 0) // nếu có câu hỏi trong cấu trúc đề thi
                {
                    string subjectContentCode = testStructDetail.SUBJECTCONTENTCODE;
                    string questionTypeCode = testStructDetail.QUESTIONTYPECODE;
                    int countQues = 0; //tổng số câu hỏi đã lấy được
                                       //   double countMark = 0; // tổng số điểm lấy được
                                       // get ListQuestionGroup by subjectContentCode and questiontypecode
                    List<QUESTIONGROUP_OBJ> liQuesGroup = new QuestionController().GetQGroupBySbjContent(subjectContentCode, questionTypeCode);
                    List<string> selectedQuesGroupCode = new List<string>(); // danh sách nhóm câu hỏi đã được chọn
                    //Random ra câu hỏi,
                    //random được câu nào thì remove câu đó khỏi danh sách ban đầu (ko bị random lại)
                    while (liQuesGroup.Count > 0 && countQues < amountQues)
                    {
                        int r = rnd.Next(0, liQuesGroup.Count);
                        QUESTIONGROUP_OBJ questionGroup = liQuesGroup[r];
                        selectedQuesGroupCode.Add(questionGroup.CODE);
                        liQuesGroup.RemoveAt(r);
                        countQues++;
                    }
                    // insert examformdetail

                    //ret = InsertExamFormDetail(objExamform.CODE, selectedQuesGroupCode, testStructDetail.CODE);
                    //Tính toán các bước để xác định các được sinh ra

                    for (int i = 0; i < selectedQuesGroupCode.Count; i++)
                    {
                        obj = new EXAMFORMDETAIL_OBJ();
                        obj.EXAMFORMCODE = objExamform.CODE;
                        obj.QUESTIONGROUPCODE = selectedQuesGroupCode[i];
                        obj.TESTSTRUCTDETAILCODE = testStructDetail.CODE;
                        obj.THEORDER = i + 1;
                        obj.CODE = currentCode;
                        //Tính toán mã mới
                        currentCode = bus.genNextCode(obj, currentCode);
                        //Thêm vào danh sách chuẩn bị vào
                        liExamformdetail.Add(obj);
                    }
                }
            }
            //Insert here
            //ret = bus.InsertMultiItems(liExamformdetail);
            //bus.CloseConnection();
            return ret;
        }

        public JsonResult GetByExamtime(string examtimecode)
        {
            var ret = 0;
            EXAMFORM_BUS bus = new EXAMFORM_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("EXAMTIMECODE", examtimecode, 0));
            lipa.Add(new fieldpara("LOCK", "0", 0));
            var data = bus.getAllBy2("CODE", lipa.ToArray());
            if (data == null)
                ret = -1;
            bus.CloseConnection();
            return Json(new { ret, lst = data }, JsonRequestBehavior.AllowGet);
        }
    }
}