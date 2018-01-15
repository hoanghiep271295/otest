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
    public class STAFFSTATUSHISTORY_BUS: BusinessController<STAFFSTATUSHISTORY_OBJ, STAFFSTATUSHISTORY_OBJ.BusinessObjectID>
    {
        public STAFFSTATUSHISTORY_BUS()
        {
        }
        public override STAFFSTATUSHISTORY_OBJ createObject()
        {
            STAFFSTATUSHISTORY_OBJ obj = new STAFFSTATUSHISTORY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STAFFSTATUSHISTORY_OBJ createNull()
        {
            return null;
        }

    }

}

