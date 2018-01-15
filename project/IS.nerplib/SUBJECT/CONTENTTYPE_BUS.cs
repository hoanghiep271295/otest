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
    public class CONTENTTYPE_BUS: BusinessController<CONTENTTYPE_OBJ, CONTENTTYPE_OBJ.BusinessObjectID>
    {
        public CONTENTTYPE_BUS()
        {
        }
        public override CONTENTTYPE_OBJ createObject()
        {
            CONTENTTYPE_OBJ obj = new CONTENTTYPE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override CONTENTTYPE_OBJ createNull()
        {
            return null;
        }

    }

}

