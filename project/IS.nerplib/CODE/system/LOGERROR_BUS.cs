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
    public class LOGERROR_BUS: BusinessController<LOGERROR_OBJ, LOGERROR_OBJ.BusinessObjectID>
    {
        public LOGERROR_BUS()
        {
        }
        public override LOGERROR_OBJ createObject()
        {
            LOGERROR_OBJ obj = new LOGERROR_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override LOGERROR_OBJ createNull()
        {
            return null;
        }

    }

}

