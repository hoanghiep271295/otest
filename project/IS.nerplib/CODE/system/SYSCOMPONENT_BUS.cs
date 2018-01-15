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
    public class SYSCOMPONENT_BUS: BusinessController<SYSCOMPONENT_OBJ, SYSCOMPONENT_OBJ.BusinessObjectID>
    {
        public SYSCOMPONENT_BUS()
        {
        }
        public override SYSCOMPONENT_OBJ createObject()
        {
            SYSCOMPONENT_OBJ obj = new SYSCOMPONENT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override SYSCOMPONENT_OBJ createNull()
        {
            return null;
        }

    }

}

