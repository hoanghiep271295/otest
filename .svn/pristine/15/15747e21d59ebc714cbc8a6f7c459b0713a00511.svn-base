using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class EDUCATIONFIELDSTAFF_OBJ: BusinessObject<EDUCATIONFIELDSTAFF_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _EDUCATIONFIELDCODE;
	private System.String _STAFFCODE;

		public BusinessObjectID(System.String mEDUCATIONFIELDCODE,System.String mSTAFFCODE)
		{
		_EDUCATIONFIELDCODE = mEDUCATIONFIELDCODE;
		_STAFFCODE = mSTAFFCODE;

		}

    public System.String EDUCATIONFIELDCODE
    {
        get { return _EDUCATIONFIELDCODE; }
        set { _EDUCATIONFIELDCODE = value; }
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
		if (this.EDUCATIONFIELDCODE != that.EDUCATIONFIELDCODE) return false;
		if (this.STAFFCODE != that.STAFFCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return EDUCATIONFIELDCODE.GetHashCode() ^ STAFFCODE.GetHashCode();
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

	public EDUCATIONFIELDSTAFF_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public EDUCATIONFIELDSTAFF_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("EDUCATIONFIELDCODE",10,"VARCHAR",0)
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
	 [tablereference("EDUCATIONFIELD", "CODE", "EDUCATIONFIELDCODE")]
   public EDUCATIONFIELD_OBJ _EDUCATIONFIELDCODE;
 [tablereference("STAFF", "CODE", "STAFFCODE")]
   public STAFF_OBJ _STAFFCODE;

    public virtual System.String EDUCATIONFIELDCODE
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

