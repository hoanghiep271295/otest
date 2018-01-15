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
    public class MAPPING_BUS: BusinessController<MAPPING_OBJ, MAPPING_OBJ.BusinessObjectID>
    {
        public MAPPING_BUS()
        {
        }
        public override MAPPING_OBJ createObject()
        {
            MAPPING_OBJ obj = new MAPPING_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override MAPPING_OBJ createNull()
        {
            return null;
        }

    }

}

