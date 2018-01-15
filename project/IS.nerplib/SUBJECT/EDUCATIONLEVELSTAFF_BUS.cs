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
    public class EDUCATIONLEVELSTAFF_BUS: BusinessController<EDUCATIONLEVELSTAFF_OBJ, EDUCATIONLEVELSTAFF_OBJ.BusinessObjectID>
    {
        public EDUCATIONLEVELSTAFF_BUS()
        {
        }
        public override EDUCATIONLEVELSTAFF_OBJ createObject()
        {
            EDUCATIONLEVELSTAFF_OBJ obj = new EDUCATIONLEVELSTAFF_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EDUCATIONLEVELSTAFF_OBJ createNull()
        {
            return null;
        }

    }

}

