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
    public class TESTSTRUCTCONTENT_BUS: BusinessController<TESTSTRUCTCONTENT_OBJ, TESTSTRUCTCONTENT_OBJ.BusinessObjectID>
    {
        public TESTSTRUCTCONTENT_BUS()
        {
        }
        public override TESTSTRUCTCONTENT_OBJ createObject()
        {
            TESTSTRUCTCONTENT_OBJ obj = new TESTSTRUCTCONTENT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override TESTSTRUCTCONTENT_OBJ createNull()
        {
            return null;
        }

    }

}

