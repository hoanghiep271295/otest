using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class EXAMFORMDETAIL_OBJ: BusinessObject<EXAMFORMDETAIL_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _CODE;

		public BusinessObjectID(System.String mCODE)
		{
		_CODE = mCODE;

		}

    public System.String CODE
    {
        get { return _CODE; }
        set { _CODE = value; }
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
		if (this.CODE != that.CODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return CODE.GetHashCode();
		}

	}
	//main object
	protected string _codeP="{yyMMdd}{CCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public EXAMFORMDETAIL_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public EXAMFORMDETAIL_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("CODE",10,"VARCHAR",0)
,new fieldInfo("EXAMFORMCODE",10,"VARCHAR",0)
,new fieldInfo("TESTSTRUCTDETAILCODE",10,"VARCHAR",0)
,new fieldInfo("QUESTIONGROUPCODE",10,"VARCHAR",0)
,new fieldInfo("THEORDER",0,"INT",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("EXAMFORM", "CODE", "EXAMFORMCODE")]
   public EXAMFORM_OBJ _EXAMFORMCODE;
 [tablereference("TESTSTRUCTDETAIL", "CODE", "TESTSTRUCTDETAILCODE")]
   public TESTSTRUCTDETAIL_OBJ _TESTSTRUCTDETAILCODE;
 [tablereference("QUESTIONGROUP", "CODE", "QUESTIONGROUPCODE")]
   public QUESTIONGROUP_OBJ _QUESTIONGROUPCODE;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    public virtual System.String EXAMFORMCODE
    {
        get ;
        set ;
    }
    public virtual System.String TESTSTRUCTDETAILCODE
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONGROUPCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 THEORDER
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

