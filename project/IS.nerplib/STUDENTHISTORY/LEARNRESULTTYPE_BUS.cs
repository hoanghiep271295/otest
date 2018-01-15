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
    public class LEARNRESULTTYPE_BUS: BusinessController<LEARNRESULTTYPE_OBJ, LEARNRESULTTYPE_OBJ.BusinessObjectID>
    {
        public LEARNRESULTTYPE_BUS()
        {
        }
        public override LEARNRESULTTYPE_OBJ createObject()
        {
            LEARNRESULTTYPE_OBJ obj = new LEARNRESULTTYPE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override LEARNRESULTTYPE_OBJ createNull()
        {
            return null;
        }

    }

}

