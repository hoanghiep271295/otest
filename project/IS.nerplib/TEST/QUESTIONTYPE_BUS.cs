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
    public class QUESTIONTYPE_BUS: BusinessController<QUESTIONTYPE_OBJ, QUESTIONTYPE_OBJ.BusinessObjectID>
    {
        public QUESTIONTYPE_BUS()
        {
        }
        public override QUESTIONTYPE_OBJ createObject()
        {
            QUESTIONTYPE_OBJ obj = new QUESTIONTYPE_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override QUESTIONTYPE_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Lấy về đối tượng hiện tại và đếm số lượng phần tử
        /// </summary>
        /// <param name="questiontypecode"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public QUESTIONTYPE_OBJ getMaxCount(string questiontypecode, out int count)
        {
            QUESTIONTYPE_OBJ obj = GetByID(new QUESTIONTYPE_OBJ.BusinessObjectID(questiontypecode));
            QUESTIONGROUP_BUS bus = new QUESTIONGROUP_BUS();
            int ret = bus.checkCode(null, new fieldpara("questiontypecode", questiontypecode));
            bus.CloseConnection();
            count = ret + 1;
            return obj;
        }
    }

}

