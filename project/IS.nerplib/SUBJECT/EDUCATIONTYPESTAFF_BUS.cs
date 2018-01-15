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
    public class EDUCATIONTYPESTAFF_BUS: BusinessController<EDUCATIONTYPESTAFF_OBJ, EDUCATIONTYPESTAFF_OBJ.BusinessObjectID>
    {
        public EDUCATIONTYPESTAFF_BUS()
        {
        }
        public override EDUCATIONTYPESTAFF_OBJ createObject()
        {
            EDUCATIONTYPESTAFF_OBJ obj = new EDUCATIONTYPESTAFF_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EDUCATIONTYPESTAFF_OBJ createNull()
        {
            return null;
        }

    }

}

