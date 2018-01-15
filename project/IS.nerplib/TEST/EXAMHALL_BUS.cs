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
    public class EXAMHALL_BUS: BusinessController<EXAMHALL_OBJ, EXAMHALL_OBJ.BusinessObjectID>
    {
        public EXAMHALL_BUS()
        {
        }
        public override EXAMHALL_OBJ createObject()
        {
            EXAMHALL_OBJ obj = new EXAMHALL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EXAMHALL_OBJ createNull()
        {
            return null;
        }

    }

}

