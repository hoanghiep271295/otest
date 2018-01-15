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
    public class STUDENTRESULTHISTORY_BUS: BusinessController<STUDENTRESULTHISTORY_OBJ, STUDENTRESULTHISTORY_OBJ.BusinessObjectID>
    {
        public STUDENTRESULTHISTORY_BUS()
        {
        }
        public override STUDENTRESULTHISTORY_OBJ createObject()
        {
            STUDENTRESULTHISTORY_OBJ obj = new STUDENTRESULTHISTORY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STUDENTRESULTHISTORY_OBJ createNull()
        {
            return null;
        }

    }

}

