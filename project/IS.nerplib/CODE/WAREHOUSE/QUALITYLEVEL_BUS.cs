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
    public class QUALITYLEVEL_BUS: BusinessController<QUALITYLEVEL_OBJ, QUALITYLEVEL_OBJ.BusinessObjectID>
    {
        public QUALITYLEVEL_BUS()
        {
        }
        public override QUALITYLEVEL_OBJ createObject()
        {
            QUALITYLEVEL_OBJ obj = new QUALITYLEVEL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override QUALITYLEVEL_OBJ createNull()
        {
            return null;
        }

    }

}

