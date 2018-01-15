using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class SUBJECT_OBJ: BusinessObject<SUBJECT_OBJ.BusinessObjectID>
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
	protected string _codeP= "S{SHORD}{CCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public SUBJECT_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public SUBJECT_OBJ(BusinessObjectID id)
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
,new fieldInfo("NOTE",200,"NVARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("NAMEENGLISH",200,"NVARCHAR",0)
,new fieldInfo("EDUCATIONLEVELCODE",10,"VARCHAR",0)
,new fieldInfo("LEARNINGTYPECODE",10,"VARCHAR",0)
,new fieldInfo("CREDIT",0,"INT",0)
,new fieldInfo("CLASSPERIOD",0,"INT ",0)
,new fieldInfo("DEPARTMENTCODE",10,"VARCHAR",0)
,new fieldInfo("THEORYPERIOD",0,"INT",0)
,new fieldInfo("PRACTICEPERIOD",0,"INT",0)
,new fieldInfo("ASSIGNPERIOD",0,"INT",0)
,new fieldInfo("TESTINGTYPECODE",10,"VARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("DEPARTMENTCODE1",10,"VARCHAR",0)
,new fieldInfo("COUNTCOLUMN",0,"INT",0)
,new fieldInfo("MARKTYPECODE",10,"VARCHAR",0)
,new fieldInfo("TESTPERIOD",0,"INT",0)
,new fieldInfo("MATERIAL",200,"NVARCHAR",0)
,new fieldInfo("LESSONPLAN",200,"NVARCHAR",0)
,new fieldInfo("LESSONDETAIL",200,"NVARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("LANG",10,"VARCHAR",0)
,new fieldInfo("ORIGINALCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("EDUCATIONLEVEL", "CODE", "EDUCATIONLEVELCODE")]
   public EDUCATIONLEVEL_OBJ _EDUCATIONLEVELCODE;
 [tablereference("LEARNINGTYPE", "CODE", "LEARNINGTYPECODE")]
 //  public LEARNINGTYPE_OBJ _LEARNINGTYPECODE;
 //[tablereference("DEPARTMENT", "CODE", "DEPARTMENTCODE")]
   public DEPARTMENT_OBJ _DEPARTMENTCODE;
 [tablereference("DEPARTMENT", "CODE", "DEPARTMENTCODE1")]
   public DEPARTMENT_OBJ _DEPARTMENTCODE1;
 //[tablereference("TESTINGTYPE", "CODE", "TESTINGTYPECODE")]
 //  public TESTINGTYPE_OBJ _TESTINGTYPECODE;
 [tablereference("MARKTYPE", "CODE", "MARKTYPECODE")]
   public MARKTYPE_OBJ _MARKTYPECODE;

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
    [Display(Name="Tên tiếng anh")]
    public virtual System.String NAMEENGLISH
    {
        get ;
        set ;
    }
    [Display(Name="Cấp học")]
    public virtual System.String EDUCATIONLEVELCODE
    {
        get ;
        set ;
    }
    [Display(Name="Hình thức giảng dạy")]
    public virtual System.String LEARNINGTYPECODE
    {
        get ;
        set ;
    }
    [Display(Name="Số tín chỉ")]
    public virtual System.Int32 CREDIT
    {
        get ;
        set ;
    }
    [Display(Name="Số tiết")]
    public virtual System.Int32 CLASSPERIOD
    {
        get ;
        set ;
    }
    [Display(Name="Đơn vị phụ trách")]
    public virtual System.String DEPARTMENTCODE
    {
        get ;
        set ;
    }
    [Display(Name="Số tiết lý thuyết")]
    public virtual System.Int32 THEORYPERIOD
    {
        get ;
        set ;
    }
    [Display(Name="Số tiết thực hành")]
    public virtual System.Int32 PRACTICEPERIOD
    {
        get ;
        set ;
    }
    [Display(Name="Số tiết bài tập")]
    public virtual System.Int32 ASSIGNPERIOD
    {
        get ;
        set ;
    }
    [Display(Name="Hình thức thi")]
    public virtual System.String TESTINGTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    [Display(Name="Mã khoa")]
    public virtual System.String DEPARTMENTCODE1
    {
        get ;
        set ;
    }
    public virtual System.Int32 COUNTCOLUMN
    {
        get ;
        set ;
    }
    public virtual System.String MARKTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 TESTPERIOD
    {
        get ;
        set ;
    }
    public virtual System.String MATERIAL
    {
        get ;
        set ;
    }
    public virtual System.String LESSONPLAN
    {
        get ;
        set ;
    }
    public virtual System.String LESSONDETAIL
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String LANG
    {
        get ;
        set ;
    }
    public virtual System.String ORIGINALCODE
    {
        get ;
        set ;
    }


	public override int GetHashCode()
	{
		return _ID.GetHashCode();
	}

}
}

