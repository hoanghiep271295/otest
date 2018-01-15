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
    public class STUDENTDISCIPLINEHISTORY_BUS: BusinessController<STUDENTDISCIPLINEHISTORY_OBJ, STUDENTDISCIPLINEHISTORY_OBJ.BusinessObjectID>
    {
        public STUDENTDISCIPLINEHISTORY_BUS()
        {
        }
        public override STUDENTDISCIPLINEHISTORY_OBJ createObject()
        {
            STUDENTDISCIPLINEHISTORY_OBJ obj = new STUDENTDISCIPLINEHISTORY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STUDENTDISCIPLINEHISTORY_OBJ createNull()
        {
            return null;
        }

    }

}

