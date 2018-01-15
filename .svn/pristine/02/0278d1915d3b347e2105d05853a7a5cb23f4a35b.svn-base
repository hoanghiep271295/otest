using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class CONTENTTYPEQUESTIONUSE_OBJ: BusinessObject<CONTENTTYPEQUESTIONUSE_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _CONTENTTYPECODE;
	private System.String _QUESTIONUSECODE;

		public BusinessObjectID(System.String mCONTENTTYPECODE,System.String mQUESTIONUSECODE)
		{
		_CONTENTTYPECODE = mCONTENTTYPECODE;
		_QUESTIONUSECODE = mQUESTIONUSECODE;

		}

    public System.String CONTENTTYPECODE
    {
        get { return _CONTENTTYPECODE; }
        set { _CONTENTTYPECODE = value; }
    }

    public System.String QUESTIONUSECODE
    {
        get { return _QUESTIONUSECODE; }
        set { _QUESTIONUSECODE = value; }
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
		if (this.CONTENTTYPECODE != that.CONTENTTYPECODE) return false;
		if (this.QUESTIONUSECODE != that.QUESTIONUSECODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return CONTENTTYPECODE.GetHashCode() ^ QUESTIONUSECODE.GetHashCode();
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

	public CONTENTTYPEQUESTIONUSE_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public CONTENTTYPEQUESTIONUSE_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("CONTENTTYPECODE",10,"VARCHAR",0)
,new fieldInfo("QUESTIONUSECODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("CONTENTTYPE", "CODE", "CONTENTTYPECODE")]
   public CONTENTTYPE_OBJ _CONTENTTYPECODE;
 [tablereference("QUESTIONUSE", "CODE", "QUESTIONUSECODE")]
   public QUESTIONUSE_OBJ _QUESTIONUSECODE;

    public virtual System.String CONTENTTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONUSECODE
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

