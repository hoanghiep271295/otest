using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class CLASS_OBJ: BusinessObject<CLASS_OBJ.BusinessObjectID>
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
	protected string _codeP= "C{SHORD}{CCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public CLASS_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public CLASS_OBJ(BusinessObjectID id)
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
,new fieldInfo("DEPARTMENTCODE",10,"VARCHAR",0)
,new fieldInfo("DEPARTMENTCODE2",10,"VARCHAR",0)
,new fieldInfo("AMOUNT",0,"INT",0)
,new fieldInfo("GRADECODE",10,"VARCHAR",0)
,new fieldInfo("FEE",0,"INT",0)
,new fieldInfo("STUDENTGROUPTYPE",10,"VARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
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
	 [tablereference("GRADE", "CODE", "GRADECODE")]
   public GRADE_OBJ _GRADECODE;
 [tablereference("DEPARTMENT", "CODE", "DEPARTMENTCODE")]
   public DEPARTMENT_OBJ _DEPARTMENTCODE;
 [tablereference("DEPARTMENT", "CODE", "DEPARTMENTCODE2")]
   public DEPARTMENT_OBJ _DEPARTMENTCODE2;
 [tablereference("STUDENTGROUPTYPE", "CODE", "STUDENTGROUPTYPE")]
   public STUDENTGROUPTYPE_OBJ _STUDENTGROUPTYPE;

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
    public virtual System.String DEPARTMENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String DEPARTMENTCODE2
    {
        get ;
        set ;
    }
    public virtual System.Int32 AMOUNT
    {
        get ;
        set ;
    }
    public virtual System.String GRADECODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 FEE
    {
        get ;
        set ;
    }
    public virtual System.String STUDENTGROUPTYPE
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

