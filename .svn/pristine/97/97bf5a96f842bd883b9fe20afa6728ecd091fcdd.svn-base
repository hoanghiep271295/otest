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
    public class DAYOFF_BUS: BusinessController<DAYOFF_OBJ, DAYOFF_OBJ.BusinessObjectID>
    {
        public DAYOFF_BUS()
        {
        }
        public override DAYOFF_OBJ createObject()
        {
            DAYOFF_OBJ obj = new DAYOFF_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override DAYOFF_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Get all dayoff in a year - 
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="year"></param>
        /// <returns></returns>
        public int getByYear(ref DataSet ds, string tableName, int year)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("year", year, SqlDbType.Int, 0));
            string sql = @"select * from dayoff where YEAR(dayoff) = @year";
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// get all day off in a range to compare
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="begin"></param>
        /// <param name="end"></param>
        /// <returns></returns>
        public int getInRange(ref DataSet ds, string tableName, DateTime begin, DateTime end)
        {
            int ret=0;
            string sql="select *, cast(floor(cast(dayoff as float)) as datetime) dayoffex from dayoff where dayoff<=@endtime AND dayoff>=@begintime ORDER BY dayoff";
            List<fieldpara> li =  new List<fieldpara>();
            li.Add(new fieldpara("endtime",end, SqlDbType.DateTime,0));
            li.Add(new fieldpara("begintime",begin, SqlDbType.DateTime,0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
    }

}

