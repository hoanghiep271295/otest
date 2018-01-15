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
    public class ARMYRANK_BUS: BusinessController<ARMYRANK_OBJ, ARMYRANK_OBJ.BusinessObjectID>
    {
        public ARMYRANK_BUS()
        {
        }
        public override ARMYRANK_OBJ createObject()
        {
            ARMYRANK_OBJ obj = new ARMYRANK_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override ARMYRANK_OBJ createNull()
        {
            return null;
        }

    }

}

