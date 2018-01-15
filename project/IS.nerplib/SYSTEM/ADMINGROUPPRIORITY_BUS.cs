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
    public class ADMINGROUPPRIORITY_BUS: BusinessController<ADMINGROUPPRIORITY_OBJ, ADMINGROUPPRIORITY_OBJ.BusinessObjectID>
    {
        public ADMINGROUPPRIORITY_BUS()
        {
        }
        public override ADMINGROUPPRIORITY_OBJ createObject()
        {
            ADMINGROUPPRIORITY_OBJ obj = new ADMINGROUPPRIORITY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override ADMINGROUPPRIORITY_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Lấy phân quyền của một giáo viên thông qua mã của giáo viên
        /// </summary>
        /// <param name="staffcode"></param>
        /// <returns></returns>
        public List<ADMINGROUPPRIORITY_OBJ> getByStaff(string staffcode)
        {
            int ret = 0;
            DataSet ds = new DataSet();
            string tablename = "priority";
            List<ADMINGROUPPRIORITY_OBJ> li = new List<ADMINGROUPPRIORITY_OBJ>();
            List<jointable> lipara = new List<jointable>();
            lipara.Add(new jointable(typeof(STAFFADMINGROUP_OBJ), "OBJECTCODE", "ADMINGROUPCODE", new fieldpara("OBJECTCODE", staffcode), new fieldpara("THETYPE", "STAFFADMINGROUP")));
            ret = getAllBy(ref ds, tablename, lipara);
            if (ret >= 0)
            {
                foreach (DataRow dr in ds.Tables[tablename].Rows)
                {
                    ADMINGROUPPRIORITY_OBJ obj = this.createObjectFromRow(dr);
                    li.Add(obj);

                }
            }
            return li;
        }
    }

}

