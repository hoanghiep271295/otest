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
    public class TASKNOTE_BUS: BusinessController<TASKNOTE_OBJ, TASKNOTE_OBJ.BusinessObjectID>
    {
        public TASKNOTE_BUS()
        {
        }
        public override TASKNOTE_OBJ createObject()
        {
            TASKNOTE_OBJ obj = new TASKNOTE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override TASKNOTE_OBJ createNull()
        {
            return null;
        }

    }

}

