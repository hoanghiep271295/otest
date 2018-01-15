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
    public class LEVELTITLEPRIORITY_BUS: BusinessController<LEVELTITLEPRIORITY_OBJ, LEVELTITLEPRIORITY_OBJ.BusinessObjectID>
    {
        public LEVELTITLEPRIORITY_BUS()
        {
        }
        public override LEVELTITLEPRIORITY_OBJ createObject()
        {
            LEVELTITLEPRIORITY_OBJ obj = new LEVELTITLEPRIORITY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override LEVELTITLEPRIORITY_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Get all role of active levetitles
        /// </summary>
        /// <param name="staffcode"></param>
        /// <returns></returns>
        public List<LEVELTITLEPRIORITY_OBJ> getAllByStaff(string staffcode)
        {
            string sql = "select A.* from leveltitlepriority A INNER JOIN  leveltitlehistory B ON A.objectcode=B.thecode where B.staffcode=@staffcode and ISNULL(B.lock,0)=0 and isnull(B.endtime,'1753-01-01 00:00:00.000')<='1753-01-01 00:00:00.000'";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("staffcode", staffcode, paraType.VARCHAR, 0,0));
            DataSet ds = new DataSet();
            string table = "level";
            int ret = 0;
            ret = getByQuery(ref ds, table, sql, li);
            List<LEVELTITLEPRIORITY_OBJ> liret = new List<LEVELTITLEPRIORITY_OBJ>();
            if(ret<0)
            {
                return liret;
            }
            foreach(DataRow dr in ds.Tables[table].Rows)
            {
                LEVELTITLEPRIORITY_OBJ obj = new LEVELTITLEPRIORITY_OBJ();
                obj = createObjectFromRow(dr);
                liret.Add(obj);
            }
            return liret;
        }
    }

}

