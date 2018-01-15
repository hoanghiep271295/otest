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
    public class EDUCATIONLEVEL_BUS: BusinessController<EDUCATIONLEVEL_OBJ, EDUCATIONLEVEL_OBJ.BusinessObjectID>
    {
        public EDUCATIONLEVEL_BUS()
        {
        }
        public override EDUCATIONLEVEL_OBJ createObject()
        {
            EDUCATIONLEVEL_OBJ obj = new EDUCATIONLEVEL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EDUCATIONLEVEL_OBJ createNull()
        {
            return null;
        }
        public int getByStaff(ref DataSet ds, string tableName, string staffcode)
        {
            int ret = 0;
            //List<jointable> litb = new List<jointable>();
            //litb.Add(new jointable(typeof(EDUCATIONLEVELSTAFF_OBJ), "CODE", "EDUCATIONLEVELCODE", JOIN.INNER, new fieldpara("STAFFCODE", staffcode)));
            //int ret = getAllBy(ref ds, tableName, null, litb);
            return ret;
        }        

    }

}

