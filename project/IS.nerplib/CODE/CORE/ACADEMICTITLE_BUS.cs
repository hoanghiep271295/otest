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
    public class ACADEMICTITLE_BUS: BusinessController<ACADEMICTITLE_OBJ, ACADEMICTITLE_OBJ.BusinessObjectID>
    {
        public ACADEMICTITLE_BUS()
        {
        }
        public override ACADEMICTITLE_OBJ createObject()
        {
            ACADEMICTITLE_OBJ obj = new ACADEMICTITLE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override ACADEMICTITLE_OBJ createNull()
        {
            return null;
        }

    }

}

