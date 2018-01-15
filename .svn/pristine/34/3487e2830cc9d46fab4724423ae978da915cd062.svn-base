using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class NATIONREFERENCE_OBJ: BusinessObject<NATIONREFERENCE_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _NATIONCODE;
	private System.String _CURRENTCODE;

		public BusinessObjectID(System.String mNATIONCODE,System.String mCURRENTCODE)
		{
		_NATIONCODE = mNATIONCODE;
		_CURRENTCODE = mCURRENTCODE;

		}

    public System.String NATIONCODE
    {
        get { return _NATIONCODE; }
        set { _NATIONCODE = value; }
    }

    public System.String CURRENTCODE
    {
        get { return _CURRENTCODE; }
        set { _CURRENTCODE = value; }
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
		if (this.NATIONCODE != that.NATIONCODE) return false;
		if (this.CURRENTCODE != that.CURRENTCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return NATIONCODE.GetHashCode() ^ CURRENTCODE.GetHashCode();
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

	public NATIONREFERENCE_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public NATIONREFERENCE_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("NATIONCODE",10,"VARCHAR",0)
,new fieldInfo("CURRENTCODE",10,"VARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("NATION", "CODE", "NATIONCODE")]
   public NATION_OBJ _NATIONCODE;
 [tablereference("NATION", "CODE", "CURRENTCODE")]
   public NATION_OBJ _CURRENTCODE;

    public virtual System.String NATIONCODE
    {
        get ;
        set ;
    }
    public virtual System.String CURRENTCODE
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


	public override int GetHashCode()
	{
		return _ID.GetHashCode();
	}

}
}

