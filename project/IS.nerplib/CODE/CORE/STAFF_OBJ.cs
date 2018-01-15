using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class STAFF_OBJ: BusinessObject<STAFF_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _CODE;

		public BusinessObjectID(System.String mCODE)
		{
		_CODE = mCODE;

		}

    public System.String CODE
    {
        get { return _CODE; }
        set { _CODE = value; }
    }


		public override bool Equals(object obj)
		{
			if (obj == this) return true;
			if (obj == null) return false;

			BusinessObjectID that = obj as BusinessObjectID;
			if (that == null)
			{
				return false;
			}
			else
			{
		if (this.CODE != that.CODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return CODE.GetHashCode();
		}

	}
	//main object
	protected string _codeP="{yyMMdd}{CCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public STAFF_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public STAFF_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("CODE",10,"VARCHAR",0)
,new fieldInfo("CODEVIEW",20,"VARCHAR",0)
,new fieldInfo("NAME",200,"NVARCHAR",0)
,new fieldInfo("NOTE",4000,"NVARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("BIRTHDAY",0,"DATETIME",0)
,new fieldInfo("ADDRESS",400,"NVARCHAR",0)
,new fieldInfo("ACADEMICTITLECODE",10,"VARCHAR",0)
,new fieldInfo("DEGREECODE",10,"VARCHAR",0)
,new fieldInfo("LEVELTITLECODE",10,"VARCHAR",0)
,new fieldInfo("DEPARTMENTCODE",10,"VARCHAR",0)
,new fieldInfo("ARMYRANKCODE",10,"VARCHAR",0)
,new fieldInfo("PARTYLEVELTITLECODE",10,"VARCHAR",0)
,new fieldInfo("MOBIPHONE",20,"VARCHAR",0)
,new fieldInfo("TEL",20,"VARCHAR",0)
,new fieldInfo("USERPASSWORD",100,"VARCHAR",0)
,new fieldInfo("PHOTO",200,"NVARCHAR",0)
,new fieldInfo("TEACHING",0,"INT",0)
,new fieldInfo("MANAGER",0,"INT",0)
,new fieldInfo("EMAIL",100,"NVARCHAR",0)
,new fieldInfo("CHANGEPASS",0,"SMALLINT",0)
,new fieldInfo("ACADEMICLEVELCODE",10,"VARCHAR",0)
,new fieldInfo("STAFFSTATUSCODE",10,"VARCHAR",0)
,new fieldInfo("PROVINCECODE",10,"VARCHAR",0)
,new fieldInfo("DISTRICTCODE",10,"VARCHAR",0)
,new fieldInfo("TOWNCODE",10,"VARCHAR",0)
,new fieldInfo("INTERNALEMAIL",100,"NVARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("SEX",0,"INT",0)
,new fieldInfo("ETHNICCODE",10,"VARCHAR",0)
,new fieldInfo("RELIGIONCODE",10,"VARCHAR",0)
,new fieldInfo("HOMETOWN",500,"NVARCHAR",0)
,new fieldInfo("USERNAME",100,"NVARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("CIVILID",50,"VARCHAR",0)
,new fieldInfo("LANGUAGECODE",10,"VARCHAR",0)
,new fieldInfo("ORIGINALCODE",10,"VARCHAR",0)
,new fieldInfo("RESEARCHDEPARTMENTCODE",10,"VARCHAR",0)
,new fieldInfo("RESEARCHSTATUS",0,"INT",0)
,new fieldInfo("EXPERTSPECIALIZECODE",10,"VARCHAR",0)
,new fieldInfo("EXPERTGROUPCODE",10,"VARCHAR",0)
,new fieldInfo("EXPERTFIELD",10,"VARCHAR",0)
,new fieldInfo("UNITYPE",500,"NVARCHAR",0)
,new fieldInfo("UNINAME",500,"NVARCHAR",0)
,new fieldInfo("UNIFIELD",500,"NVARCHAR",0)
,new fieldInfo("UNINATION",500,"NVARCHAR",0)
,new fieldInfo("UNIYEAR",0,"INT",0)
,new fieldInfo("MASTERFIELD",500,"NVARCHAR",0)
,new fieldInfo("MASTERYEAR",0,"INT",0)
,new fieldInfo("MASTERUNINAME",500,"NVARCHAR",0)
,new fieldInfo("MASTERTHESIS",1000,"NVARCHAR",0)
,new fieldInfo("PHDFIELD",500,"NVARCHAR",0)
,new fieldInfo("PHDYEAR",0,"INT",0)
,new fieldInfo("PHDUNINAME",500,"NVARCHAR",0)
,new fieldInfo("PHDTHESIS",1000,"NVARCHAR",0)
,new fieldInfo("HAVEBIRTH",0,"DATETIME",0)
,new fieldInfo("STATUSDATESHOW",20,"VARCHAR",0)
,new fieldInfo("STATUSDATE",0,"DATETIME",0)
,new fieldInfo("EXTENSIONCODE",200,"VARCHAR",0)

                               }; ;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("ACADEMICTITLE", "CODE", "ACADEMICTITLECODE")]
   public ACADEMICTITLE_OBJ _ACADEMICTITLECODE;
 [tablereference("DEGREE", "CODE", "DEGREECODE")]
   public DEGREE_OBJ _DEGREECODE;
 [tablereference("LEVELTITLE", "CODE", "LEVELTITLECODE")]
   public LEVELTITLE_OBJ _LEVELTITLECODE;
 [tablereference("DEPARTMENT", "CODE", "DEPARTMENTCODE")]
   public DEPARTMENT_OBJ _DEPARTMENTCODE;
 [tablereference("ARMYRANK", "CODE", "ARMYRANKCODE")]
   public ARMYRANK_OBJ _ARMYRANKCODE;
 [tablereference("PARTYLEVELTITLE", "CODE", "PARTYLEVELTITLECODE")]
   public PARTYLEVELTITLE_OBJ _PARTYLEVELTITLECODE;
 [tablereference("PROVINCE", "CODE", "PROVINCECODE")]
   public PROVINCE_OBJ _PROVINCECODE;
 [tablereference("DISTRICT", "CODE", "DISTRICTCODE")]
   public DISTRICT_OBJ _DISTRICTCODE;
 [tablereference("TOWN", "CODE", "TOWNCODE")]
   public TOWN_OBJ _TOWNCODE;
 [tablereference("ACADEMICLEVEL", "CODE", "ACADEMICLEVELCODE")]
   public ACADEMICLEVEL_OBJ _ACADEMICLEVELCODE;
 [tablereference("STAFFSTATUS", "CODE", "STAFFSTATUSCODE")]
   public STAFFSTATUS_OBJ _STAFFSTATUSCODE;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    [Display(Name="Mã")]
    public virtual System.String CODEVIEW
    {
        get ;
        set ;
    }
    [Display(Name="Tên")]
    public virtual System.String NAME
    {
        get ;
        set ;
    }
    [Display(Name="Ghi chú")]
    public virtual System.String NOTE
    {
        get ;
        set ;
    }
    public virtual System.String EDITUSER
    {
        get ;
        set ;
    }
    public virtual System.DateTime EDITTIME
    {
        get ;
        set ;
    }
    public virtual System.Int16 LOCK
    {
        get ;
        set ;
    }
    public virtual System.DateTime LOCKDATE
    {
        get ;
        set ;
    }
    [Display(Name="Ngày sinh")]
    public virtual System.DateTime BIRTHDAY
    {
        get ;
        set ;
    }
    [Display(Name="Địa chỉ liên lạc")]
    public virtual System.String ADDRESS
    {
        get ;
        set ;
    }
    [Display(Name="Học hàm")]
    public virtual System.String ACADEMICTITLECODE
    {
        get ;
        set ;
    }
    [Display(Name="Học vị")]
    public virtual System.String DEGREECODE
    {
        get ;
        set ;
    }
    [Display(Name="Chức vụ")]
    public virtual System.String LEVELTITLECODE
    {
        get ;
        set ;
    }
    [Display(Name="Đơn vị")]
    public virtual System.String DEPARTMENTCODE
    {
        get ;
        set ;
    }
    [Display(Name="Cấp bậc")]
    public virtual System.String ARMYRANKCODE
    {
        get ;
        set ;
    }
    [Display(Name="Chức vụ Đảng")]
    public virtual System.String PARTYLEVELTITLECODE
    {
        get ;
        set ;
    }
    [Display(Name="Di động")]
    public virtual System.String MOBIPHONE
    {
        get ;
        set ;
    }
    [Display(Name="Điện thoại")]
    public virtual System.String TEL
    {
        get ;
        set ;
    }
    [Display(Name="Mật khẩu")]
    public virtual System.String USERPASSWORD
    {
        get ;
        set ;
    }
    [Display(Name="Ảnh")]
    public virtual System.String PHOTO
    {
        get ;
        set ;
    }
    public virtual System.Int32 TEACHING
    {
        get ;
        set ;
    }
    public virtual System.Int32 MANAGER
    {
        get ;
        set ;
    }
    [Display(Name="Thư")]
    public virtual System.String EMAIL
    {
        get ;
        set ;
    }
    public virtual System.Int16 CHANGEPASS
    {
        get ;
        set ;
    }
    [Display(Name="Chức danh chuyên môn nghiệp vụ")]
    public virtual System.String ACADEMICLEVELCODE
    {
        get ;
        set ;
    }
    [Display(Name="Trạng thái giáo viên")]
    public virtual System.String STAFFSTATUSCODE
    {
        get ;
        set ;
    }
    public virtual System.String PROVINCECODE
    {
        get ;
        set ;
    }
    public virtual System.String DISTRICTCODE
    {
        get ;
        set ;
    }
    public virtual System.String TOWNCODE
    {
        get ;
        set ;
    }
    [Display(Name="Thư nội bộ")]
    public virtual System.String INTERNALEMAIL
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.Int32 SEX
    {
        get ;
        set ;
    }
    public virtual System.String ETHNICCODE
    {
        get ;
        set ;
    }
    public virtual System.String RELIGIONCODE
    {
        get ;
        set ;
    }
    public virtual System.String HOMETOWN
    {
        get ;
        set ;
    }
    public virtual System.String USERNAME
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String CIVILID
    {
        get ;
        set ;
    }
    public virtual System.String LANGUAGECODE
    {
        get ;
        set ;
    }
    public virtual System.String ORIGINALCODE
    {
        get ;
        set ;
    }
    [Display(Name="Đơn vị học thuật")]
    public virtual System.String RESEARCHDEPARTMENTCODE
    {
        get ;
        set ;
    }
    [Display(Name="Trạng thái nghiên cứu")]
    public virtual System.Int32 RESEARCHSTATUS
    {
        get ;
        set ;
    }
    public virtual System.String EXPERTSPECIALIZECODE
    {
        get ;
        set ;
    }
    public virtual System.String EXPERTGROUPCODE
    {
        get ;
        set ;
    }
    public virtual System.String EXPERTFIELD
    {
        get ;
        set ;
    }
    public virtual System.String UNITYPE
    {
        get ;
        set ;
    }
    public virtual System.String UNINAME
    {
        get ;
        set ;
    }
    public virtual System.String UNIFIELD
    {
        get ;
        set ;
    }
    public virtual System.String UNINATION
    {
        get ;
        set ;
    }
    public virtual System.Int32 UNIYEAR
    {
        get ;
        set ;
    }
    public virtual System.String MASTERFIELD
    {
        get ;
        set ;
    }
    public virtual System.Int32 MASTERYEAR
    {
        get ;
        set ;
    }
    public virtual System.String MASTERUNINAME
    {
        get ;
        set ;
    }
    public virtual System.String MASTERTHESIS
    {
        get ;
        set ;
    }
    public virtual System.String PHDFIELD
    {
        get ;
        set ;
    }
    public virtual System.Int32 PHDYEAR
    {
        get ;
        set ;
    }
    public virtual System.String PHDUNINAME
    {
        get ;
        set ;
    }
    public virtual System.String PHDTHESIS
    {
        get ;
        set ;
    }
    [Display(Name="Thời điểm sinh con cuối cùng")]
    public virtual System.DateTime HAVEBIRTH
    {
        get ;
        set ;
    }
    [Display(Name="Thời điểm thay đổi")]
    public virtual System.String STATUSDATESHOW
    {
        get ;
        set ;
    }
    public virtual System.DateTime STATUSDATE
    {
        get ;
        set ;
    }
    public virtual System.String EXTENSIONCODE
    {
        get;
        set;
    }


        public override int GetHashCode()
	{
		return _ID.GetHashCode();
	}

}
}

