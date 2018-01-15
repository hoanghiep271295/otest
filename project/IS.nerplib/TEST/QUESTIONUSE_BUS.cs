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
    public class QUESTIONUSE_BUS: BusinessController<QUESTIONUSE_OBJ, QUESTIONUSE_OBJ.BusinessObjectID>
    {
        public QUESTIONUSE_BUS()
        {
        }
        public override QUESTIONUSE_OBJ createObject()
        {
            QUESTIONUSE_OBJ obj = new QUESTIONUSE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override QUESTIONUSE_OBJ createNull()
        {
            return null;
        }

    }

}

