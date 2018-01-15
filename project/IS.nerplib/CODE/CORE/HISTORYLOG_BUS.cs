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
    public class HISTORYLOG_BUS: BusinessController<HISTORYLOG_OBJ, HISTORYLOG_OBJ.BusinessObjectID>
    {
        public HISTORYLOG_BUS()
        {
        }
        public override HISTORYLOG_OBJ createObject()
        {
            HISTORYLOG_OBJ obj = new HISTORYLOG_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override HISTORYLOG_OBJ createNull()
        {
            return null;
        }

    }

}

