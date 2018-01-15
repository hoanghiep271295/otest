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
    public class STUDENTGROUPTYPE_BUS: BusinessController<STUDENTGROUPTYPE_OBJ, STUDENTGROUPTYPE_OBJ.BusinessObjectID>
    {
        public STUDENTGROUPTYPE_BUS()
        {
        }
        public override STUDENTGROUPTYPE_OBJ createObject()
        {
            STUDENTGROUPTYPE_OBJ obj = new STUDENTGROUPTYPE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STUDENTGROUPTYPE_OBJ createNull()
        {
            return null;
        }

    }

}

