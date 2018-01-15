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
    public class TOWNREFERENCE_BUS: BusinessController<TOWNREFERENCE_OBJ, TOWNREFERENCE_OBJ.BusinessObjectID>
    {
        public TOWNREFERENCE_BUS()
        {
        }
        public override TOWNREFERENCE_OBJ createObject()
        {
            TOWNREFERENCE_OBJ obj = new TOWNREFERENCE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override TOWNREFERENCE_OBJ createNull()
        {
            return null;
        }

    }

}

