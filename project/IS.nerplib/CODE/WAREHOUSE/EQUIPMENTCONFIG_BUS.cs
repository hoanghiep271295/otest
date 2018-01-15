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
    public class EQUIPMENTCONFIG_BUS: BusinessController<EQUIPMENTCONFIG_OBJ, EQUIPMENTCONFIG_OBJ.BusinessObjectID>
    {
        public EQUIPMENTCONFIG_BUS()
        {
        }
        public override EQUIPMENTCONFIG_OBJ createObject()
        {
            EQUIPMENTCONFIG_OBJ obj = new EQUIPMENTCONFIG_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EQUIPMENTCONFIG_OBJ createNull()
        {
            return null;
        }

    }

}

