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
    public class ACADEMICLEVEL_BUS: BusinessController<ACADEMICLEVEL_OBJ, ACADEMICLEVEL_OBJ.BusinessObjectID>
    {
        public ACADEMICLEVEL_BUS()
        {
        }
        public override ACADEMICLEVEL_OBJ createObject()
        {
            ACADEMICLEVEL_OBJ obj = new ACADEMICLEVEL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override ACADEMICLEVEL_OBJ createNull()
        {
            return null;
        }
        public int search(ref DataSet ds, string tableName, int status)
        {
            int ret;
            string sql = @"select A.* from academiclevel A INNER JOIN researchstatusacademiclevel B On a.code=B.staffpropertycode where b.researchstatuscode=@codelink ORDER BY A.THEORDER";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("codelink", status, paraType.INT, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }



    }

}

