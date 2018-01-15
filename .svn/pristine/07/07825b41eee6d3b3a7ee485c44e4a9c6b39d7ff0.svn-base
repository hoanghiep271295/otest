using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class MAPPINGLINK_OBJ: BusinessObject<MAPPINGLINK_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _UNIVERSITYCODE;
	private System.String _TABLENAME;
	private System.Int32 _THECODELINK;

		public BusinessObjectID(System.String mUNIVERSITYCODE,System.String mTABLENAME,System.Int32 mTHECODELINK)
		{
		_UNIVERSITYCODE = mUNIVERSITYCODE;
		_TABLENAME = mTABLENAME;
		_THECODELINK = mTHECODELINK;

		}

    public System.String UNIVERSITYCODE
    {
        get { return _UNIVERSITYCODE; }
        set { _UNIVERSITYCODE = value; }
    }

    public System.String TABLENAME
    {
        get { return _TABLENAME; }
        set { _TABLENAME = value; }
    }

    public System.Int32 THECODELINK
    {
        get { return _THECODELINK; }
        set { _THECODELINK = value; }
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
		if (this.UNIVERSITYCODE != that.UNIVERSITYCODE) return false;
		if (this.TABLENAME != that.TABLENAME) return false;
		if (this.THECODELINK != that.THECODELINK) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return UNIVERSITYCODE.GetHashCode() ^ TABLENAME.GetHashCode() ^ THECODELINK.GetHashCode();
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

	public MAPPINGLINK_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public MAPPINGLINK_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("TABLENAME",100,"VARCHAR",0)
,new fieldInfo("THECODELINK",0,"INT",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("LANGUAGECODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	

    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String TABLENAME
    {
        get ;
        set ;
    }
    public virtual System.Int32 THECODELINK
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
    public virtual System.String LANGUAGECODE
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

