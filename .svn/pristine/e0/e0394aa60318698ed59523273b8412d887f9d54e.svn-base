using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.Comm;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.IO;
namespace IS.localcomm
{    
    /// <summary>
    /// provides all common function for only this solution.
    /// </summary>   

    public class localcommonlib : CommonLib
    {     
        /// <summary>
        /// check if the text is vietnameses, return "vn" for vietnamese else "en"
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        static public string languageDetect(string text)
        {
            string[] vietnammes = { "À", "á", "Â", "ã", "È", "É", "Ê", "Ì", "Í", "Ò", "ó", "Ô", "Õ", "Ù", "Ú", "Ý", "à", "á", "â", "ã", "è", "é", "ê", "ì", "í", "ò", "ó", "ô", "õ", "ù", "ú", "ý", "Ă", "ă", "Đ", "đ", "Ĩ", "ĩ", "Ũ", "ũ", "Ơ", "ơ", "Ư", "ư", "Ạ", "ạ", "Ả", "ả", "Ấ", "ấ", "Ầ", "ầ", "Ẩ", "ẩ", "Ẫ", "ẫ", "Ậ", "ậ", "Ẵ", "ẵ", "Ằ", "ằ", "Ẳ", "ẳ", "Ắ", "ắ", "Ặ", "ặ", "Ẹ", "ẹ", "Ẻ", "ẻ", "Ẽ", "ẽ", "Ế", "ế", "Ề", "ề", "Ể", "ể", "Ễ", "ễ", "Ệ", "ệ", "Ỉ", "ỉ", "Ị", "ị", "Ọ", "ọ", "Ỏ", "ỏ", "Ố", "ố", "Ồ", "ồ", "Ổ", "ổ", "Ỗ", "ỗ", "Ộ", "ộ", "Ớ", "ớ", "Ờ", "ờ", "Ở", "ở", "Ỡ", "ỡ", "Ợ", "ợ", "Ụ", "ụ", "Ủ", "ủ", "Ứ", "ứ", "Ừ", "ừ", "Ử", "ử", "Ữ", "ữ", "Ự", "ự", "Ỳ", "ỳ", "Ỵ", "ỵ", "Ỷ", "ỷ", "Ỹ", "ỹ" };
            int i, count = 0;

            for (i = 0; i < vietnammes.Length; i++)
            {
                if (text.Contains(vietnammes[i]))
                {
                    count++;
                    if (count >= 2)
                        break;
                }
            }
            if (count >= 2)
            {
                return "vn";
            }
            return "en";
        }
        /// <summary>
        /// try to calculate the file name with delivery option and type option
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="branch"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string realFileName(string fileName, string branch, string type)
        {
            string pre = fileName;
            string suf = "";
            string dot = "";
            int lastDot = fileName.LastIndexOf('.');
            if (lastDot >= 0 && lastDot < fileName.Length)
            {
                //has dot
                dot = ".";
                pre = fileName.Substring(0, lastDot - 1);
                suf = fileName.Substring(lastDot);
            }
            if (!(branch == "" || branch == "HVKTQS"))
            {
                pre += branch;
            }
            if (!(type == "" || type == "QS"))
            {
                pre += type;
            }
            return pre + dot + suf;
        }
        /// <summary>
        /// try to calculate file name with type (without branch)
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="type"></param>
        /// <returns></returns>
        public string realFileName(string fileName, string type)
        {
            string pre = fileName;
            string suf = "";
            string dot = "";
            int lastDot = fileName.LastIndexOf('.');
            if (lastDot >= 0 && lastDot < fileName.Length)
            {
                //has dot
                dot = ".";
                pre = fileName.Substring(0, lastDot - 1);
                suf = fileName.Substring(lastDot);
            }
            if (!(type == "" || type == "QS"))
            {
                pre += type;
            }
            return pre + dot + suf;
        }
 
