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
    public class MAPPINGLINK_BUS: BusinessController<MAPPINGLINK_OBJ, MAPPINGLINK_OBJ.BusinessObjectID>
    {
        public MAPPINGLINK_BUS()
        {
        }
        public override MAPPINGLINK_OBJ createObject()
        {
            MAPPINGLINK_OBJ obj = new MAPPINGLINK_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override MAPPINGLINK_OBJ createNull()
        {
            return null;
        }

    }

}

