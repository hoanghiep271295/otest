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
    public class DEGREEHISTORY_BUS: BusinessController<DEGREEHISTORY_OBJ, DEGREEHISTORY_OBJ.BusinessObjectID>
    {
        public DEGREEHISTORY_BUS()
        {
        }
        public override DEGREEHISTORY_OBJ createObject()
        {
            DEGREEHISTORY_OBJ obj = new DEGREEHISTORY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override DEGREEHISTORY_OBJ createNull()
        {
            return null;
        }

    }

}

