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
    public class STAFFSTATUS_BUS: BusinessController<STAFFSTATUS_OBJ, STAFFSTATUS_OBJ.BusinessObjectID>
    {
        public STAFFSTATUS_BUS()
        {
        }
        public override STAFFSTATUS_OBJ createObject()
        {
            STAFFSTATUS_OBJ obj = new STAFFSTATUS_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STAFFSTATUS_OBJ createNull()
        {
            return null;
        }

    }

}

