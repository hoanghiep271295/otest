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
    public class PRIORITYPOLICY_BUS: BusinessController<PRIORITYPOLICY_OBJ, PRIORITYPOLICY_OBJ.BusinessObjectID>
    {
        public PRIORITYPOLICY_BUS()
        {
        }
        public override PRIORITYPOLICY_OBJ createObject()
        {
            PRIORITYPOLICY_OBJ obj = new PRIORITYPOLICY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override PRIORITYPOLICY_OBJ createNull()
        {
            return null;
        }

    }

}

