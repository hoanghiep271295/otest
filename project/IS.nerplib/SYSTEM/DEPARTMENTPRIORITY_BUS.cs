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
    public class DEPARTMENTPRIORITY_BUS: BusinessController<DEPARTMENTPRIORITY_OBJ, DEPARTMENTPRIORITY_OBJ.BusinessObjectID>
    {
        public DEPARTMENTPRIORITY_BUS()
        {
        }
        public override DEPARTMENTPRIORITY_OBJ createObject()
        {
            DEPARTMENTPRIORITY_OBJ obj = new DEPARTMENTPRIORITY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override DEPARTMENTPRIORITY_OBJ createNull()
        {
            return null;
        }
        public int getByCode(ref DataSet ds, string tableName, string departmentCode)
        {
            string sql = @"SELECT [departmentcode], [pritoritycode], [isauthorization],[forman]
                            FROM [departmentpriority] WHERE departmentcode = @departmentcode";
            SqlCommand cm = db.createCommandSQL(sql
                , new spParam("@departmentcode", SqlDbType.NVarChar, departmentCode, ParameterDirection.Input)
                );
            return db.getCommand(ref ds, tableName, ref cm);

        }
        public int deleteByCode(string departmentCode)
        {
            string sql = @"DELETE FROM [departmentpriority] WHERE departmentcode = @departmentcode";
            SqlCommand cm = db.createCommandSQL(sql
                , new spParam("@departmentcode", SqlDbType.NVarChar, departmentCode, ParameterDirection.Input)
                );
            return db.doCommand(ref cm);
        }
    }

}

