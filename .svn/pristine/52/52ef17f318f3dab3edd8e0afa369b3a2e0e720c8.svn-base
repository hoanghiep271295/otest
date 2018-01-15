using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
using System.Web.UI;
using IS.Comm;
using IS.Sess;
namespace IS.uni
{
    public class SYSTEMPARAMETER_BUS: BusinessController<SYSTEMPARAMETER_OBJ, SYSTEMPARAMETER_OBJ.BusinessObjectID>
    {
        CommonLib com = new CommonLib();
        session ses = new session();
        public SYSTEMPARAMETER_BUS()
        {
        }
        public override SYSTEMPARAMETER_OBJ createObject()
        {
            SYSTEMPARAMETER_OBJ obj = new SYSTEMPARAMETER_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override SYSTEMPARAMETER_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Load all system parameter; It is called by login to get curent parameter, in front end It is called before using global paremeter
        /// </summary>
        /// <returns></returns>
        public int loadParameter()
        {
            int ret = 0;
            DataSet ds = new DataSet();
            ret = getAllBy(ref ds, "syspara", new fieldpara("active", 1));
            if (ret >= 0)
            {

                ses.gHEADEDU = parameterValue(ds.Tables["syspara"], "HEADEDU", "");
                ses.gRECTOR = parameterValue(ds.Tables["syspara"], "RECTOR", "");
                ses.gUNIT1 = parameterValue(ds.Tables["syspara"], "UNIT1", "");
                ses.gUNIT2 = parameterValue(ds.Tables["syspara"], "UNIT2", "");
                ses.gTITLE = parameterValue(ds.Tables["syspara"], "TITLE", "");
                ses.gBRANCH = parameterValue(ds.Tables["syspara"], "BRANCH", "");
                ses.gWEEKEND = com.convert2Int(parameterValue(ds.Tables["syspara"], "WEEKEND", "2"), 2);
                ses.gBRANCHCODE = parameterValue(ds.Tables["syspara"], "BRANCHCODE", "");
                ses.gVERSION = com.convert2Int(parameterValue(ds.Tables["syspara"], "VERSION", "1"), 1);
                ses.gWORKINGYEAR = com.convert2Int(parameterValue(ds.Tables["syspara"], "WORKINGYEAR", "2015"),2015);

            }
            return ret;
        }
        /// <summary>
        /// Get valua from datatable based on @ref key
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        string parameterValue(DataTable dt, string key, string def)
        {
            string value = def;
            if (dt == null)
                return value;
            DataRow[] dr = dt.Select("codeview='" + key + "'");
            if (dr.Length == 1)
            {
                value = com.string4Row(dr[0], "value", def);
            }

            return value;
        }
        /// <summary>
        /// get parameter in date
        /// </summary>
        /// <param name="dt"></param>
        /// <param name="key"></param>
        /// <param name="def"></param>
        /// <returns></returns>
        DateTime parameterValue(DataTable dt, string key, DateTime def)
        {
            DateTime value = def;
            string stringvalue;
            if (dt == null)
                return value;
            DataRow[] dr = dt.Select("codeview='" + key + "'");
            if (dr.Length == 1)
            {
                stringvalue = com.string4Row(dr[0], "value",  def.ToString("dd/MM/yyyy"));
                value = com.date4Text(stringvalue, def);
            }

            return value;
        }
        /// <summary>
        /// Thực hiện câu lệnh SQL cho việc cập nhật file
        /// </summary>
        /// <param name="sql"></param>
        /// <returns></returns>
        public int doSql(string sql)
        {
            List<fieldpara> li_pa = new List<fieldpara>();
            int ret = doQuery(sql, li_pa);
            return ret;
        }
    }

}

