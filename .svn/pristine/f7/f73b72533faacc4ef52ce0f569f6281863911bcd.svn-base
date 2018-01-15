using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
using IS.Sec;

namespace IS.uni
{
    public class MARK_BUS: BusinessController<MARK_OBJ, MARK_OBJ.BusinessObjectID>
    {
        public MARK_BUS()
        {
        }
        public override MARK_OBJ createObject()
        {
            MARK_OBJ obj = new MARK_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override MARK_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Get students that have enrolled to this course
        /// </summary>
        /// <param name="ds">Dataset to hold the data</param>
        /// <param name="tableName">Table in dataset to hold data</param>
        /// <param name="courseCode">The course code</param>
        /// <returns>poisitve is ok</returns>
        public int getStudent(ref DataSet ds , string tableName, string courseCode)
        {
            int ret = 0;
            string sql = "select a.name recode,convert(bit,1) choosen, A.code,B.codeview studentcode, B.name studentname, B.birthday studentbirthday, C.name classname, C.codeview classcode, B.sex as sex from (SELECT * FROM mark WHERE coursecode=@coursecode) A inner join student B on A.studentcode=B.code inner join class C ON B.classcode=C.code  order by c.code, dbo.TENHO(b.name)";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("COURSECODE", courseCode,SqlDbType.VarChar, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// Get all student in a class that have not enrolled to a course
        /// </summary>
        /// <param name="ds">Dataset to hold the data</param>
        /// <param name="tableName">Table name that hold the data</param>
        /// <param name="courseCode">The course that the student have enrolled</param>
        /// <param name="classcode">The manage class that students in</param>
        /// <returns></returns>
        public int getFreeStudent(ref DataSet ds, string tableName, string courseCode, string classcode)
        {
            int ret = 0;
            string sql = "select convert(bit,0) choosen, A.code,A.codeview studentcode,  A.name studentname, A.birthday studentbirthday, B.name classname, B.codeview classcode  from (select *  from student WHERE code not in (SELECT studentcode FROM mark WHERE coursecode=@coursecode) ) A  INNER JOIN  (select * from class where code = @classcode) B ON A.classcode = B.code";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("COURSECODE", courseCode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("CLASSCODE", classcode, SqlDbType.VarChar, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// get all student reexam and not in the course; for course2register (reexame course)
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="courseCode"></param>
        /// <param name="subjectCode"></param>
        /// <returns></returns>
        public int getReexamStudent(ref DataSet ds, string tableName, string courseCode, string subjectCode, int year, int term)
        {
            int ret = 0;
/*
            string sql =
@"with reexamstuden as
(
select C.studentcode, c.subjectcode, max(isnull(mark10,'')) mark10, max(markTHI) markthi, MAX(isnull(mark4,'')) mark4 FROM 
(
select A.code,A.studentcode, B.subjectcode, a.mark10, a.mark4, a.markTHI, case
	when ltrim(isnull(markthi,''))='' then 1
    when ISNUMERIC('0'+ltrim(ISNULL(markthi,'')))=1 then
		case 
			when convert(float,'0'+ltrim(isnull(mark10,'')))<4 then 0
			else
				1
		end
	else
		2
end pass from mark A inner join (SELECT * FROM course WHERE term=@term AND [year]=@year AND code <> @coursecode AND subjectcode=@subjectcode) B on A.coursecode=B.code
) C group by C.studentcode, c.subjectcode 
having MAX(pass)=0 and COUNT(code)=1
)
select E.code, E.codeview, E.name, E.classcode, F.codeview classcodeview, F.name classname, E.birthday, D.markTHI, D.mark10, D.mark4, F.fee from (SELECT * FROM reexamstuden where studentcode not in (SELECT studentcode FROM mark where coursecode=@coursecode)) D inner join student E ON D.studentcode=E.code INNER JOIN class F ON E.classcode=F.code 
ORDER BY F.codeview, dbo.TENHO(E.name)";
  */
//            string sql =
//@"with reexamstuden as
//(
//select C.studentcode, c.subjectcode, max(isnull(mark10,'')) mark10, max(markTHI) markthi, MAX(isnull(mark4,'')) mark4 FROM 
//(
//select A.code,A.studentcode, B.subjectcode, a.mark10, a.mark4, a.markTHI, case
//	when ltrim(isnull(markthi,''))='' then 1
//    when ISNUMERIC('0'+ltrim(ISNULL(markthi,'')))=1 then
//		case 
//			when convert(float,'0'+ltrim(isnull(mark10,'')))<4 then 0
//			else
//				1
//		end
//	else
//		2
//end pass from mark A inner join (SELECT * FROM course WHERE ((term<=@term AND [year]=@year) OR ([year]<@year)) AND code <> @coursecode AND subjectcode=@subjectcode) B on A.coursecode=B.code
//) C group by C.studentcode, c.subjectcode 
//having MAX(pass)=0 and COUNT(code)=1
//)
//select E.code, E.codeview, E.name, E.classcode, F.codeview classcodeview, F.name classname, E.birthday, D.markTHI, D.mark10, D.mark4, F.fee from (SELECT * FROM reexamstuden where studentcode not in (SELECT studentcode FROM mark where coursecode=@coursecode)) D inner join student E ON D.studentcode=E.code INNER JOIN class F ON E.classcode=F.code 
//ORDER BY F.codeview, dbo.TENHO(E.name)"; 
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("subjectcode", subjectCode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("term", term, SqlDbType.Int, 0, 0));
            ret = storedProcedure(ref ds,tableName, "reexamestudent", li); ;
            return ret;
        }
        /// <summary>
        /// Get student's marks in a course for input, output (report)
        /// </summary>
        /// <param name="ds">Dataset to hold data</param>
        /// <param name="tableName">Table name to hold data</param>
        /// <param name="courseCode">Course that students in </param>
        /// <returns>Positive is ok</returns>
        public int getStudentMark(ref DataSet ds, string tableName, string courseCode)
        {
            int ret = 0;
            //A.markCCI, A.markTXI,A.markThiI, 
            //, convert(int,ISNULL(markCC,'0')) markCCI, convert(int,ISNULL(markTX,'0')) markTXI, convert(int,ISNULL(markTHI,'0')) markThiI
            string sql = @"select a.pass, A.code,B.codeview studentcode, B.name studentname, B.birthday studentbirthday, '' classname, C.codeview classcode, A.markTHI, A.markTHI THIKETTHUC, A.markCC, A.markTX, A.markTX KIEMTRA
, A.mark10 markall ,	CONVERT(bit, case WHEN isnull(A.lock,0)=0 THEN 1
		ELSE 0 
	end)
	lock , A.note, D.name marklevel, D.codeview marklevelcodeview
	from (select *  from mark WHERE coursecode=@coursecode) A inner join student B on A.studentcode=B.code 
		inner join class C ON B.classcode=C.code 
        LEFT JOIN learnresulttype D ON A.learnresulttypecode = D.code
        order by b.classcode, dbo.tenho(B.name)
";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("COURSECODE", courseCode, SqlDbType.VarChar, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        /// <summary>
        /// Lấy các điểm của một lớp môn học dựa theo một thành phần nhất định
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="courseCode"></param>
        /// <param name="testgroupdetailcode"></param>
        /// <returns></returns>
        public int getStudentMark(ref DataSet ds, string tableName, string courseCode,string testgroupdetailcode)
        {
            int ret = 0;
            //A.markCCI, A.markTXI,A.markThiI, 
            //, convert(int,ISNULL(markCC,'0')) markCCI, convert(int,ISNULL(markTX,'0')) markTXI, convert(int,ISNULL(markTHI,'0')) markThiI
            string sql = @"select D.codeview marklevelcodeview, D.name marklevel, D.comparelevel, C.mark, B.name studentname, B.birthday studentbirthday, A.* from mark A
INNER JOIN student B ON A.studentcode=B.code
INNER JOIN markdetail C On A.code = C.markcode
INNER JOIN learnresulttype D On CONVERT(float,isnull(C.mark,'')) between minlevel and maxlevel
where A.coursecode=@coursecode AND C.testgroupdetailcode=@testgroupdetailcode
        order by dbo.tenho(B.name)";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("COURSECODE", courseCode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("TESTGROUPDETAILCODE", testgroupdetailcode, SqlDbType.VarChar, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }        /// <summary>
        /// Lấy điểm chi tiết
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="courseCode"></param>
        /// <param name="columncode"></param>
        /// <returns></returns>
        public int getStudentMarkdetail(ref DataSet ds, string tableName, string courseCode, string columncode)
        {
            int ret = 0;
            //A.markCCI, A.markTXI,A.markThiI, 
            //, convert(int,ISNULL(markCC,'0')) markCCI, convert(int,ISNULL(markTX,'0')) markTXI, convert(int,ISNULL(markTHI,'0')) markThiI
            string sql = @"select a.pass, A.code,B.codeview studentcode, B.name studentname, B.birthday studentbirthday, C.name classname, C.codeview classcode, A.markTHI THIKETTHUC, A.markCC, A.markTX KIEMTRA
, A.mark10 markall ,	CONVERT(bit, case WHEN isnull(A.lock,0)=0 THEN 1
		ELSE 0 
	end)
	lock , A.note, D.name marklevel, D.codeview marklevelcodeview, e.mark, e.marknumber
	from (select *  from mark WHERE coursecode=@coursecode) A inner join student B on A.studentcode=B.code 
		inner join class C ON B.classcode=C.code 
        LEFT JOIN learnresulttype D ON A.learnresulttypecode = D.code
        INNER JOIN (SELECT * FROM markdetail WHERE testgroupdetailcode=@testgroupdetailcode) E ON E.markcode=A.code 
        order by b.classcode, dbo.tenho(B.name)
";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("COURSECODE", courseCode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("testgroupdetailcode", columncode, SqlDbType.VarChar, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }        /// <summary>
        /// Get student's marks in a course for input, output (report), for input the last mark
        /// </summary>
        /// <param name="ds">Dataset to hold data</param>
        /// <param name="tableName">Table name to hold data</param>
        /// <param name="courseCode">Course that students in </param>
        /// <returns>Positive is ok</returns>
        public int getStudentMarkPos(ref DataSet ds, string tableName, string courseCode)
        {
            int ret = 0;
            //A.markCCI, A.markTXI,A.markThiI, 
            //, convert(int,ISNULL(markCC,'0')) markCCI, convert(int,ISNULL(markTX,'0')) markTXI, convert(int,ISNULL(markTHI,'0')) markThiI
            string sql = @"select A.name recode, A.code,B.codeview studentcode, B.name studentname, B.birthday studentbirthday, C.name classname, C.codeview classcode, A.markTHI, A.markCC, A.markTX 
,	CONVERT(bit, case WHEN isnull(A.lock,0)=0 OR isnull(A.lock,0)=2 THEN 1
		ELSE 0 
	end)
	lock , A.note

	from (select *  from mark WHERE coursecode=@coursecode) A inner join student B on A.studentcode=B.code 
		inner join class C ON B.classcode=C.code order by b.classcode, dbo.tenho(B.name)
";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("COURSECODE", courseCode, SqlDbType.VarChar, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// Get student's marks in a course for input, output (report), for input the last mark
        /// </summary>
        /// <param name="ds">Dataset to hold data</param>
        /// <param name="tableName">Table name to hold data</param>
        /// <param name="courseCode">Course that students in </param>
        /// <returns>Positive is ok</returns>
//        public int getStudentMarkReview(ref DataSet ds, string tableName, string courseCode)
//        {
//            int ret = 0;
//            //A.markCCI, A.markTXI,A.markThiI, 
//            //, convert(int,ISNULL(markCC,'0')) markCCI, convert(int,ISNULL(markTX,'0')) markTXI, convert(int,ISNULL(markTHI,'0')) markThiI
//            string sql = @"select A.code,B.codeview studentcode, B.name studentname, B.birthday studentbirthday, C.name classname, C.codeview classcode, A.markTHI, A.markCC, A.markTX 
//,	CONVERT(bit, case WHEN isnull(A.lock,0)=0  THEN 0
//		ELSE 1 
//	end)
//	lock 
//
//	from (select *  from mark WHERE coursecode=@coursecode) A inner join student B on A.studentcode=B.code 
//		inner join class C ON B.classcode=C.code order by b.classcode, dbo.tenho(B.name)
//";
//            List<fieldpara> li = new List<fieldpara>();
//            li.Add(new fieldpara("COURSECODE", courseCode, SqlDbType.VarChar, 0, 0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
//        }        
        /// <summary>
        /// calculate the normal mark for student (01.,02.,0.7), it may change base on the config file
        /// </summary>
        /// <param name="markCC">Attention mark</param>
        /// <param name="markTX">Assignment mark</param>
        /// <param name="markThi">Exam mark</param>
        /// <returns>string in the format</returns>
        public string normalMark(double markCC, double markTX, double markThi)
        {
            double t = 0;
            if (markThi < 4)
            {
                t = markThi;
            }
            else
            {
                t=Math.Truncate(1 * markCC + 2 * markTX + 7 * markThi+0.5)/10;
            }
            string kq = t.ToString("#0.0");
            //if (kq[0] == '0')
            //{
            //    kq = kq.Remove(0, 1);
            //}
            return kq;
        }
        public string normalMark(string markCC, string markTX, string markThi)
        {
            Comm.CommonLib com =new Comm.CommonLib();
            string u = markThi.ToUpper();
            if (com.checkDecimal(u) != 0)
            {
                return "";
            }
            if (markCC == "" && markTX == "")
            {
                return markThi;
            }
            double mThi, mTX, mCC;
            mThi = com.convert2Double(markThi,0);
            mTX = com.convert2Double(markTX,0);
            mCC = com.convert2Double(markCC,0);
            double t = 0;
            if (mThi < 4)
            {
                return markThi;
            }
            else
            {
                t = Math.Truncate( mCC + 2 * mTX + 7 * mThi+0.5)/10;
            }
            string kq = t.ToString("#0.0");
            //if (kq[0] == '0')
            //{
            //    kq = kq.Remove(0, 1);
            //}
            return kq;
        }
        public double normalMarkC(string markCC, string markTX, string markThi)
        {
            Comm.CommonLib com = new Comm.CommonLib();
            double mThi, mTX, mCC;
            mThi = com.convert2Double(markThi, 0);
            mTX = com.convert2Double(markTX, 0);
            mCC = com.convert2Double(markCC, 0);
            string u = markThi.ToUpper();
            if (com.checkDecimal(u) != 0)
            {
                return 0;
            }
            if (markCC == "" && markTX == "")
            {
                return mThi;
            }
            double t = 0;
            if (mThi < 4)
            {
                return mThi;
            }
            else
            {
                return  Math.Truncate(( mCC + 2 * mTX + 7 * mThi)+0.5)/10;
            }
        }

        public double normalMarkC(double markCC, double markTX, double markThi)
        {
            double t = 0;
            if (markThi < 4)
            {
                t = markThi;
            }
            else
            {
                t =  Math.Truncate((markCC + 2 * markTX + 7 * markThi)+0.5)/10; 
            }

            return  t;
        }
        public string markA(Double mark10)
        {
//            mark10 = Math.Truncate(10 * mark10 + 0.5) / 10;
            mark10 = Math.Round(mark10, 1);
            if (mark10 >= 9)
            {
                return "A+";
            }
            if (mark10 >= 8.5)
            {
                return "A";
            }
            if (mark10 >= 8)
            {
                return "B+";
            }
            if (mark10 >= 7)
            {
                return "B";
            }
            if (mark10 >= 6.5)
            {
                return "C+";
            }
            if (mark10 >= 5.5)
            {
                return "C";
            }
            //if (mark10 >= 5.0) //only for civil
            //{
            //    return "D+";
            //}
            if (mark10 >= 4.0)
            {
                return "D";
            }
            return "F";
        }
        /// <summary>
        /// chuyển đổi hình thức từ điểm sang xếp loại
        /// </summary>
        /// <param name="li"></param>
        /// <param name="mark10"></param>
        /// <returns></returns>
        public string learnresulttype(List<LEARNRESULTTYPE_OBJ> li, Double mark10)
        {
            string code = "";
            foreach(LEARNRESULTTYPE_OBJ obj in li)
            {
                if(obj.MINLEVEL<=mark10 && obj.MAXLEVEL>=mark10)
                {
                    code = obj.CODE;
                    break;
                }
            }
            return code;
        }

        /// <summary>
        /// convert from a mark4 to description
        /// </summary>
        /// <param name="mark4"></param>
        /// <returns></returns>
        public string markSumType(double mark4)
        {
            //mark4 = Math.Truncate(100 * mark4 ) / 100;
            mark4 = Math.Round(mark4, 2);
            if (mark4 >= 3.6)
            {
                return "Xuất sắc";
            }
            if (mark4 >= 3.2)
            {
                return "Giỏi";
            }
            if (mark4 >= 2.5)
            {
                return "Khá";
            }
            //if (mark4 >= 2.3)  //only for civil
            //{
            //    return "Trung bình khá";
            //}
            if (mark4 >= 2)
            {
                return "Trung bình";
            }
            //if (mark4 >= 1.5)  //only for civil
            //{
            //    return "Trung bình yếu";
            //}
            if (mark4 >= 1)
            {
                return "Yếu";
            }

            return "Kém";
        }
        /// <summary>
        /// Chuyển đổi điểm tổng kết hệ 10 sang loại
        /// </summary>
        /// <param name="mark4"></param>
        /// <returns></returns>
        public string markSumType10(double mark10)
        {
            //mark4 = Math.Truncate(100 * mark4 ) / 100;
            mark10 = Math.Round(mark10, 2);
            if (mark10 >= 9)
            {
                return "Xuất sắc";
            }
            if (mark10 >= 8)
            {
                return "Giỏi";
            }
            if (mark10 >= 7)
            {
                return "Khá";
            }
            if (mark10 >= 6)  //only for civil
            {
                return "Trung bình khá";
            }
            if (mark10 >= 5)
            {
                return "Trung bình";
            }
            //if (mark4 >= 1.5)  //only for civil
            //{
            //    return "Trung bình yếu";
            //}
            if (mark10 >= 3)
            {
                return "Yếu";
            }

            return "Kém";
        }
        /// <summary>
        /// chuyển đổi điểm tổng kết sang xếp loại học tập
        /// </summary>
        /// <param name="mark10"></param>
        /// <returns></returns>
        public string markType10(double mark10)
        {
            mark10 = Math.Round(mark10, 2);
            //   mark4 = Math.Truncate(10 * mark4 + 0.5) / 10;
            if (mark10 >= 9)
            {
                return "Xuất sắc";
            }
            if (mark10 >= 8)
            {
                return "Giỏi";
            }
            if (mark10 >= 7)
            {
                return "Khá";
            }
            //if (mark4 >= 2.3)  //only for civil
            //{
            //    return "Trung bình khá";
            //}
            if (mark10 >= 5)
            {
                return "Trung bình";
            }
            //if (mark4 >= 1.5)  //only for civil
            //{
            //    return "Trung bình yếu";
            //}
            if (mark10 >= 3)
            {
                return "Yếu";
            }

            return "Kém";
        }
        public string markType(double mark4)
        {
            mark4 = Math.Round(mark4, 2);
         //   mark4 = Math.Truncate(10 * mark4 + 0.5) / 10;
            if (mark4 >= 3.6)
            {
                return "Xuất sắc";
            }
            if (mark4 >= 3.2)
            {
                return "Giỏi";
            }
            if (mark4 >= 2.5)
            {
                return "Khá";
            }
            //if (mark4 >= 2.3)  //only for civil
            //{
            //    return "Trung bình khá";
            //}
            if (mark4 >= 2)
            {
                return "Trung bình";
            }
            //if (mark4 >= 1.5)  //only for civil
            //{
            //    return "Trung bình yếu";
            //}
            if (mark4 >= 1)
            {
                return "Yếu";
            }

            return "Kém";
        }
        public string markTypeShort(double mark4)
        {
//            mark4 = Math.Truncate(10*mark4+0.5)/10;
            mark4 = Math.Round(mark4, 2);
            if (mark4 >= 3.6)
            {
                return "XS";
            }
            if (mark4 >= 3.2)
            {
                return "G";
            }
            if (mark4 >= 2.5)
            {
                return "KH";
            }
            //if (mark4 >= 2.3)  //only for civil
            //{
            //    return "Trung bình khá";
            //}
            if (mark4 >= 2)
            {
                return "TB";
            }
            //if (mark4 >= 1.5)  //only for civil
            //{
            //    return "Trung bình yếu";
            //}
            if (mark4 >= 1)
            {
                return "Y";
            }

            return "K";
        }
        public string mark4(Double mark10)
        {
//            mark10 = Math.Truncate(10 * mark10 + 0.5) / 10;
            mark10 = Math.Round(mark10, 1);
            if (mark10 >= 9)
            {
                return "4";
            }
            if (mark10 >= 8.5)
            {
                return "3.7";
            }
            if (mark10 >= 8)
            {
                return "3.5";
            }
            if (mark10 >= 7)
            {
                return "3";
            }
            if (mark10 >= 6.5)
            {
                return "2.5";
            }
            if (mark10 >= 5.5)
            {
                return "2";
            }
            //if (mark10 >= 5.0)    //only for civil
            //{
            //    return "1.5";
            //}
            if (mark10 >= 4.0)
            {
                return "1";
            }
            return "0";
        }
        /// <summary>
        /// read the mark to string 
        /// </summary>
        /// <param name="mark">the mark in format 0.0</param>
        /// <returns>string of mark</returns>
        public string readMark(string mark)
        {
            string[] strSo ={ "Không", "Một", "Hai", "Ba", "Bốn", "Năm", "Sáu", "Bảy", "Tám", "Chín","Mười" };
            string[] strSo1 ={ "không", "một", "hai", "ba", "bốn", "năm", "sáu", "bảy", "tám", "chín" };
            string s = "";
            char []sp={'.',','};
            string[] ss = mark.Split(sp);
            int pre=0, suf=0;
            if (ss.Length <= 0)
            {
                return "Không nhập";
            }
            int.TryParse(ss[0], out pre);
            if (ss.Length > 1)
            {
                int.TryParse(ss[1], out suf);
            }
            pre = pre % 11;
            s = strSo[pre];
            if (suf == 0)
            {
                s += " chẵn";
            }
            else
            {
                s += " chấm " + strSo1[suf % 10];

            }
            return s;
        }
        /// <summary>
        /// Get all mark of a student
        /// </summary>
        /// <param name="ds">Dataset to hold the data</param>
        /// <param name="tableName">Table name to hold data</param>
        /// <param name="code">The code of student</param>
        /// <returns>Negative values is error</returns>
//        public int getPersonalMark(ref DataSet ds, string tableName, string code)
//        {
//            int ret = 0;
//            List<fieldpara> li = new List<fieldpara>();
//            string sql = @"SELECT A.*, C.name subjectname, c.codeview subjectcodeview, c.credit,d.marktype,d.finalexam,d.groupprint,d.pass10,b.term, convert(char(4),b.year)+'-'+convert(char(4),b.year+1) as year   FROM (SELECT * FROM mark WHERE studentcode=@studentcode) A 
//INNER JOIN course B ON A.coursecode=B.code 
//	INNER JOIN subject C ON B.subjectcode=C.code
//		INNER JOIN learningtype D ON C.learningtypecode=D.code
//        Order by [year]*10+term";
//            li.Add(new fieldpara("studentcode",code, SqlDbType.VarChar,0,0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
//        }
    /// <summary>
    /// Get get mark of student in class in year/term where they are defined
    /// </summary>
    /// <param name="ds">Return dataset hold data</param>
    /// <param name="tableName">table name in dataset</param>
    /// <param name="classCode">class code, if '' is all</param>
    /// <param name="studentcode">student code if '' is all student in the class</param>
    /// <param name="year">if 0 all year (current)</param>
    /// <param name="term">if 0 all term in the year</param>
    /// <param name="pass">0: all subject (including fail subject), 1: passed subject</param>
    /// <returns></returns>
        public int personalMark(ref DataSet ds, string tableName, string classCode, string studentcode, int year, int term, int pass, int notfull)
        {
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0));
            li.Add(new fieldpara("studentcode", studentcode, SqlDbType.VarChar, 0));
            li.Add(new fieldpara("year", year, SqlDbType.Int, 0));
            li.Add(new fieldpara("term", term, SqlDbType.Int, 0));
            li.Add(new fieldpara("pass", pass, SqlDbType.Int, 0));
            li.Add(new fieldpara("notfull", notfull, SqlDbType.Int, 0));
            int ret = storedProcedure(ref ds, tableName, "personalmark", li);//all course
            return ret;
//            int ret = 0;
//            List<fieldpara> li = new List<fieldpara>();
//            string sql = @"SELECT A.*, C.name subjectname, c.codeview subjectcodeview, c.credit,d.marktype,d.finalexam,d.groupprint,d.pass10,b.term, convert(char(4),b.year)+'-'+convert(char(4),b.year+1) as year   FROM (SELECT A1.* FROM mark A1 INNER JOIN student A2 ON A1.studentcode=A2.code WHERE A2.classcode=@classcode) A 
//INNER JOIN course B ON A.coursecode=B.code 
//	INNER JOIN subject C ON B.subjectcode=C.code
//		INNER JOIN learningtype D ON C.learningtypecode=D.code
//        WHERE (B.year=@year OR @year=0) AND (B.term = @term OR @term=0)
//        Order by A.studentcode, [year]*10+term";
//            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0, 0));
//            li.Add(new fieldpara("year", year, SqlDbType.Int, 0, 0));
//            li.Add(new fieldpara("term", term, SqlDbType.Int, 0, 0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
        }
//        public int personalMark(ref DataSet ds, string tableName, string classCode, string studentCode, int year, int term)
//        {
//            int ret = 0;
//            List<fieldpara> li = new List<fieldpara>();
//            string sql = @"SELECT A.*, C.name subjectname, c.codeview subjectcodeview, c.credit,d.marktype,d.finalexam,d.groupprint,d.pass10,b.term, convert(char(4),b.year)+'-'+convert(char(4),b.year+1) as year   FROM (SELECT A1.* FROM mark A1 INNER JOIN student A2 ON A1.studentcode=A2.code WHERE A2.classcode=@classcode AND A2.code=@studentcode) A 
//INNER JOIN course B ON A.coursecode=B.code 
//	INNER JOIN subject C ON B.subjectcode=C.code
//		INNER JOIN learningtype D ON C.learningtypecode=D.code  
//        WHERE (B.year=@year OR @year=0) AND (B.term = @term OR @term=0)
//        Order by A.studentcode, [year]*10+term";
//            li.Add(new fieldpara("year", year, SqlDbType.Int, 0, 0));
//            li.Add(new fieldpara("term", term, SqlDbType.Int, 0, 0));
//            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0, 0));
//            li.Add(new fieldpara("studentcode", studentCode, SqlDbType.VarChar, 0, 0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
//        }
//        public int getPersonalMark(ref DataSet ds, string tableName, string code, int term, int year)
//        {
//            int ret = 0;
//            List<fieldpara> li = new List<fieldpara>();
//            string sql = @"SELECT A.*, C.name subjectname, c.codeview subjectcodeview, c.credit,d.marktype,d.finalexam,d.groupprint,d.pass10,b.term, convert(char(4),b.year)+'-'+convert(char(4),b.year+1) as year   FROM (SELECT * FROM mark WHERE studentcode=@studentcode) A 
//INNER JOIN (SELECT * FROM course WHERE term=@term AND [year]=@year) B ON A.coursecode=B.code 
//	INNER JOIN subject C ON B.subjectcode=C.code
//		INNER JOIN learningtype D ON C.learningtypecode=D.code
//        Order by [year]*10+term";
//            li.Add(new fieldpara("studentcode", code, SqlDbType.VarChar, 0, 0));
//            li.Add(new fieldpara("term", term, SqlDbType.SmallInt, 0, 0));
//            li.Add(new fieldpara("year", year, SqlDbType.Int, 0, 0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
//        }

        public string encrypt(MARK_OBJ obj)
        {
            string t = "";
            string ac = "IS.FIT-LQDTU";
            MaHoa sec = new MaHoa();
            string code = string.Format("{0}:{1}:{2}:{3}:{4}:{5}:{6}:{7}", obj.COURSECODE, obj.STUDENTCODE, obj.MARK10, obj.MARK4, obj.MARKA, obj.MARKCC, obj.MARKTHI,obj.MARKTX);

            t = sec.Encrypt(ac, code);
            return t;
        }
        public int checkIntegrity(string code, MARK_OBJ obj)
        {
            string t = encrypt(obj);
            if (t == code)
            {
                return 0;
            }
            return -1;
        }
        public int classTerm(ref DataSet ds, string tableName, string classCode, int year, int term)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0));
            li.Add(new fieldpara("year", year, SqlDbType.Int, 0));
            li.Add(new fieldpara("term", term, SqlDbType.Int, 0));
            ret = storedProcedure(ref ds, tableName, "markClassTerm", li);
            return ret;
        }
        /// <summary>
        /// all marks that students in the class learn in period
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="classCode"></param>
        /// <param name="year"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public int classLearnMark(ref DataSet ds, string tableName, string classCode, int year, int term)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0));
            li.Add(new fieldpara("year", year, SqlDbType.Int, 0));
            li.Add(new fieldpara("term", term, SqlDbType.Int, 0));
            ret = storedProcedure(ref ds, tableName, "classlearnmark", li);
            return ret;
        }
        public int checkRecode(string coursecode)
        {
            int ret = 0;
            DataSet ds = new DataSet();
            string sql=@"SELECT COUNT(B.code) countstudent, 
SUM(
CASE
     WHEN ISNULL(B.name,'')='' THEN 0 
     ELSE 1 
END
) countrecode
  FROM  mark B 
  WHERE coursecode=@coursecode
GROUP BY B.coursecode
";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("coursecode",coursecode, SqlDbType.VarChar,0));
            ret = getByQuery(ref ds, "check", sql, li);
            if (ret < 0)
            {
                return ret;
            }
            if (ds.Tables["check"].Rows.Count != 1)
            {
                return -5;
            }
            Comm.CommonLib com = new Comm.CommonLib();
            int c1, c2;
            c1 = com.int4Row(ds.Tables["check"].Rows[0], "countstudent", 0);
            c2 = com.int4Row(ds.Tables["check"].Rows[0], "countrecode", -1);
            return c2-c1;
        }
        /// <summary>
        /// Tính lại điểm dựa trên danh sách dữ liệu được nhập vào
        /// </summary>
        /// <param name="li_testgroup"></param>
        /// <param name="li_testgroupdetail"></param>
        /// <param name="li_markdetail"></param>
        /// <param name="obj"></param>
        /// <returns></returns>
        public int recalmark(List<TESTGROUP_OBJ> li_testgroup , List<TESTGROUPDETAIL_OBJ> li_testgroupdetail , List<MARKDETAIL_OBJ> li_markdetail, MARK_OBJ obj)
        {
            int ret = 0;

            return ret;
        }
    }

}

