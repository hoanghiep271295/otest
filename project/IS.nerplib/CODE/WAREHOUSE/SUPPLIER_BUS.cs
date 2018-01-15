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
    public class SUPPLIER_BUS: BusinessController<SUPPLIER_OBJ, SUPPLIER_OBJ.BusinessObjectID>
    {
        public SUPPLIER_BUS()
        {
        }
        public override SUPPLIER_OBJ createObject()
        {
            SUPPLIER_OBJ obj = new SUPPLIER_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override SUPPLIER_OBJ createNull()
        {
            return null;
        }

    }

}

