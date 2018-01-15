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
    public class PRIORITYREGION_BUS: BusinessController<PRIORITYREGION_OBJ, PRIORITYREGION_OBJ.BusinessObjectID>
    {
        public PRIORITYREGION_BUS()
        {
        }
        public override PRIORITYREGION_OBJ createObject()
        {
            PRIORITYREGION_OBJ obj = new PRIORITYREGION_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override PRIORITYREGION_OBJ createNull()
        {
            return null;
        }

    }

}

