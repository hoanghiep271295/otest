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
    public class EXAMFORMDETAIL_BUS: BusinessController<EXAMFORMDETAIL_OBJ, EXAMFORMDETAIL_OBJ.BusinessObjectID>
    {
        public EXAMFORMDETAIL_BUS()
        {
        }
        public override EXAMFORMDETAIL_OBJ createObject()
        {
            EXAMFORMDETAIL_OBJ obj = new EXAMFORMDETAIL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EXAMFORMDETAIL_OBJ createNull()
        {
            return null;
        }

    }

}

