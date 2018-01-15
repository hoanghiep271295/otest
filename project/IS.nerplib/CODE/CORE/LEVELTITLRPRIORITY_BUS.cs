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
    public class LEVELTITLRPRIORITY_BUS: BusinessController<LEVELTITLRPRIORITY_OBJ, LEVELTITLRPRIORITY_OBJ.BusinessObjectID>
    {
        public LEVELTITLRPRIORITY_BUS()
        {
        }
        public override LEVELTITLRPRIORITY_OBJ createObject()
        {
            LEVELTITLRPRIORITY_OBJ obj = new LEVELTITLRPRIORITY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override LEVELTITLRPRIORITY_OBJ createNull()
        {
            return null;
        }

    }

}

