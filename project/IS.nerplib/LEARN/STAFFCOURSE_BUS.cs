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
    public class STAFFCOURSE_BUS: BusinessController<STAFFCOURSE_OBJ, STAFFCOURSE_OBJ.BusinessObjectID>
    {
        public STAFFCOURSE_BUS()
        {
        }
        public override STAFFCOURSE_OBJ createObject()
        {
            STAFFCOURSE_OBJ obj = new STAFFCOURSE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STAFFCOURSE_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Get all staff teach a course
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tablename"></param>
        /// <param name="coursecode"></param>
        /// <returns></returns>
        public int getByCourse(ref DataSet ds, string tableName, string coursecode)
        {
            int ret = 0;
            List<fieldpara> lipa = new List<fieldpara>();
            string sql = @"select C.code, B.name learningtypename, C.codeview, C.name, a.edituser, a.edittime, a.lock
, a.educationlevelcode, C.termcode, C.subjectcode, a.staffcode, D.name staffname, C.studentamount, C.enddate
, C.credit, A.edupoint, A.classperiod, C.departmentcode, A.learningtypecode, C.marktesttypecode, B.unitname
, C.year, C.quater, C.quateryear  from staffcourse A 
INNER JOIN learningtype B ON A.learningtypecode=B.code
INNER JOIN course C ON a.coursecode=C.code
INNER JOIN staff D ON A.staffcode=D.code
WHERE A.coursecode=@coursecode
";
            lipa.Add(new fieldpara("coursecode", coursecode, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, lipa);
            return ret;
        }
    }

}

