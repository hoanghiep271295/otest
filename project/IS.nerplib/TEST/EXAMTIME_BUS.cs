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
    public class EXAMTIME_BUS: BusinessController<EXAMTIME_OBJ, EXAMTIME_OBJ.BusinessObjectID>
    {
        public EXAMTIME_BUS()
        {
        }
        public override EXAMTIME_OBJ createObject()
        {
            EXAMTIME_OBJ obj = new EXAMTIME_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EXAMTIME_OBJ createNull()
        {
            return null;
        }

    }

}

