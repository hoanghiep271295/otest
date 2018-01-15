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
    public class LEVELTITLEHISTORY_BUS: BusinessController<LEVELTITLEHISTORY_OBJ, LEVELTITLEHISTORY_OBJ.BusinessObjectID>
    {
        public LEVELTITLEHISTORY_BUS()
        {
        }
        public override LEVELTITLEHISTORY_OBJ createObject()
        {
            LEVELTITLEHISTORY_OBJ obj = new LEVELTITLEHISTORY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override LEVELTITLEHISTORY_OBJ createNull()
        {
            return null;
        }

    }

}

