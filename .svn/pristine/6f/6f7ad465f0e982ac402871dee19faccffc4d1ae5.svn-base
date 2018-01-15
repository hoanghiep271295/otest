using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class STAFFADMINGROUP_OBJ: BusinessObject<STAFFADMINGROUP_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _OBJECTCODE;
	private System.String _THETYPE;
	private System.String _ADMINGROUPCODE;

		public BusinessObjectID(System.String mOBJECTCODE,System.String mTHETYPE,System.String mADMINGROUPCODE)
		{
		_OBJECTCODE = mOBJECTCODE;
		_THETYPE = mTHETYPE;
		_ADMINGROUPCODE = mADMINGROUPCODE;

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

    public System.String ADMINGROUPCODE
    {
        get { return _ADMINGROUPCODE; }
        set { _ADMINGROUPCODE = value; }
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
		if (this.ADMINGROUPCODE != that.ADMINGROUPCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return OBJECTCODE.GetHashCode() ^ THETYPE.GetHashCode() ^ ADMINGROUPCODE.GetHashCode();
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

	public STAFFADMINGROUP_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public STAFFADMINGROUP_OBJ(BusinessObjectID id)
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
,new fieldInfo("ADMINGROUPCODE",40,"NVARCHAR",0)
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
	 [tablereference("ADMINGROUP", "CODE", "ADMINGROUPCODE")]
   public ADMINGROUP_OBJ _ADMINGROUPCODE;

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
    public virtual System.String ADMINGROUPCODE
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

