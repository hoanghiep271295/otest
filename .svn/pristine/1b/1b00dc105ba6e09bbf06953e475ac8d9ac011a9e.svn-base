using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class EXAMRESULT_OBJ: BusinessObject<EXAMRESULT_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _EXAMHALLSTUDENTCODE;
	private System.String _EXAMFORMDETAILCODE;
	private System.String _QUESTIONCODE;

		public BusinessObjectID(System.String mEXAMHALLSTUDENTCODE,System.String mEXAMFORMDETAILCODE,System.String mQUESTIONCODE)
		{
		_EXAMHALLSTUDENTCODE = mEXAMHALLSTUDENTCODE;
		_EXAMFORMDETAILCODE = mEXAMFORMDETAILCODE;
		_QUESTIONCODE = mQUESTIONCODE;

		}

    public System.String EXAMHALLSTUDENTCODE
    {
        get { return _EXAMHALLSTUDENTCODE; }
        set { _EXAMHALLSTUDENTCODE = value; }
    }

    public System.String EXAMFORMDETAILCODE
    {
        get { return _EXAMFORMDETAILCODE; }
        set { _EXAMFORMDETAILCODE = value; }
    }

    public System.String QUESTIONCODE
    {
        get { return _QUESTIONCODE; }
        set { _QUESTIONCODE = value; }
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
		if (this.EXAMHALLSTUDENTCODE != that.EXAMHALLSTUDENTCODE) return false;
		if (this.EXAMFORMDETAILCODE != that.EXAMFORMDETAILCODE) return false;
		if (this.QUESTIONCODE != that.QUESTIONCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return EXAMHALLSTUDENTCODE.GetHashCode() ^ EXAMFORMDETAILCODE.GetHashCode() ^ QUESTIONCODE.GetHashCode();
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

	public EXAMRESULT_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public EXAMRESULT_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("EXAMHALLSTUDENTCODE",10,"VARCHAR",0)
,new fieldInfo("EXAMFORMCODE",10,"VARCHAR",0)
,new fieldInfo("EXAMFORMDETAILCODE",10,"VARCHAR",0)
,new fieldInfo("QUESTIONCODE",10,"VARCHAR",0)
,new fieldInfo("ANSWERCODE",10,"VARCHAR",0)
,new fieldInfo("ANSWERTEXT",4000,"NVARCHAR",0)
,new fieldInfo("ANSWERFILE",100,"NVARCHAR",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("MARK",0,"FLOAT",0)
,new fieldInfo("QUESTIONGROUPCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("QUESTIONGROUP", "CODE", "QUESTIONGROUPCODE")]
   public QUESTIONGROUP_OBJ _QUESTIONGROUPCODE;
 [tablereference("QUESTION", "CODE", "QUESTIONCODE")]
   public QUESTION_OBJ _QUESTIONCODE;

    public virtual System.String EXAMHALLSTUDENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String EXAMFORMCODE
    {
        get ;
        set ;
    }
    public virtual System.String EXAMFORMDETAILCODE
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONCODE
    {
        get ;
        set ;
    }
    public virtual System.String ANSWERCODE
    {
        get ;
        set ;
    }
    public virtual System.String ANSWERTEXT
    {
        get ;
        set ;
    }
    public virtual System.String ANSWERFILE
    {
        get ;
        set ;
    }
    public virtual System.DateTime LOCKDATE
    {
        get ;
        set ;
    }
    public virtual System.Int16 LOCK
    {
        get ;
        set ;
    }
    public virtual System.Double MARK
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONGROUPCODE
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

