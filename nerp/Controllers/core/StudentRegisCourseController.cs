﻿using IS.fitframework;
using IS.Sess;
using IS.uni;
using System;
using System.Collections.Generic;
using System.Web.Mvc;

namespace nerp.Controllers.core
{
    public class StudentRegisCourseController : Controller
    {
        private readonly session _ses = new session();

        // GET: StudentRegisterCourse
        /// <summary>
        /// lấy danh sách các khóa học và vẽ nên làm cây dropdowntree
        /// </summary>
        /// <returns></returns>
        public JsonResult LoadListGrade()
        {
            //Kiểm tra phân quyền
            //  List<GRADE_OBJ> reslist = new List<GRADE_OBJ>();
            //if (_ses.isLogin() < 0)
            //{
            //    return Json(new { reslist, ret = -1 }, JsonRequestBehavior.AllowGet);
            //}
            //Lây dữ iệu
            GRADE_BUS bus = new GRADE_BUS();
            //lấy tất cả không cần phân trang; sáp xếp tăng dần theo thứ tự hiển thị
            List<GRADE_OBJ> lst = bus.getAllBy2(" NAME ", new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0)); //get all
            bus.CloseConnection();
            foreach (GRADE_OBJ obj in lst)
            {
                obj.EDUCATIONLEVELCODE = "";
            }
            CLASS_BUS busClass = new CLASS_BUS();
            var liClass = busClass.getAllBy2("CODE", new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            busClass.CloseConnection();

            CLASS_OBJ classDefault = new CLASS_OBJ();
            if (liClass.Count > 0)
            {
                classDefault = liClass[0];
            }

            //thực hiện load đồng bộ danh sách lớp
            //điều cần thiết là cần 2 cấp nên nếu là lớp thứ nhất thì mặc định biến nó về làm lớp cha
            //bằng cách gán nó vào lớp con của nó thì đương nhiên nó làm cha
            //cách này không hay nhưng hết cách rồi
            foreach (CLASS_OBJ objClass in liClass)
            {
                GRADE_OBJ objGrade = new GRADE_OBJ
                {
                    CODE = objClass.CODE,
                    CODEVIEW = objClass.CODEVIEW,
                    NAME = objClass.NAME,
                    EDUCATIONLEVELCODE = objClass.GRADECODE
                };

                lst.Add(objGrade);
            }
            //send default to load list

            var ret = lst.Count >= 0 ? 1 : -1;
            //Trả về cho client
            return Json(new { lst, ret, classDefault }, JsonRequestBehavior.AllowGet);
        }
        /// <summary>
        /// lấy danh sách sinh viên theo lớp môn học bao gồm lấy danh sách sinh viên đã đăng kí vào lớp môn học đó rồi danh sách sinh viên chưa đăng kí vào lớp môn học
        /// ở đây sẽ hiển thị lên danh sách sinh viên của 1 lớp học (1 class) mà chưa đăng kí được vào
        /// trong lớp môn học(1 course)
        /// đầu tiên cần lấy danh sách sinh viên thuộc 1 lớp(class)
        /// lấy danh sách sinh viên thuộc lớp môn học(course)
        /// cuối cùng là danh sách sinh viên không thuộc lớp môn học(course)
        /// </summary>
        /// <param name="classCode"> mã lớp học</param>
        /// <param name="gradeCode"> mã khóa học</param>
        /// <param name="courseCode">mã lớp môn học</param>
        /// <returns>danh sách sinh viên chưa đăng kí vào lớp môn học</returns>
        public JsonResult LoadListStudentNotRegisted(string classCode, string gradeCode, string courseCode)
        {
            STUDENT_BUS busStudent = new STUDENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>
            {
                new fieldpara("CLASSCODE", classCode, 0),
                new fieldpara("GRADECODE", gradeCode, 0),
                //kiểm tra xem có thuộc lớp course này hay không
                new fieldpara("MARK.COURSECODE", null)
        };
            List<jointable> lijoin = new List<jointable>();
            lijoin.Clear();
            //danh sách sinh viên thuộc lớp và chưa thuộc lớp môn học
            //
            // jointable typof(đối tượng lấy làm gốc)
            // lijoin.Add(new jointable(typeof(	"Kiểu đối tượng sẽ kết nối đến (sử dụng typeof(tên đối tượng) ) để nhập vào"),
            // "Tên trường trên bảng chính (đối tượng gọi hiện tại)",
            //"Tên trường trên bảng tham chiếu (đối tượng được gọi) sẽ tham gia vào đối tượng join, chỉ tham gia so sánh bằng",
            //điều kiện lọc;
            lijoin.Add(new jointable(typeof(MARK_OBJ), "CODE", "STUDENTCODE", JOIN.LEFT, new fieldpara("COURSECODE", courseCode, (int)searchType.NONE)));
            List<STUDENT_OBJ> liStudent = busStudent.getAllBy2("CODE", lipa, lijoin);
            var ret = liStudent.Count >= 0 ? 1 : -1;

            return Json(
            new
            {
                ret,
                lst = liStudent
            }, JsonRequestBehavior.AllowGet
            );
        }
        /// <summary>
        /// Lây toàn bộ danh sách sinh viên đã đăng kí vào lớp môn học
        /// </summary>
        /// <param name="coursecode">mã lớp môn học</param>
        /// <param name="code">mã code để tìm kiếm</param>
        /// <param name="codetype">loại tìm kiếm là chứa hay ==</param>
        /// <param name="name">tên</param>
        /// <param name="nametype"> kiểu tìm kiếm</param>
        /// <param name="note">ghi chú</param>
        /// <param name="notetype">kiểu tìm kiếm</param>
        /// <returns>danh sách sinh viên đã đăng kí vào lớp môn học</returns>
        public JsonResult LoadListStudentOnCourse(string coursecode, string code, bool codetype, string name, bool nametype, string note, bool notetype)
        {
            //khai báo lấy dữ liệu
            STUDENT_BUS bus = new STUDENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            //mặc định cho phần trang
            if (!string.IsNullOrEmpty(coursecode))
            {
                lipa.Add(new fieldpara("COURSECODE", coursecode, 0));
            }
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
            List<jointable> lijoin = new List<jointable>();
            lijoin.Clear();
            lijoin.Add(new jointable(typeof(MARK_OBJ), "CODE", "STUDENTCODE", new fieldpara("COURSECODE", coursecode, (int)searchType.NONE)));
            List<STUDENT_OBJ> liStudent = bus.getAllBy2("CODEVIEW", lipa, lijoin);
            //kiểm tra danh sách trả về có null hay không
            var ret = liStudent.Count >= 0 ? 1 : -1;
            return Json(new
            {
                ret,
                lst = liStudent
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// xóa sinh viên của lớp môn học
        /// cho phep xoa hay khong
        /// ret= -2 ;//sử dụng trong trường hợp xóa đơn một bản ghi có tham chiếu
        /// ret= 0 : không có gì để xóa
        /// ans = 1: //xóa thành công
        /// ret= -3 : Bản ghi hiện tại không còn trong hệ thống, truy cập trái phép
        /// </summary>
        /// <param name="listStudentCode">danh sách mã sinh viên</param>
        /// <param name="coursecode">mã lớp môn học</param>
        /// <returns></returns>
        public JsonResult DeleteStudentCourse(List<string> listStudentCode, string coursecode)
        {
            int ret = 0;
            EXAMHALLSTUDENT_BUS busExam = new EXAMHALLSTUDENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            MARK_BUS busMark = new MARK_BUS();
            List<MARK_OBJ.BusinessObjectID> deleteListId = new List<MARK_OBJ.BusinessObjectID>();
            //kiểm tra tất cả các item đưa vào xem có con hay không
            foreach (var item in listStudentCode)
            {
                var mark = busMark.GetByID(new MARK_OBJ.BusinessObjectID(item));
                //check xem subject có còn tồn tại trong hệ thống hay không
                if (mark == null)
                {
                    ret = -3;
                    return Json(new
                    {
                        ret
                    }, JsonRequestBehavior.AllowGet);
                }
                // ** chú ý: nếu muốn xóa nhiều bản ghi thì cần phải clear lipa trước khi sử dụng nó lại
                lipa.Clear();
                lipa.Add(new fieldpara("MARKCODE", item, 0));
                lipa.Add(new fieldpara("COURSECODE", coursecode,0));
                lipa.Add(new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
                //checkcode sẽ trả về là 0 nếu không có con
                // nhiều hơn 0 tức là tồn tại bản ghi con 
                // nhỏ hơn 0 tức là lỗi hệ thống
                var exams = busExam.checkCode(null, lipa.ToArray());
                //nếu không có con thì cho vào danh sách xóa
                //tức là checkcode sẽ trả về là số lượng bản ghi con phụ thuộc
                //bad request
                if (exams < 0)
                {   //nếu mà gặp lỗi thì thoát luôn không cần xóa gì nữa
                    ret = -3;
                    return Json(new
                    {
                        ret
                    }, JsonRequestBehavior.AllowGet);
                }
                if (exams == 0)
                {
                    //add to delete list
                    deleteListId.Add(mark._ID);
                }
            }
            //nếu phần tử nằm trong danh sách xóa có thì sẽ phải xóa
            //xóa 1 bản ghi và trong trường hợp muốn xóa đơn lẻ mà bản ghi đưa vào không tồn tại con
            ////có 1 bản ghi và bản ghi đó không được phép xóa
            if (listStudentCode.Count == 1 && deleteListId.Count < 1)
            {
                //không cho xóa 1 bản ghi
                ret = -2;
            }

            //còn đây là trường hợp xóa nhiều, cứ thông báo là xóa thành công là xong
            //mặc dù còn có các bản ghi không được xóa còn có tham chiếu nhưng không nên thông báo quá chi tiết
            if (deleteListId.Count >= 1)
            {
                //mặc định khi vào danh sách này là xóa thành công nên ret= 1;
                //duyệt toàn bộ danh sách bản ghi để xóa
                busMark.BeginTransaction();
                ret = busMark.DeletetMultiItems(deleteListId);
                if (ret < 0)
                {
                    //Trong trường hợp nhiều thao tác, có một thao tác không thành công,
                    //hàm này được gọi để quay lại trạng thái trước khi thực hiện (bắt đầu từ khi gọi BeginTransaction()
                    busMark.RollbackTransaction();
                }
                else
                {
                    //Sau khi thao tác dữ liệu thành công, hàm này được gọi để thực hiện ghi vào cơ sở dữ liệu
                    busMark.CommitTransaction();
                }
            }
            //close all connection

            busExam.CloseConnection();
            busMark.CloseConnection();
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }

        /// <summary>
        /// Tính số lượng sinh viên của lớp môn học
        /// </summary>
        /// <param name="coursecode">mã lớp môn học</param>
        /// <returns></returns>
        public int UpdateStudentAmount(string coursecode)
        {
            var ret = 0;
            COURSE_BUS bus = new COURSE_BUS();
            var course = bus.GetByID(new COURSE_OBJ.BusinessObjectID(coursecode));
            if (course == null)
            {
                ret = -1;
                bus.CloseConnection();
                return ret;
            }
            // tính số sinh viên của lớp học
            MARK_BUS markBus = new MARK_BUS();
            var liMark = markBus.getAllBy2("CODE", new fieldpara("COURSECODE", coursecode, 0),
                                                   new fieldpara("UNIVERSITYCODE", _ses.gUNIVERSITYCODE, 0));
            if (liMark != null)
            {
                course.STUDENTAMOUNT = liMark.Count;
                ret = bus.Update(course);
            }
            markBus.CloseConnection();
            bus.CloseConnection();
            return ret;
        }

        /// <summary>
        /// update danh sách sinh viên lớp môn học
        /// </summary>
        /// <param name="listStudentCode">danh sách mã sinh viên</param>
        /// <param name="coursecode">mã lớp môn học</param>
        /// <param name="subjectcode">Môn học</param>
        /// <returns></returns>
        public JsonResult UpdateStudentCourse(List<string> listStudentCode, string coursecode, string subjectcode)
        {
            int ret = 0;
            MARK_BUS busMark = new MARK_BUS();
            List<MARK_OBJ> liMark = new List<MARK_OBJ>();
            MARK_OBJ midMarkObj = new MARK_OBJ();
            //gennextcode to define first code to gennextcode for other  n list
            string markCode = busMark.genNextCode(midMarkObj);
            if (listStudentCode == null)
                ret = -1;
            else
            {
                foreach (var studentCode in listStudentCode)
                {
                    MARK_OBJ objMark = new MARK_OBJ {CODE = markCode};
                    markCode = busMark.GenNextCode(objMark, markCode);  //gán giá trị code đầu tiên cho giá trị mặc định sinh được tiến hành gán lại giá trị mặc định mặc gennextcode của đối tượng hiện tại
                    objMark.LOCKDATE = DateTime.Now;
                    objMark.CODEVIEW = objMark.CODEVIEW;
                    objMark.COURSECODE = coursecode;
                    objMark.STUDENTCODE = studentCode;
                    objMark.SUBJECTCODE = subjectcode;
                    objMark.LOCK = 0;
                    objMark.EDITTIME = DateTime.Now; // thời điểm sửa bản ghi
                    objMark.EDITUSER = _ses.loginCode;
                    objMark.UNIVERSITYCODE = _ses.gUNIVERSITYCODE;
                    liMark.Add(objMark);
                }
            }
            //Tạo phiên làm việc, thực hiện trong trường hợp có nhiều thao tác với cơ sở dữ liệu,
            //yêu cầu khi thực hiện nhiều hơn một lệnh có thay đổi dữ liệu phải gọi phương thức này.
            busMark.BeginTransaction();
            if (ret >= 0)
            {
                ret = busMark.InsertMultiItems(liMark);
                if (ret < 0)
                {
                    //Trong trường hợp nhiều thao tác, có một thao tác không thành công,
                    //hàm này được gọi để quay lại trạng thái trước khi thực hiện (bắt đầu từ khi gọi BeginTransaction()
                    busMark.RollbackTransaction();
                }
                else
                {
                    //Sau khi thao tác dữ liệu thành công, hàm này được gọi để thực hiện ghi vào cơ sở dữ liệu
                    busMark.CommitTransaction();
                }
            }
            busMark.CloseConnection();
            return Json(new
            {
                ret
            }, JsonRequestBehavior.AllowGet);
        }
    }
}