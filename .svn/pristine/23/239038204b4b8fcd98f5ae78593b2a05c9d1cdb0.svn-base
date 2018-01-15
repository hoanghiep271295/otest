using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using IS.fitframework;
using IS.localcomm;
using IS.uni;
using IS.Pool;
using System.Web.Configuration;
using IS.Config;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;
using System.IO;

namespace nerp
{
    public class update
    {
        string basepath = "";
        int doUpate(string thefile)
        {
            SYSTEMPARAMETER_BUS bus = new SYSTEMPARAMETER_BUS();

            string filename = basepath+ "sqlupdate\\" + thefile ;
            FileInfo file = new FileInfo(filename);
            StreamReader filereader = file.OpenText();
            string script = filereader.ReadToEnd();
            filereader.Close();
            filereader.Dispose();

            string[] ir = new string[] { "GO\t", "GO ", "GO\r\n", "\r\nGO" };
            string[] ac = script.Split(ir, StringSplitOptions.RemoveEmptyEntries);
            int ret = 0;
            ret=bus.BeginTransaction();
            string sql;
            foreach (string i in ac)
            {
                if (ret >= 0 && (!string.IsNullOrWhiteSpace(i)))
                {
                    sql = i;
                    //sql = i.Replace("\r\n", "  ");
                    //sql = sql.Replace("\\r\\n", "  ");
                    //sql = sql.Replace("\t", "      ");
                    //sql = sql.Replace("\\t", "      ");
                    ret = bus.doSql(sql);
                    if(ret<0)
                    {
                        break;
                    }
                }

            }
            if(ret>=0)
            {
                bus.CommitTransaction();
            }
            else
            {
                bus.RollbackTransaction();
            }
            bus.CloseConnection();
            return ret;
        }
        public int updateAll(string _basepath)
        {
            basepath = _basepath;
            localcommonlib com = new localcommonlib();
            int ret = 0;
            SYSTEMPARAMETER_BUS bus = new SYSTEMPARAMETER_BUS();
            SYSTEMPARAMETER_OBJ obj = bus.GetByKey(new fieldpara("CODEVIEW", "VERSION"));
            if(obj== null)
            {
                obj = new SYSTEMPARAMETER_OBJ();
                obj.UNIVERSITYCODE = "HVKTQS";
                obj.CODEVIEW = "VERSION";
                obj.NAME = "Phiên bản";
                obj.VALUE = "0";
            }
            int version = 0;
            version = com.convert2Int(obj.VALUE, 0);

            int thenext = 20;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171128_ver20.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 21;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171129_ver21.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 22;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171130_ver22.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 23;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171205_ver23.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 24;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171205_ver24.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 25;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171206_ver25.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 26;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171206_ver26.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 27;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171206_ver27.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 28;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171206_ver28.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 29;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171206_ver29.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 30;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171206_ver30.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 31;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171208_ver31.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 32;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171209_ver32.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 33;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171212_ver33.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 34;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171218_ver34.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 35;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171218_ver35.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 36;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171218_ver36.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 37;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171221_ver37.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 38;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171221_ver38.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 39;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171224_ver39.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 40;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171225_ver40.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 41;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171226_ver41.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 42;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20171226_ver42.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 43;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20180102_ver43.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 44;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20180102_ver44.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 45;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20180102_ver45.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 46;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20180102_ver46.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 47;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20180103_ver47.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 48;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20180105_ver48.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            thenext = 49;
            if (ret >= 0 && version < thenext)
            {
                ret = doUpate("20180105_ver49.sql");
                if (ret >= 0)
                {
                    obj.VALUE = thenext.ToString();
                }
            }
            int ret2 = 0;
            if (string.IsNullOrEmpty(obj.CODE))
            {
                //thêm mới
                obj.CODE = bus.genNextCode(obj);
                ret2= bus.Insert(obj);                    
            }
            else
            {
                //cập nhật
                obj._ID.CODE = obj.CODE;
                ret2=bus.Update(obj);
            }
            return ret2;
        }
    }
}