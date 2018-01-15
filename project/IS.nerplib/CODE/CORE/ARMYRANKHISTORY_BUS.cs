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
    public class ARMYRANKHISTORY_BUS: BusinessController<ARMYRANKHISTORY_OBJ, ARMYRANKHISTORY_OBJ.BusinessObjectID>
    {
        public ARMYRANKHISTORY_BUS()
        {
        }
        public override ARMYRANKHISTORY_OBJ createObject()
        {
            ARMYRANKHISTORY_OBJ obj = new ARMYRANKHISTORY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override ARMYRANKHISTORY_OBJ createNull()
        {
            return null;
        }

    }

}

