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
    public class SUBJECTCONTENT_BUS: BusinessController<SUBJECTCONTENT_OBJ, SUBJECTCONTENT_OBJ.BusinessObjectID>
    {
        public SUBJECTCONTENT_BUS()
        {
        }
        public override SUBJECTCONTENT_OBJ createObject()
        {
            SUBJECTCONTENT_OBJ obj = new SUBJECTCONTENT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override SUBJECTCONTENT_OBJ createNull()
        {
            return null;
        }

    }

}

