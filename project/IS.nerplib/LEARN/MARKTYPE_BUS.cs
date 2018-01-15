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
    public class MARKTYPE_BUS: BusinessController<MARKTYPE_OBJ, MARKTYPE_OBJ.BusinessObjectID>
    {
        public MARKTYPE_BUS()
        {
        }
        public override MARKTYPE_OBJ createObject()
        {
            MARKTYPE_OBJ obj = new MARKTYPE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override MARKTYPE_OBJ createNull()
        {
            return null;
        }

    }

}

