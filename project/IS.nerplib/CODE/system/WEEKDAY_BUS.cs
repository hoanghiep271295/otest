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
    public class WEEKDAY_BUS: BusinessController<WEEKDAY_OBJ, WEEKDAY_OBJ.BusinessObjectID>
    {
        public WEEKDAY_BUS()
        {
        }
        public override WEEKDAY_OBJ createObject()
        {
            WEEKDAY_OBJ obj = new WEEKDAY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override WEEKDAY_OBJ createNull()
        {
            return null;
        }

    }

}

