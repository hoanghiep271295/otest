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
    public class GROUPNAME_BUS: BusinessController<GROUPNAME_OBJ, GROUPNAME_OBJ.BusinessObjectID>
    {
        public GROUPNAME_BUS()
        {
        }
        public override GROUPNAME_OBJ createObject()
        {
            GROUPNAME_OBJ obj = new GROUPNAME_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override GROUPNAME_OBJ createNull()
        {
            return null;
        }

    }

}

