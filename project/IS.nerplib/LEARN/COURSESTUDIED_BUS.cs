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
    public class COURSESTUDIED_BUS: BusinessController<COURSESTUDIED_OBJ, COURSESTUDIED_OBJ.BusinessObjectID>
    {
        public COURSESTUDIED_BUS()
        {
        }
        public override COURSESTUDIED_OBJ createObject()
        {
            COURSESTUDIED_OBJ obj = new COURSESTUDIED_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override COURSESTUDIED_OBJ createNull()
        {
            return null;
        }

    }

}

