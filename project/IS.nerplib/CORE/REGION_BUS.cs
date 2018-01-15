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
    public class REGION_BUS: BusinessController<REGION_OBJ, REGION_OBJ.BusinessObjectID>
    {
        public REGION_BUS()
        {
        }
        public override REGION_OBJ createObject()
        {
            REGION_OBJ obj = new REGION_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override REGION_OBJ createNull()
        {
            return null;
        }

    }

}

