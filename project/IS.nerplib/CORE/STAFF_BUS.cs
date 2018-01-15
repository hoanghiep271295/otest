using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
using IS.Sec;
using IS.Config;
using IS.basetype;
using IS.localcomm;

namespace IS.uni
{
   
    public class STAFF_BUS : BusinessController<STAFF_OBJ, STAFF_OBJ.BusinessObjectID>
    {
        public STAFF_BUS()
        {
        }
        public override STAFF_OBJ createObject()
        {
            STAFF_OBJ obj = new STAFF_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STAFF_OBJ createNull()
        {
            return null;
        }
        public string encrypt(string username, string userpass)
        {
            string t = "";
            string ac = AppConfig.AppCode();// "ITMS-HVKTQS";
            MaHoa sec = new MaHoa();
            t = sec.encrypt(ac, username + "_WEB_" + userpass);
            return t;
        }
        /// <summary>
        /// Check the login staff
        /// </summary>
        /// <param name="obj">Input staff with codeview and the password</param>
        /// <param name="curObj">the staff has just logined</param>
        /// <param name="lipermission">All permission the staff that the staff has</param>
        /// <returns></returns>
        public int login(STAFF_OBJ obj, out STAFF_OBJ curObj, out List<STAFFPRIORITY> lipermission)
        {
            lipermission = new List<STAFFPRIORITY>();
            STAFF_OBJ obj_priv = null;
            curObj = null;
            DataSet ds = new DataSet();
            obj_priv = GetByKey(new fieldpara("USERNAME", obj.CODEVIEW),
                            new fieldpara("USERPASSWORD", encrypt(obj.CODEVIEW, obj.USERPASSWORD)));
            if (obj_priv == null)
            {
                return -1;
            }
            curObj = obj_priv;
            //get special priority function for staff
            STAFFPRIORITY_BUS bus_stap = new STAFFPRIORITY_BUS();
            List<fieldpara> lipara = new List<fieldpara>();
            lipara.Add(new fieldpara("OBJECTCODE", obj_priv.CODE));
            lipara.Add(new fieldpara("THETYPE", "STAFFPRIORITY"));

            List<STAFFPRIORITY_OBJ> lipermission1 = bus_stap.getAllBy("PRIORITYCODE", lipara);
            bus_stap.CloseConnection();
            if (lipermission1 != null)
            {
                foreach (STAFFPRIORITY_OBJ objpri in lipermission1)
                {
                    if (objpri.LOCK == 0)
                    {
                        STAFFPRIORITY obj_temp = new STAFFPRIORITY();
                        obj_temp.STAFFCODE = obj_priv.CODE;
                        obj_temp.PRIORITYCODE = objpri.PRIORITYCODE;
                        obj_temp.INHERIT = objpri.INHERIT;
                        obj_temp.THECODE = objpri.THECODE;
                        obj_temp.TABLENAME = objpri.TABLENAME;
                        obj_temp.EXTENSIONCODE = objpri.EXTENSIONCODE;
                        obj_temp.FUNC = objpri.FUNC;
                        obj_temp.SYSCOMPONENTCODE = objpri.SYSCOMPONENTCODE;
                        obj_temp.AUTHEN = 0;
                        lipermission.Add(obj_temp);
                    }

                }
            }
            //permission 4 groups that person is in
            ADMINGROUPPRIORITY_BUS bus_admingrouppriority = new ADMINGROUPPRIORITY_BUS();
            List<ADMINGROUPPRIORITY_OBJ> li_admingrouppriority = bus_admingrouppriority.getByStaff(obj_priv.CODE);
            bus_admingrouppriority.CloseConnection();
            if (li_admingrouppriority != null)
            {
                //convert to staffpriority_obj
                foreach (ADMINGROUPPRIORITY_OBJ objpri in li_admingrouppriority)
                {
                    STAFFPRIORITY obj_temp = new STAFFPRIORITY();
                    obj_temp.STAFFCODE = obj_priv.CODE;
                    obj_temp.PRIORITYCODE = objpri.PRIORITYCODE;
                    obj_temp.INHERIT = objpri.INHERIT;
                    obj_temp.THECODE = objpri.THECODE;
                    obj_temp.TABLENAME = objpri.TABLENAME;
                    obj_temp.EXTENSIONCODE = objpri.EXTENSIONCODE;
                    obj_temp.FUNC = objpri.FUNC;
                    obj_temp.SYSCOMPONENTCODE = objpri.SYSCOMPONENTCODE;
                    obj_temp.AUTHEN = 0;
                    lipermission.Add(obj_temp);
                }

            }
            ////staff role
            //LEVELTITLE_BUS bus_leveltitle = new LEVELTITLE_BUS();
            //LEVELTITLE_OBJ obj_leveltitle = bus_leveltitle.GetByID(new LEVELTITLE_OBJ.BusinessObjectID(obj_priv.LEVELTITLECODE));
            //bus_leveltitle.CloseConnection();

            ////permission 4 department role
            //DEPARTMENTPRIORITY_BUS bus_depp = new DEPARTMENTPRIORITY_BUS();
            //lipara.Clear();
            //lipara.Add(new fieldpara("DEPARTMENTCODE", obj_priv.DEPARTMENTCODE));
            //List<DEPARTMENTPRIORITY_OBJ> li_depp = bus_depp.getAllBy("PRIORITYCODE", lipara);
            //bus_depp.CloseConnection();
            //if (li_depp != null)
            //{
            //    //add to list
            //    foreach (DEPARTMENTPRIORITY_OBJ objpri in li_depp)
            //    {
            //        //incase this is forman only or not
            //        if ((objpri.FORMAN == 1 && obj_leveltitle.MAN == 1 && obj_leveltitle != null) || objpri.FORMAN == 0)
            //        {
            //            STAFFPRIORITY obj_temp = new STAFFPRIORITY();
            //            obj_temp.DEPARTMENTCODE = objpri.THECODE;
            //            obj_temp.EDITTIME = objpri.EDITTIME;
            //            obj_temp.EDITUSER = objpri.EDITUSER;
            //            obj_temp.FUNC = objpri.FUNC;
            //            obj_temp.INHERIT = objpri.INHERIT;
            //            obj_temp.LOCK = objpri.LOCK;
            //            obj_temp.PRIORITYCODE = objpri.PRIORITYCODE;
            //            obj_temp.STAFFCODE = obj_priv.CODE;
            //            obj_temp.WHOIS = objpri.WHOIS;
            //            obj_temp.AUTHEN = 0;
            //            lipermission.Add(obj_temp);
            //        }
            //    }
            //}
            ////permission 4 levletitle
            //LEVELTITLEPRIORITY_BUS bus_leveltitlepriority = new LEVELTITLEPRIORITY_BUS();
            //lipara.Clear();
            //lipara.Add(new fieldpara("LEVELTITLECODE", obj_priv.LEVELTITLECODE));
            ////            List<LEVELTITLEPRIORITY_OBJ> li_leveltitlepriority = bus_leveltitlepriority.getAllBy("PRIORITYCODE", lipara);
            //List<LEVELTITLEPRIORITY_OBJ> li_leveltitlepriority = bus_leveltitlepriority.getAllByStaff(obj_priv.CODE);
            //bus_leveltitlepriority.CloseConnection();
            //if (li_leveltitlepriority != null)
            //{
            //    foreach (LEVELTITLEPRIORITY_OBJ objpri in li_leveltitlepriority)
            //    {
            //        STAFFPRIORITY obj_temp = new STAFFPRIORITY();
            //        obj_temp.DEPARTMENTCODE = objpri.DEPARTMENTCODE;
            //        obj_temp.EDITTIME = objpri.EDITTIME;
            //        obj_temp.EDITUSER = objpri.EDITUSER;
            //        obj_temp.FUNC = objpri.FUNC;
            //        obj_temp.INHERIT = objpri.INHERIT;
            //        obj_temp.LOCK = objpri.LOCK;
            //        obj_temp.PRIORITYCODE = objpri.PRIORITYCODE;
            //        obj_temp.STAFFCODE = obj_priv.CODE;
            //        obj_temp.WHOIS = objpri.WHOIS;
            //        obj_temp.AUTHEN = 0;
            //        lipermission.Add(obj_temp);
            //    }
            //}

            //try to sort this permission list
            STAFFPRIORITY_COM cp = new STAFFPRIORITY_COM();
            lipermission.Sort(cp);
            return 0;
        }
        /// <summary>
        /// Đổi mật khẩu của người dùng
        /// </summary>
        /// <param name="loginName"></param>
        /// <param name="oldPass"></param>
        /// <param name="newPass"></param>
        /// <returns></returns>
        public int changePass(string loginName, string oldPass, string newPass)
        {
            oldPass = encrypt(loginName, oldPass);
            newPass = encrypt(loginName, newPass);
            STAFF_OBJ obj = GetByKey(new fieldpara("CODEVIEW", loginName), new fieldpara("USERPASSWORD", oldPass));
            if (obj == null)
                return -1;
            obj.USERPASSWORD = newPass;
            obj.CHANGEPASS = 0;
            obj._ID.CODE = obj.CODE;
            string[] field = { "USERPASSWORD", "CHANGEPASS" };
            if (Update(field, obj) < 0)
            {
                return -2;
            }
            return 0;
        }
        /// <summary>
        /// Ghi mật khẩu mới cho người dùng đã kiểm tra
        /// </summary>
        /// <param name="obj"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public int setPass(STAFF_OBJ obj, string password)
        {
            string passwordnew = encrypt(obj.USERNAME, password);
            obj.USERPASSWORD = passwordnew;
            obj.CHANGEPASS = 1;
            obj._ID.CODE = obj.CODE;
            string[] field = { "USERPASSWORD", "CHANGEPASS", "USERNAME" };
            if (Update(field, obj) < 0)
            {
                return -2;
            }
            return 0;
        }
    }

}