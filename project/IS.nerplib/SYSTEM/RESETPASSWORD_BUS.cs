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
    public class RESETPASSWORD_BUS: BusinessController<RESETPASSWORD_OBJ, RESETPASSWORD_OBJ.BusinessObjectID>
    {
        public RESETPASSWORD_BUS()
        {
        }
        public override RESETPASSWORD_OBJ createObject()
        {
            RESETPASSWORD_OBJ obj = new RESETPASSWORD_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override RESETPASSWORD_OBJ createNull()
        {
            return null;
        }

    }

}

