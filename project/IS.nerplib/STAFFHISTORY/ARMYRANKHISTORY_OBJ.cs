using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class ARMYRANKHISTORY_OBJ: BusinessObject<ARMYRANKHISTORY_OBJ.BusinessObjectID>
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

	public ARMYRANKHISTORY_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public ARMYRANKHISTORY_OBJ(BusinessObjectID id)
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
,new fieldInfo("THECODE",10,"VARCHAR",0)
,new fieldInfo("APPROVEDSTATUSCODE",10,"VARCHAR",0)
,new fieldInfo("APPROVEDBY",10,"VARCHAR",0)
,new fieldInfo("APPROVALTIME",0,"DATETIME",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("CHANGECURRRENT",0,"INT",0)
,new fieldInfo("PICKUPDATE",0,"DATETIME",0)
,new fieldInfo("PICKUPDATESHOW",20,"VARCHAR",0)
,new fieldInfo("ENDTIME",0,"DATETIME",0)
,new fieldInfo("ENDTIMESHOW",20,"VARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("OFFICIALNUMBER",50,"NVARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("THETYPE",50,"VARCHAR",0)
,new fieldInfo("STAFFINFOCODE",10,"VARCHAR",0)

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
 [tablereference("ARMYRANK", "CODE", "ARMYRANKCODE")]
   public ARMYRANK_OBJ _ARMYRANKCODE;
 [tablereference("APPROVEDSTATUS", "CODE", "APPROVEDSTATUSCODE")]
   public APPROVEDSTATUS_OBJ _APPROVEDSTATUSCODE;
 [tablereference("STAFFINFO", "CODE", "STAFFINFOCODE")]
   public STAFFINFO_OBJ _STAFFINFOCODE;

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
    public virtual System.String THECODE
    {
        get ;
        set ;
    }
    public virtual System.String APPROVEDSTATUSCODE
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
    public virtual System.Int32 CHANGECURRRENT
    {
        get ;
        set ;
    }
    public virtual System.DateTime PICKUPDATE
    {
        get ;
        set ;
    }
    public virtual System.String PICKUPDATESHOW
    {
        get ;
        set ;
    }
    public virtual System.DateTime ENDTIME
    {
        get ;
        set ;
    }
    public virtual System.String ENDTIMESHOW
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
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String THETYPE
    {
        get ;
        set ;
    }
    public virtual System.String STAFFINFOCODE
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

