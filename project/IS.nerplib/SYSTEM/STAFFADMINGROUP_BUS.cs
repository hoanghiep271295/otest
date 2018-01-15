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
    public class STAFFADMINGROUP_BUS: BusinessController<STAFFADMINGROUP_OBJ, STAFFADMINGROUP_OBJ.BusinessObjectID>
    {
        public STAFFADMINGROUP_BUS()
        {
        }
        public override STAFFADMINGROUP_OBJ createObject()
        {
            STAFFADMINGROUP_OBJ obj = new STAFFADMINGROUP_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STAFFADMINGROUP_OBJ createNull()
        {
            return null;
        }
        //public int getByStaff(ref DataSet ds, string tableName, STAFF_OBJ.BusinessObjectID ID)
        //{
        //    int ret=0;
        //    string sql = @"SELECT [staffcode],[admingroupcode]  FROM [staffadmingroup] WHERE [staffcode]=@staffcode";
        //    SqlCommand cm = db.createCommandSQL(sql
        //        , new spParam("@staffcode", SqlDbType.NVarChar, ID.CODE, ParameterDirection.Input)
        //        );
        //    ret= db.getCommand(ref ds, tableName, ref cm);
        //    return ret;
        //}
        //public int deleteByStaff(STAFF_OBJ.BusinessObjectID ID)
        //{
        //    int ret = 0;
        //    string sql = @"DELETE FROM [staffadmingroup] WHERE staffcode = @staffcode";
        //    SqlCommand cm = db.createCommandSQL(sql
        //        , new spParam("@staffcode", SqlDbType.NVarChar, ID.CODE, ParameterDirection.Input)
        //        );
        //    ret= db.doCommand(ref cm);
        //    return ret;
        //}


    }

}

