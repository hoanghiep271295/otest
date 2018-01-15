using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class ANSWER_OBJ: BusinessObject<ANSWER_OBJ.BusinessObjectID>
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
	protected string _codeP= "A{SHORD}{CCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public ANSWER_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public ANSWER_OBJ(BusinessObjectID id)
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
,new fieldInfo("CODEVIEW",20,"VARCHAR",0)
,new fieldInfo("NAME",200,"NVARCHAR",0)
,new fieldInfo("CONTENT",4000,"NVARCHAR",0)
,new fieldInfo("CONTENTIMG",200,"NVARCHAR",0)
,new fieldInfo("QUESTIONGROUPCODE",10,"VARCHAR",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("TRUEANSWER",0,"INT",0)
,new fieldInfo("QUESTIONCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("QUESTIONGROUP", "CODE", "QUESTIONGROUPCODE")]
   public QUESTIONGROUP_OBJ _QUESTIONGROUPCODE;
 [tablereference("QUESTION", "CODE", "QUESTIONCODE")]
   public QUESTION_OBJ _QUESTIONCODE;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    public virtual System.String CODEVIEW
    {
        get ;
        set ;
    }
    public virtual System.String NAME
    {
        get ;
        set ;
    }
    public virtual System.String CONTENT
    {
        get ;
        set ;
    }
    public virtual System.String CONTENTIMG
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
    public virtual System.Int32 TRUEANSWER
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONCODE
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

