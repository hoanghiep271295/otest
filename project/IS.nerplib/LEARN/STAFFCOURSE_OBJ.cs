using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class STAFFCOURSE_OBJ: BusinessObject<STAFFCOURSE_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _COURSECODE;
	private System.String _STAFFCODE;
	private System.String _LEARNINGTYPECODE;

		public BusinessObjectID(System.String mCOURSECODE,System.String mSTAFFCODE,System.String mLEARNINGTYPECODE)
		{
		_COURSECODE = mCOURSECODE;
		_STAFFCODE = mSTAFFCODE;
		_LEARNINGTYPECODE = mLEARNINGTYPECODE;

		}

    public System.String COURSECODE
    {
        get { return _COURSECODE; }
        set { _COURSECODE = value; }
    }

    public System.String STAFFCODE
    {
        get { return _STAFFCODE; }
        set { _STAFFCODE = value; }
    }

    public System.String LEARNINGTYPECODE
    {
        get { return _LEARNINGTYPECODE; }
        set { _LEARNINGTYPECODE = value; }
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
		if (this.COURSECODE != that.COURSECODE) return false;
		if (this.STAFFCODE != that.STAFFCODE) return false;
		if (this.LEARNINGTYPECODE != that.LEARNINGTYPECODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return COURSECODE.GetHashCode() ^ STAFFCODE.GetHashCode() ^ LEARNINGTYPECODE.GetHashCode();
		}

	}
	//main object
	protected string _codeP="{C}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public STAFFCOURSE_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public STAFFCOURSE_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("COURSECODE",10,"VARCHAR",0)
,new fieldInfo("STAFFCODE",20,"VARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("EDUCATIONLEVELCODE",10,"VARCHAR",0)
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
,new fieldInfo("LEARNINGTYPECODE",10,"VARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("COURSE", "CODE", "COURSECODE")]
   public COURSE_OBJ _COURSECODE;
 [tablereference("STAFF", "CODE", "STAFFCODE")]
   public STAFF_OBJ _STAFFCODE;
 [tablereference("EDUCATIONLEVEL", "CODE", "EDUCATIONLEVELCODE")]
   public EDUCATIONLEVEL_OBJ _EDUCATIONLEVELCODE;
 [tablereference("DEPARTMENT", "CODE", "DEPARTMENTCODE")]
   public DEPARTMENT_OBJ _DEPARTMENTCODE;
 //[tablereference("LEARNINGTYPE", "CODE", "LEARNINGTYPECODE")]
 //  public LEARNINGTYPE_OBJ _LEARNINGTYPECODE;

    public virtual System.String COURSECODE
    {
        get ;
        set ;
    }
    public virtual System.String STAFFCODE
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
    public virtual System.String LEARNINGTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
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

