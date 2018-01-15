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
    public class PARTYLEVELTITLE_BUS: BusinessController<PARTYLEVELTITLE_OBJ, PARTYLEVELTITLE_OBJ.BusinessObjectID>
    {
        public PARTYLEVELTITLE_BUS()
        {
        }
        public override PARTYLEVELTITLE_OBJ createObject()
        {
            PARTYLEVELTITLE_OBJ obj = new PARTYLEVELTITLE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override PARTYLEVELTITLE_OBJ createNull()
        {
            return null;
        }

    }

}

