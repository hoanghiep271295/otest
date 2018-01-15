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
    public class EDUCATIONTYPE_BUS: BusinessController<EDUCATIONTYPE_OBJ, EDUCATIONTYPE_OBJ.BusinessObjectID>
    {
        public EDUCATIONTYPE_BUS()
        {
        }
        public override EDUCATIONTYPE_OBJ createObject()
        {
            EDUCATIONTYPE_OBJ obj = new EDUCATIONTYPE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EDUCATIONTYPE_OBJ createNull()
        {
            return null;
        }
        public int getByStaff(ref DataSet ds, string tableName, string staffcode, string educationfieldcode)
        {
            List<jointable> litb = new List<jointable>();
            litb.Add(new jointable(typeof(EDUCATIONTYPESTAFF_OBJ), "EDUCATIONTYPECODE", new fieldpara("STAFFCODE", staffcode)));
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("EDUCATIONFIELDCODE", educationfieldcode));
            int ret = getAllBy(ref ds, tableName, lipa, litb);
            return ret;
        }
    }

}

