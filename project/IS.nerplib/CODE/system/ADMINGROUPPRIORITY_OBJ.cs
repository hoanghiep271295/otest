using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class ADMINGROUPPRIORITY_OBJ: BusinessObject<ADMINGROUPPRIORITY_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _OBJECTCODE;
	private System.String _THETYPE;
	private System.String _PRIORITYCODE;
	private System.Int32 _FORMAN;
	private System.String _THECODE;
	private System.String _TABLENAME;

		public BusinessObjectID(System.String mOBJECTCODE,System.String mTHETYPE,System.String mPRIORITYCODE,System.Int32 mFORMAN,System.String mTHECODE,System.String mTABLENAME)
		{
		_OBJECTCODE = mOBJECTCODE;
		_THETYPE = mTHETYPE;
		_PRIORITYCODE = mPRIORITYCODE;
		_FORMAN = mFORMAN;
		_THECODE = mTHECODE;
		_TABLENAME = mTABLENAME;

		}

    public System.String OBJECTCODE
    {
        get { return _OBJECTCODE; }
        set { _OBJECTCODE = value; }
    }

    public System.String THETYPE
    {
        get { return _THETYPE; }
        set { _THETYPE = value; }
    }

    public System.String PRIORITYCODE
    {
        get { return _PRIORITYCODE; }
        set { _PRIORITYCODE = value; }
    }

    public System.Int32 FORMAN
    {
        get { return _FORMAN; }
        set { _FORMAN = value; }
    }

    public System.String THECODE
    {
        get { return _THECODE; }
        set { _THECODE = value; }
    }

    public System.String TABLENAME
    {
        get { return _TABLENAME; }
        set { _TABLENAME = value; }
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
		if (this.OBJECTCODE != that.OBJECTCODE) return false;
		if (this.THETYPE != that.THETYPE) return false;
		if (this.PRIORITYCODE != that.PRIORITYCODE) return false;
		if (this.FORMAN != that.FORMAN) return false;
		if (this.THECODE != that.THECODE) return false;
		if (this.TABLENAME != that.TABLENAME) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return OBJECTCODE.GetHashCode() ^ THETYPE.GetHashCode() ^ PRIORITYCODE.GetHashCode() ^ FORMAN.GetHashCode() ^ THECODE.GetHashCode() ^ TABLENAME.GetHashCode();
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

	public ADMINGROUPPRIORITY_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public ADMINGROUPPRIORITY_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("OBJECTCODE",10,"VARCHAR",0)
,new fieldInfo("THETYPE",50,"VARCHAR",0)
,new fieldInfo("PRIORITYCODE",40,"NVARCHAR",0)
,new fieldInfo("FORMAN",0,"INT",0)
,new fieldInfo("FUNC",0,"INT",0)
,new fieldInfo("INHERIT",0,"INT",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("THECODE",10,"VARCHAR",0)
,new fieldInfo("EXTENSIONCODE",200,"VARCHAR",0)
,new fieldInfo("TABLENAME",50,"VARCHAR",0)
,new fieldInfo("SYSCOMPONENTCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("PRIORITY", "CODE", "PRIORITYCODE")]
   public PRIORITY_OBJ _PRIORITYCODE;

    public virtual System.String OBJECTCODE
    {
        get ;
        set ;
    }
    public virtual System.String THETYPE
    {
        get ;
        set ;
    }
    public virtual System.String PRIORITYCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 FORMAN
    {
        get ;
        set ;
    }
    public virtual System.Int32 FUNC
    {
        get ;
        set ;
    }
    public virtual System.Int32 INHERIT
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
    public virtual System.String THECODE
    {
        get ;
        set ;
    }
    public virtual System.String EXTENSIONCODE
    {
        get ;
        set ;
    }
    public virtual System.String TABLENAME
    {
        get ;
        set ;
    }
    public virtual System.String SYSCOMPONENTCODE
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

