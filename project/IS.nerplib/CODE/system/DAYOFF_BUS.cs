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
    public class DAYOFF_BUS: BusinessController<DAYOFF_OBJ, DAYOFF_OBJ.BusinessObjectID>
    {
        public DAYOFF_BUS()
        {
        }
        public override DAYOFF_OBJ createObject()
        {
            DAYOFF_OBJ obj = new DAYOFF_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override DAYOFF_OBJ createNull()
        {
            return null;
        }

    }

}

