using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class CLASSSTAFF_OBJ: BusinessObject<CLASSSTAFF_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _CLASSCODE;
	private System.String _STAFFCODE;

		public BusinessObjectID(System.String mCLASSCODE,System.String mSTAFFCODE)
		{
		_CLASSCODE = mCLASSCODE;
		_STAFFCODE = mSTAFFCODE;

		}

    public System.String CLASSCODE
    {
        get { return _CLASSCODE; }
        set { _CLASSCODE = value; }
    }

    public System.String STAFFCODE
    {
        get { return _STAFFCODE; }
        set { _STAFFCODE = value; }
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
		if (this.CLASSCODE != that.CLASSCODE) return false;
		if (this.STAFFCODE != that.STAFFCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return CLASSCODE.GetHashCode() ^ STAFFCODE.GetHashCode();
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

	public CLASSSTAFF_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public CLASSSTAFF_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("CLASSCODE",10,"VARCHAR",0)
,new fieldInfo("STAFFCODE",10,"VARCHAR",0)
,new fieldInfo("FUNC",0,"INT",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("ISAUTHORIZATION",0,"INT",0)
,new fieldInfo("AUTHORIZEDBY",10,"VARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("CLASS", "CODE", "CLASSCODE")]
   public CLASS_OBJ _CLASSCODE;
 [tablereference("STAFF", "CODE", "STAFFCODE")]
   public STAFF_OBJ _STAFFCODE;

    public virtual System.String CLASSCODE
    {
        get ;
        set ;
    }
    public virtual System.String STAFFCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 FUNC
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
    public virtual System.Int32 ISAUTHORIZATION
    {
        get ;
        set ;
    }
    public virtual System.String AUTHORIZEDBY
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

