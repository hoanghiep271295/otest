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
    public class LOGRESETPASSWORD_BUS: BusinessController<LOGRESETPASSWORD_OBJ, LOGRESETPASSWORD_OBJ.BusinessObjectID>
    {
        public LOGRESETPASSWORD_BUS()
        {
        }
        public override LOGRESETPASSWORD_OBJ createObject()
        {
            LOGRESETPASSWORD_OBJ obj = new LOGRESETPASSWORD_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override LOGRESETPASSWORD_OBJ createNull()
        {
            return null;
        }

    }

}

