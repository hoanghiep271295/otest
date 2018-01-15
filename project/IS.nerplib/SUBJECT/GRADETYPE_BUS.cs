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
    public class GRADETYPE_BUS: BusinessController<GRADETYPE_OBJ, GRADETYPE_OBJ.BusinessObjectID>
    {
        public GRADETYPE_BUS()
        {
        }
        public override GRADETYPE_OBJ createObject()
        {
            GRADETYPE_OBJ obj = new GRADETYPE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override GRADETYPE_OBJ createNull()
        {
            return null;
        }

    }

}

