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
    public class GRADESTAFF_BUS: BusinessController<GRADESTAFF_OBJ, GRADESTAFF_OBJ.BusinessObjectID>
    {
        public GRADESTAFF_BUS()
        {
        }
        public override GRADESTAFF_OBJ createObject()
        {
            GRADESTAFF_OBJ obj = new GRADESTAFF_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override GRADESTAFF_OBJ createNull()
        {
            return null;
        }

    }

}

