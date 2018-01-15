using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
using IS.Sec;

namespace IS.uni
{
    public class EXAMHALLSTUDENT_BUS: BusinessController<EXAMHALLSTUDENT_OBJ, EXAMHALLSTUDENT_OBJ.BusinessObjectID>
    {
        public EXAMHALLSTUDENT_BUS()
        {
        }
        public override EXAMHALLSTUDENT_OBJ createObject()
        {
            EXAMHALLSTUDENT_OBJ obj = new EXAMHALLSTUDENT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override EXAMHALLSTUDENT_OBJ createNull()
        {
            return null;
        }
        public string encrypt(EXAMHALLSTUDENT_OBJ obj)
        {
            string t = "";
            string ac = "IS.FIT-LQDTU";
            MaHoa sec = new MaHoa();
            string code = string.Format("{0}:{1}:{2}:{3}:{4}:{5}", obj.EXAMTIMECODE, obj.MARKCODE, obj.RECODE, obj.EXAMHALLCODE, obj.CODE, obj.STATUS);

            t = sec.Encrypt(ac, code);
            return t;
        }

    }

}

