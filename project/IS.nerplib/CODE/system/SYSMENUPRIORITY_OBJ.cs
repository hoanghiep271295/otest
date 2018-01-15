using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class SYSMENUPRIORITY_OBJ: BusinessObject<SYSMENUPRIORITY_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _SYSMENUCODE;
	private System.String _PRIORITYCODE;

		public BusinessObjectID(System.String mSYSMENUCODE,System.String mPRIORITYCODE)
		{
		_SYSMENUCODE = mSYSMENUCODE;
		_PRIORITYCODE = mPRIORITYCODE;

		}

    public System.String SYSMENUCODE
    {
        get { return _SYSMENUCODE; }
        set { _SYSMENUCODE = value; }
    }

    public System.String PRIORITYCODE
    {
        get { return _PRIORITYCODE; }
        set { _PRIORITYCODE = value; }
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
		if (this.SYSMENUCODE != that.SYSMENUCODE) return false;
		if (this.PRIORITYCODE != that.PRIORITYCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return SYSMENUCODE.GetHashCode() ^ PRIORITYCODE.GetHashCode();
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

	public SYSMENUPRIORITY_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public SYSMENUPRIORITY_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("SYSMENUCODE",10,"VARCHAR",0)
,new fieldInfo("PRIORITYCODE",100,"NVARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("EXTENSIONCODE",200,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("SYSMENU", "CODE", "SYSMENUCODE")]
   public SYSMENU_OBJ _SYSMENUCODE;

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
    public virtual System.String SYSMENUCODE
    {
        get ;
        set ;
    }
    public virtual System.String PRIORITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.String EXTENSIONCODE
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