        /// <summary>
        /// Get checkbox control from list of controls,
        /// </summary>
        /// <param name="cts">List of controls</param>
        /// <param name="name">Name of checkbox control</param>
        /// <returns>null if cannot find out</returns>
        public static CheckBox getCheckControl(ControlCollection cts, string name)
        {

            CheckBox c;
            int i;
            name = name.ToUpper();
            for (i = 0; i < cts.Count; i++)
            {
                if (cts[i] != null)
                {
                    if (cts[i].ID != null)
                    {
                        if (cts[i].ID.ToUpper() == name)
                        {
                            break;
                        }
                    }
                }
            }
            if (i == cts.Count)
                return null;
            try
            {
                c = (CheckBox)cts[i];
            }
            catch
            {
                return null;
            }
            return c;
        }
        /// <summary>
        /// Get text box control from list of controls,
        /// </summary>
        /// <param name="cts">List of controls</param>
        /// <param name="name">Name of text box control</param>
        /// <returns>null if cannot find out</returns>
        public static TextBox getTextBoxControl(ControlCollection cts, string name)
        {
            TextBox c;
            int i;
            name = name.ToUpper();
            for (i = 0; i < cts.Count; i++)
            {
                if (cts[i] != null)
                {
                    if (cts[i].ID != null)
                    {
                        if (cts[i].ID.ToUpper() == name)
                        {
                            break;
                        }
                    }
                }
            }
            if (i == cts.Count)
                return null;
            try
            {
                c = (TextBox)cts[i];
            }
            catch
            {
                return null;
            }
            return c;

        }
        /// <summary>
        /// Get hidden control from list of controls,
        /// </summary>
        /// <param name="cts">List of controls</param>
        /// <param name="name">Name of hidden control</param>
        /// <returns>null if cannot find out</returns>
        public static HiddenField getHiddenControl(ControlCollection cts, string name)
        {
            HiddenField c;
            int i;
            name = name.ToUpper();
            for (i = 0; i < cts.Count; i++)
            {
                if (cts[i] != null)
                {
                    if (cts[i].ID != null)
                    {
                        if (cts[i].ID.ToUpper() == name)
                        {
                            break;
                        }
                    }
                }
            }
            if (i == cts.Count)
                return null;
            try
            {
                c = (HiddenField)cts[i];
            }
            catch
            {
                return null;
            }
            return c;



        }
        /// <summary>
        /// show message box in client; The client must declare the approximate html control  as below
        ///&lt;div id=&quot;output&quot;&gt;&lt;/div&gt;
        ///&lt;div id=&quot;overlay&quot; class=&quot;web_dialog_overlay&quot;&gt;&lt;/div&gt;
        ///&lt;div id=&quot;dialog&quot; class=&quot;web_dialog&quot;&gt;
        ///   &lt;table style=&quot;width: 100%; border: 0px;&quot; cellpadding=&quot;3&quot; cellspacing=&quot;0&quot;&gt;
        ///      &lt;tr&gt;
        ///         &lt;td class=&quot;web_dialog_title&quot; &gt;
        ///&lt;div id=&quot;divMessageTitleBack&quot;&gt;&lt;div id=&quot;divMessageTitle&quot; style=&quot;display: inline;&quot;&gt;Th&#244;ng b&#225;o&lt;/div&gt; 
        ///&lt;div id=&quot;divMessageTitle1&quot; style=&quot;float: right;display: inline; text-align:right;&quot;&gt;&lt;a href=&quot;#&quot; id=&quot;btnClose&quot;&gt;[ Đ&#243;ng ]&lt;/a&gt;&lt;/div&gt;
        ///&lt;/div&gt;
        ///&lt;/td&gt;
        ///&lt;/tr&gt;
        ///&lt;tr&gt;&lt;td &gt;&lt;div id=&quot;divMessageContent&quot; style=&quot;text-align:center&quot;&gt; Kh&#244;ng c&#243; g&#236; để th&#244;ng b&#225;o cả&lt;/div&gt;&lt;/td&gt;&lt;/tr&gt;
        ///&lt;tr&gt;
        ///&lt;td style=&quot;text-align: center;&quot; &gt;
        ///&lt;input id=&quot;btnSubmit&quot; type=&quot;button&quot; value=&quot;Đ&#243;ng&quot; /&gt;
        ///&lt;/td&gt;
        ///&lt;/tr&gt;
        ///&lt;/table&gt;
        ///&lt;/div&gt;
        /// </summary>
        /// <param name="a">The updatepanel in page to call this function (Updatepanel1)</param>
        /// <param name="t">The type of page call this function (GetType())</param>
        /// <param name="title">The title of dialog</param>
        /// <param name="mes">Messagebox including html format</param>
        /// <param name="modal">true: modal - must close this dialog befor other acitons, false: auto close when click outside this dialog</param>
        /// <param name="time">time waiting in milisecond, -1: none stop</param>
        /// <returns></returns>
        public int clientShowMessage(UpdatePanel a,  Type t, string title, string mes, bool modal, int time)
        {
            int ret = 0;
            string v="warning('{0}','{1}',{2},{3});  document.getElementById(\"btnSubmit\").focus();";
            v=string.Format(v,title,mes,modal.ToString().ToLower(),time);
            System.Web.UI.ScriptManager.RegisterStartupScript(a,t,"myScript",v,true);
            //ScriptManager
            //a.RegisterStartupScript(t, "MyScript", v, true);
            return ret;
        }
        /// <summary>
        /// set menu
        /// </summary>
        /// <param name="a"></param>
        /// <param name="script"></param>
        /// <returns></returns>
        public int setMenu(Page a, string menuname)
        {
            return setMenu(a, menuname, "selected");

        }
        /// <summary>
        /// set menu
        /// </summary>
        /// <param name="a"></param>
        /// <param name="script"></param>
        /// <returns></returns>
        public int setMenu(Page a, string menuname,string status)
        {
            int ret = 0;
            //            string v="document.getElementById(\"++\").focus();";
            //            v=string.Format(v,title,mes,modal.ToString().ToLower(),time);
            ClientScriptManager cs = a.ClientScript;
            String csname2 = "menuname";
            Type cstype = this.GetType();
            if (!cs.IsClientScriptBlockRegistered(cstype, csname2))
            {
                StringBuilder cstext2 = new StringBuilder();
                cstext2.Append("<script type=\"text/javascript\"> ");
                cstext2.Append(string.Format("document.getElementById('{0}').className = '{1}';", menuname,status));
                cstext2.Append("</script>");
                cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), false);
            }
            //            System.Web.UI.ScriptManager.RegisterStartupScript(a,t,"myScript",script,true);
            //ScriptManager
            //a.RegisterStartupScript(t, "MyScript", v, true);
            return ret;

        }
        /// <summary>
        /// show and hid men
        /// </summary>
        /// <param name="a"></param>
        /// <param name="menuname"></param>
        /// <param name="status"></param>
        /// <returns></returns>
        public int hideMenu(Page a, string menuname, string status)
        {
            ClientScriptManager cs = a.ClientScript;
            String csname2 = menuname;
            Type cstype = this.GetType();
            if (!cs.IsClientScriptBlockRegistered(cstype, csname2))
            {
                StringBuilder cstext2 = new StringBuilder();
                cstext2.Append("<script type=\"text/javascript\"> ");
//                cstext2.Append("alert('hello');");
                cstext2.Append(string.Format("document.getElementById('{0}').style.display = '{1}';", menuname, status));
//                cstext2.Append("alert(\"" + string.Format("document.getElementById('{0}').style.display = '{1}';", menuname, status) + "\");");
                cstext2.Append("</script>");
                cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), false);
            }
            return 0;

        }
        /// <summary>
        /// Hid menu
        /// </summary>
        /// <param name="a"></param>
        /// <param name="menuname"></param>
        /// <returns></returns>
        public int hideMenu(Page a, string menuname)
        {
            return hideMenu(a, menuname, "none");
        }

        /// <summary>
        /// run alient script
        /// </summary>
        /// <param name="a"></param>
        /// <param name="script"></param>
        /// <returns></returns>
        public int clientScripting(Page a, string script)
        {
            int ret = 0;
//            string v="document.getElementById(\"++\").focus();";
//            v=string.Format(v,title,mes,modal.ToString().ToLower(),time);
            ClientScriptManager cs = a.ClientScript;
            String csname2 = "clientscript";
            Type cstype = this.GetType();
            if(!cs.IsClientScriptBlockRegistered(cstype, csname2))
            {
                StringBuilder cstext2 = new StringBuilder();
                cstext2.Append("<script type=\"text/javascript\"> ");
                cstext2.Append(script);
                cstext2.Append("</script>");
                cs.RegisterClientScriptBlock(cstype, csname2, cstext2.ToString(), false);
            }
//            System.Web.UI.ScriptManager.RegisterStartupScript(a,t,"myScript",script,true);
            //ScriptManager
            //a.RegisterStartupScript(t, "MyScript", v, true);
            return ret;

        }
        /// <summary>
        /// Hiển thị thông báo của client sau đó tiến hành chuyển focus đến đối tượng được định nghĩa trong focusID
        /// </summary>
        /// <param name="a"></param>
        /// <param name="t"></param>
        /// <param name="title"></param>
        /// <param name="mes"></param>
        /// <param name="modal"></param>
        /// <param name="focusID"></param>
        /// <param name="time"></param>
        /// <returns></returns>
        public int clientShowMessage(UpdatePanel a, Type t, string title, string mes, bool modal, string focusID, int time)
        {
            int ret = 0;
            string v = "warningFocus('{0}','{1}',{2},{3},'{4}');  document.getElementById(\"btnSubmit\").focus();";
            v = string.Format(v, title, mes, modal.ToString().ToLower(), time,focusID);
            System.Web.UI.ScriptManager.RegisterStartupScript(a, t, "myScript", v, true);
            //ScriptManager
            //a.RegisterStartupScript(t, "MyScript", v, true);
            return ret;
        }
        /// <summary>
        /// change client
        /// </summary>
        /// <param name="a"></param>
        /// <param name="t"></param>
        /// <param name="id"></param>
        /// <param name="sh"></param>
        /// <returns></returns>
        public int showObject(UpdatePanel a, Type t, string id, string sh)
        {
            int ret = 0;
            string v = "document.getElementById(\"{0}\").style.display = '{1}';";
            v = string.Format(v, id,sh);
            System.Web.UI.ScriptManager.RegisterStartupScript(a, t, "myScript", v, true);
            //ScriptManager
            //a.RegisterStartupScript(t, "MyScript", v, true);
            return ret;
        }
        public int callClientScript(UpdatePanel a, Type t, string key, string func)
        {
            int ret = 0;
            System.Web.UI.ScriptManager.RegisterStartupScript(a, t, key, func, true);
            return ret;
        }
        /// <summary>
        /// show message box in client; The client must declare the approximate html control  as below, after finishing will change to url; all thing like above <see cref="clientShowMessage"/>
        /// </summary>
        /// <param name="a"></param>
        /// <param name="t"></param>
        /// <param name="title"></param>
        /// <param name="mes"></param>
        /// <param name="modal"></param>
        /// <param name="time"></param>
        /// <param name="url"></param>
        /// <returns></returns>
        public int clientShowMessage(UpdatePanel a, Type t, string title, string mes, bool modal, int time, string url)
        {
            int ret = 0;
            string v = "warningUrl('{0}','{1}',{2},{3},'{4}');  document.getElementById(\"btnSubmit\").focus();";
            v = string.Format(v, title, mes, modal.ToString().ToLower(), time,url);
            System.Web.UI.ScriptManager.RegisterStartupScript(a, t, "myScript", v, true);
            //ScriptManager
            //a.RegisterStartupScript(t, "MyScript", v, true);
            return ret;
        }
        /// <summary>
        /// convert lock status to string for tables. Return 'Khóa' for all value except 0
        /// </summary>
        /// <param name="obj">lock status in int format</param>
        /// <returns></returns>
        public string isLock(object obj)
        {
            if (obj == null)
            {
                return "";
            }
            if (obj == DBNull.Value)
            {
                return "";
            }
            int v = this.convert2Int(obj.ToString(), 0);
            if (v == 0)
            {
                return "";
            }
            return "Khóa";
        }
        /// <summary>
        /// replace the pattern (pa) with value (v) with the bound is {} or not
        /// </summary>
        /// <param name="s"></param>
        /// <param name="pa"></param>
        /// <param name="v"></param>
        /// <returns></returns>
        public string replaceIf(string s, params string [] key)
        {
            int ii;
            string pa, v;
            for (ii = 0; ii < key.Length / 2; ii++)
            {
                pa = key[ii * 2];
                v = key[ii * 2 + 1];
                string before = "", after = "", mid;
                int fi = s.IndexOf(pa);
                if (fi < 0)
                {
                    //do nothing
                    continue;
                }
                int le = fi, ri = fi + pa.Length-1;
                int i, len = s.Length;
                //locate the {
                i = le ;
                while (i >= 0 && s[i] != '{' && s[i] != '}')
                    i--;
                if (i >= 0)
                {
                    if (s[i] == '{')
                        le = i;
                }
                //locate the }
                i = ri ;
                while (i < len && s[i] != '{' && s[i] != '}')
                    i++;
                if (i < len)
                {
                    if (s[i] == '}')
                        ri = i;
                }
                before = s.Substring(0, le);
                mid = s.Substring(le, ri - le + 1);
                if (v == "")
                {
                    mid = "";
                }
                else
                {
                    mid = mid.Replace(pa, v);
                    if (mid[0] == '{')
                    {
                        mid = mid.Substring(1, mid.Length - 1);
                    }
                    if (mid[mid.Length - 1] == '}')
                    {
                        mid = mid.Substring(0, mid.Length - 1);
                    }
                }
                after = s.Substring(ri + 1);
                s= before + mid + replaceIf(after, pa, v);
            }
            return s;

        }
        /// <summary>
        /// text date like Aug 2014
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public string textDate(string d)
        {
            if(string.IsNullOrEmpty(d))
            {
                return "";
            }
            d = d.Trim();//remove last space
            int li = d.LastIndexOf(" ");
            string y = "", m = "";
            if (li > 0)
            {
                y = d.Substring(li).Trim();
                m = d.Substring(0, li);
            }
            if (y.Length == 4 || y.Length == 2)
            {
                int yi = convert2Int(y, 0);
                if (yi == 0)
                {
                    return "";
                }
                if (yi < 100)
                {
                    if (yi < 50)
                    {
                        yi = yi + 2000;
                    }
                    else
                    {
                        yi = yi + 1900;
                    }

                }
                y = yi.ToString();
            }
            else
            {
                return "";
            }
            if (m == "")
            {
                return "1/1/" + y;
            }
            string[] monthname = { "Jan", "Feb", "Mar", "Apr", "May", "Jun", "Jul", "Aug", "Sep", "Oct", "Nov", "Dec" };
            int mi = -1;
            for (int i = 0; i < monthname.Length; i++)
            {
                if (m.Contains(monthname[i]))
                {
                    mi = i + 1;
                    break;
                }
            }
            if (mi == -1)
            {
                return "";
            }
            m = mi.ToString();
            return "1/" + m + "/" + y;
        }
        /// <summary>
        /// convert list of author in bib format to reference format
        /// </summary>
        /// <param name="author"></param>
        /// <param name="language"></param>
        /// <returns></returns>
        static public string author2display(string author, string language)
        {
            if(author==null)
            {
                return "";
            }
            string s = author;
            string outp = s;
            int vt = s.LastIndexOf(";");
            string and = " and ";
            if (language.ToUpper() == "VN")
            {
                and = " và ";
            }
            if (vt > 0)
            {
                outp = s.Substring(0, vt).Replace(";", ", ") + and + s.Substring(vt + 1);
                outp = outp.Trim();
            }
            outp = outp.Replace("  ", " ");
            return outp;
        }
        /// <summary>
        /// convert list of author in bib
        /// </summary>
        /// <param name="author"></param>
        /// <returns></returns>
        static public string author2P6(string author)
        {
            if (author != null)
            {
                string s = author.Replace(" and ", "; ");
                return s;
            }
            return author;
        }
        /// <summary>
        /// try to convert input date to date time; input may only year, month/year and full
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public string convert2DatePaper(string d)
        {
            if (d == "")
            {
                return "";
            }
            //full datetime
            if (checkDate(d) == 0)
            {
                return d;
            }
            //month/yyyy
            if (checkDate("01/" + d) == 0)
            {
                return "01/" + d;
            }
            //check for Aug 2014
            string cd = textDate(d);
            if (cd != "")
            {
                return cd;
            }
            //not number only
            if (checkInt(d) != 0)
            {
                return "";
            }
            //number on ly
            int v = convert2Int(d, 0);
            if (v == 0)
            {
                return "";
            }
            //only year/ month is 1
            if (v < 9000)
            {
                return "1/1/" + d;
            }
            //month and year
            if (v < 130000)
            {
                int m = v / 10000;
                int y = v % 10000;
                return string.Format("1/{0}/{1}", m, y);
            }
            if (v < 32000000)
            {
                int dd = v / 1000000;
                int mm = (v % 1000000) / 10000;
                int yy = v % 10000;
                return string.Format("{0}/{1}/{2}", dd, mm, yy);
            }
            return "";
        }
        /// <summary>
        /// Tự động điền thêm phần ngày, tháng thiếu trong năm  với định dạng d/M/yyyy
        /// </summary>
        /// <param name="d"></param>
        /// <returns></returns>
        public string fillDate(string d)
        {
            if (d == "")
            {
                return "";
            }
            //full datetime
            if (checkDate(d) == 0)
            {
                return d;
            }
            //month/yyyy
            if (checkDate("01/" + d) == 0)
            {
                return "01/" + d;
            }
            //check for Aug 2014
            string cd = textDate(d);
            if (cd != "")
            {
                return cd;
            }
            //not number only
            if (checkInt(d) != 0)
            {
                return "";
            }
            //number on ly
            int v = convert2Int(d, 0);
            if (v == 0)
            {
                return "";
            }
            //only year/ month is 1
            if (v < 9000)
            {
                return "1/1/" + d;
            }
            //month and year
            if (v < 130000)
            {
                int m = v / 10000;
                int y = v % 10000;
                return string.Format("1/{0}/{1}", m, y);
            }
            if (v < 32000000)
            {
                int dd = v / 1000000;
                int mm = (v % 1000000) / 10000;
                int yy = v % 10000;
                return string.Format("{0}/{1}/{2}", dd, mm, yy);
            }
            return "";
        }
        /// <summary>
        /// Chuyển từ ngày tháng sang quý và năm
        /// </summary>
        /// <param name="currentdate"></param>
        /// <param name="year"></param>
        /// <param name="quater"></param>
        /// <returns></returns>
        public int getQuater(DateTime currentdate, out int year, out int quater)
        {
            DateTime c = currentdate;
            int y, m, d, q, qy;
            y = c.Year;
            m = c.Month;
            d = c.Day;

            q = (m - 1) / 3 + 1;
            if (d > 15 && m % 3 == 0)
                q++;
            qy = y;
            if (q > 4)
            {
                q = 1;
                qy++;
            }
            year = qy;
            quater = q;
            return 0;
        }
        /// <summary>
        /// Chuyển từ ngày tháng sang quý và năm học theo mô hình cũ
        /// </summary>
        /// <param name="currentdate"></param>
        /// <param name="year"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public int getTermYear( DateTime currentdate, out int year, out int term)
        {
            DateTime c = currentdate;
            int y, m, d, t, ty;
            y = c.Year;
            m = c.Month;
            d = c.Day;
            if (m >= 8)
            {
                t = 1;
                ty = y;
            }
            else
            {
                t = 2;
                ty = y - 1;
            }
            term = t;
            year = ty;

            return 0;
        }
        /// <summary>
        /// Chuyển đổi thời gian theo name học thành ngày
        /// </summary>
        /// <param name="year">Năm học</param>
        /// <param name="term">Học kỳ cần xet 0, 1, 2,</param>
        /// <param name="beginterm1">Thời điểm bắt đầu của kỳ 1(được lưu trong session)</param>
        /// <param name="endterm1">Thời điểm kết thúc kỳ 1 (được lưu trong session)</param>
        /// <param name="beginterm2">Thời điểm bắt đầu của kỳ 2(được lưu trong session)</param>
        /// <param name="endterm2">Thời điểm kết thúc kỳ 2 (được lưu trong session)</param>
        /// <param name="begintime">thời điểm bắt đầu</param>
        /// <param name="endtime">thời điểm kết thúc</param>
        public void getBeginEndTime(int year, int term, DateTime beginterm1, DateTime endterm1, DateTime beginterm2, DateTime endterm2, ref DateTime begintime, ref DateTime endtime)
        {
            begintime = new  DateTime(year, beginterm1.Month, beginterm1.Day);
            endtime = new DateTime(year + endterm2.Year-beginterm1.Year, endterm2.Month, endterm2.Day);
            if(term==1)
            {
                //shorten the end
                endtime = new DateTime(year + endterm1.Year - beginterm1.Year, endterm1.Month, endterm1.Day);
            }
            if(term==2)
            {
                //move up the begin
                begintime= new DateTime(year + beginterm2.Year - beginterm1.Year, beginterm1.Month, beginterm1.Day);
            }
        }
        #region lam viec voi thong so tu client
        /// <summary>
        /// Lấy địa chỉ IP máy trạm; \n Lời gọi ham trong mỗi trang là getIp(this)
        /// </summary>
        /// <param name="p">Trang web cần được đưa vao</param>
        /// <returns></returns>
        public string getIp(HttpRequestBase p)
        {
            string visitorIPAddress = p.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (String.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = p.ServerVariables["REMOTE_ADDR"];

            if (string.IsNullOrEmpty(visitorIPAddress))
                visitorIPAddress = p.UserHostAddress;
            return visitorIPAddress;
        }
        /// <summary>
        /// Lấy trình duyệt web đang thực hiện
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string getWebBrowser(HttpRequestBase p)
        {
            string name = p.Browser.Browser;
            if (name == null)
            {
                name = "";
            }
            string version = p.Browser.Version;
            if (version == null)
            {
                version = "";
            }
            if (version != "")
            {
                name += " (" + version + ")";
            }
            return name;
        }
        /// <summary>
        /// Lấy hệ điều hành
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string getOS(HttpRequestBase p)
        {
            string name = p.Browser.Platform;
            string agent = p.UserAgent;
            if (agent == null)
            {
                agent = "";
            }
            if (name == null)
            {
                name = "";
            }
            string convertofullname = "";
            if (agent.IndexOf("Windows NT 6.3") > 0)
            {
                //Windows 8.1
            }
            else if (agent.IndexOf("Windows NT 6.2") > 0)
            {
                convertofullname = "Windows 8";
            }
            else if (agent.IndexOf("Windows NT 6.1") > 0)
            {
                convertofullname = "Windows 7";
            }
            else if (agent.IndexOf("Windows NT 6.0") > 0)
            {
                convertofullname = "Windows Vista";
            }
            else if (agent.IndexOf("Windows NT 5.2") > 0)
            {
                convertofullname = "Windows Server 2003; Windows XP x64 Edition";
            }
            else if (agent.IndexOf("Windows NT 5.1") > 0)
            {
                convertofullname = "Windows XP";
            }
            else if (agent.IndexOf("Windows NT 5.01") > 0)
            {
                convertofullname = "Windows 2000, Service Pack 1 (SP1)";
            }
            else if (agent.IndexOf("Windows NT 5.0") > 0)
            {
                convertofullname = "Windows 2000";
            }
            else if (agent.IndexOf("Windows NT 4.0") > 0)
            {
                convertofullname = "Microsoft Windows NT 4.0";
            }
            else if (agent.IndexOf("Win 9x 4.90") > 0)
            {
                convertofullname = "Windows Millennium Edition (Windows Me)";
            }
            else if (agent.IndexOf("Windows 98") > 0)
            {
                convertofullname = "Windows 98";
            }
            else if (agent.IndexOf("Windows 95") > 0)
            {
                convertofullname = "Windows 95";
            }
            else if (agent.IndexOf("Windows CE") > 0)
            {
                convertofullname = "Windows CE";
            }
            else if (agent.IndexOf("Linux") > 0)
            {
                if (p.Browser.IsMobileDevice)
                {
                    convertofullname = "Android";
                }
                else
                {
                    convertofullname = "Linux";
                }
            }
            else if (agent.IndexOf("iPhone OS") > 0)
            {
                if (p.Browser.IsMobileDevice)
                {
                    convertofullname = "iPhone";
                }
                else
                {
                    convertofullname = "Mac";
                }
            }
            else if (agent.IndexOf("Mac OS") > 0)
            {
                if (p.Browser.IsMobileDevice)
                {
                    convertofullname = "iPhone";
                }
                else
                {
                    convertofullname = "Mac";
                }
            }

            if (agent != "" || convertofullname != "")
            {
                name += "(" + convertofullname + ")" + "-(" + agent + ")";
            }

            return name;
        }
        /// <summary>
        /// Trạng thái được gọi từ mobile
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string isMobile(HttpRequestBase p)
        {
            return p.Browser.IsMobileDevice.ToString();
        }
        /// <summary>
        /// Lấy tên máy
        /// </summary>
        /// <param name="p"></param>
        /// <returns></returns>
        public string getComputerName(HttpRequestBase p)
        {
            //string[] computer_name = System.Net.Dns.GetHostEntry(p.Request.ServerVariables["remote_addr"]).HostName.Split(new Char[] { '.' });
            //String ecn = System.Environment.MachineName;
            //return computer_name[0].ToString();
            return "";
        }
        #endregion
        /// <summary>
        /// Lấy phần mở rộng của file 
        /// </summary>
        /// <param name="fileName"></param>
        /// <returns></returns>
        public string fileExtension(string fileName)
        {
            string dot = "";
            int lastDot = fileName.LastIndexOf('.');
            if (lastDot >= 0 && lastDot < fileName.Length)
            {
                //has dot
                dot = fileName.Substring(lastDot + 1);
            }
            return dot;
        }
        /// <summary>
        /// Tạo đường dẫn, nếu không thành công trả về ""
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public string createDirectory(string directory)
        {
            try
            {
                Directory.CreateDirectory(directory);
                return directory;
            }
            catch
            {
                return "";
            }
        }
        /// <summary>
        /// Lấy giá trị truyền qua url trong MVC thông qua đối tượng request
        /// </summary>
        /// <param name="rq">Đối tượng request hiện thời</param>
        /// <param name="key">Tên cần lấy</param>
        /// <param name="defaultvalue">Giá trị trong trường hợp bị null</param>
        /// <returns></returns>
        public string getMVCValue(HttpRequestBase rq,string key, string defaultvalue)
        {
            string ret = defaultvalue;
            if(rq[key]!=null)
            {
                ret = rq[key].ToString();
            }
            return ret;
        }
        /// <summary>
        /// Chuyển đổi từ unicode dựng sẵn sang unicode
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public string unicodeComposite2Unicode(string st)
        {
            string suniComposite = "à|ả|ã|á|ạ|ă|ằ|ẳ|ẵ|ắ|ặ|â|ầ|ẩ|ẫ|ấ|ậ|è|ẻ|ẽ|é|ẹ|ê|ề|ể|ễ|ế|ệ|ì|ỉ|ĩ|í|ị|ỳ|ỷ|ỹ|ý|ỵ|ò|ỏ|õ|ó|ọ|ơ|ờ|ở|ỡ|ớ|ợ|ô|ồ|ổ|ỗ|ố|ộ|ù|ủ|ũ|ú|ụ|ư|ừ|ử|ữ|ứ|ự|đ";
            string sUNIComposite = "À|Ả|Ã|Á|Ạ|Ă|Ằ|Ẳ|Ẵ|Ắ|Ặ|Â|Ầ|Ẩ|Ẫ|Ấ|Ậ|È|Ẻ|Ẽ|É|Ẹ|Ê|Ề|Ể|Ễ|Ế|Ệ|Ì|Ỉ|Ĩ|Í|Ị|Ỳ|Ỷ|Ỹ|Ý|Ỵ|Ò|Ỏ|Õ|Ó|Ọ|Ơ|Ờ|Ở|Ỡ|Ớ|Ợ|Ô|Ồ|Ổ|Ỗ|Ố|Ộ|Ù|Ủ|Ũ|Ú|Ụ|Ư|Ừ|Ử|Ữ|Ứ|Ự|Đ";
            string suni = "à|ả|ã|á|ạ|ă|ằ|ẳ|ẵ|ắ|ặ|â|ầ|ẩ|ẫ|ấ|ậ|è|ẻ|ẽ|é|ẹ|ê|ề|ể|ễ|ế|ệ|ì|ỉ|ĩ|í|ị|ỳ|ỷ|ỹ|ý|ỵ|ò|ỏ|õ|ó|ọ|ơ|ờ|ở|ỡ|ớ|ợ|ô|ồ|ổ|ỗ|ố|ộ|ù|ủ|ũ|ú|ụ|ư|ừ|ử|ữ|ứ|ự|đ";
            string sUNI = "À|Ả|Ã|Á|Ạ|Ă|Ằ|Ẳ|Ẵ|Ắ|Ặ|Â|Ầ|Ẩ|Ẫ|Ấ|Ậ|È|Ẻ|Ẽ|É|Ẹ|Ê|Ề|Ể|Ễ|Ế|Ệ|Ì|Ỉ|Ĩ|Í|Ị|Ỳ|Ỷ|Ỹ|Ý|Ỵ|Ò|Ỏ|Õ|Ó|Ọ|Ơ|Ờ|Ở|Ỡ|Ớ|Ợ|Ô|Ồ|Ổ|Ỗ|Ố|Ộ|Ù|Ủ|Ũ|Ú|Ụ|Ư|Ừ|Ử|Ữ|Ứ|Ự|Đ";
            // uint[] uniComposite = { 0x61CC80, 0x61CC89, 0x61CC83, 0x61CC81, 0x61CCA3, 0xC483, 0xC483CC80, 0xC483CC89, 0xC483CC83, 0xC483CC81, 0xC483CCA3, 0xC3A2, 0xC3A2CC80, 0xC3A2CC89, 0xC3A2CC83, 0xC3A2CC81, 0xC3A2CCA3, 0x65CC80, 0x65CC89, 0x65CC83, 0x65CC81, 0x65CCA3, 0xC3AA, 0xC3AACC80, 0xC3AACC89, 0xC3AACC83, 0xC3AACC81, 0xC3AACCA3, 0x69CC80, 0x69CC89, 0x69CC83, 0x69CC81, 0x69CCA3, 0x79CC80, 0x79CC89, 0x79CC83, 0x79CC81, 0x79CCA3, 0x6FCC80, 0x6FCC89, 0x6FCC83, 0x6FCC81, 0x6FCCA3, 0xC6A1, 0xC6A1CC80, 0xC6A1CC89, 0xC6A1CC83, 0xC6A1CC81, 0xC6A1CCA3, 0xC3B4, 0xC3B4CC80, 0xC3B4CC89, 0xC3B4CC83, 0xC3B4CC81, 0xC3B4CCA3, 0x75CC80, 0x75CC89, 0x75CC83, 0x75CC81, 0x75CCA3, 0xC6B0, 0xC6B0CC80, 0xC6B0CC89, 0xC6B0CC83, 0xC6B0CC81, 0xC6B0CCA3, 0xC491};
            //uint[] UNIComposite = { 0x41CC80, 0x41CC89, 0x41CC83, 0x41CC81, 0x41CCA3, 0xC482, 0xC482CC80, 0xC482CC89, 0xC482CC83, 0xC482CC81, 0xC482CCA3, 0xC382, 0xC382CC80, 0xC382CC89, 0xC382CC83, 0xC382CC81, 0xC382CCA3, 0x45CC80, 0x45CC89, 0x45CC83, 0x45CC81, 0x45CCA3, 0xC38A, 0xC38ACC80, 0xC38ACC89, 0xC38ACC83, 0xC38ACC81, 0xC38ACCA3, 0x49CC80, 0x49CC89, 0x49CC83, 0x49CC81, 0x49CCA3, 0x59CC80, 0x59CC89, 0x59CC83, 0x59CC81, 0x59CCA3, 0x4FCC80, 0x4FCC89, 0x4FCC83, 0x4FCC81, 0x4FCCA3, 0xC6A0, 0xC6A0CC80, 0xC6A0CC89, 0xC6A0CC83, 0xC6A0CC81, 0xC6A0CCA3, 0xC394, 0xC394CC80, 0xC394CC89, 0xC394CC83, 0xC394CC81, 0xC394CCA3, 0x55CC80, 0x55CC89, 0x55CC83, 0x55CC81, 0x55CCA3, 0xC6AF, 0xC6AFCC80, 0xC6AFCC89, 0xC6AFCC83, 0xC6AFCC81, 0xC6AFCCA3, 0xC490 };
            //uint[] uni = { 0xC3A0, 0xE1BAA3, 0xC3A3, 0xC3A1, 0xE1BAA1, 0xC483, 0xE1BAB1, 0xE1BAB3, 0xE1BAB5, 0xE1BAAF, 0xE1BAB7, 0xC3A2, 0xE1BAA7, 0xE1BAA9, 0xE1BAAB, 0xE1BAA5, 0xE1BAAD, 0xC3A8, 0xE1BABB, 0xE1BABD, 0xC3A9, 0xE1BAB9, 0xC3AA, 0xE1BB81, 0xE1BB83, 0xE1BB85, 0xE1BABF, 0xE1BB87, 0xC3AC, 0xE1BB89, 0xC4A9, 0xC3AD, 0xE1BB8B, 0xE1BBB3, 0xE1BBB7, 0xE1BBB9, 0xC3BD, 0xE1BBB5, 0xC3B2, 0xE1BB8F, 0xC3B5, 0xC3B3, 0xE1BB8D, 0xC6A1, 0xE1BB9D, 0xE1BB9F, 0xE1BBA1, 0xE1BB9B, 0xE1BBA3, 0xC3B4, 0xE1BB93, 0xE1BB95, 0xE1BB97, 0xE1BB91, 0xE1BB99, 0xC3B9, 0xE1BBA7, 0xC5A9, 0xC3BA, 0xE1BBA5, 0xC6B0, 0xE1BBAB, 0xE1BBAD, 0xE1BBAF, 0xE1BBA9, 0xE1BBB1, 0xC491 };
            //uint[] UNI = { 0xC380, 0xE1BAA2, 0xC383, 0xC381, 0xE1BAA0, 0xC482, 0xE1BAB0, 0xE1BAB2, 0xE1BAB4, 0xE1BAAE, 0xE1BAB6, 0xC382, 0xE1BAA6, 0xE1BAA8, 0xE1BAAA, 0xE1BAA4, 0xE1BAAC, 0xC388, 0xE1BABA, 0xE1BABC, 0xC389, 0xE1BAB8, 0xC38A, 0xE1BB80, 0xE1BB82, 0xE1BB84, 0xE1BABE, 0xE1BB86, 0xC38C, 0xE1BB88, 0xC4A8, 0xC38D, 0xE1BB8A, 0xE1BBB2, 0xE1BBB6, 0xE1BBB8, 0xC39D, 0xE1BBB4, 0xC392, 0xE1BB8E, 0xC395, 0xC393, 0xE1BB8C, 0xC6A0, 0xE1BB9C, 0xE1BB9E, 0xE1BBA0, 0xE1BB9A, 0xE1BBA2, 0xC394, 0xE1BB92, 0xE1BB94, 0xE1BB96, 0xE1BB90, 0xE1BB98, 0xC399, 0xE1BBA6, 0xC5A8, 0xC39A, 0xE1BBA4, 0xC6AF, 0xE1BBAA, 0xE1BBAC, 0xE1BBAE, 0xE1BBA8, 0xE1BBB0, 0xC490 };
            //uint[] non = { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'i', 'i', 'i', 'i', 'i', 'y', 'y', 'y', 'y', 'y', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'd' };
            //uint[] NON = { 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'I', 'I', 'I', 'I', 'I', 'Y', 'Y', 'Y', 'Y', 'Y', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'D' };
            int i = 0;
            string[] tsuniComposite = suniComposite.Split('|');
            string[] tsuni = suni.Split('|');
            for (i = 0; i < tsuniComposite.Length; i++)
            {
                st = st.Replace(tsuniComposite[i], tsuni[i]);
            }
            tsuniComposite = sUNIComposite.Split('|');
            tsuni = sUNI.Split('|');
            for (i = 0; i < tsuniComposite.Length; i++)
            {
                st = st.Replace(tsuniComposite[i], tsuni[i]);
            }
            return st;
        }
        /// <summary>
        /// Chuyển từ unicode dựng sẵn sang không dấu
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public string unicodeComposite2None(string st)
        {
            string suniComposite = "à|ả|ã|á|ạ|ă|ằ|ẳ|ẵ|ắ|ặ|â|ầ|ẩ|ẫ|ấ|ậ|è|ẻ|ẽ|é|ẹ|ê|ề|ể|ễ|ế|ệ|ì|ỉ|ĩ|í|ị|ỳ|ỷ|ỹ|ý|ỵ|ò|ỏ|õ|ó|ọ|ơ|ờ|ở|ỡ|ớ|ợ|ô|ồ|ổ|ỗ|ố|ộ|ù|ủ|ũ|ú|ụ|ư|ừ|ử|ữ|ứ|ự|đ";
            string sUNIComposite = "À|Ả|Ã|Á|Ạ|Ă|Ằ|Ẳ|Ẵ|Ắ|Ặ|Â|Ầ|Ẩ|Ẫ|Ấ|Ậ|È|Ẻ|Ẽ|É|Ẹ|Ê|Ề|Ể|Ễ|Ế|Ệ|Ì|Ỉ|Ĩ|Í|Ị|Ỳ|Ỷ|Ỹ|Ý|Ỵ|Ò|Ỏ|Õ|Ó|Ọ|Ơ|Ờ|Ở|Ỡ|Ớ|Ợ|Ô|Ồ|Ổ|Ỗ|Ố|Ộ|Ù|Ủ|Ũ|Ú|Ụ|Ư|Ừ|Ử|Ữ|Ứ|Ự|Đ";
            string suni = "a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|e|e|e|e|e|e|e|e|e|e|e|i|i|i|i|i|y|y|y|y|y|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|u|u|u|u|u|u|u|u|u|u|u|d";
            string sUNI = "A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|E|E|E|E|E|E|E|E|E|E|E|I|I|I|I|I|Y|Y|Y|Y|Y|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|U|U|U|U|U|U|U|U|U|U|U|D";
            // uint[] uniComposite = { 0x61CC80, 0x61CC89, 0x61CC83, 0x61CC81, 0x61CCA3, 0xC483, 0xC483CC80, 0xC483CC89, 0xC483CC83, 0xC483CC81, 0xC483CCA3, 0xC3A2, 0xC3A2CC80, 0xC3A2CC89, 0xC3A2CC83, 0xC3A2CC81, 0xC3A2CCA3, 0x65CC80, 0x65CC89, 0x65CC83, 0x65CC81, 0x65CCA3, 0xC3AA, 0xC3AACC80, 0xC3AACC89, 0xC3AACC83, 0xC3AACC81, 0xC3AACCA3, 0x69CC80, 0x69CC89, 0x69CC83, 0x69CC81, 0x69CCA3, 0x79CC80, 0x79CC89, 0x79CC83, 0x79CC81, 0x79CCA3, 0x6FCC80, 0x6FCC89, 0x6FCC83, 0x6FCC81, 0x6FCCA3, 0xC6A1, 0xC6A1CC80, 0xC6A1CC89, 0xC6A1CC83, 0xC6A1CC81, 0xC6A1CCA3, 0xC3B4, 0xC3B4CC80, 0xC3B4CC89, 0xC3B4CC83, 0xC3B4CC81, 0xC3B4CCA3, 0x75CC80, 0x75CC89, 0x75CC83, 0x75CC81, 0x75CCA3, 0xC6B0, 0xC6B0CC80, 0xC6B0CC89, 0xC6B0CC83, 0xC6B0CC81, 0xC6B0CCA3, 0xC491};
            //uint[] UNIComposite = { 0x41CC80, 0x41CC89, 0x41CC83, 0x41CC81, 0x41CCA3, 0xC482, 0xC482CC80, 0xC482CC89, 0xC482CC83, 0xC482CC81, 0xC482CCA3, 0xC382, 0xC382CC80, 0xC382CC89, 0xC382CC83, 0xC382CC81, 0xC382CCA3, 0x45CC80, 0x45CC89, 0x45CC83, 0x45CC81, 0x45CCA3, 0xC38A, 0xC38ACC80, 0xC38ACC89, 0xC38ACC83, 0xC38ACC81, 0xC38ACCA3, 0x49CC80, 0x49CC89, 0x49CC83, 0x49CC81, 0x49CCA3, 0x59CC80, 0x59CC89, 0x59CC83, 0x59CC81, 0x59CCA3, 0x4FCC80, 0x4FCC89, 0x4FCC83, 0x4FCC81, 0x4FCCA3, 0xC6A0, 0xC6A0CC80, 0xC6A0CC89, 0xC6A0CC83, 0xC6A0CC81, 0xC6A0CCA3, 0xC394, 0xC394CC80, 0xC394CC89, 0xC394CC83, 0xC394CC81, 0xC394CCA3, 0x55CC80, 0x55CC89, 0x55CC83, 0x55CC81, 0x55CCA3, 0xC6AF, 0xC6AFCC80, 0xC6AFCC89, 0xC6AFCC83, 0xC6AFCC81, 0xC6AFCCA3, 0xC490 };
            //uint[] uni = { 0xC3A0, 0xE1BAA3, 0xC3A3, 0xC3A1, 0xE1BAA1, 0xC483, 0xE1BAB1, 0xE1BAB3, 0xE1BAB5, 0xE1BAAF, 0xE1BAB7, 0xC3A2, 0xE1BAA7, 0xE1BAA9, 0xE1BAAB, 0xE1BAA5, 0xE1BAAD, 0xC3A8, 0xE1BABB, 0xE1BABD, 0xC3A9, 0xE1BAB9, 0xC3AA, 0xE1BB81, 0xE1BB83, 0xE1BB85, 0xE1BABF, 0xE1BB87, 0xC3AC, 0xE1BB89, 0xC4A9, 0xC3AD, 0xE1BB8B, 0xE1BBB3, 0xE1BBB7, 0xE1BBB9, 0xC3BD, 0xE1BBB5, 0xC3B2, 0xE1BB8F, 0xC3B5, 0xC3B3, 0xE1BB8D, 0xC6A1, 0xE1BB9D, 0xE1BB9F, 0xE1BBA1, 0xE1BB9B, 0xE1BBA3, 0xC3B4, 0xE1BB93, 0xE1BB95, 0xE1BB97, 0xE1BB91, 0xE1BB99, 0xC3B9, 0xE1BBA7, 0xC5A9, 0xC3BA, 0xE1BBA5, 0xC6B0, 0xE1BBAB, 0xE1BBAD, 0xE1BBAF, 0xE1BBA9, 0xE1BBB1, 0xC491 };
            //uint[] UNI = { 0xC380, 0xE1BAA2, 0xC383, 0xC381, 0xE1BAA0, 0xC482, 0xE1BAB0, 0xE1BAB2, 0xE1BAB4, 0xE1BAAE, 0xE1BAB6, 0xC382, 0xE1BAA6, 0xE1BAA8, 0xE1BAAA, 0xE1BAA4, 0xE1BAAC, 0xC388, 0xE1BABA, 0xE1BABC, 0xC389, 0xE1BAB8, 0xC38A, 0xE1BB80, 0xE1BB82, 0xE1BB84, 0xE1BABE, 0xE1BB86, 0xC38C, 0xE1BB88, 0xC4A8, 0xC38D, 0xE1BB8A, 0xE1BBB2, 0xE1BBB6, 0xE1BBB8, 0xC39D, 0xE1BBB4, 0xC392, 0xE1BB8E, 0xC395, 0xC393, 0xE1BB8C, 0xC6A0, 0xE1BB9C, 0xE1BB9E, 0xE1BBA0, 0xE1BB9A, 0xE1BBA2, 0xC394, 0xE1BB92, 0xE1BB94, 0xE1BB96, 0xE1BB90, 0xE1BB98, 0xC399, 0xE1BBA6, 0xC5A8, 0xC39A, 0xE1BBA4, 0xC6AF, 0xE1BBAA, 0xE1BBAC, 0xE1BBAE, 0xE1BBA8, 0xE1BBB0, 0xC490 };
            //uint[] non = { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'i', 'i', 'i', 'i', 'i', 'y', 'y', 'y', 'y', 'y', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'd' };
            //uint[] NON = { 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'I', 'I', 'I', 'I', 'I', 'Y', 'Y', 'Y', 'Y', 'Y', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'D' };
            int i = 0;
            string[] tsuniComposite = suniComposite.Split('|');
            string[] tsuni = suni.Split('|');
            for (i = 0; i < tsuniComposite.Length; i++)
            {
                st = st.Replace(tsuniComposite[i], tsuni[i]);
            }
            tsuniComposite = sUNIComposite.Split('|');
            tsuni = sUNI.Split('|');
            for (i = 0; i < tsuniComposite.Length; i++)
            {
                st = st.Replace(tsuniComposite[i], tsuni[i]);
            }
            return st;
        }
        /// <summary>
        /// Chuyển từ unicode dựng sẵn sang không dấu
        /// </summary>
        /// <param name="st"></param>
        /// <returns></returns>
        public string unicode2None(string st)
        {
            string suniComposite = "à|ả|ã|á|ạ|ă|ằ|ẳ|ẵ|ắ|ặ|â|ầ|ẩ|ẫ|ấ|ậ|è|ẻ|ẽ|é|ẹ|ê|ề|ể|ễ|ế|ệ|ì|ỉ|ĩ|í|ị|ỳ|ỷ|ỹ|ý|ỵ|ò|ỏ|õ|ó|ọ|ơ|ờ|ở|ỡ|ớ|ợ|ô|ồ|ổ|ỗ|ố|ộ|ù|ủ|ũ|ú|ụ|ư|ừ|ử|ữ|ứ|ự|đ";
            string sUNIComposite = "À|Ả|Ã|Á|Ạ|Ă|Ằ|Ẳ|Ẵ|Ắ|Ặ|Â|Ầ|Ẩ|Ẫ|Ấ|Ậ|È|Ẻ|Ẽ|É|Ẹ|Ê|Ề|Ể|Ễ|Ế|Ệ|Ì|Ỉ|Ĩ|Í|Ị|Ỳ|Ỷ|Ỹ|Ý|Ỵ|Ò|Ỏ|Õ|Ó|Ọ|Ơ|Ờ|Ở|Ỡ|Ớ|Ợ|Ô|Ồ|Ổ|Ỗ|Ố|Ộ|Ù|Ủ|Ũ|Ú|Ụ|Ư|Ừ|Ử|Ữ|Ứ|Ự|Đ";
            string suni = "a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|a|e|e|e|e|e|e|e|e|e|e|e|i|i|i|i|i|y|y|y|y|y|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|o|u|u|u|u|u|u|u|u|u|u|u|d";
            string sUNI = "A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|A|E|E|E|E|E|E|E|E|E|E|E|I|I|I|I|I|Y|Y|Y|Y|Y|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|O|U|U|U|U|U|U|U|U|U|U|U|D";
            // uint[] uniComposite = { 0x61CC80, 0x61CC89, 0x61CC83, 0x61CC81, 0x61CCA3, 0xC483, 0xC483CC80, 0xC483CC89, 0xC483CC83, 0xC483CC81, 0xC483CCA3, 0xC3A2, 0xC3A2CC80, 0xC3A2CC89, 0xC3A2CC83, 0xC3A2CC81, 0xC3A2CCA3, 0x65CC80, 0x65CC89, 0x65CC83, 0x65CC81, 0x65CCA3, 0xC3AA, 0xC3AACC80, 0xC3AACC89, 0xC3AACC83, 0xC3AACC81, 0xC3AACCA3, 0x69CC80, 0x69CC89, 0x69CC83, 0x69CC81, 0x69CCA3, 0x79CC80, 0x79CC89, 0x79CC83, 0x79CC81, 0x79CCA3, 0x6FCC80, 0x6FCC89, 0x6FCC83, 0x6FCC81, 0x6FCCA3, 0xC6A1, 0xC6A1CC80, 0xC6A1CC89, 0xC6A1CC83, 0xC6A1CC81, 0xC6A1CCA3, 0xC3B4, 0xC3B4CC80, 0xC3B4CC89, 0xC3B4CC83, 0xC3B4CC81, 0xC3B4CCA3, 0x75CC80, 0x75CC89, 0x75CC83, 0x75CC81, 0x75CCA3, 0xC6B0, 0xC6B0CC80, 0xC6B0CC89, 0xC6B0CC83, 0xC6B0CC81, 0xC6B0CCA3, 0xC491};
            //uint[] UNIComposite = { 0x41CC80, 0x41CC89, 0x41CC83, 0x41CC81, 0x41CCA3, 0xC482, 0xC482CC80, 0xC482CC89, 0xC482CC83, 0xC482CC81, 0xC482CCA3, 0xC382, 0xC382CC80, 0xC382CC89, 0xC382CC83, 0xC382CC81, 0xC382CCA3, 0x45CC80, 0x45CC89, 0x45CC83, 0x45CC81, 0x45CCA3, 0xC38A, 0xC38ACC80, 0xC38ACC89, 0xC38ACC83, 0xC38ACC81, 0xC38ACCA3, 0x49CC80, 0x49CC89, 0x49CC83, 0x49CC81, 0x49CCA3, 0x59CC80, 0x59CC89, 0x59CC83, 0x59CC81, 0x59CCA3, 0x4FCC80, 0x4FCC89, 0x4FCC83, 0x4FCC81, 0x4FCCA3, 0xC6A0, 0xC6A0CC80, 0xC6A0CC89, 0xC6A0CC83, 0xC6A0CC81, 0xC6A0CCA3, 0xC394, 0xC394CC80, 0xC394CC89, 0xC394CC83, 0xC394CC81, 0xC394CCA3, 0x55CC80, 0x55CC89, 0x55CC83, 0x55CC81, 0x55CCA3, 0xC6AF, 0xC6AFCC80, 0xC6AFCC89, 0xC6AFCC83, 0xC6AFCC81, 0xC6AFCCA3, 0xC490 };
            //uint[] uni = { 0xC3A0, 0xE1BAA3, 0xC3A3, 0xC3A1, 0xE1BAA1, 0xC483, 0xE1BAB1, 0xE1BAB3, 0xE1BAB5, 0xE1BAAF, 0xE1BAB7, 0xC3A2, 0xE1BAA7, 0xE1BAA9, 0xE1BAAB, 0xE1BAA5, 0xE1BAAD, 0xC3A8, 0xE1BABB, 0xE1BABD, 0xC3A9, 0xE1BAB9, 0xC3AA, 0xE1BB81, 0xE1BB83, 0xE1BB85, 0xE1BABF, 0xE1BB87, 0xC3AC, 0xE1BB89, 0xC4A9, 0xC3AD, 0xE1BB8B, 0xE1BBB3, 0xE1BBB7, 0xE1BBB9, 0xC3BD, 0xE1BBB5, 0xC3B2, 0xE1BB8F, 0xC3B5, 0xC3B3, 0xE1BB8D, 0xC6A1, 0xE1BB9D, 0xE1BB9F, 0xE1BBA1, 0xE1BB9B, 0xE1BBA3, 0xC3B4, 0xE1BB93, 0xE1BB95, 0xE1BB97, 0xE1BB91, 0xE1BB99, 0xC3B9, 0xE1BBA7, 0xC5A9, 0xC3BA, 0xE1BBA5, 0xC6B0, 0xE1BBAB, 0xE1BBAD, 0xE1BBAF, 0xE1BBA9, 0xE1BBB1, 0xC491 };
            //uint[] UNI = { 0xC380, 0xE1BAA2, 0xC383, 0xC381, 0xE1BAA0, 0xC482, 0xE1BAB0, 0xE1BAB2, 0xE1BAB4, 0xE1BAAE, 0xE1BAB6, 0xC382, 0xE1BAA6, 0xE1BAA8, 0xE1BAAA, 0xE1BAA4, 0xE1BAAC, 0xC388, 0xE1BABA, 0xE1BABC, 0xC389, 0xE1BAB8, 0xC38A, 0xE1BB80, 0xE1BB82, 0xE1BB84, 0xE1BABE, 0xE1BB86, 0xC38C, 0xE1BB88, 0xC4A8, 0xC38D, 0xE1BB8A, 0xE1BBB2, 0xE1BBB6, 0xE1BBB8, 0xC39D, 0xE1BBB4, 0xC392, 0xE1BB8E, 0xC395, 0xC393, 0xE1BB8C, 0xC6A0, 0xE1BB9C, 0xE1BB9E, 0xE1BBA0, 0xE1BB9A, 0xE1BBA2, 0xC394, 0xE1BB92, 0xE1BB94, 0xE1BB96, 0xE1BB90, 0xE1BB98, 0xC399, 0xE1BBA6, 0xC5A8, 0xC39A, 0xE1BBA4, 0xC6AF, 0xE1BBAA, 0xE1BBAC, 0xE1BBAE, 0xE1BBA8, 0xE1BBB0, 0xC490 };
            //uint[] non = { 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'a', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'e', 'i', 'i', 'i', 'i', 'i', 'y', 'y', 'y', 'y', 'y', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'o', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'u', 'd' };
            //uint[] NON = { 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'A', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'E', 'I', 'I', 'I', 'I', 'I', 'Y', 'Y', 'Y', 'Y', 'Y', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'O', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'U', 'D' };
            int i = 0;
            string[] tsuniComposite = suniComposite.Split('|');
            string[] tsuni = suni.Split('|');
            for (i = 0; i < tsuniComposite.Length; i++)
            {
                st = st.Replace(tsuniComposite[i], tsuni[i]);
            }
            tsuniComposite = sUNIComposite.Split('|');
            tsuni = sUNI.Split('|');
            for (i = 0; i < tsuniComposite.Length; i++)
            {
                st = st.Replace(tsuniComposite[i], tsuni[i]);
            }
            return st;
        }
    }
}