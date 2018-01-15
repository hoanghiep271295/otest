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
    public class STUDENTDISCIPLINETYPE_BUS: BusinessController<STUDENTDISCIPLINETYPE_OBJ, STUDENTDISCIPLINETYPE_OBJ.BusinessObjectID>
    {
        public STUDENTDISCIPLINETYPE_BUS()
        {
        }
        public override STUDENTDISCIPLINETYPE_OBJ createObject()
        {
            STUDENTDISCIPLINETYPE_OBJ obj = new STUDENTDISCIPLINETYPE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STUDENTDISCIPLINETYPE_OBJ createNull()
        {
            return null;
        }

    }

}

