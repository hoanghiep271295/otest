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
    public class ADMINGROUP_BUS: BusinessController<ADMINGROUP_OBJ, ADMINGROUP_OBJ.BusinessObjectID>
    {
        public ADMINGROUP_BUS()
        {
        }
        public override ADMINGROUP_OBJ createObject()
        {
            ADMINGROUP_OBJ obj = new ADMINGROUP_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override ADMINGROUP_OBJ createNull()
        {
            return null;
        }

    }

}

