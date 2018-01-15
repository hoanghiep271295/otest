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
    public class STUDENTREWARDTYPE_BUS: BusinessController<STUDENTREWARDTYPE_OBJ, STUDENTREWARDTYPE_OBJ.BusinessObjectID>
    {
        public STUDENTREWARDTYPE_BUS()
        {
        }
        public override STUDENTREWARDTYPE_OBJ createObject()
        {
            STUDENTREWARDTYPE_OBJ obj = new STUDENTREWARDTYPE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STUDENTREWARDTYPE_OBJ createNull()
        {
            return null;
        }

    }

}

