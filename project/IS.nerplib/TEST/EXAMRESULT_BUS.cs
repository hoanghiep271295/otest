﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
namespace IS.uni
{
    public class EXAMRESULT_BUS: BusinessController<EXAMRESULT_OBJ, EXAMRESULT_OBJ.BusinessObjectID>
    {
        public EXAMRESULT_BUS()
        {
        }
        public override EXAMRESULT_OBJ createObject()
        {
            EXAMRESULT_OBJ obj = new EXAMRESULT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EXAMRESULT_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// lấy danh sách các câu hỏi, câu trả lời đúng, điểm theo đề thi
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="examformcode">mã đề thi</param>
        /// <returns></returns>
        public int getExamform(ref DataSet ds, string tablename, string examformcode)
        {
            int ret = 0;
            string sql = @"select A.code , D.content,  D.code trueanswer , A.mark from question A
                            inner join examformdetail B on A.questiongroupcode = B.questiongroupcode
                            inner join questiongroup C on A.questiongroupcode = C.code
                            inner join answer D on D.questioncode = A.code
                            where D.trueanswer = 1 and B.examformcode = @examformcode";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("examformcode", examformcode, 0, (int)searchType.NONE));
            ret = getByQuery(ref ds, tablename, sql, li);
            return ret;
        }
        /// <summary>
        /// lấy danh sách các câu hỏi và câu trả lời của sinh viên trong bài thi
        /// chỉ lấy khi các câu hỏi có kiểu: MC	Lựa chọn dạng 1 nhiều
        //        FI: Điền vào đoạn trống
        //       CO  Dạng câu hỏi tổng kết
        //       LA  Nghe nói
        // PA Dạng ghép đôi
        //MS Câu hỏi một nhiều đơn
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="examhallstudentcode"></param>
        /// <returns></returns>
        public int getExamresult(ref DataSet ds, string tablename, string examhallstudentcode)
        {
            int ret = 0;
            string sql = @"select examformdetailcode, questioncode, answercode, A.answertext, questiongroupcode, C.codeview questiontype  from examresult A
                        inner join questiongroup B on A.questiongroupcode = B.code
                        inner join questiontype C on B.questiontypecode = C.code
                        and examhallstudentcode = @examhallstudentcode";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("examhallstudentcode", examhallstudentcode, 0, (int)searchType.NONE));
            ret = getByQuery(ref ds, tablename, sql, li);
            return ret;
        }
    }

}

