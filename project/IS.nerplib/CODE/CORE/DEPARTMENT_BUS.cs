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
    public class DEPARTMENT_BUS: BusinessController<DEPARTMENT_OBJ, DEPARTMENT_OBJ.BusinessObjectID>
    {
        public DEPARTMENT_BUS()
        {
        }
        public override DEPARTMENT_OBJ createObject()
        {
            DEPARTMENT_OBJ obj = new DEPARTMENT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override DEPARTMENT_OBJ createNull()
        {
            return null;
        }

    }

}

