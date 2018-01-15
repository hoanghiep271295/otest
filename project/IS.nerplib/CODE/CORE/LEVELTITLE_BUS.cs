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
    public class LEVELTITLE_BUS : BusinessController<LEVELTITLE_OBJ, LEVELTITLE_OBJ.BusinessObjectID>
    {
        public LEVELTITLE_BUS()
        {
        }
        public override LEVELTITLE_OBJ createObject()
        {
            LEVELTITLE_OBJ obj = new LEVELTITLE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override LEVELTITLE_OBJ createNull()
        {
            return null;
        }
        public int countLeveltitle(ref DataSet ds, string tableName, string departmentextensioncode)
        {
            int ret = 0;
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("departmentextensioncode", departmentextensioncode, 0, 0));
            string sql = @"select AA.departmentcode, AA.leveltitlecode,BB.name, amountstaff from
(select a.departmentcode, a.leveltitlecode, COUNT(*) as amountstaff from staff A
WHERE LEFT(a.extensioncode, len(@departmentextensioncode))= @departmentextensioncode
group by a.departmentcode, a.leveltitlecode) AA, leveltitle BB
where aa.leveltitlecode = BB.code
";
            ret = getByQuery(ref ds, tableName, sql, lipa);
            
            return ret;
        }

    }

}

