using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
namespace IS.uni
{
    public class SUBJECT_BUS: BusinessController<SUBJECT_OBJ, SUBJECT_OBJ.BusinessObjectID>
    {
        public SUBJECT_BUS()
        {
        }
        public override SUBJECT_OBJ createObject()
        {
            SUBJECT_OBJ obj = new SUBJECT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override SUBJECT_OBJ createNull()
        {
            return null;
        }



        public int getReexam(ref DataSet ds, string tableName, string educationlevelCode, int year, int term, string name)
        {
            int ret = 0;
            string sql = @"select A.*, A.name + '-' + convert(varchar(4),A.credit) fullname from [subject] A 
INNER JOIN (select distinct subjectcode from course where educationlevelcode=@educationlevelcode AND ((term<=@term AND [year]=@year) OR ([year]<@year))) B		
ON A.code = B.subjectcode";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("educationlevelcode", educationlevelCode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("term", term, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("year", year, SqlDbType.Int, 0, 0));
            if (name != "")
            {
                li.Add(new fieldpara("A.name",name, SqlDbType.NVarChar,1,1));
            }
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }


        public int search(ref DataSet ds, string facultyCode,  string name)
        {
            int ret = 0;
            string sql = @"select * from subject A where (name like '%" + name + "%' OR codeview like '%" + name + "%' OR code like '%" + name + "%'  ) and departmentcode='" + facultyCode + "'";
            List<fieldpara> li = new List<fieldpara>();            
            ret = getByQuery(ref ds, "subject", sql, li);
            return ret;
        }

        public int getSubjectClassTerm(ref DataSet ds, string tableName,  string classCode, int year, int term)
        {
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode",classCode, SqlDbType.VarChar,0));
            li.Add(new fieldpara("year",year, SqlDbType.Int,0));
            li.Add(new fieldpara("term",term, SqlDbType.Int,0));
            int ret = storedProcedure(ref ds, tableName, "subjectclassterm", li);
            return ret;
        }
        public int getSubjectStaffTerm(ref DataSet ds, string tableName, string staffCode, int year, int term)
        {
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("staffcode", staffCode, SqlDbType.VarChar, 0));
            li.Add(new fieldpara("year", year, SqlDbType.Int, 0));
            li.Add(new fieldpara("term", term, SqlDbType.Int, 0));
            int ret = storedProcedure(ref ds, tableName, "subjectstaffterm", li);
            return ret;
        }
        public int getSubjectList(ref DataSet ds, string tableName, string educationlevelcode, string name)
        {
            int ret = 0;
            string sql = @"
select * from 
(
select * , name +'-'+ CONVERT(varchar(3),credit) fullname from subject  where educationlevelcode=@educationlevelcode
)
A
";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("educationlevelcode", educationlevelcode, SqlDbType.VarChar, 0));// based on educationlevelcode
            if (name != "")
            {
                //for search
                li.Add(new fieldpara("fullname", name, SqlDbType.NVarChar, 1, 1));
            }
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// Lấy danh sách các môn học mà các bộ môn trong khoa departmentcode phụ trách, trong trường hợp nếu departmentcode là một bộ môn thì lấy các môn học cùng khoa với bộ môn đó
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="departmentcode">Mã của khoa, hoặc của bộ môn</param>
        /// <returns>Giá trị âm là lỗi</returns>
        public int getTheSameFaculty(ref DataSet ds, string tableName, string departmentcode)
        {
            int ret = 0;
            string sql = @"select A.*, F.codeview departmentcodeview, F.name departmentname from subject A
INNER JOIN (SELECT distinct * FROM  (SELECT B.* FROM  (select * FROM department) B 
				INNER JOIN (SELECT * FROM department WHERE code=@code)C  ON C.parentcode=B.parentcode
			UNION
			SELECT * FROM department WHERE parentcode=@code
UNION select * FROM department where code=@code)
			 D) F
ON A.departmentcode=F.code";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("code", departmentcode, paraType.VARCHAR, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        /// <summary>
        /// Lấy các môn học trong cùng một khoa theo cấp học
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="departmentcode"></param>
        /// <param name="educationlevelcode"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public int getTheSameFacultyWithKey(ref DataSet ds, string tableName, string departmentcode, string educationlevelcode,string key)
        {
            int ret = 0;
            string sql = @"select TOP 20 A.*, F.codeview departmentcodeview, F.name departmentname from subject A
INNER JOIN (SELECT distinct * FROM  (SELECT B.* FROM  (select * FROM department) B 
				INNER JOIN (SELECT * FROM department WHERE code=@code)C  ON C.parentcode=B.parentcode
			UNION
			SELECT * FROM department WHERE parentcode=@code
UNION select * FROM department where code=@code)
			 D) F
ON A.departmentcode=F.code where A.educationlevelcode=@educationlevelcode AND ( A.code like '%" + key + "%' or A.name like N'%" + key + "%' or A.codeview like '%" + key + "%') ORDER BY CASE WHEN A.departmentcode = @code THEN '1' ELSE A.codeview  END ASC ";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("code", departmentcode, paraType.VARCHAR, 0));
            li.Add(new fieldpara("educationlevelcode", educationlevelcode, paraType.VARCHAR, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
    }

}

