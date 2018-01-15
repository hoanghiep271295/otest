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
    public class ACADEMICLEVELHISTORY_BUS: BusinessController<ACADEMICLEVELHISTORY_OBJ, ACADEMICLEVELHISTORY_OBJ.BusinessObjectID>
    {
        public ACADEMICLEVELHISTORY_BUS()
        {
        }
        public override ACADEMICLEVELHISTORY_OBJ createObject()
        {
            ACADEMICLEVELHISTORY_OBJ obj = new ACADEMICLEVELHISTORY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override ACADEMICLEVELHISTORY_OBJ createNull()
        {
            return null;
        }

    }

}

