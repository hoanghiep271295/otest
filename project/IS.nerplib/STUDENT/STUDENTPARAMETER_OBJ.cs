using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class STUDENTPARAMETER_OBJ: BusinessObject<STUDENTPARAMETER_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _STUDENTCODE;
	private System.String _THETYPECODE;

		public BusinessObjectID(System.String mSTUDENTCODE,System.String mTHETYPECODE)
		{
		_STUDENTCODE = mSTUDENTCODE;
		_THETYPECODE = mTHETYPECODE;

		}

    public System.String STUDENTCODE
    {
        get { return _STUDENTCODE; }
        set { _STUDENTCODE = value; }
    }

    public System.String THETYPECODE
    {
        get { return _THETYPECODE; }
        set { _THETYPECODE = value; }
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
		if (this.STUDENTCODE != that.STUDENTCODE) return false;
		if (this.THETYPECODE != that.THETYPECODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return STUDENTCODE.GetHashCode() ^ THETYPECODE.GetHashCode();
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

	public STUDENTPARAMETER_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public STUDENTPARAMETER_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("STUDENTCODE",10,"VARCHAR",0)
,new fieldInfo("THETYPECODE",50,"VARCHAR",0)
,new fieldInfo("THEVALUE",200,"NVARCHAR",0)
,new fieldInfo("DATATYPE",50,"NVARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("STAFF", "CODE", "STUDENTCODE")]
   public STAFF_OBJ _STUDENTCODE;

    public virtual System.String STUDENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String THETYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String THEVALUE
    {
        get ;
        set ;
    }
    public virtual System.String DATATYPE
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

