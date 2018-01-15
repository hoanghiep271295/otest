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
    public class STAFFAUTHORIZE_BUS: BusinessController<STAFFAUTHORIZE_OBJ, STAFFAUTHORIZE_OBJ.BusinessObjectID>
    {
        public STAFFAUTHORIZE_BUS()
        {
        }
        public override STAFFAUTHORIZE_OBJ createObject()
        {
            STAFFAUTHORIZE_OBJ obj = new STAFFAUTHORIZE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STAFFAUTHORIZE_OBJ createNull()
        {
            return null;
        }

    }

}

