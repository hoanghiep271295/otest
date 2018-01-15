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
    public class ACEDEMICTITLEHISTORY_BUS: BusinessController<ACEDEMICTITLEHISTORY_OBJ, ACEDEMICTITLEHISTORY_OBJ.BusinessObjectID>
    {
        public ACEDEMICTITLEHISTORY_BUS()
        {
        }
        public override ACEDEMICTITLEHISTORY_OBJ createObject()
        {
            ACEDEMICTITLEHISTORY_OBJ obj = new ACEDEMICTITLEHISTORY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override ACEDEMICTITLEHISTORY_OBJ createNull()
        {
            return null;
        }

    }

}

