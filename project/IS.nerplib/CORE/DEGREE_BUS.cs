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
    public class DEGREE_BUS: BusinessController<DEGREE_OBJ, DEGREE_OBJ.BusinessObjectID>
    {
        public DEGREE_BUS()
        {
        }
        public override DEGREE_OBJ createObject()
        {
            DEGREE_OBJ obj = new DEGREE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override DEGREE_OBJ createNull()
        {
            return null;
        }

    }

}

