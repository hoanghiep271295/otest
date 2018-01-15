using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class COURSE_OBJ: BusinessObject<COURSE_OBJ.BusinessObjectID>
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

	public COURSE_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public COURSE_OBJ(BusinessObjectID id)
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
,new fieldInfo("EDUCATIONLEVELCODE",10,"VARCHAR",0)
,new fieldInfo("TERM",0,"SMALLINT",0)
,new fieldInfo("YEAR",0,"INT",0)
,new fieldInfo("SUBJECTCODE",10,"VARCHAR",0)
,new fieldInfo("STAFFCODE",10,"VARCHAR",0)
,new fieldInfo("HALLCODE",10,"VARCHAR",0)
,new fieldInfo("STUDENTAMOUNT",0,"INT",0)
,new fieldInfo("EXAMDATE",0,"DATETIME",0)
,new fieldInfo("BEGINDATE",0,"DATETIME",0)
,new fieldInfo("ENDDATE",0,"DATETIME",0)
,new fieldInfo("REEXAM",0,"INT",0)
,new fieldInfo("COUNTCOLUMN",0,"INT",0)
,new fieldInfo("FORCEFEE",0,"INT",0)
,new fieldInfo("CREDIT",0,"FLOAT",0)
,new fieldInfo("APPROVALLINK",1000,"NVARCHAR",0)
,new fieldInfo("APPROVEDSTATUS",0,"INT",0)
,new fieldInfo("APPROVEDBY",10,"VARCHAR",0)
,new fieldInfo("APPROVALTIME",0,"DATETIME",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("CLASSTIME",0,"INT",0)
,new fieldInfo("RESEARCHPOINT",18,"DECIMAL",2)
,new fieldInfo("RESEARCHSUPPORT",18,"DECIMAL",2)
,new fieldInfo("EDUPOINT",18,"DECIMAL",2)
,new fieldInfo("EDUSUPPORT",18,"DECIMAL",2)
,new fieldInfo("CLASSPERIOD",0,"INT ",0)
,new fieldInfo("DEPARTMENTCODE",10,"VARCHAR",0)
,new fieldInfo("THEORYPERIOD",0,"INT",0)
,new fieldInfo("PRACTICEPERIOD",0,"INT",0)
,new fieldInfo("ASSIGNPERIOD",0,"INT",0)
,new fieldInfo("COUNTSTAFF",0,"INT",0)
,new fieldInfo("GRADETYPECODE",10,"VARCHAR",0)
,new fieldInfo("TERMCODE",10,"VARCHAR",0)
,new fieldInfo("SUBJECTNAME",200,"NVARCHAR",0)
,new fieldInfo("LEARNINGTYPECODE",10,"VARCHAR",0)
,new fieldInfo("MARKTESTTYPECODE",10,"VARCHAR",0)
,new fieldInfo("QUATER",0,"INT",0)
,new fieldInfo("QUATERYEAR",0,"INT",0)
,new fieldInfo("THEFILE",200,"NVARCHAR",0)
,new fieldInfo("PREMARKENDDATE",0,"DATETIME",0)
,new fieldInfo("MARKENDDATE",0,"DATETIME",0)
,new fieldInfo("MARKTYPECODE",10,"VARCHAR",0)
,new fieldInfo("REGISTEREDSTUDENT",0,"INT",0)
,new fieldInfo("MAXSTUDENT",0,"INT",0)
,new fieldInfo("MINSTUDENT",0,"INT",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("LANG",10,"VARCHAR",0)

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
 [tablereference("SUBJECT", "CODE", "SUBJECTCODE")]
   public SUBJECT_OBJ _SUBJECTCODE;
 [tablereference("STAFF", "CODE", "STAFFCODE")]
   public STAFF_OBJ _STAFFCODE;
 [tablereference("HALL", "CODE", "HALLCODE")]
   public HALL_OBJ _HALLCODE;
 //[tablereference("APPROVEDSTATUS", "CODELINK", "APPROVEDSTATUS")]
 //  public APPROVEDSTATUS_OBJ _APPROVEDSTATUS;
 [tablereference("STAFF", "CODE", "APPROVEDBY")]
   public STAFF_OBJ _APPROVEDBY;
 [tablereference("DEPARTMENT", "CODE", "DEPARTMENTCODE")]
   public DEPARTMENT_OBJ _DEPARTMENTCODE;
 //[tablereference("TERM", "CODE", "TERMCODE")]
 //  public TERM_OBJ _TERMCODE;
 //[tablereference("LEARNINGTYPE", "CODE", "LEARNINGTYPECODE")]
 //  public LEARNINGTYPE_OBJ _LEARNINGTYPECODE;
 //[tablereference("MARKTESTTYPE", "CODE", "MARKTESTTYPECODE")]
 //  public MARKTESTTYPE_OBJ _MARKTESTTYPECODE;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    public virtual System.String CODEVIEW
    {
        get ;
        set ;
    }
    public virtual System.String NAME
    {
        get ;
        set ;
    }
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
    public virtual System.String EDUCATIONLEVELCODE
    {
        get ;
        set ;
    }
    public virtual System.Int16 TERM
    {
        get ;
        set ;
    }
    public virtual System.Int32 YEAR
    {
        get ;
        set ;
    }
    public virtual System.String SUBJECTCODE
    {
        get ;
        set ;
    }
    public virtual System.String STAFFCODE
    {
        get ;
        set ;
    }
    public virtual System.String HALLCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 STUDENTAMOUNT
    {
        get ;
        set ;
    }
    public virtual System.DateTime EXAMDATE
    {
        get ;
        set ;
    }
    public virtual System.DateTime BEGINDATE
    {
        get ;
        set ;
    }
    public virtual System.DateTime ENDDATE
    {
        get ;
        set ;
    }
    public virtual System.Int32 REEXAM
    {
        get ;
        set ;
    }
    public virtual System.Int32 COUNTCOLUMN
    {
        get ;
        set ;
    }
    public virtual System.Int32 FORCEFEE
    {
        get ;
        set ;
    }
    public virtual System.Double CREDIT
    {
        get ;
        set ;
    }
    public virtual System.String APPROVALLINK
    {
        get ;
        set ;
    }
    public virtual System.Int32 APPROVEDSTATUS
    {
        get ;
        set ;
    }
    public virtual System.String APPROVEDBY
    {
        get ;
        set ;
    }
    public virtual System.DateTime APPROVALTIME
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.Int32 CLASSTIME
    {
        get ;
        set ;
    }
    public virtual System.Decimal RESEARCHPOINT
    {
        get ;
        set ;
    }
    public virtual System.Decimal RESEARCHSUPPORT
    {
        get ;
        set ;
    }
    public virtual System.Decimal EDUPOINT
    {
        get ;
        set ;
    }
    public virtual System.Decimal EDUSUPPORT
    {
        get ;
        set ;
    }
    public virtual System.Int32 CLASSPERIOD
    {
        get ;
        set ;
    }
    public virtual System.String DEPARTMENTCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 THEORYPERIOD
    {
        get ;
        set ;
    }
    public virtual System.Int32 PRACTICEPERIOD
    {
        get ;
        set ;
    }
    public virtual System.Int32 ASSIGNPERIOD
    {
        get ;
        set ;
    }
    public virtual System.Int32 COUNTSTAFF
    {
        get ;
        set ;
    }
    public virtual System.String GRADETYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String TERMCODE
    {
        get ;
        set ;
    }
    public virtual System.String SUBJECTNAME
    {
        get ;
        set ;
    }
    public virtual System.String LEARNINGTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String MARKTESTTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 QUATER
    {
        get ;
        set ;
    }
    public virtual System.Int32 QUATERYEAR
    {
        get ;
        set ;
    }
    [Display(Name="Minh chứng")]
    public virtual System.String THEFILE
    {
        get ;
        set ;
    }
    public virtual System.DateTime PREMARKENDDATE
    {
        get ;
        set ;
    }
    public virtual System.DateTime MARKENDDATE
    {
        get ;
        set ;
    }
    public virtual System.String MARKTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 REGISTEREDSTUDENT
    {
        get ;
        set ;
    }
    public virtual System.Int32 MAXSTUDENT
    {
        get ;
        set ;
    }
    public virtual System.Int32 MINSTUDENT
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


	public override int GetHashCode()
	{
		return _ID.GetHashCode();
	}

}
}

