using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
using Microsoft.SqlServer.Server;

namespace IS.uni
{
    public class TESTSTRUCTDETAIL_BUS: BusinessController<TESTSTRUCTDETAIL_OBJ, TESTSTRUCTDETAIL_OBJ.BusinessObjectID>
    {
        public TESTSTRUCTDETAIL_BUS()
        {
        }
        public override TESTSTRUCTDETAIL_OBJ createObject()
        {
            TESTSTRUCTDETAIL_OBJ obj = new TESTSTRUCTDETAIL_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override TESTSTRUCTDETAIL_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Lấy danh sách test struct detail thông qua mã cấu trúc
        /// </summary>
        /// <param name="teststructcode"></param>
        /// <param name="universitycode"></param>
        /// <returns></returns>
        public List<TESTSTRUCTDETAIL_OBJ> getByTestStruct(string teststructcode, string universitycode)
        {
            List<TESTSTRUCTDETAIL_OBJ> data = null;
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("TESTSTRUCTCODE", teststructcode, 0));
            lipa.Add(new fieldpara("UNIVERSITYCODE", universitycode, 0));
            data= getAllBy2("CODE", lipa.ToArray());
            return data;

        }

    }

}

