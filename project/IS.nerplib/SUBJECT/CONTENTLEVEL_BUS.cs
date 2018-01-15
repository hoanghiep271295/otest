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
    public class CONTENTLEVEL_BUS: BusinessController<CONTENTLEVEL_OBJ, CONTENTLEVEL_OBJ.BusinessObjectID>
    {
        public CONTENTLEVEL_BUS()
        {
        }
        public override CONTENTLEVEL_OBJ createObject()
        {
            CONTENTLEVEL_OBJ obj = new CONTENTLEVEL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override CONTENTLEVEL_OBJ createNull()
        {
            return null;
        }

    }

}

