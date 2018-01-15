using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class GRADESTAFF_OBJ: BusinessObject<GRADESTAFF_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _GRADECODE;
	private System.String _STAFFCODE;

		public BusinessObjectID(System.String mGRADECODE,System.String mSTAFFCODE)
		{
		_GRADECODE = mGRADECODE;
		_STAFFCODE = mSTAFFCODE;

		}

    public System.String GRADECODE
    {
        get { return _GRADECODE; }
        set { _GRADECODE = value; }
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
		if (this.GRADECODE != that.GRADECODE) return false;
		if (this.STAFFCODE != that.STAFFCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return GRADECODE.GetHashCode() ^ STAFFCODE.GetHashCode();
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

	public GRADESTAFF_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public GRADESTAFF_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("GRADECODE",10,"VARCHAR",0)
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
	 [tablereference("GRADE", "CODE", "GRADECODE")]
   public GRADE_OBJ _GRADECODE;
 [tablereference("STAFF", "CODE", "STAFFCODE")]
   public STAFF_OBJ _STAFFCODE;

    public virtual System.String GRADECODE
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

