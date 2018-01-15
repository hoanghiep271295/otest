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
    public class FACTORGROUP_BUS: BusinessController<FACTORGROUP_OBJ, FACTORGROUP_OBJ.BusinessObjectID>
    {
        public FACTORGROUP_BUS()
        {
        }
        public override FACTORGROUP_OBJ createObject()
        {
            FACTORGROUP_OBJ obj = new FACTORGROUP_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override FACTORGROUP_OBJ createNull()
        {
            return null;
        }

    }

}

