using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Dynamic;
using System.Data;
//using System.Configuration;
//using System.Web;
//using System.Web.Security;
//using System.Web.UI;
//using System.Web.UI.WebControls;
//using System.Web.UI.WebControls.WebParts;
//using System.Web.UI.HtmlControls;

namespace IS.Lang
{
    public class DynamicLang : DynamicObject
    {
        // The inner dictionary.
        Dictionary<string, object> dictionary
            = new Dictionary<string, object>();

        // This property returns the number of elements
        // in the inner dictionary.
        public int Count
        {
            get
            {
                return dictionary.Count;
            }
        }

        // If you try to get a value of a property 
        // not defined in the class, this method is called.
        public override bool TryGetMember(
            GetMemberBinder binder, out object result)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            string name = binder.Name.ToLower();

            // If the property name is found in a dictionary,
            // set the result parameter to the property value and return true.
            // Otherwise, return false.
            return dictionary.TryGetValue(name, out result);
        }

        // If you try to set a value of a property that is
        // not defined in the class, this method is called.
        public override bool TrySetMember(
            SetMemberBinder binder, object value)
        {
            // Converting the property name to lowercase
            // so that property names become case-insensitive.
            dictionary[binder.Name.ToLower()] = value;

            // You can always add a value to a dictionary,
            // so this method always returns true.
            return true;
        }
    }
    public static class Langresource
    {
        /// <summary>
        /// Load dữ liệu từ file cấu hình với tên bảng tương ứng với tên của các giao diện; ngôn ngữ được xác định trong danh sách lang
        /// </summary>
        /// <param name="filename">Tên file được tính toán đầy đủ</param>
        /// <param name="lang">Tên của ngôn ngữ "vn", "en", ru"</param>
        /// <param name="tableName">Tên bảng tương ứng với tên chức năng được gọi</param>
        /// <param name="clientjson">Chuỗi thay định dạng json để truyền về cho client javascript tạo ra đối tượng json</param>
        /// <returns></returns>
        public static ExpandoObject LangResource(string filename, string lang, string tableName, out string clientjson)
        {
            clientjson = "";
            //Try to load file
            DataSet ds = new DataSet();
            DataRow dr = null;
            try
            {
                ds.ReadXml(filename);
            }
            catch
            {
                return null;
            }

            if (!ds.Tables.Contains(tableName))
            {
                return null;
            }
            foreach (DataRow edr in ds.Tables[tableName].Rows)
            {
                if (edr["id"].ToString() == lang)
                {
                    dr = edr;
                    break;
                }
            }
            if(dr==null)
            {
                return null;
            }
            //try to convert to object dynamically
            int countcolumn, i;
            countcolumn = ds.Tables[tableName].Columns.Count;
            string columnname = "";
            string value = "";
            ExpandoObject obj = new ExpandoObject();
            var dictionary = (IDictionary<string, object>)obj;
            string js = "";
            for (i=0;i<countcolumn;i++)
            {
                columnname = ds.Tables[tableName].Columns[i].ColumnName;
                value = dr[columnname].ToString();
                dictionary.Add(columnname, value);
                if (js != "")
                {
                    js += ",";
                }
                js += string.Format("\"{0}\":\"{1}\"",columnname,value);
            }
            js = "{" + js + "}";
            clientjson = js;
            ExpandoObject b = obj;
            return b;
        }
     }
}
