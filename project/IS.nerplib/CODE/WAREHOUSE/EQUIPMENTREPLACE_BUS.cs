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
    public class EQUIPMENTREPLACE_BUS: BusinessController<EQUIPMENTREPLACE_OBJ, EQUIPMENTREPLACE_OBJ.BusinessObjectID>
    {
        public EQUIPMENTREPLACE_BUS()
        {
        }
        public override EQUIPMENTREPLACE_OBJ createObject()
        {
            EQUIPMENTREPLACE_OBJ obj = new EQUIPMENTREPLACE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EQUIPMENTREPLACE_OBJ createNull()
        {
            return null;
        }

    }

}

