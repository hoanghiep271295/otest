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
    public class PRIORITY_BUS: BusinessController<PRIORITY_OBJ, PRIORITY_OBJ.BusinessObjectID>
    {
        public PRIORITY_BUS()
        {
        }
        public override PRIORITY_OBJ createObject()
        {
            PRIORITY_OBJ obj = new PRIORITY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override PRIORITY_OBJ createNull()
        {
            return null;
        }
        public int getAuthenList(ref DataSet ds, string tableName)
        {
            string sql = "SELECT [code],[description],[showauth] FROM [priority] WHERE [showauth]=1";
            return db.getSQL(ref ds, tableName, sql);
        }
        //public int getDepartmentAuthen(ref DataSet ds, string tableName)
        //{
        //    string sql = "SELECT [code],[description],[showauth] FROM [priority] WHERE [showauth]=1";
        //    return db.getSQL(ref ds, tableName, sql);
        //}
        /// <summary>
        /// Lấy danh sách các phân quyền chưa được chọn trong nhóm này
        /// </summary>
        /// <param name="admingroupcode"></param>
        /// <returns></returns>
        public List<PRIORITY_OBJ> getUncheck(string admingroupcode)
        {
            string sql = @"select A.* from priority A 
LEFT JOIN (SELECT * FROM ADMINGROUPPRIORITY WHERE thetype='ADMINGROUPPRIORITY' and thecode=@admingroupcode) B ON A.code=B.prioritycode
WHERE B.prioritycode is null order by A.groupcode
";
            int ret = 0;
            List<PRIORITY_OBJ> li = new List<PRIORITY_OBJ>();
            DataSet ds = new DataSet();
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("admingroupcode", admingroupcode, 0, 0));
            ret = getByQuery(ref ds, "PRIORITY", sql, lipa);
            if (ret < 0)
            {
                return null;
            }
            foreach (DataRow dr in ds.Tables["PRIORITY"].Rows)
            {
                PRIORITY_OBJ obj_temp = createObjectFromRow(dr);
                li.Add(obj_temp);
            }
            return li;
        }
    }

}

