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
    public class STAFFINFO_BUS: BusinessController<STAFFINFO_OBJ, STAFFINFO_OBJ.BusinessObjectID>
    {
        public STAFFINFO_BUS()
        {
        }
        public override STAFFINFO_OBJ createObject()
        {
            STAFFINFO_OBJ obj = new STAFFINFO_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STAFFINFO_OBJ createNull()
        {
            return null;
        }

    }

}

