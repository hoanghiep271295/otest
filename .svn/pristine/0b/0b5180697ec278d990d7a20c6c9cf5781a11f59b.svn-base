using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IS.basetype
{
    public class STAFFPRIORITY_COM : IComparer<STAFFPRIORITY>
    {
        public int Compare(STAFFPRIORITY x, STAFFPRIORITY y)
        {
            if (x == null)
            {
                if (y == null)
                {
                    // If x is null and y is null, they're
                    // equal. 
                    return 0;
                }
                else
                {
                    // If x is null and y is not null, y
                    // is greater. 
                    return -1;
                }
            }
            else
            {
                // If x is not null...
                //
                if (y == null)
                // ...and y is null, x is greater.
                {
                    return 1;
                }
                else
                {
                    // ...and y is not null, compare the 
                    // lengths of the two strings.
                    //
                    int c = x.PRIORITYCODE.CompareTo(y.PRIORITYCODE);
                    if(c!=0)
                    {
                        return c;
                    }
                    if(x.AUTHEN>y.AUTHEN)
                    {
                        return 1;
                    }
                    return 0;
                }
            }
        }
    }
    /// <summary>
    /// Các trạng thái nhập liệu và phê duyệt
    /// </summary>
    public enum APPROVEDSTATUSTYPE { 
        /// <summary>
        /// Trạng thái tạm thời, chỉ người nhập thấy được thông tin
        /// </summary>
        TEMPORARY, 
        /// <summary>
        /// Trạng thái nhập và đang đợi duyệt
        /// </summary>
        WAITING, 
        /// <summary>
        /// Trạng thái đã được duyệt
        /// </summary>
        APPROVED, 
        /// <summary>
        /// Yêu cầu thực hiện lại
        /// </summary>
        REDO };
    public class STAFFPRIORITY
    {
        public virtual System.String STAFFCODE
        {
                get;
                set;
        }
        public virtual System.String PRIORITYCODE
        {
            get;
            set;
        }
        public virtual System.Int32 INHERIT
        {
            get;
            set;
        }
        public virtual System.String THECODE
        {
            get;
            set;
        }
        public virtual System.String TABLENAME
        {
            get;
            set;
        }
        public virtual System.String EXTENSIONCODE
        {
            get;
            set;
        }
        public virtual System.Int32 FUNC
        {
            get;
            set;
        }
        public virtual System.String SYSCOMPONENTCODE
        {
            get;
            set;
        }
        public virtual System.Int32 AUTHEN
        {
            get;
            set;
        }

    }
    /// <summary>
    /// LOGINED STAFF
    /// </summary>
    public class STAFF_INFO
    {
        public STAFF_INFO()
        {

        }
        /// <summary>
        /// Xác định thông tin của người đăng nhập hiện tại
        /// </summary>
        /// <param name="universitycode"></param>
        /// <param name="code"></param>
        /// <param name="codeview"></param>
        /// <param name="name"></param>
        /// <param name="departmentcode"></param>
        /// <param name="degreecode"></param>
        /// <param name="leveltitlecode"></param>
        /// <param name="academictitecode"></param>
        /// <param name="armyrankcode"></param>
        /// <param name="partyleveltitlecode"></param>
        /// <param name="changepass"></param>
        /// <param name="logintime"></param>
        /// <param name="type"></param>
        /// <param name="img"></param>
        /// <param name="deparmtmentname"></param>
        public STAFF_INFO(string universitycode, string code, string codeview, string name, string departmentcode, string degreecode, string leveltitlecode, string academictitecode, string armyrankcode, string partyleveltitlecode, int changepass, DateTime logintime, string type, string img, string deparmtmentname)
        {
            CODE = code;
            CODEVIEW = codeview;
            NAME = name;
            DEPARTMENTCODE = departmentcode;
            DEGREECODE = degreecode;
            LEVELTITLECODE = leveltitlecode;
            ACADEMICTITLECODE = academictitecode;
            ARMYRANKCODE = armyrankcode;
            PARTYLEVELTITLECODE = partyleveltitlecode;
            CHANGEPASS = changepass;
            LOGTIME = logintime;
            TYPE = type;
            UNIVERSITYCODE = universitycode;
            IMG = img;
            DEPARTMENTNAME = deparmtmentname;
        }
        public string UNIVERSITYCODE;
        public string CODE;
        public string CODEVIEW;
        public string NAME;
        public string DEPARTMENTCODE;
        public string DEGREECODE;
        public string LEVELTITLECODE;
        public string ACADEMICTITLECODE;
        public string ARMYRANKCODE;
        public string PARTYLEVELTITLECODE;
        public int CHANGEPASS;
        public DateTime LOGTIME;
        public string TYPE;
        public string IMG;
        public string DEPARTMENTNAME;
    }
}
