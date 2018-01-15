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
    public class PERSONALPARAMETER_BUS: BusinessController<PERSONALPARAMETER_OBJ, PERSONALPARAMETER_OBJ.BusinessObjectID>
    {
        public PERSONALPARAMETER_BUS()
        {
        }
        public override PERSONALPARAMETER_OBJ createObject()
        {
            PERSONALPARAMETER_OBJ obj = new PERSONALPARAMETER_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override PERSONALPARAMETER_OBJ createNull()
        {
            return null;
        }

    }

}

