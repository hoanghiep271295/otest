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
    public class STUDENTDISCIPLINELEVEL_BUS: BusinessController<STUDENTDISCIPLINELEVEL_OBJ, STUDENTDISCIPLINELEVEL_OBJ.BusinessObjectID>
    {
        public STUDENTDISCIPLINELEVEL_BUS()
        {
        }
        public override STUDENTDISCIPLINELEVEL_OBJ createObject()
        {
            STUDENTDISCIPLINELEVEL_OBJ obj = new STUDENTDISCIPLINELEVEL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STUDENTDISCIPLINELEVEL_OBJ createNull()
        {
            return null;
        }

    }

}

