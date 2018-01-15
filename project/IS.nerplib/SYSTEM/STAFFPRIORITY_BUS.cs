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
    public class STAFFPRIORITY_BUS: BusinessController<STAFFPRIORITY_OBJ, STAFFPRIORITY_OBJ.BusinessObjectID>
    {
        public STAFFPRIORITY_BUS()
        {
        }
        public override STAFFPRIORITY_OBJ createObject()
        {
            STAFFPRIORITY_OBJ obj = new STAFFPRIORITY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STAFFPRIORITY_OBJ createNull()
        {
            return null;
        }

    }

}

