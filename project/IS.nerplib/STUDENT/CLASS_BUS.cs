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
    public class CLASS_BUS: BusinessController<CLASS_OBJ, CLASS_OBJ.BusinessObjectID>
    {
        public CLASS_BUS()
        {
        }
        public override CLASS_OBJ createObject()
        {
            CLASS_OBJ obj = new CLASS_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override CLASS_OBJ createNull()
        {
            return null;
        }
        public int getClass(ref DataSet ds, string tableName, string gradeCode)
        {
            List<fieldpara> li = new List<fieldpara>();
            return getClass(ref ds, tableName, gradeCode, li);
        }
        //public int getClass(ref DataSet ds, string tableName, string gradeCode, string staffcode)
        //{
        //    return getClass(ref ds, tableName, gradeCode, staffcode,null);
        //}
        //public int getClass(ref DataSet ds, string tableName, string gradeCode, string staffcode, List<fieldpara> lia)
        //{
        //    int ret = 0;
        //    string sql = @"select *, B.name departmentMan, C.name departmentEdu from 
        //    (SELECT * FROM class WHERE gradecode=@gradecode) A 
        //    LEFT JOIN department B ON A.departmentcode = B.code 
        //    LEFT JOIN department C ON A.departmentcode2=C.code
        //    INNER JOIN (SELECT * FROM classstaff WHERE staffcode=@staffcode)D ON A.code=D.classcode
        //    ";

        //    List<fieldpara> li = new List<fieldpara>();
        //    li.Add(new fieldpara("GRADECODE", gradeCode, SqlDbType.VarChar, 0, 0));
        //    li.Add(new fieldpara("STAFFCODE", staffcode, SqlDbType.VarChar, 0, 0));
        //    if (lia != null)
        //    {
        //        foreach (fieldpara f in lia)
        //        {
        //            li.Add(f);
        //        }
        //    }
        //    ret = getByQuery(ref ds, tableName, sql, li);
        //    return ret;
        //}
        public int getClass(ref DataSet ds, string tableName, string gradeCode, List<fieldpara> lia)
        {
            int ret = 0;
            string sql = @"select *, B.name departmentMan, C.name departmentEdu from 
            (SELECT * FROM class WHERE gradecode=@gradecode) A 
            LEFT JOIN department B ON A.departmentcode = B.code 
            LEFT JOIN department C ON A.departmentcode2=C.code
            ";

            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("GRADECODE", gradeCode, SqlDbType.VarChar, 0, 0));
            if (lia != null)
            {
                foreach (fieldpara f in lia)
                {
                    li.Add(f);
                }
            }
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        public int getByStaff(ref DataSet ds, string tableName, string staffcode, string gradecode)
        {
            int ret = 0;
            //List<jointable> litb = new List<jointable>();
            //litb.Add(new jointable(typeof(CLASSSTAFF_OBJ), "CODE", "CLASSCODE", JOIN.INNER, new fieldpara("STAFFCODE", staffcode)));
            //List<fieldpara> lipa = new List<fieldpara>();
            //lipa.Add(new fieldpara("GRADECODE", gradecode));
            //int ret = getAllBy(ref ds, tableName, lipa, litb);
            return ret;
        }
        
        /// <summary>
        /// Get class inform mation, included: class, grade, educationlevel, studentgrouptype
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="classCode"></param>
        /// <returns></returns>
        public int classInfo(ref DataSet ds, string tableName, string classCode)
        {
            int ret = 0;
            string sql = @"select A.code, A.codeview, A.name, B.code gradecode, b.codeview gradecodeview, b.name gradename, B.yearin, B.yearout , c.code educationlevelcode, c.codeview educationlevelcodeview, c.name educationlevelname, D.code studentgrouptypecode, D.codeview studentgrouptypecodeview, D.name studentgrouptypename from class A 
INNER JOIN grade B ON A.gradecode=B.code        
INNER JOIN educationlevel C ON B.educationlevelcode=C.code
LEFT JOIN studentgrouptype D ON A.studentgrouptypecode=D.code
WHERE A.code=@classcode";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode",classCode, SqlDbType.VarChar,0,0));
            ret=getByQuery(ref ds, tableName,sql,li);
            return ret;
        }
    }

}

