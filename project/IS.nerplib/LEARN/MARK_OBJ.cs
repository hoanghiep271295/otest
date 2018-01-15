using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class MARK_OBJ: BusinessObject<MARK_OBJ.BusinessObjectID>
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

	public MARK_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public MARK_OBJ(BusinessObjectID id)
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
,new fieldInfo("STUDENTCODE",10,"VARCHAR",0)
,new fieldInfo("COURSECODE",10,"VARCHAR",0)
,new fieldInfo("MARKCC",10,"VARCHAR",0)
,new fieldInfo("MARKTX",10,"VARCHAR",0)
,new fieldInfo("MARKTHI",10,"VARCHAR",0)
,new fieldInfo("MARK10",4,"VARCHAR",0)
,new fieldInfo("MARKA",2,"CHAR",0)
,new fieldInfo("MARK4",4,"VARCHAR",0)
,new fieldInfo("MANAGEDEPARTMENTCODE",10,"VARCHAR",0)
,new fieldInfo("EDUCATIONDEPARTMENTCODE",10,"VARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("CREDIT",0,"FLOAT",0)
,new fieldInfo("SUBJECTCODE",10,"VARCHAR",0)
,new fieldInfo("YEAR",0,"INT",0)
,new fieldInfo("TERM",0,"INT",0)
,new fieldInfo("PASS",0,"INT",0)
,new fieldInfo("LEARNRESULTTYPECODE",10,"VARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("SUBJECT", "CODE", "SUBJECTCODE")]
   public SUBJECT_OBJ _SUBJECTCODE;
 [tablereference("STUDENT", "CODE", "STUDENTCODE")]
   public STUDENT_OBJ _STUDENTCODE;
 [tablereference("COURSE", "CODE", "COURSECODE")]
   public COURSE_OBJ _COURSECODE;
 [tablereference("STAFF", "CODE", "MANAGEDEPARTMENTCODE")]
   public STAFF_OBJ _MANAGEDEPARTMENTCODE;
 [tablereference("STAFF", "CODE", "EDUCATIONDEPARTMENTCODE")]
   public STAFF_OBJ _EDUCATIONDEPARTMENTCODE;
 [tablereference("LEARNRESULTTYPE", "CODE", "LEARNRESULTTYPECODE")]
   public LEARNRESULTTYPE_OBJ _LEARNRESULTTYPECODE;

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
    public virtual System.String STUDENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String COURSECODE
    {
        get ;
        set ;
    }
    public virtual System.String MARKCC
    {
        get ;
        set ;
    }
    public virtual System.String MARKTX
    {
        get ;
        set ;
    }
    public virtual System.String MARKTHI
    {
        get ;
        set ;
    }
    public virtual System.String MARK10
    {
        get ;
        set ;
    }
    public virtual System.String MARKA
    {
        get ;
        set ;
    }
    public virtual System.String MARK4
    {
        get ;
        set ;
    }
    public virtual System.String MANAGEDEPARTMENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String EDUCATIONDEPARTMENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.Double CREDIT
    {
        get ;
        set ;
    }
    public virtual System.String SUBJECTCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 YEAR
    {
        get ;
        set ;
    }
    public virtual System.Int32 TERM
    {
        get ;
        set ;
    }
    public virtual System.Int32 PASS
    {
        get ;
        set ;
    }
    public virtual System.String LEARNRESULTTYPECODE
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

