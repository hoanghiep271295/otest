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
    public class STUDENTREWARDLEVEL_BUS: BusinessController<STUDENTREWARDLEVEL_OBJ, STUDENTREWARDLEVEL_OBJ.BusinessObjectID>
    {
        public STUDENTREWARDLEVEL_BUS()
        {
        }
        public override STUDENTREWARDLEVEL_OBJ createObject()
        {
            STUDENTREWARDLEVEL_OBJ obj = new STUDENTREWARDLEVEL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STUDENTREWARDLEVEL_OBJ createNull()
        {
            return null;
        }

    }

}

