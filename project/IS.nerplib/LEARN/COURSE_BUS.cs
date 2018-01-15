using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
using IS.localcomm;
namespace IS.uni
{
    public class COURSE_BUS : BusinessController<COURSE_OBJ, COURSE_OBJ.BusinessObjectID>
    {
        localcommonlib com = new localcommonlib();
        public COURSE_BUS()
        {
        }
        public override COURSE_OBJ createObject()
        {
            COURSE_OBJ obj = new COURSE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override COURSE_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Get all reexam student and their subject, met requirement; Return number of page
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="educationlevelCode"></param>
        /// <param name="gradeCode"></param>
        /// <param name="classCode"></param>
        /// <param name="studentCode"></param>
        /// <param name="term"></param>
        /// <param name="year"></param>
        /// <param name="itemInPage">number item in page</param>
        /// <returns></returns>
        public int getAllReexamEx(ref DataSet ds, string tableName, string educationlevelCode, string gradeCode, string classCode, string studentCode, int term, int year, int itemInPage)
        {
            int ret = 0;

            return ret;
        }
        public int getAllReexam(ref DataSet ds, string tableName, string educationlevelCode, string studentname, string subjectname, string classname)
        {
            int ret = 0;
            string sql =
@"with reexamstuden as
(
select C.studentcode, c.subjectcode, max(isnull(mark10,'')) mark10, max(markTHI) markthi, MAX(isnull(mark4,'')) mark4, COUNT(code) counttime, MAX(yearterm) yearterm FROM 
(
select a.code, A.studentcode, B.subjectcode, a.mark10, a.mark4, a.markTHI, case
	when ltrim(isnull(markthi,''))='' then 1
	when ISNUMERIC('0'+ltrim(ISNULL(markthi,'')))=1 then
		case 
			when convert(float,'0'+ltrim(isnull(mark10,'')))<4 then 0
			else
				1
		end
	else
		2
end pass, isnull(B.term,1) + 10*isnull(B.year,1) yearterm from mark A inner join (SELECT * FROM course WHERE educationlevelcode=@educationlevelcode) B on A.coursecode=B.code
) C group by C.studentcode, c.subjectcode 
having MAX(pass)=0
)
,reexamstudentcredit as
(
	select A.studentcode, sum(B.credit) credit, count(*) countsubject from reexamstuden A INNER JOIN (SELECT * FROM subject WHERE educationlevelcode=@educationlevelcode) B ON A.subjectcode=B.code
	GROUP BY A.studentcode
)
,studentcredit as
(
	SELECT BB.studentcode, sum(AA.credit) credit FROM (SELECT * FROM subject WHERE educationlevelcode=@educationlevelcode) AA INNER JOIN
  (	
   SELECT distinct A.studentcode, B.subjectcode FROM mark A INNER JOIN (SELECT * FROM course WHERE educationlevelcode=@educationlevelcode) B 
		ON A.coursecode=B.code
  )
	BB ON AA.code = BB.subjectcode
  GROUP BY BB.studentcode
  
)
, thelist as
(
select d.subjectcode, k.codeview subjectcodeview, K.name subjectname, E.code, E.codeview, E.name, E.classcode, F.codeview classcodeview, F.name classname, E.birthday, D.markTHI, D.mark10, D.mark4, D.counttime, d.yearterm %10 term, d.yearterm /10 year, G.credit reexamcredit, H.credit sumcredit, G.credit*100.0/ H.credit creditpercent, G.countsubject, K.credit from (SELECT * FROM reexamstuden ) D 
inner join student E ON D.studentcode=E.code 
INNER JOIN class F ON E.classcode=F.code 
INNER JOIN subject K ON d.subjectcode=K.code
LEFT JOIN reexamstudentcredit G ON D.studentcode= G.studentcode
LEFT JOIN studentcredit H ON D.studentcode= H.studentcode
)
select * from thelist";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("educationlevelcode", educationlevelCode, SqlDbType.VarChar, 0, 0));
            if (studentname != "")
            {
                //search for student name
                li.Add(new fieldpara("name", studentname, SqlDbType.NVarChar, 1, 1));
            }
            if (subjectname != "")
            {
                //search for student name
                li.Add(new fieldpara("subjectname", subjectname, SqlDbType.NVarChar, 1, 1));
            }
            if (classname != "")
            {
                //search for student name
                li.Add(new fieldpara("classname", classname, SqlDbType.NVarChar, 1, 1));
            }
            ret = getByQuery(ref ds, tableName, sql, " classcodeview, dbo.TENHO(name) ", li);
            return ret;
        }
        public int getAllCourseClasstime(ref DataSet ds, string tableName, string educationlevelcode
            , int year, int term, string departmentcode, string staffcode, string codeview, string staffname, string subjectname, int reexam)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("EDUCATIONLEVELCODE", educationlevelcode, SqlDbType.VarChar, 0));
            li.Add(new fieldpara("YEAR", year, SqlDbType.Int, year));
            li.Add(new fieldpara("TERM", term, SqlDbType.Int, term));
            if (codeview != "")
            {
                li.Add(new fieldpara("A.CODEVIEW", codeview, SqlDbType.VarChar, 1, 1));
            }
            if (staffname != "")
            {
                li.Add(new fieldpara("C.NAME", staffname, SqlDbType.NVarChar, 1, 1));
            }
            if (subjectname != "")
            {
                li.Add(new fieldpara("B.NAME", subjectname, SqlDbType.NVarChar, 1, 1));
            }
            if (departmentcode != "")
            {
                li.Add(new fieldpara("C.DEPARTMENTCODE", departmentcode, SqlDbType.VarChar, 0, 1));
            }
            if (staffcode != "")
            {
                li.Add(new fieldpara("C.CODE", staffcode, SqlDbType.VarChar, 0, 1));
            }
            if (reexam != 2)
            {
                li.Add(new fieldpara("A.REEXAM", reexam, SqlDbType.Int, 0, 1));
            }
            string sql = @"select A.*, B.name  subjectname, C.name  staffname, D.name hallname, D.codeview hallcodeview , isnull(E.classtime,0) classtime, B.credit
                        from (select * from course where educationlevelcode=@educationlevelcode AND [year] = @year AND term=@term) A 
                                INNER JOIN subject B on a.subjectcode = B.code 
                                INNER JOIN staff C ON A.staffcode=C.code 
                                INNER JOIN hall D ON A.hallcode=D.code
                                LEFT JOIN 
                                (select coursecode, SUM(periodend-periodbegin+1) classtime from teachingschedule where year=@year and term=@term and educationlevelcode=@educationlevelcode group by coursecode) E
                                ON A.code=E.coursecode ";
            ret = this.getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// get all course with search option
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="educationlevelcode"></param>
        /// <param name="year"></param>
        /// <param name="term"></param>
        /// <param name="departmentcode"></param>
        /// <param name="staffcode"></param>
        /// <param name="codeview"></param>
        /// <param name="staffname"></param>
        /// <param name="subjectname"></param>
        /// <param name="reexam"></param>
        /// <returns></returns>
        public int getAllCourse(ref DataSet ds, string tableName, string educationlevelcode
            , int year, int term, string departmentcode, string staffcode, string codeview, string staffname, string subjectname, int reexam)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("EDUCATIONLEVELCODE", educationlevelcode, SqlDbType.VarChar, 0));
            li.Add(new fieldpara("YEAR", year, SqlDbType.Int, year));
            li.Add(new fieldpara("TERM", term, SqlDbType.Int, term));
            if (codeview != "")
            {
                li.Add(new fieldpara("A.CODEVIEW", codeview, SqlDbType.VarChar, 1, 1));
            }
            if (staffname != "")
            {
                li.Add(new fieldpara("C.NAME", staffname, SqlDbType.NVarChar, 1, 1));
            }
            if (subjectname != "")
            {
                li.Add(new fieldpara("B.NAME", subjectname, SqlDbType.NVarChar, 1, 1));
            }
            if (departmentcode != "")
            {
                li.Add(new fieldpara("C.DEPARTMENTCODE", departmentcode, SqlDbType.VarChar, 0, 1));
            }
            if (staffcode != "")
            {
                li.Add(new fieldpara("C.CODE", staffcode, SqlDbType.VarChar, 0, 1));
            }
            if (reexam != 2)
            {
                li.Add(new fieldpara("A.REEXAM", reexam, SqlDbType.Int, 0, 1));
            }
            string sql = @"select A.*, B.name  subjectname, C.name  staffname, D.name hallname, D.codeview hallcodeview , B.credit
                        from (select * from course where educationlevelcode=@educationlevelcode AND [year] = @year AND term=@term) A 
                                INNER JOIN subject B on a.subjectcode = B.code 
                                INNER JOIN staff C ON A.staffcode=C.code 
                                INNER JOIN hall D ON A.hallcode=D.code";
            ret = this.getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        public int getAllCourseRecode(ref DataSet ds, string tableName, string educationlevelcode
            , int year, int term, string departmentcode, string staffcode, string codeview, string staffname, string subjectname, int reexam)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("EDUCATIONLEVELCODE", educationlevelcode, SqlDbType.VarChar, 0));
            li.Add(new fieldpara("YEAR", year, SqlDbType.Int, year));
            li.Add(new fieldpara("TERM", term, SqlDbType.Int, term));
            if (codeview != "")
            {
                li.Add(new fieldpara("A.CODEVIEW", codeview, SqlDbType.VarChar, 1, 1));
            }
            if (staffname != "")
            {
                li.Add(new fieldpara("C.NAME", staffname, SqlDbType.NVarChar, 1, 1));
            }
            if (subjectname != "")
            {
                li.Add(new fieldpara("B.NAME", subjectname, SqlDbType.NVarChar, 1, 1));
            }
            if (departmentcode != "")
            {
                li.Add(new fieldpara("C.DEPARTMENTCODE", departmentcode, SqlDbType.VarChar, 0, 1));
            }
            if (staffcode != "")
            {
                li.Add(new fieldpara("C.CODE", staffcode, SqlDbType.VarChar, 0, 1));
            }
            if (reexam != 2)
            {
                li.Add(new fieldpara("A.REEXAM", reexam, SqlDbType.Int, 0, 1));
            }
            string sql = @"select A.*, E.countstudent-E.countrecode recodeyet, B.name  subjectname, C.name  staffname, D.name hallname, D.codeview hallcodeview 
                        from (select * from course where educationlevelcode=@educationlevelcode AND [year] = @year AND term=@term) A 
                                INNER JOIN subject B on a.subjectcode = B.code 
                                INNER JOIN staff C ON A.staffcode=C.code 
                                INNER JOIN hall D ON A.hallcode=D.code
                                INNER JOIN 
                                (
                                SELECT A.code, COUNT(B.code) countstudent, 
SUM(
CASE
     WHEN ISNULL(B.name,'')='' THEN 0 
     ELSE 1 
END
) countrecode
  FROM 
(                                
select * from course where educationlevelcode=@educationlevelcode AND [year] = @year AND term=@term                                
) A
 INNER JOIN mark B
 ON A.code=B.coursecode
GROUP BY A.code
) E
ON A.code=E.code";
            ret = this.getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        public int getCourseInfo(ref DataSet ds, string tableName, string courseCode)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("COURSECODE", courseCode, SqlDbType.VarChar, 0));
            string sql = @"select A.*,B.name subjectname, B.classperiod, B.credit, c.name staffname, c.departmentcode staffdepartmentcode, d.name hallname from (select * from course where code =@coursecode) A Inner join subject B ON A.subjectcode=B.code INNER JOIN staff C ON A.staffcode=C.code INNER JOIN hall D ON A.hallcode=D.code";
            ret = this.getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        public int updateCourseStudent(string courseCode)
        {
            int ret = 0;
            string sql = "update course set studentamount= (select COUNT(*) from mark where coursecode=@coursecode) where code=@coursecode";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("coursecode", courseCode, SqlDbType.VarChar, 0));
            this.doQuery(sql, li); //UYENNM_ERROR
            return ret;
        }
        public int checkOwner(string departmentcode, string staffcode, string coursecode)
        {
            int ret = 0;
            DataSet ds = new DataSet();
            string sql = @"select * from 
(
select A.*, B.departmentcode from course A
inner join staff B ON A.staffcode=B.code where A.code=@code
)
C ";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("CODE", coursecode, SqlDbType.VarChar, 0));
            if (departmentcode != "")
            {
                li.Add(new fieldpara("DEPARTMENTCODE", departmentcode, SqlDbType.VarChar, 1));
            }
            if (staffcode != "")
            {
                li.Add(new fieldpara("STAFFCODE", staffcode, SqlDbType.VarChar, 1));
            }
            ret = getByQuery(ref ds, "checkpermission", sql, li);
            if (ret < 0)
            {
                return -1;
            }
            if (ds.Tables["checkpermission"].Rows.Count != 1)
            {
                return -2;
            }
            return 0;
        }
        public int getStudentCourse(ref DataSet ds, string tableName, string studentcode, int term, int year)
        {
            int ret = 0;
            string sql = @"SELECT F.*, E.* FROM subject F INNER JOIN 
(
	 SELECT A.code markcode,  B.code coursecode, B.codeview coursecodeview, B.subjectcode , B.staffcode, D.name staffname, C.codeview hallcodeview, c.name hallname FROM 
	(select code, coursecode from mark where studentcode=@studentcode) A
	INNER JOIN 
	(select * from course where [year]=@year and term=@term) B
	ON A.coursecode=B.code
	LEFT JOIN hall C
	ON B.hallcode=C.code
	INNER JOIN staff D 
	ON B.staffcode=D.code
)
E
ON E.subjectcode=F.code ";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("studentcode", studentcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("term", term, SqlDbType.Int, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        public int getStudentCourseNominated(ref DataSet ds, string tableName, string studentcode, int term, int year, string staffname, string subjectname)
        {
            int ret = 0;
            string sql = @"SELECT F.*, E.* FROM subject F INNER JOIN 
(
	 SELECT B.code coursecode, B.subjectcode, B.codeview coursecodeview, D.name staffname, c.codeview hallcodeview, c.name hallname FROM 
	(	select a.* from (SELECT * FROM course where year=@year AND term=@term) A where code not in 
			(
				select coursecode from mark where studentcode=@studentcode
			)
	) B
	LEFT JOIN hall C
	ON B.hallcode=C.code
	INNER JOIN staff D 
	ON B.staffcode=D.code
)
E
ON E.subjectcode=F.code
 ";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("studentcode", studentcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("term", term, SqlDbType.Int, 0, 0));
            if (staffname != "")
            {
                li.Add(new fieldpara("staffname", staffname, SqlDbType.NVarChar, 1, 1));
            }
            if (subjectname != "")
            {
                li.Add(new fieldpara("name", subjectname, SqlDbType.NVarChar, 1, 1));
            }
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        //public double standartClassPeriod(string learningtypecode, int studentAmount, int period)
        //{
        //    double hs = 1;
        //    double rs = 0.0;
        //    DataSet ds = new DataSet();
        //    LEARNINGTYPE_BUS learningtype_bus = new LEARNINGTYPE_BUS();
        //    LEARNINGTYPEDEATIL_BUS learningtypedetail_bus = new LEARNINGTYPEDEATIL_BUS();
        //    LEARNINGTYPE_OBJ learningtype_obj = learningtype_bus.GetByID(new LEARNINGTYPE_OBJ.BusinessObjectID(learningtypecode));
        //    LEARNINGTYPEDEATIL_OBJ obj_detail;
        //    double prelevel = 0;
        //    learningtype_bus.CloseConnection();
        //    if(learningtype_obj==null)
        //    {
        //        //Không kiểm tra được dữ liệu
        //        return 0;//
        //    }
        //    List<fieldpara> lipa = new List<fieldpara>();
        //    lipa.Add(new fieldpara("learningtypecode", learningtype_obj.CODE));
        //    //Có dữ liệu
        //    switch (learningtype_obj.DETAIL)
        //    {
        //        case 0://tính trực tiếp
        //            hs = learningtype_obj.FACTOR;
        //            rs = hs * period;
        //            break;
        //        case 1:
        //            //tính theo ngưỡng
        //            lipa.Add(new fieldpara("minamount", studentAmount, paraType.INT, (int)searchType.GREATER,1));
        //            lipa.Add(new fieldpara("maxamount", studentAmount, paraType.INT, (int)searchType.LESS,1));
        //            obj_detail = learningtypedetail_bus.GetByKey(lipa.ToArray());
        //            if (obj_detail == null)
        //            {
        //                rs = period * learningtype_obj.FACTOR;
        //            }
        //            else
        //            {
        //                rs = period * obj_detail.FACTOR;
        //            }
        //            break;
        //        case 2:
        //            //tính theo lát cắt
        //            lipa.Add(new fieldpara("minamount", studentAmount, paraType.INT, (int)searchType.GREATER,1));
        //            List<LEARNINGTYPEDEATIL_OBJ> li = learningtypedetail_bus.getAllBy2(" maxamount ", lipa.ToArray());
        //            rs = 0;
        //            foreach(LEARNINGTYPEDEATIL_OBJ obj in li)
        //            {
        //                hs += (Math.Min(obj.MAXAMOUNT, period) - prelevel) * obj.FACTOR;
        //                prelevel = obj.MAXAMOUNT;
        //            }
        //            break;
        //        default:
        //            rs= 0;
        //            break;
        //    }
        //    learningtypedetail_bus.CloseConnection();

        //    return rs;
        //}


        /*public double standartClassPeriod(string learningtypecode, int studentAmount, int classperiod, int theoryperiod, int practicperiod, int assign)
        {
            double hs = 1;
            double rs = 0.0;
            DataSet ds = new DataSet();
            LEARNINGTYPE_BUS learningtype_bus = new LEARNINGTYPE_BUS();
            LEARNINGTYPEDEATIL_BUS learningtypedetail_bus = new LEARNINGTYPEDEATIL_BUS();
            LEARNINGTYPE_OBJ learningtype_obj = learningtype_bus.GetByID(new LEARNINGTYPE_OBJ.BusinessObjectID(learningtypecode));
            if (learningtype_obj != null)
            {
                if (learningtype_obj.DETAIL == 1)
                {
                    int check = learningtypedetail_bus.getLearningTypeDetaild(ref ds, learningtype_obj.CODE, studentAmount);
                    if (check >= 1)
                    {
                        hs = com.convert2Double(ds.Tables[0].Rows[0]["factor"].ToString(), 2);
                    }

                    if (learningtype_obj.CODE != "DHLT")
                    {
                        rs = hs * classperiod;
                    }
                    else
                    {
                        rs += theoryperiod * hs;
                        rs += (practicperiod + assign) * 0.5;
                    }
                }
                else if (learningtype_obj.DETAIL == 2)
                {
                    int check = learningtypedetail_bus.getListLearningTypeDetaild(ref ds, learningtype_obj.CODE, studentAmount);
                    if (check >= 1)
                    {
                        for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                        {
                            if (i < ds.Tables[0].Rows.Count - 1)
                            {
                                hs = com.convert2Double(ds.Tables[0].Rows[i]["factor"].ToString(), 2);
                                rs += hs * com.convert2Int(ds.Tables[0].Rows[i]["maxamount"].ToString(), 0);
                                //classperiodStandart.Text += rs.ToString();
                            }
                            else
                            {
                                hs = com.convert2Double(ds.Tables[0].Rows[i]["factor"].ToString(), 2);
                                rs += hs * (1 + studentAmount - com.convert2Int(ds.Tables[0].Rows[i]["minamount"].ToString(), 0));
                                // classperiodStandart.Text +="_"+ rs.ToString();
                            }
                        }

                    }


                }
                else
                {
                    hs = learningtype_obj.FACTOR;
                }

            }
            return rs;
        }*/

        //public int getAllCourse(ref DataSet ds, string tableName, List<fieldpara> para)
        //{
        //    int ret = 0;
        //    string sql = "select A.*, B.name  subjectname, C.name  staffname from (select * from course where educationlevelcode=@educationlevelcode AND [year] = @year AND term=@term) A inner join subject B on a.subjectcode = B.code inner join staff C ON A.staffcode=C.code";
        //    ret = this.getByQuery(ref ds, tableName, sql, para);
        //    return ret;
        //}

        /// <summary>
        /// get all waiting for approving, or has just approved
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename"></param>
        /// <param name="staffcode"></param>
        /// <returns></returns>
        public int listWaiting(ref DataSet ds, string tablename, string staffcode)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            string sql = @"select A.*, E.name approvedname from course A 
LEFT JOIN APPROVEDSTATUS E ON A.approvedstatus=E.codelink
WHERE A.staffcode = @code and (A.approvedstatus=1 OR ((A.approvedstatus=2 OR A.approvedstatus=3 ) AND datediff(HOUR, A.approvaltime,GETDATE())<=24))
";
            li.Add(new fieldpara("code", staffcode, paraType.VARCHAR, 0));//has existed
            ret = getByQuery(ref ds, tablename, sql, li);
            if (ret >= 0)
            {
                return ds.Tables[tablename].Rows.Count;
            }
            return ret;
        }
        /// <summary>
        /// lấy theo các nhóm
        /// </summary>
        /// <param name="staffcode"></param>
        /// <param name="educationcode"></param>
        /// <returns></returns>
        public List<COURSE_OBJ> listWaiting(string staffcode, string educationcode)
        {
            List<COURSE_OBJ> liret= new List<COURSE_OBJ>();
            DataSet ds = new DataSet();
            string tablename = "TEMP";
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            string sql = @"select A.*, E.name approvedname from course A 
LEFT JOIN APPROVEDSTATUS E ON A.approvedstatus=E.codelink
WHERE A.staffcode = @code and (A.approvedstatus=1 OR ((A.approvedstatus=2 OR A.approvedstatus=3 ) AND datediff(HOUR, A.approvaltime,GETDATE())<=24)) AND A.educationlevelcode=@educationlevelcode
";
            li.Add(new fieldpara("code", staffcode, paraType.VARCHAR, 0));//has existed
            li.Add(new fieldpara("educationlevelcode", educationcode, paraType.VARCHAR, 0));//has existed
            ret = getByQuery(ref ds, tablename, sql, li);
            if(ret<0)
            {
                return liret;
            }
            COURSE_OBJ obj = null;
            foreach(DataRow dr in ds.Tables[tablename].Rows)
            {
                obj = createObjectFromRow(dr);
                liret.Add(obj);
            }
            return liret;

        }

    }

}

