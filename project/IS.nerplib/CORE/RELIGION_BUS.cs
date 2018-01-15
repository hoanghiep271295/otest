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
    public class RELIGION_BUS: BusinessController<RELIGION_OBJ, RELIGION_OBJ.BusinessObjectID>
    {
        public RELIGION_BUS()
        {
        }
        public override RELIGION_OBJ createObject()
        {
            RELIGION_OBJ obj = new RELIGION_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override RELIGION_OBJ createNull()
        {
            return null;
        }

    }

}

