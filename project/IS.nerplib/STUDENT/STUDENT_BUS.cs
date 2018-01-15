using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
using IS.Sec;
using IS.basetype;

namespace IS.uni
{
    public class STUDENT_BUS: BusinessController<STUDENT_OBJ, STUDENT_OBJ.BusinessObjectID>
    {
        public STUDENT_BUS()
        {
        }
        public override STUDENT_OBJ createObject()
        {
            STUDENT_OBJ obj = new STUDENT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STUDENT_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// get all students in a class
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public int getClassStudent(ref DataSet ds, string tableName, string classCode)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            string sql = @"select A.*, B.codeview provincecodeview, B.name provincename, C.codeview studentrankcodeview
, C.name studentrankname, D.codeview studentleveltitlecodeview, D.name studentleveltitlename 
from (select * from student where classcode=@classcode ) A 
LEFT join province B on A.provincecode=B.code				
LEFT JOIN studentrank C ON A.studentrankcode=C.code
LEFT JOIN studentleveltitle D ON A.studentleveltitlecode=D.code";
            li.Add(new fieldpara("CLASSCODE", classCode, SqlDbType.VarChar, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        public int getEducationlevel(ref DataSet ds, string tableName, string classCode)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            string sql = @"select B.name gradename, C.name educationlevelname from (select * from class where code=@code) A 
                    inner join grade B on A.gradecode=B.code
	                    inner join educationlevel C ON B.educationlevelcode = C.code";
            li.Add(new fieldpara("CODE", classCode, SqlDbType.VarChar, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// Get everage(mark) of student in term
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="classCode"></param>
        /// <param name="markGroupType"></param>
        /// <param name="learningType"></param>
        /// <param name="markbarrier"></param>
        /// <param name="year"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        /*
        ---- mon dau tien
        declare  @year int, @term int, @classcode varchar(10), @learningtypecode varchar (10), @markbarrier float
        set @year=2011
        set @term=1
        set @learningtypecode=''
        set @markbarrier=5
        set @classcode='DK547';

        -- A DIEM cua tat ca sinh vien trong mot lop
        with studentlearncourse  AS
        (	select A1.* FROM (SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier)  A1 INNER JOIN 
                (
                    SELECT code FROM student WHERE classcode=@classcode
                ) A2 ON A1.studentcode=A2.code
        )
        -- B Cac khoa hoc trong khoang
        ,courseinfo AS
        (
            SELECT B1.*, B2.credit FROM 
                (
                    select * from course where [year]=@year AND term=@term
                ) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
        )
        -- C tat ca mon hoc can phai tinh cho sinh vien trong lop
        ,studentsummark AS
        (
        SELECT E.studentcode, SUM(convert(float,'0'+isnull(E.mark10,''))) summark, sum(D.credit) sumcredit FROM mark E INNER JOIN 
            (
                select studentcode, right(coursecodecom,len(coursecodecom)-5) coursecode, credit from 
                (
                    select A.studentcode, B.subjectcode, min(convert(varchar,B.[year]*10+ B.term)+B.code) coursecodecom, COUNT(*) coursecount, MAX(B.credit)  credit
                        from 	studentlearncourse  A 
                            inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
                ) C 
            )D 
            ON E.studentcode=D.studentcode AND E.coursecode=D.coursecode 
        GROUP BY E.studentcode
        )
        -- Thong tin các sinh vien
        , studentinfo AS
        (
            SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
        )
        -- All
        select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
---- mon diem lon nhat
declare  @year int, @term int, @classcode varchar(10), @learningtypecode varchar (10), @markbarrier float
set @year=2011
set @term=1
set @learningtypecode=''
set @markbarrier=5
set @classcode='DK547';

-- A DIEM cua tat ca sinh vien trong mot lop
with studentlearncourse  AS
(	select A1.* FROM 
	(
		SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier
	) A1 INNER JOIN 
		(
			SELECT code FROM student WHERE classcode=@classcode
		) A2 ON A1.studentcode=A2.code
)
-- B Cac khoa hoc trong khoang
,courseinfo AS
(
	SELECT B1.*, B2.credit FROM 
		(
			select * from course where [year]=@year AND term=@term
		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
)
-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
,studentsummark AS
(
	select studentcode, sum(mark) summark, sum(credit) sumcredit from 
	(
		select A.studentcode, B.subjectcode, max(convert(float,'0'+isnull(A.mark10,''))) mark, COUNT(*) coursecount, MAX(B.credit)  credit
			from 	studentlearncourse  A 
				inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
	) C 
	GROUP BY studentcode
)
--Thong tin sinh vien
, studentinfo AS
(
	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
)
--ALL
select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
 
         */
        private string sortOrder(string field, string sortType)
        {
            string s = field;
            string o = sortType;
            string ret = "";
            switch (s)
            {
                case "studentname":
                    ret = "ORDER BY dbo.TENHO(H1.name) " + o;
                    break;
                case "TBC10":
                    ret = "ORDER BY H2.summark/H2.sumcredit " + o;
                    break;
                case "TBC4":
                    ret = "ORDER BY H2.summark4/H2.sumcredit " + o;
                    break;
            }
            return ret;

        }
        public int learnstat(ref DataSet ds, string tableName, string gradeCode, int year, int term, string markGroupType, int pass, int notfull)
        {
            int ret = 0;
            string storeName = "learnstatfirst";//In default, get the first mark for a subject
            if( markGroupType!="FIRST")//other case get the highest mark for a subject
            {
                storeName = "learnstatmax";//must change the name
            }
            List<fieldpara> fi = new List<fieldpara>();
            fi.Add(new fieldpara("term", term, SqlDbType.Int, 0, 0));
            fi.Add(new fieldpara("year", year, SqlDbType.Int, 0, 0));
            fi.Add(new fieldpara("pass", pass, SqlDbType.Int, 0, 0));
            fi.Add(new fieldpara("gradecode", gradeCode, SqlDbType.VarChar, 0, 0));
            fi.Add(new fieldpara("notfull", notfull, SqlDbType.Int, 0, 0));
            ret = storedProcedure(ref ds, tableName, storeName, fi);
            return ret;
        }
/// <summary>
/// learning result
/// </summary>
/// <param name="ds"></param>
/// <param name="tableName"></param>
/// <param name="educationlevelcode"></param>
/// <param name="gradecode"></param>
/// <param name="classCode"></param>
/// <param name="year"></param>
/// <param name="term"></param>
/// <param name="pass"></param>
/// <param name="notfull"></param>
/// <param name="markGroupType"></param>
/// <returns></returns>
        public int studentsummarkTerm(ref DataSet ds, string tableName, string educationlevelcode, string gradecode, string classCode, int year, int term, int pass, int notfull, string markGroupType)
        {
            int ret = 0;
            string storeName = "sumstudentmark";//In default get highest
            if (markGroupType == "FIRST")//other case get the highest mark for a subject
            {
                storeName = "sumstudentmarkfirst";//must change the name
            }
            List<fieldpara> fi = new List<fieldpara>();
            fi.Add(new fieldpara("term", term, SqlDbType.Int, 0, 0));
            fi.Add(new fieldpara("year", year, SqlDbType.Int, 0, 0));
            fi.Add(new fieldpara("educationlevelcode", educationlevelcode, SqlDbType.VarChar, 0, 0));
            fi.Add(new fieldpara("gradecode", gradecode, SqlDbType.VarChar, 0, 0));
            fi.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0, 0));
            fi.Add(new fieldpara("pass", pass, SqlDbType.Int, 0, 0));
            fi.Add(new fieldpara("notfull", notfull, SqlDbType.Int, 0, 0));
            ret = storedProcedure(ref ds, tableName, storeName, fi);
            return ret;
            //            string sql = "";
//            string courseSql = "";
//            switch (type)
//            {
//                case 1:
//                    courseSql = "select * from course where [year]=@year AND term=@term";
//                    break;
//                case 2:
//                    courseSql = "select * from course where [year]=@year ";
//                    break;
//                case 3:
//                    courseSql = "select * from course ";
//                    break;
//            }
//            if (markGroupType == "FIRST")
//            {
//                //the first course on the subjects' mark
//                sql = @"
//with studentlearncourse  AS
//(	select A1.* FROM (SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier)  A1 INNER JOIN 
//		(
//			SELECT code FROM student WHERE classcode=@classcode
//		) A2 ON A1.studentcode=A2.code
//)
//-- B Cac khoa hoc trong khoang
//,courseinfo AS
//(
//	SELECT B1.*, B2.credit FROM 
//		(
//			{%courseselect%}
//		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
//)
//-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//,studentsummark AS
//(
//SELECT E.studentcode, SUM(convert(float,'0'+isnull(E.mark10,''))*D.credit) summark, SUM(convert(float,'0'+isnull(E.mark4,''))*D.credit) summark4, sum(D.credit) sumcredit FROM mark E INNER JOIN 
//	(
//		select studentcode, right(coursecodecom,len(coursecodecom)-5) coursecode, credit from 
//		(
//			select A.studentcode, B.subjectcode, min(convert(varchar,B.[year]*10+ B.term)+B.code) coursecodecom, COUNT(*) coursecount, MAX(B.credit)  credit
//				from 	studentlearncourse  A 
//					inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//		) C 
//	)D 
//	ON E.studentcode=D.studentcode AND E.coursecode=D.coursecode 
//GROUP BY E.studentcode
//)
//-- Thong tin các sinh vien
//, studentinfo AS
//(
//	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//)
//-- All
//select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode " + sortOrder(field,sorttype);
//            }
//            else
//            {
//                //the max mark on the subjects
//                sql = @"
//with studentlearncourse  AS
//(	select A1.* FROM 
//	(
//		SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier
//	) A1 INNER JOIN 
//		(
//			SELECT code FROM student WHERE classcode=@classcode
//		) A2 ON A1.studentcode=A2.code
//)
//-- B Cac khoa hoc trong khoang
//,courseinfo AS
//(
//	SELECT B1.*, B2.credit FROM 
//		(
//			{%courseselect%}
//		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
//)
//-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//,studentsummark AS
//(
//	select studentcode, sum(mark*credit) summark, sum(mark4*credit) summark4, sum(credit) sumcredit from 
//	(
//		select A.studentcode, B.subjectcode, max(convert(float,'0'+isnull(A.mark10,''))) mark,max(convert(float,'0'+isnull(A.mark4,''))) mark4, COUNT(*) coursecount, MAX(B.credit)  credit
//			from 	studentlearncourse  A 
//				inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//	) C 
//	GROUP BY studentcode
//)
//--Thong tin sinh vien
//, studentinfo AS
//(
//	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//)
//--ALL
//select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode "  +sortOrder(field, sorttype);
//            }
//            sql=sql.Replace("{%courseselect%}",courseSql);
//            List<fieldpara> li = new List<fieldpara>();
//            li.Add(new fieldpara("year", year, SqlDbType.Int, 0));
//            li.Add(new fieldpara("term", term, SqlDbType.Int, 0));
//            li.Add(new fieldpara("learningtypecode", learningType, SqlDbType.VarChar, 0));
//            li.Add(new fieldpara("markbarrier", markbarrier, SqlDbType.Float, 0));
//            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
        }
        /// <summary>
        /// Get everage(mark) of student in year
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="classCode"></param>
        /// <param name="markGroupType"></param>
        /// <param name="learningType"></param>
        /// <param name="markbarrier"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        /*
        ---- mon dau tien
        declare  @year int, @term int, @classcode varchar(10), @learningtypecode varchar (10), @markbarrier float
        set @year=2011
        set @term=1
        set @learningtypecode=''
        set @markbarrier=5
        set @classcode='DK547';

        -- A DIEM cua tat ca sinh vien trong mot lop
        with studentlearncourse  AS
        (	select A1.* FROM (SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier)  A1 INNER JOIN 
                (
                    SELECT code FROM student WHERE classcode=@classcode
                ) A2 ON A1.studentcode=A2.code
        )
        -- B Cac khoa hoc trong khoang
        ,courseinfo AS
        (
            SELECT B1.*, B2.credit FROM 
                (
                    select * from course where [year]=@year 
                ) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
        )
        -- C tat ca mon hoc can phai tinh cho sinh vien trong lop
        ,studentsummark AS
        (
        SELECT E.studentcode, SUM(convert(float,'0'+isnull(E.mark10,''))) summark, sum(D.credit) sumcredit FROM mark E INNER JOIN 
            (
                select studentcode, right(coursecodecom,len(coursecodecom)-5) coursecode, credit from 
                (
                    select A.studentcode, B.subjectcode, min(convert(varchar,B.[year]*10+ B.term)+B.code) coursecodecom, COUNT(*) coursecount, MAX(B.credit)  credit
                        from 	studentlearncourse  A 
                            inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
                ) C 
            )D 
            ON E.studentcode=D.studentcode AND E.coursecode=D.coursecode 
        GROUP BY E.studentcode
        )
        -- Thong tin các sinh vien
        , studentinfo AS
        (
            SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
        )
        -- All
        select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
---- mon diem lon nhat
declare  @year int, @term int, @classcode varchar(10), @learningtypecode varchar (10), @markbarrier float
set @year=2011
set @term=1
set @learningtypecode=''
set @markbarrier=5
set @classcode='DK547';

-- A DIEM cua tat ca sinh vien trong mot lop
with studentlearncourse  AS
(	select A1.* FROM 
	(
		SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier
	) A1 INNER JOIN 
		(
			SELECT code FROM student WHERE classcode=@classcode
		) A2 ON A1.studentcode=A2.code
)
-- B Cac khoa hoc trong khoang
,courseinfo AS
(
	SELECT B1.*, B2.credit FROM 
		(
			select * from course where [year]=@year 
		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
)
-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
,studentsummark AS
(
	select studentcode, sum(mark) summark, sum(credit) sumcredit from 
	(
		select A.studentcode, B.subjectcode, max(convert(float,'0'+isnull(A.mark10,''))) mark, COUNT(*) coursecount, MAX(B.credit)  credit
			from 	studentlearncourse  A 
				inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
	) C 
	GROUP BY studentcode
)
--Thong tin sinh vien
, studentinfo AS
(
	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
)
--ALL
select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
 
         */
//        public int studentsummarkYear(ref DataSet ds, string tableName, string classCode, string markGroupType, string learningType, double markbarrier, int year)
//        {
//            int ret = 0;
//            string sql = "";
//            if (markGroupType == "FIRST")
//            {
//                //the first course on the subjects' mark
//                sql = @"
//with studentlearncourse  AS
//(	select A1.* FROM (SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier)  A1 INNER JOIN 
//		(
//			SELECT code FROM student WHERE classcode=@classcode
//		) A2 ON A1.studentcode=A2.code
//)
//-- B Cac khoa hoc trong khoang
//,courseinfo AS
//(
//	SELECT B1.*, B2.credit FROM 
//		(
//			select * from course where [year]=@year 
//		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
//)
//-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//,studentsummark AS
//(
//SELECT E.studentcode, SUM(convert(float,'0'+isnull(E.mark10,''))) summark, sum(D.credit) sumcredit FROM mark E INNER JOIN 
//	(
//		select studentcode, right(coursecodecom,len(coursecodecom)-5) coursecode, credit from 
//		(
//			select A.studentcode, B.subjectcode, min(convert(varchar,B.[year]*10+ B.term)+B.code) coursecodecom, COUNT(*) coursecount, MAX(B.credit)  credit
//				from 	studentlearncourse  A 
//					inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//		) C 
//	)D 
//	ON E.studentcode=D.studentcode AND E.coursecode=D.coursecode 
//GROUP BY E.studentcode
//)
//-- Thong tin các sinh vien
//, studentinfo AS
//(
//	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//)
//-- All
//select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
//";
//            }
//            else
//            {
//                //the max mark on the subjects
//                sql = @"
//with studentlearncourse  AS
//(	select A1.* FROM 
//	(
//		SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier
//	) A1 INNER JOIN 
//		(
//			SELECT code FROM student WHERE classcode=@classcode
//		) A2 ON A1.studentcode=A2.code
//)
//-- B Cac khoa hoc trong khoang
//,courseinfo AS
//(
//	SELECT B1.*, B2.credit FROM 
//		(
//			select * from course where [year]=@year 
//		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
//)
//-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//,studentsummark AS
//(
//	select studentcode, sum(mark) summark, sum(credit) sumcredit from 
//	(
//		select A.studentcode, B.subjectcode, max(convert(float,'0'+isnull(A.mark10,''))) mark, COUNT(*) coursecount, MAX(B.credit)  credit
//			from 	studentlearncourse  A 
//				inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//	) C 
//	GROUP BY studentcode
//)
//--Thong tin sinh vien
//, studentinfo AS
//(
//	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//)
//--ALL
//select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
//";
//            }
//            List<fieldpara> li = new List<fieldpara>();
//            li.Add(new fieldpara("year", year, SqlDbType.Int, 0));
//            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0));
//            li.Add(new fieldpara("learningtypecode", learningType, SqlDbType.VarChar, 0));
//            li.Add(new fieldpara("markbarrier", markbarrier, SqlDbType.Float, 0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
//        }
//        /// <summary>
//        /// Get everage(mark) of student in year
//        /// </summary>
//        /// <param name="ds"></param>
//        /// <param name="tableName"></param>
//        /// <param name="classCode"></param>
//        /// <param name="markGroupType"></param>
//        /// <param name="learningType"></param>
//        /// <param name="markbarrier"></param>
//        /// <returns></returns>
//        /*
//        ---- mon dau tien
//        declare  @year int, @term int, @classcode varchar(10), @learningtypecode varchar (10), @markbarrier float
//        set @year=2011
//        set @term=1
//        set @learningtypecode=''
//        set @markbarrier=5
//        set @classcode='DK547';

//        -- A DIEM cua tat ca sinh vien trong mot lop
//        with studentlearncourse  AS
//        (	select A1.* FROM (SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier)  A1 INNER JOIN 
//                (
//                    SELECT code FROM student WHERE classcode=@classcode
//                ) A2 ON A1.studentcode=A2.code
//        )
//        -- B Cac khoa hoc trong khoang
//        ,courseinfo AS
//        (
//            SELECT B1.*, B2.credit FROM 
//                (
//                    select * from course where [year]=@year 
//                ) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
//        )
//        -- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//        ,studentsummark AS
//        (
//        SELECT E.studentcode, SUM(convert(float,'0'+isnull(E.mark10,''))) summark, sum(D.credit) sumcredit FROM mark E INNER JOIN 
//            (
//                select studentcode, right(coursecodecom,len(coursecodecom)-5) coursecode, credit from 
//                (
//                    select A.studentcode, B.subjectcode, min(convert(varchar,B.[year]*10+ B.term)+B.code) coursecodecom, COUNT(*) coursecount, MAX(B.credit)  credit
//                        from 	studentlearncourse  A 
//                            inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//                ) C 
//            )D 
//            ON E.studentcode=D.studentcode AND E.coursecode=D.coursecode 
//        GROUP BY E.studentcode
//        )
//        -- Thong tin các sinh vien
//        , studentinfo AS
//        (
//            SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//        )
//        -- All
//        select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
//---- mon diem lon nhat
//declare  @year int, @term int, @classcode varchar(10), @learningtypecode varchar (10), @markbarrier float
//set @year=2011
//set @term=1
//set @learningtypecode=''
//set @markbarrier=5
//set @classcode='DK547';

//-- A DIEM cua tat ca sinh vien trong mot lop
//with studentlearncourse  AS
//(	select A1.* FROM 
//    (
//        SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier
//    ) A1 INNER JOIN 
//        (
//            SELECT code FROM student WHERE classcode=@classcode
//        ) A2 ON A1.studentcode=A2.code
//)
//-- B Cac khoa hoc trong khoang
//,courseinfo AS
//(
//    SELECT B1.*, B2.credit FROM 
//        (
//            select * from course where [year]=@year 
//        ) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
//)
//-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//,studentsummark AS
//(
//    select studentcode, sum(mark) summark, sum(credit) sumcredit from 
//    (
//        select A.studentcode, B.subjectcode, max(convert(float,'0'+isnull(A.mark10,''))) mark, COUNT(*) coursecount, MAX(B.credit)  credit
//            from 	studentlearncourse  A 
//                inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//    ) C 
//    GROUP BY studentcode
//)
//--Thong tin sinh vien
//, studentinfo AS
//(
//    SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//)
//--ALL
//select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
 
//         */
//        public int studentsummark(ref DataSet ds, string tableName, string classCode, string markGroupType, string learningType, double markbarrier)
//        {
//            int ret = 0;
//            string sql = "";
//            if (markGroupType == "FIRST")
//            {
//                //the first course on the subjects' mark
//                sql = @"
//with studentlearncourse  AS
//(	select A1.* FROM (SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier)  A1 INNER JOIN 
//		(
//			SELECT code FROM student WHERE classcode=@classcode
//		) A2 ON A1.studentcode=A2.code
//)
//-- B Cac khoa hoc trong khoang
//,courseinfo AS
//(
//	SELECT B1.*, B2.credit FROM 
//		(
//			select * from course 
//		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
//)
//-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//,studentsummark AS
//(
//SELECT E.studentcode, SUM(convert(float,'0'+isnull(E.mark10,''))) summark, sum(D.credit) sumcredit FROM mark E INNER JOIN 
//	(
//		select studentcode, right(coursecodecom,len(coursecodecom)-5) coursecode, credit from 
//		(
//			select A.studentcode, B.subjectcode, min(convert(varchar,B.[year]*10+ B.term)+B.code) coursecodecom, COUNT(*) coursecount, MAX(B.credit)  credit
//				from 	studentlearncourse  A 
//					inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//		) C 
//	)D 
//	ON E.studentcode=D.studentcode AND E.coursecode=D.coursecode 
//GROUP BY E.studentcode
//)
//-- Thong tin các sinh vien
//, studentinfo AS
//(
//	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//)
//-- All
//select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
//";
//            }
//            else
//            {
//                //the max mark on the subjects
//                sql = @"
//with studentlearncourse  AS
//(	select A1.* FROM 
//	(
//		SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=@markbarrier
//	) A1 INNER JOIN 
//		(
//			SELECT code FROM student WHERE classcode=@classcode
//		) A2 ON A1.studentcode=A2.code
//)
//-- B Cac khoa hoc trong khoang
//,courseinfo AS
//(
//	SELECT B1.*, B2.credit FROM 
//		(
//			select * from course 
//		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>@learningtypecode)  B2 ON B1.subjectcode=B2.code
//)
//-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//,studentsummark AS
//(
//	select studentcode, sum(mark) summark, sum(credit) sumcredit from 
//	(
//		select A.studentcode, B.subjectcode, max(convert(float,'0'+isnull(A.mark10,''))) mark, COUNT(*) coursecount, MAX(B.credit)  credit
//			from 	studentlearncourse  A 
//				inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//	) C 
//	GROUP BY studentcode
//)
//--Thong tin sinh vien
//, studentinfo AS
//(
//	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//)
//--ALL
//select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode
//";
//            }
//            List<fieldpara> li = new List<fieldpara>();
//            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0));
//            li.Add(new fieldpara("learningtypecode", learningType, SqlDbType.VarChar, 0));
//            li.Add(new fieldpara("markbarrier", markbarrier, SqlDbType.Float, 0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
//        }
        public int search(ref DataSet ds, string tableName, string educationlevel, string gradecode, string classcode, string codeview, string name, string personalid, string staffcode)
        {
            int ret = 0;
            string sql = @"select A.*,B.code classcode, B.codeview classcodeview, B.name classname,C.code gradecode, C.codeview gradecodeview, c.name gradename,d.code educationlevelcode, d.codeview educationlevelcodeview, d.name educationlevelname 
            from student A inner join 
            (SELECT A1.* FROM class A1 INNER JOIN classstaff A2 ON A1.code=A2.classcode WHERE A2.staffcode=@staffcode) B on A.classcode=B.code 
            inner join grade C on B.gradecode=C.code 
            INNER JOIN educationlevel D ON C.educationlevelcode=D.code";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("staffcode", staffcode, SqlDbType.VarChar, 0, 0));
            if (educationlevel != "")
            {
                li.Add(new fieldpara("D.code", educationlevel, SqlDbType.VarChar, 0, 1));
            }
            if (gradecode != "")
            {
                li.Add(new fieldpara("C.code", gradecode, SqlDbType.VarChar, 0, 1));
            }
            if (classcode != "")
            {
                li.Add(new fieldpara("B.code", classcode, SqlDbType.VarChar, 0, 1));
            }
            if (codeview != "")
            {
                li.Add(new fieldpara("A.codeview", codeview, SqlDbType.VarChar, 1, 1));
            }
            if (name != "")
            {
                li.Add(new fieldpara("A.name", name, SqlDbType.NVarChar, 1, 1));
            }
            if (personalid != "")
            {
                li.Add(new fieldpara("A.idnumber", personalid, SqlDbType.VarChar, 1, 1));
            }
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        public int moveClass(string classCode, List<string> student)
        {
            int ret = 0;
            string sql = "";
            BeginTransaction();
            foreach (string item in student)
            {

                sql = "UPDATE student SET classcode=@classcode WHERE code=@code";
                List<fieldpara> li = new List<fieldpara>();
                li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0, 0));
                li.Add(new fieldpara("code", item, SqlDbType.VarChar, 0, 0));
                ret = doQuery(sql, li);
                if (ret < 0)
                {
                    break;
                }
            }
            if (ret >= 0)
            {
                CommitTransaction();
            }
            else
            {
                RollbackTransaction();
            }
            return ret;
        }
        public string encrypt(string username, string userpass)
        {
            string t = "";
            string ac = "ITMS-HVKTQS";
            MaHoa sec = new MaHoa();
            t = sec.Encrypt(ac, username + "WEB" + userpass);
            return t;
        }
        /// <summary>
        /// Đăng nhập của sinh viên
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="curObj"></param>
        /// <param name="loginFuncs"></param>
        /// <returns></returns>
        public int login(STUDENT_OBJ obj, out STUDENT_OBJ curObj, out List<STAFFPRIORITY> lipermission )
        {
            int ret = 0;
            STUDENT_OBJ obj_priv = null;
            string tempFuncs = "";
            List<STAFFPRIORITY> lp = new List<STAFFPRIORITY>();
            lipermission = lp;
            curObj = null;
            DataSet ds = new DataSet();
            obj_priv = GetByKey(new fieldpara("CODEVIEW", obj.CODEVIEW),
                            new fieldpara("USERPASSWORD", encrypt(obj.CODEVIEW, obj.USERPASSWORD)));
            if (obj_priv == null)
            {
                return -1;
            }
            //check lock status
            if (obj_priv.LOCK == 1)
            {
                return -2;
            }
            curObj = obj_priv;//SINHVIEN
            if (ret >= 0)
            {
                //Assign permission
                //STULEARN
                STAFFPRIORITY obj_temp = new STAFFPRIORITY();
                if (ret >= 0)
                {
                    obj_temp.THECODE = obj_priv.CLASSCODE;
                    //                obj_temp.EDITTIME = DateTime.Now;
                    //                obj_temp.EDITUSER = "";
                    obj_temp.FUNC = 15;
                    obj_temp.INHERIT = 1;
                    //obj_temp.LOCK = 0;
                    obj_temp.PRIORITYCODE = "STULEARN";
                    obj_temp.STAFFCODE = obj_priv.CODE;
                    //                obj_temp.WHOIS = "";
                    obj_temp.AUTHEN = 0;
                    lipermission.Add(obj_temp);

                }
            }
            //            ADMINGROUPPRIORITY_BUS bus = new ADMINGROUPPRIORITY_BUS();
            //            List<ADMINGROUPPRIORITY_OBJ> li_admingrouppriority;
            //            li_admingrouppriority = bus.getAllBy("objectcode", new fieldpara("OBJECTCODE","STUDENT"), new fieldpara("THETYPE", "ADMINGROUPPRIORITY"));//default group for student is SINHVIEN
            //            bus.CloseConnection();
            //            foreach(ADMINGROUPPRIORITY_OBJ obj_admingroup in li_admingrouppriority)
            //            {
            //                //add
            //                obj_temp = new STAFFPRIORITY();
            //                //obj_temp.DEPARTMENTCODE = obj_priv.CLASSCODE;
            //                //obj_temp.EDITTIME = DateTime.Now;
            //                //obj_temp.EDITUSER = "";
            //                obj_temp.FUNC = obj_admingroup.FUNC;
            //                obj_temp.INHERIT = 1;
            //                //obj_temp.LOCK = 0;
            //                obj_temp.PRIORITYCODE = obj_admingroup.PRIORITYCODE;
            //                obj_temp.STAFFCODE = obj_priv.CODE;
            //                //obj_temp.WHOIS = "";
            //                obj_temp.AUTHEN = 1;
            //                lipermission.Add(obj_temp);
            //            }
            //get special priority function for staff
            //STAFFPRIORITY_BUS bus_stap = new STAFFPRIORITY_BUS();
            //if (bus_stap.getAllBy(ref ds, "userpriority", new fieldpara("STAFFCODE", obj_priv.CODE)) >= 0)
            //{
            //    foreach (DataRow dr in ds.Tables["userpriority"].Rows)
            //    {
            //        if (tempFuncs != "")
            //        {
            //            tempFuncs += ";";
            //        }
            //        tempFuncs += dr["prioritycode"].ToString();
            //    }

            //}
            //DEPARTMENTPRIORITY_BUS bus_depp = new DEPARTMENTPRIORITY_BUS();
            //if (bus_depp.getAllBy(ref ds, "departmentpriority", new fieldpara("DEPARTMENTCODE", obj_priv.DEPARTMENTCODE)) >= 0)
            //{
            //    foreach (DataRow dr in ds.Tables["departmentpriority"].Rows)
            //    {
            //        if (tempFuncs != "")
            //        {
            //            tempFuncs += ";";
            //        }
            //        tempFuncs += dr["prioritycode"].ToString();
            //    }

            //}

            //priority for group
            //            List<fieldpara> li = new List<fieldpara>();
            //            li.Add(new fieldpara("STAFFCODE", obj_priv.CODE, SqlDbType.VarChar, 0, 0));
            //            sql = @"select distinct B.prioritycode FROM 
            //                (select * from staffadmingroup where staffcode=@staffcode) A INNER JOIN
            //                (SELECT [admingroupcode],[prioritycode],[func] FROM [admingrouppriority]) B
            //                ON A.admingroupcode=B.admingroupcode";
            //            if (getByQuery(ref ds, "prioritygroup", sql, li) >= 0)
            //            {
            //                foreach (DataRow dr in ds.Tables["prioritygroup"].Rows)
            //                {
            //                    if (tempFuncs != "")
            //                    {
            //                        tempFuncs += ";";
            //                    }
            //                    tempFuncs += dr["prioritycode"].ToString();
            //                }
            //            }
            //            loginFuncs = tempFuncs;
            return 0;
        }
        public int changePass(string loginName, string oldPass, string newPass)
        {
            oldPass = encrypt(loginName, oldPass);
            newPass = encrypt(loginName, newPass);
//            STAFF_BUS bus = new STAFF_BUS();
            STUDENT_OBJ obj = GetByKey(new fieldpara("CODEVIEW", loginName), new fieldpara("USERPASSWORD", oldPass));
            if (obj == null)
                return -1;
            obj.USERPASSWORD = newPass;
            obj.CHANGEPASS = 0;
            obj._ID.CODE = obj.CODE;
            string[] field = { "USERPASSWORD", "CHANGEPASS" };
            if (Update(field, obj) < 0)
            {
                return -2;
            }
            return 0;
        }
        public int studentfee(ref DataSet ds, string tableName, string classcode)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode",classcode));
            ret =storedProcedure(ref ds, tableName, "studentfee", li);
            return ret;
        }

        public int studyAllStaff(ref DataSet ds, string tableName, string departmentCode, string orderby)
        {
            string sql = "select staff.code, staff.name, armyrank.name armyrankname,"+
                        "leveltitle.name leveltitlename, department.name subdepartmentname, "+
                        "academictitle.name academictitlename, degree.name degreename "+
                        "from staff "+
                        "left outer join armyrank on staff.armyrankcode = armyrank.code "+
                        "left outer join leveltitle on staff.leveltitlecode = leveltitle.code "+
                        "left outer join department on right(staff.codeview,3) = department.code "+
                        "left outer join degree on staff.degreecode = degree.code "+
                        "left outer join academictitle on staff.academictitlecode = academictitle.code "+
                        "WHERE departmentcode=@departmentCode ";
            if (orderby != "")
            {
                sql = sql + " ORDER BY " + orderby;
            }
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("departmentCode", departmentCode, SqlDbType.VarChar, 0, 0));
            int ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        public int studyAllStat(ref DataSet ds, string tableName, string classCode, string orderby)
        {
            string sql="SELECT codeview, name, 1 TB1,2 TB2,'' TB3,null TB4, null TB5, 1 recount,1 TBHP,'' TN1,'' TN2,'' TN3,'' TN4,'' PLRL,'' DTBC,'' PLTN FROM student WHERE classcode=@classcode ";
            if (orderby != "")
            {
                sql = sql + " ORDER BY " + orderby;
            }
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0, 0));
            int ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// get all student information, included: educationtype, educationfield
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public int studentInfo(ref DataSet ds, string tableName, string classCode, string studentcode, int year, int term, int pass, int notfull)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classCode));
            li.Add(new fieldpara("studentcode", studentcode));
            li.Add(new fieldpara("year", year, SqlDbType.Int,0));
            li.Add(new fieldpara("term", term, SqlDbType.Int, 0));
            li.Add(new fieldpara("pass", pass, SqlDbType.Int, 0));
            li.Add(new fieldpara("notfullmark", notfull, SqlDbType.Int, 0));
            ret = storedProcedure(ref ds, tableName, "learnstudentinfo", li);
            return ret;

//            int ret=0;
////            string sql = @"select A.code, a.codeview, a.name, a.note, a.birthday, A.sex, C.code educationtypecode, c.codeview educationtypecodeview, c.name educationtypename, D.code educationfieldcode, D.codeview educationfieldcodeview, D.name educationfieldname from student A 
////LEFT JOIN educationtypestudent B ON A.code = B.studentcode          
////LEFT JOIN educationtype C ON B.educationtypecode= C.code
////LEFT JOIN educationfield D On C.educationfieldcode=D.code
////where A.classcode=@classcode
////";
//            string sql = @"with studentlearncourse  AS
//(	select A1.* FROM 
//	(
//		SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=0
//	) A1 INNER JOIN 
//		(
//			SELECT code FROM student WHERE classcode=@classcode
//		) A2 ON A1.studentcode=A2.code
//)
//-- B Cac khoa hoc trong khoang
//,courseinfo AS
//(
//	SELECT B1.*, B2.credit FROM 
//		(
//			select * from course 
//		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>'DKTQ')  B2 ON B1.subjectcode=B2.code
//)
//-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//,studentsummark AS
//(
//	select studentcode, sum(mark*credit) summark, sum(mark4*credit) summark4, sum(credit) sumcredit from 
//	(
//		select A.studentcode, B.subjectcode, max(convert(float,'0'+isnull(A.mark10,''))) mark,max(convert(float,'0'+isnull(A.mark4,''))) mark4, COUNT(*) coursecount, MAX(B.credit)  credit
//			from 	studentlearncourse  A 
//				inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//	) C 
//	GROUP BY studentcode
//)
//--Thong tin sinh vien
//, studentinfo AS
//(
//	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//)
//--ALL
//select A.code, a.codeview, a.name, a.note, a.birthday, A.sex, A.summark, A.summark4, a.sumcredit, C.code educationtypecode, c.codeview educationtypecodeview, c.name educationtypename, D.code educationfieldcode, D.codeview educationfieldcodeview, D.name educationfieldname FROM 
//(
//select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode 
//) A 
//LEFT JOIN educationtypestudent B ON A.code = B.studentcode          
//LEFT JOIN educationtype C ON B.educationtypecode= C.code
//LEFT JOIN educationfield D On C.educationfieldcode=D.code";
//            List<fieldpara> li = new List<fieldpara>();
//            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0, 0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
        }
        /// <summary>
        /// Student information
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="classCode"></param>
        /// <param name="?"></param>
        /// <returns></returns>
//        public int studentInfoPersonal(ref DataSet ds, string tableName, string classCode, string studentCode)
//        {
//            int ret = 0;
//            //            string sql = @"select A.code, a.codeview, a.name, a.note, a.birthday, A.sex, C.code educationtypecode, c.codeview educationtypecodeview, c.name educationtypename, D.code educationfieldcode, D.codeview educationfieldcodeview, D.name educationfieldname from student A 
//            //LEFT JOIN educationtypestudent B ON A.code = B.studentcode          
//            //LEFT JOIN educationtype C ON B.educationtypecode= C.code
//            //LEFT JOIN educationfield D On C.educationfieldcode=D.code
//            //where A.classcode=@classcode
//            //";
//            string sql = @"with studentlearncourse  AS
//(	select A1.* FROM 
//	(
//		SELECT * FROM mark WHERE ISNUMERIC(isnull(markthi,'')+'0')=1 AND convert(float,'0'+isnull(mark10,''))>=0
//	) A1 INNER JOIN 
//		(
//			SELECT code FROM student WHERE classcode=@classcode AND code=@studentcode
//		) A2 ON A1.studentcode=A2.code
//)
//-- B Cac khoa hoc trong khoang
//,courseinfo AS
//(
//	SELECT B1.*, B2.credit FROM 
//		(
//			select * from course 
//		) B1 INNER JOIN (SELECT * FROM subject where learningtypecode<>'DKTQ')  B2 ON B1.subjectcode=B2.code
//)
//-- C tat ca mon hoc can phai tinh cho sinh vien trong lop
//,studentsummark AS
//(
//	select studentcode, sum(mark*credit) summark, sum(mark4*credit) summark4, sum(credit) sumcredit from 
//	(
//		select A.studentcode, B.subjectcode, max(convert(float,'0'+isnull(A.mark10,''))) mark,max(convert(float,'0'+isnull(A.mark4,''))) mark4, COUNT(*) coursecount, MAX(B.credit)  credit
//			from 	studentlearncourse  A 
//				inner join courseinfo B ON A.coursecode=B.code	group by A.studentcode, B.subjectcode
//	) C 
//	GROUP BY studentcode
//)
//--Thong tin sinh vien
//, studentinfo AS
//(
//	SELECT K1.*, K2.codeview classcodeview, K2.name classname FROM (SELECT * FROM student WHERE classcode=@classcode) K1 INNER JOIN class K2 ON K1.classcode=K2.code
//)
//--ALL
//select A.code, a.codeview, a.name, a.note, a.birthday, A.sex, A.summark, A.summark4, a.sumcredit, C.code educationtypecode, c.codeview educationtypecodeview, c.name educationtypename, D.code educationfieldcode, D.codeview educationfieldcodeview, D.name educationfieldname FROM 
//(
//select H1.*, H2.* from studentinfo H1 INNER JOIN studentsummark H2 ON H1.code=H2.studentcode 
//) A 
//LEFT JOIN educationtypestudent B ON A.code = B.studentcode          
//LEFT JOIN educationtype C ON B.educationtypecode= C.code
//LEFT JOIN educationfield D On C.educationfieldcode=D.code";
//            List<fieldpara> li = new List<fieldpara>();
//            li.Add(new fieldpara("classcode", classCode, SqlDbType.VarChar, 0, 0));
//            li.Add(new fieldpara("studentcode", studentCode, SqlDbType.VarChar, 0, 0));
//            ret = getByQuery(ref ds, tableName, sql, li);
//            return ret;
//        }
        /// <summary>
        /// get grade code of a student
        /// </summary>
        /// <param name="studentcode"></param>
        /// <param name="gradecodeview"></param>
        /// <returns></returns>
        public int getGrade(string studentcode, out string gradecodeview)
        {
            int ret = -1;
            gradecodeview = "";
            DataSet ds = new DataSet();
            string sql = "select c.codeview from student A INNER JOIN class B ON A.classcode=B.code INNER JOIN grade C ON B.gradecode=C.code WHERE A.code=@studentcode";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("studentcode", studentcode, SqlDbType.VarChar, 0));
            ret = getByQuery(ref ds, "gr", sql, li);
            if (ret < 0)
            {
                return ret;
            }
            if (ds.Tables["gr"].Rows.Count < 1)
            {
                return -2;
            }
            Comm.CommonLib com = new Comm.CommonLib();
            gradecodeview = com.string4Row(ds.Tables["gr"].Rows[0], "codeview", "");
            ds.Dispose();
            return ret;
        }
        /// <summary>
        /// Thiết lập lại mật khẩu cho sinh  viên của lớp theo tên đăng nhập
        /// </summary>
        /// <param name="classcode"></param>
        /// <returns></returns>
        public int studentSetPass(string classcode)
        {
            List<STUDENT_OBJ> li = getAllBy2(new fieldpara("classcode", classcode));
            foreach(STUDENT_OBJ obj in li)
            {
                obj.USERPASSWORD = encrypt(obj.CODEVIEW, obj.CODEVIEW);
            }
            string[] f = { "USERPASSWORD" };
            int ret = UpdateMultiItems(f, li);
            return ret;
        }

        public int SetPass(STUDENT_OBJ obj, string password)
        {
            string passwordnew = encrypt(obj.CODEVIEW, password);
            obj.USERPASSWORD = passwordnew;
            obj.CHANGEPASS = 1;
            obj._ID.CODE = obj.CODE;
            string[] field = { "USERPASSWORD", "CHANGEPASS"};
            if (Update(field, obj) < 0)
            {
                return -2;
            }
            return 0;
        }

        public int GetAllCourse(ref DataSet ds, string tableName, STUDENT_OBJ obj)
        {
            string sql = @"select a.code code, a.subjectcode, a.coursecode, b.name, d.sobai,d.sobai-c.sobaichuahoc as sobaidahoc , c.sobaichuahoc
                        from mark a 
                        inner join subject b on a.subjectcode=b.code
                        inner join
                        (
	                        select a.subjectcode, COUNT(*) sobaichuahoc
	                        from subjectcontent a
	                        left join coursestudied b on a.code=b.subjectcontentcode
	                        where (1=1)
		                        --and (a.subjectcode='1708300001')
		                        and (isnull(a.parentcode,'')='')
		                        and (b.subjectcontentcode is null)
	                        group by a.subjectcode
                        ) c on b.code = c.subjectcode
                        inner join
                        (
	                        select a.subjectcode, COUNT(*) sobai
	                        from subjectcontent a
	                        where (1=1)
		                        --and (a.subjectcode='1708300001')
		                        and (isnull(a.parentcode,'')='')
	                        group by a.subjectcode
                        ) d on b.code = d.subjectcode
                        where a.studentcode='" + obj.CODE.ToString() + @"'
                        order by b.code";
            List<fieldpara> li = new List<fieldpara>();
            int ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        public int getByExamhall(ref DataSet ds, string examhallcode)
        {
            int ret = 0;
            string sql = @"select C.code code,A.codeview codeview, A.name name, A.birthday , C.realbegintime, C.realendtime, C.code examformcode, C.lock, C.finalendtime from student A
                            inner join mark B on A.code = B.studentcode
                            inner join examhallstudent C on B.code = C.markcode
                            where examhallcode = @examhallcode";
            // Nếu muốn select thêm trường nào thì thêm vào cuối, tránh ảnh hưởng tới việc lấy dữ liệu được get ở chỗ khác
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("examhallcode", examhallcode, 0, (int)searchType.NONE));
            ret = getByQuery(ref ds, "examhallstudent", sql, li);
            return ret;
        }
        /// <summary>
        /// Lấy danh sách sinh viên theo mã của phòng thi, dùng bên quản lý
        /// </summary>
        /// <param name="examhallcode">Mã của phong thi</param>
        /// <returns></returns>
        public int getByExamhallManage(ref DataSet ds, string examhallcode)
        {
            int ret = 0;
            string sql = @"select C.code code,A.codeview codeview, A.name name, A.birthday , D.name examformname, C.realbegintime, C.realendtime, C.code examformcode, C.lock, C.finalendtime from student A
                            inner join mark B on A.code = B.studentcode
                            inner join examhallstudent C on B.code = C.markcode
                            inner join examform D on C.examformcode = D.code
                            where examhallcode = @examhallcode";
            // Nếu muốn select thêm trường nào thì thêm vào cuối, tránh ảnh hưởng tới việc lấy dữ liệu được get ở chỗ khác
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("examhallcode", examhallcode,  0, (int)searchType.NONE));
            ret = getByQuery(ref ds, "examhallstudent", sql, li);
            return ret;
        }
        public List<STUDENT_OBJ> getByExamtime(string examtimecode)
        {
            int ret = 0;
            DataSet ds = new DataSet();
            string sql = @"select A.*, C.code exhallstdcode from student A 
INNER JOIN mark B ON A.code=B.studentcode
INNER JOIN examhallstudent C ON C.markcode = B.code
where C.examtimecode = @examtimecode";
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("examtimecode", examtimecode, 0, (int)searchType.NONE));
            ret = getByQuery(ref ds, "bang", sql, lipa);
            List<STUDENT_OBJ> li = new List<STUDENT_OBJ>();
            if (ret >= 0)
            {
                foreach (DataRow dr in ds.Tables["bang"].Rows)
                {
                    STUDENT_OBJ obj = createObjectFromRow(dr);
                    obj.CODE = dr["exhallstdcode"].ToString(); // dùng cái này trong examhallstudentcode
                    li.Add(obj);
                }
            }
            return li;
        }
        public int GetAllMark(ref DataSet ds, string tableName, STUDENT_OBJ obj)
        {
            string sql = @"select
				                 a.examtimecode
				                ,m.code
				                ,b.name
				                ,d.sodiem 
				                ,m.mark10
                            from examhallstudent a 
				                inner join examtime b on a.examtimecode=b.code
				                inner join teststruct c on b.teststructcode=c.code
                                inner join
                                        (
                                            select a.teststructcode, sum(a.totalmark) sodiem
	                                        from teststructdetail a
	                                        where (1=1)
	                                        group by a.teststructcode
                                        ) d on d.teststructcode = c.code
                                inner join mark m on a.markcode=m.code
                            where m.studentcode='" + obj.CODE.ToString() + @"'
                            order by m.code";
            List<fieldpara> li = new List<fieldpara>();
            int ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
    }
    

}

