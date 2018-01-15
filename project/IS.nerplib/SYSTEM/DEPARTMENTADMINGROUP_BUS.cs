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
    public class DEPARTMENTADMINGROUP_BUS: BusinessController<DEPARTMENTADMINGROUP_OBJ, DEPARTMENTADMINGROUP_OBJ.BusinessObjectID>
    {
        public DEPARTMENTADMINGROUP_BUS()
        {
        }
        public override DEPARTMENTADMINGROUP_OBJ createObject()
        {
            DEPARTMENTADMINGROUP_OBJ obj = new DEPARTMENTADMINGROUP_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override DEPARTMENTADMINGROUP_OBJ createNull()
        {
            return null;
        }

    }

}

