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
    public class UNIVERSITY_BUS: BusinessController<UNIVERSITY_OBJ, UNIVERSITY_OBJ.BusinessObjectID>
    {
        public UNIVERSITY_BUS()
        {
        }
        public override UNIVERSITY_OBJ createObject()
        {
            UNIVERSITY_OBJ obj = new UNIVERSITY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override UNIVERSITY_OBJ createNull()
        {
            return null;
        }

    }

}

