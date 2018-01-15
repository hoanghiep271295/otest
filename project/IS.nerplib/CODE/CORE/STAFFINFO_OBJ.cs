using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class STAFFINFO_OBJ: BusinessObject<STAFFINFO_OBJ.BusinessObjectID>
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

	public STAFFINFO_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public STAFFINFO_OBJ(BusinessObjectID id)
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
,new fieldInfo("STAFFCODE",10,"VARCHAR",0)
,new fieldInfo("APPROVEDSTATUS",0,"INT",0)
,new fieldInfo("APPROVEDBY",10,"VARCHAR",0)
,new fieldInfo("APPROVALTIME",0,"DATETIME",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("OFFICIALNUMBER",50,"NVARCHAR",0)
,new fieldInfo("OFFICIALDATE",0,"DATETIME",0)
,new fieldInfo("OFFICIALDATESHOW",20,"VARCHAR",0)
,new fieldInfo("NOTE",1000,"NVARCHAR",0)
,new fieldInfo("ABSTRACT",4000,"NVARCHAR",0)
,new fieldInfo("NAME",1000,"NVARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("RELEASEOFFICE",1000,"NVARCHAR",0)
,new fieldInfo("RELEASEOFFICER",100,"NVARCHAR",0)
,new fieldInfo("THETYPE",50,"VARCHAR",0)
,new fieldInfo("EFFECTIVEDATESHOW",20,"VARCHAR",0)
,new fieldInfo("EFFECTIVEDATE",0,"DATETIME",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("STAFF", "CODE", "STAFFCODE")]
   public STAFF_OBJ _STAFFCODE;
 [tablereference("APPROVEDSTATUS", "CODELINK", "APPROVEDSTATUS")]
   public APPROVEDSTATUS_OBJ _APPROVEDSTATUS;
 [tablereference("STAFF", "CODE", "APPROVEDBY")]
   public STAFF_OBJ _APPROVEDBY;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    public virtual System.String STAFFCODE
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
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.String OFFICIALNUMBER
    {
        get ;
        set ;
    }
    public virtual System.DateTime OFFICIALDATE
    {
        get ;
        set ;
    }
    public virtual System.String OFFICIALDATESHOW
    {
        get ;
        set ;
    }
    public virtual System.String NOTE
    {
        get ;
        set ;
    }
    public virtual System.String ABSTRACT
    {
        get ;
        set ;
    }
    public virtual System.String NAME
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String RELEASEOFFICE
    {
        get ;
        set ;
    }
    public virtual System.String RELEASEOFFICER
    {
        get ;
        set ;
    }
    public virtual System.String THETYPE
    {
        get ;
        set ;
    }
    public virtual System.String EFFECTIVEDATESHOW
    {
        get ;
        set ;
    }
    public virtual System.DateTime EFFECTIVEDATE
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

