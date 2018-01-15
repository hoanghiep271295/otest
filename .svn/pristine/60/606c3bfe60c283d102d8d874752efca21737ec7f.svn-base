using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class STAFFSUBJECT_OBJ: BusinessObject<STAFFSUBJECT_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _STAFFCODE;
	private System.String _SUBJECTCODE;

		public BusinessObjectID(System.String mSTAFFCODE,System.String mSUBJECTCODE)
		{
		_STAFFCODE = mSTAFFCODE;
		_SUBJECTCODE = mSUBJECTCODE;

		}

    public System.String STAFFCODE
    {
        get { return _STAFFCODE; }
        set { _STAFFCODE = value; }
    }

    public System.String SUBJECTCODE
    {
        get { return _SUBJECTCODE; }
        set { _SUBJECTCODE = value; }
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
		if (this.STAFFCODE != that.STAFFCODE) return false;
		if (this.SUBJECTCODE != that.SUBJECTCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return STAFFCODE.GetHashCode() ^ SUBJECTCODE.GetHashCode();
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

	public STAFFSUBJECT_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public STAFFSUBJECT_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("STAFFCODE",10,"VARCHAR",0)
,new fieldInfo("SUBJECTCODE",10,"VARCHAR",0)
,new fieldInfo("SHOWON",0,"INT",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("SUBJECTCODEVIEW",20,"NVARCHAR",0)
,new fieldInfo("SUBJECTNAME",200,"NVARCHAR",0)
,new fieldInfo("SUBJECTCREDIT",0,"INT",0)
,new fieldInfo("EDUCATIONLEVELCODE",10,"VARCHAR",0)
,new fieldInfo("APPROVEDSTATUS",0,"INT",0)
,new fieldInfo("APPROVEDBY",10,"VARCHAR",0)
,new fieldInfo("APPROVALTIME",0,"DATETIME",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("EDUCATIONLEVEL", "CODE", "EDUCATIONLEVELCODE")]
   public EDUCATIONLEVEL_OBJ _EDUCATIONLEVELCODE;
 [tablereference("STAFF", "CODE", "STAFFCODE")]
   public STAFF_OBJ _STAFFCODE;
 [tablereference("SUBJECT", "CODE", "SUBJECTCODE")]
   public SUBJECT_OBJ _SUBJECTCODE;
 //[tablereference("APPROVEDSTATUS", "CODELINK", "APPROVEDSTATUS")]
 //  public APPROVEDSTATUS_OBJ _APPROVEDSTATUS;

    public virtual System.String STAFFCODE
    {
        get ;
        set ;
    }
    public virtual System.String SUBJECTCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 SHOWON
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
    public virtual System.String EDITUSER
    {
        get ;
        set ;
    }
    [Display(Name="Mã môn học")]
    public virtual System.String SUBJECTCODEVIEW
    {
        get ;
        set ;
    }
    [Display(Name="Tên môn học")]
    public virtual System.String SUBJECTNAME
    {
        get ;
        set ;
    }
    [Display(Name="Số tín chỉ")]
    public virtual System.Int32 SUBJECTCREDIT
    {
        get ;
        set ;
    }
    [Display(Name="Cấp đào tào")]
    public virtual System.String EDUCATIONLEVELCODE
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

