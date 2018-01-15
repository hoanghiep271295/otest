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
    public class MARKDETAIL_BUS: BusinessController<MARKDETAIL_OBJ, MARKDETAIL_OBJ.BusinessObjectID>
    {
        public MARKDETAIL_BUS()
        {
        }
        public override MARKDETAIL_OBJ createObject()
        {
            MARKDETAIL_OBJ obj = new MARKDETAIL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override MARKDETAIL_OBJ createNull()
        {
            return null;
        }
        
    }

}

