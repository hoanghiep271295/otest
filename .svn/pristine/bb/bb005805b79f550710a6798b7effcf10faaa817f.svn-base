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
    public class TESTGROUPDETAIL_BUS: BusinessController<TESTGROUPDETAIL_OBJ, TESTGROUPDETAIL_OBJ.BusinessObjectID>
    {
        public TESTGROUPDETAIL_BUS()
        {
        }
        public override TESTGROUPDETAIL_OBJ createObject()
        {
            TESTGROUPDETAIL_OBJ obj = new TESTGROUPDETAIL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override TESTGROUPDETAIL_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// get all detail mark for a course
        /// </summary>
        /// <param name="coursecode"></param>
        /// <returns></returns>
        public List<TESTGROUPDETAIL_OBJ> getByCourse(string coursecode)
        {
            DataSet ds = new DataSet();
            string tablename = "testgroupdetail";
            List<fieldpara> li = new List<fieldpara>();
            List<TESTGROUPDETAIL_OBJ> li_ret = new List<TESTGROUPDETAIL_OBJ>();
            string sql = @"select d.* from course A 
                INNER JOIN subject B  ON A.subjectcode=B.code
                INNER JOIN testgroupdetail D ON B.marktypecode=D.marktypecode
                 where A.code=@coursecode
                ";
            li.Add(new fieldpara("coursecode", coursecode, paraType.VARCHAR, 0));
            int ret = 0;
            ret = getByQuery(ref ds, tablename, sql, li);
            if(ret>=0)
            {
                foreach(DataRow dr in ds.Tables[tablename].Rows)
                {
                    TESTGROUPDETAIL_OBJ obj = createObjectFromRow(dr);
                    li_ret.Add(obj);
                }
            }
            return li_ret;
        }

    }

}

