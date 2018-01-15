using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class STAFFAUTHORIZE_OBJ: BusinessObject<STAFFAUTHORIZE_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _STAFFFROM;
	private System.String _PRIORITYCODE;
	private System.String _STAFFTO;

		public BusinessObjectID(System.String mSTAFFFROM,System.String mPRIORITYCODE,System.String mSTAFFTO)
		{
		_STAFFFROM = mSTAFFFROM;
		_PRIORITYCODE = mPRIORITYCODE;
		_STAFFTO = mSTAFFTO;

		}

    public System.String STAFFFROM
    {
        get { return _STAFFFROM; }
        set { _STAFFFROM = value; }
    }

    public System.String PRIORITYCODE
    {
        get { return _PRIORITYCODE; }
        set { _PRIORITYCODE = value; }
    }

    public System.String STAFFTO
    {
        get { return _STAFFTO; }
        set { _STAFFTO = value; }
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
		if (this.STAFFFROM != that.STAFFFROM) return false;
		if (this.PRIORITYCODE != that.PRIORITYCODE) return false;
		if (this.STAFFTO != that.STAFFTO) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return STAFFFROM.GetHashCode() ^ PRIORITYCODE.GetHashCode() ^ STAFFTO.GetHashCode();
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

	public STAFFAUTHORIZE_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public STAFFAUTHORIZE_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("STAFFFROM",10,"VARCHAR",0)
,new fieldInfo("PRIORITYCODE",10,"VARCHAR",0)
,new fieldInfo("STAFFTO",10,"VARCHAR",0)
,new fieldInfo("FUNC",0,"INT",0)
,new fieldInfo("THECODE",10,"VARCHAR",0)
,new fieldInfo("TABLENAME",50,"VARCHAR",0)
,new fieldInfo("INHERIT",0,"INT",0)
,new fieldInfo("BEGINTIME",0,"DATETIME",0)
,new fieldInfo("ENDTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"INT",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
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
	 [tablereference("STAFF", "CODE", "STAFFFROM")]
   public STAFF_OBJ _STAFFFROM;
 [tablereference("PRIORITY", "CODE", "PRIORITYCODE")]
   public PRIORITY_OBJ _PRIORITYCODE;
 [tablereference("STAFF", "CODE", "STAFFTO")]
   public STAFF_OBJ _STAFFTO;

    public virtual System.String STAFFFROM
    {
        get ;
        set ;
    }
    public virtual System.String PRIORITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String STAFFTO
    {
        get ;
        set ;
    }
    public virtual System.Int32 FUNC
    {
        get ;
        set ;
    }
    public virtual System.String THECODE
    {
        get ;
        set ;
    }
    public virtual System.String TABLENAME
    {
        get ;
        set ;
    }
    public virtual System.Int32 INHERIT
    {
        get ;
        set ;
    }
    public virtual System.DateTime BEGINTIME
    {
        get ;
        set ;
    }
    public virtual System.DateTime ENDTIME
    {
        get ;
        set ;
    }
    public virtual System.Int32 LOCK
    {
        get ;
        set ;
    }
    public virtual System.DateTime EDITTIME
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

