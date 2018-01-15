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
    public class STAFFPROPERTY_BUS: BusinessController<STAFFPROPERTY_OBJ, STAFFPROPERTY_OBJ.BusinessObjectID>
    {
        public STAFFPROPERTY_BUS()
        {
        }
        public override STAFFPROPERTY_OBJ createObject()
        {
            STAFFPROPERTY_OBJ obj = new STAFFPROPERTY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STAFFPROPERTY_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// Lấy các chức danh của giáo viên không thuộc các danh sách nhập quyết định
        /// </summary>
        /// <param name="ds">Nơi nhận dữ liệu</param>
        /// <param name="tableName">Bảng nhận dữ liệu</param>
        /// <param name="thetype">Kiểu bảng nhận dữ liệu *HISTORY</param>
        /// <param name="staffcode">Nhân viên lọc</param>
        /// <param name="universitycode">Đơn vị triển khai</param>
        /// <returns></returns>
        public int getList(ref DataSet ds, string tableName, string thetype, string staffcode, string universitycode)
        {
            int ret = 0;
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("thetype", thetype, 0, 0));
            lipa.Add(new fieldpara("thetypeshort", thetype.Substring(0,thetype.Length-7), 0, 0));//remove the HISTORY
            lipa.Add(new fieldpara("staffcode", staffcode, 0, 0));
//            lipa.Add(new fieldpara("universitycode", universitycode, 0, 0));  //for the next version
            string sql = @"select c.*, A.code recordcode, A.staffcode, A.approvedstatus, A.approvedby, A.approvaltime, A.changecurrrent, A.officialnumber
,A.endtime, A.endtimeshow, A.pickupdate, A.pickupdateshow from (select * from staffpropertyhistory where thetype=@thetype )A
left join
(
select A.*,A.code historycode, B.tablename, B.eventcode from staffinfo A INNER JOIN staffinfodetail B ON A.code=B.staffinfocode
where A.staffcode=@staffcode and B.tablename=@thetype
) B ON A.code = B.eventcode
INNER JOIN (select * FROM staffproperty where thetype=@thetypeshort) C ON A.thecode=C.code
where a.staffcode=@staffcode and B.eventcode is null  
and isnull(A.thecode,'') <>''
order by A.approvedstatus";
            ret = getByQuery(ref ds, tableName, sql, lipa);
            //and c.universitycode=@universitycode
            return ret;
        }

    }

}

