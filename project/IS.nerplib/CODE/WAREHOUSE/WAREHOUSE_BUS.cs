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
    public class WAREHOUSE_BUS: BusinessController<WAREHOUSE_OBJ, WAREHOUSE_OBJ.BusinessObjectID>
    {
        public WAREHOUSE_BUS()
        {
        }
        public override WAREHOUSE_OBJ createObject()
        {
            WAREHOUSE_OBJ obj = new WAREHOUSE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override WAREHOUSE_OBJ createNull()
        {
            return null;
        }

    }

}

