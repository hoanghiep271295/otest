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
    public class EDUCATIONFIELD_BUS: BusinessController<EDUCATIONFIELD_OBJ, EDUCATIONFIELD_OBJ.BusinessObjectID>
    {
        public EDUCATIONFIELD_BUS()
        {
        }
        public override EDUCATIONFIELD_OBJ createObject()
        {
            EDUCATIONFIELD_OBJ obj = new EDUCATIONFIELD_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EDUCATIONFIELD_OBJ createNull()
        {
            return null;
        }

    }

}

