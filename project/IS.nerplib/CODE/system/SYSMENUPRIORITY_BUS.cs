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
    public class SYSMENUPRIORITY_BUS: BusinessController<SYSMENUPRIORITY_OBJ, SYSMENUPRIORITY_OBJ.BusinessObjectID>
    {
        public SYSMENUPRIORITY_BUS()
        {
        }
        public override SYSMENUPRIORITY_OBJ createObject()
        {
            SYSMENUPRIORITY_OBJ obj = new SYSMENUPRIORITY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override SYSMENUPRIORITY_OBJ createNull()
        {
            return null;
        }

    }

}

