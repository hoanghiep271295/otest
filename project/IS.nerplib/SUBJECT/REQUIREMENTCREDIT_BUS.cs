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
    public class REQUIREMENTCREDIT_BUS: BusinessController<REQUIREMENTCREDIT_OBJ, REQUIREMENTCREDIT_OBJ.BusinessObjectID>
    {
        public REQUIREMENTCREDIT_BUS()
        {
        }
        public override REQUIREMENTCREDIT_OBJ createObject()
        {
            REQUIREMENTCREDIT_OBJ obj = new REQUIREMENTCREDIT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override REQUIREMENTCREDIT_OBJ createNull()
        {
            return null;
        }

    }

}

