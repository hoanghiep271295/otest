using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class LEVELTITLEPRIORITY_OBJ: BusinessObject<LEVELTITLEPRIORITY_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _LEVELTITLECODE;
	private System.String _PRIORITYCODE;

		public BusinessObjectID(System.String mLEVELTITLECODE,System.String mPRIORITYCODE)
		{
		_LEVELTITLECODE = mLEVELTITLECODE;
		_PRIORITYCODE = mPRIORITYCODE;

		}

    public System.String LEVELTITLECODE
    {
        get { return _LEVELTITLECODE; }
        set { _LEVELTITLECODE = value; }
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
		if (this.LEVELTITLECODE != that.LEVELTITLECODE) return false;
		if (this.PRIORITYCODE != that.PRIORITYCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return LEVELTITLECODE.GetHashCode() ^ PRIORITYCODE.GetHashCode();
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

	public LEVELTITLEPRIORITY_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public LEVELTITLEPRIORITY_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("LEVELTITLECODE",40,"NVARCHAR",0)
,new fieldInfo("PRIORITYCODE",40,"NVARCHAR",0)
,new fieldInfo("FORMAN",0,"INT",0)
,new fieldInfo("FUNC",0,"INT",0)
,new fieldInfo("DEPARTMENTCODE",10,"VARCHAR",0)
,new fieldInfo("INHERIT",0,"INT",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("LEVELTITLE", "CODE", "LEVELTITLECODE")]
   public LEVELTITLE_OBJ _LEVELTITLECODE;
 [tablereference("PRIORITY", "CODE", "PRIORITYCODE")]
   public PRIORITY_OBJ _PRIORITYCODE;

    public virtual System.String LEVELTITLECODE
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
    public virtual System.String DEPARTMENTCODE
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


	public override int GetHashCode()
	{
		return _ID.GetHashCode();
	}

}
}

