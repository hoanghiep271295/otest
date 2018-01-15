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
    public class QUESTION_BUS: BusinessController<QUESTION_OBJ, QUESTION_OBJ.BusinessObjectID>
    {
        public QUESTION_BUS()
        {
        }
        public override QUESTION_OBJ createObject()
        {
            QUESTION_OBJ obj = new QUESTION_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override QUESTION_OBJ createNull()
        {
            return null;
        }

    }

}

