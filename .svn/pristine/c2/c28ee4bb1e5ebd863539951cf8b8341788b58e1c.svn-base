using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class QUESTIONGROUPUSE_OBJ: BusinessObject<QUESTIONGROUPUSE_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _QUESITONGROUPCODE;

		public BusinessObjectID(System.String mQUESITONGROUPCODE)
		{
		_QUESITONGROUPCODE = mQUESITONGROUPCODE;

		}

    public System.String QUESITONGROUPCODE
    {
        get { return _QUESITONGROUPCODE; }
        set { _QUESITONGROUPCODE = value; }
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
		if (this.QUESITONGROUPCODE != that.QUESITONGROUPCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return QUESITONGROUPCODE.GetHashCode();
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

	public QUESTIONGROUPUSE_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public QUESTIONGROUPUSE_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("QUESITONGROUPCODE",10,"VARCHAR",0)
,new fieldInfo("QUESTIONUSECODE",10,"VARCHAR",0)
,new fieldInfo("LOCK",0,"INT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	

    public virtual System.String QUESITONGROUPCODE
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONUSECODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 LOCK
    {
        get ;
        set ;
    }
    public virtual System.DateTime LOCKDATE
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

