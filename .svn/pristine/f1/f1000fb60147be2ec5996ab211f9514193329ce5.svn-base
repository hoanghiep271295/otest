using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class SUBJECTCONTENTTEST_OBJ: BusinessObject<SUBJECTCONTENTTEST_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _SUBJECTCONTENTCODE;
	private System.String _EXAMTIMECODE;
	private System.String _QUESTIONUSECODE;
	private System.String _EXAMFORMCODE;

		public BusinessObjectID(System.String mSUBJECTCONTENTCODE,System.String mEXAMTIMECODE,System.String mQUESTIONUSECODE,System.String mEXAMFORMCODE)
		{
		_SUBJECTCONTENTCODE = mSUBJECTCONTENTCODE;
		_EXAMTIMECODE = mEXAMTIMECODE;
		_QUESTIONUSECODE = mQUESTIONUSECODE;
		_EXAMFORMCODE = mEXAMFORMCODE;

		}

    public System.String SUBJECTCONTENTCODE
    {
        get { return _SUBJECTCONTENTCODE; }
        set { _SUBJECTCONTENTCODE = value; }
    }

    public System.String EXAMTIMECODE
    {
        get { return _EXAMTIMECODE; }
        set { _EXAMTIMECODE = value; }
    }

    public System.String QUESTIONUSECODE
    {
        get { return _QUESTIONUSECODE; }
        set { _QUESTIONUSECODE = value; }
    }

    public System.String EXAMFORMCODE
    {
        get { return _EXAMFORMCODE; }
        set { _EXAMFORMCODE = value; }
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
		if (this.SUBJECTCONTENTCODE != that.SUBJECTCONTENTCODE) return false;
		if (this.EXAMTIMECODE != that.EXAMTIMECODE) return false;
		if (this.QUESTIONUSECODE != that.QUESTIONUSECODE) return false;
		if (this.EXAMFORMCODE != that.EXAMFORMCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return SUBJECTCONTENTCODE.GetHashCode() ^ EXAMTIMECODE.GetHashCode() ^ QUESTIONUSECODE.GetHashCode() ^ EXAMFORMCODE.GetHashCode();
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

	public SUBJECTCONTENTTEST_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public SUBJECTCONTENTTEST_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("SUBJECTCONTENTCODE",10,"VARCHAR",0)
,new fieldInfo("EXAMTIMECODE",10,"VARCHAR",0)
,new fieldInfo("QUESTIONUSECODE",10,"VARCHAR",0)
,new fieldInfo("NOTE",4000,"NVARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("LANG",10,"VARCHAR",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("NAME",500,"NVARCHAR",0)
,new fieldInfo("EXAMFORMCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return null; 
		} 
	}
	 [tablereference("SUBJECTCONTENT", "CODE", "SUBJECTCONTENTCODE")]
   public SUBJECTCONTENT_OBJ _SUBJECTCONTENTCODE;
 [tablereference("EXAMTIME", "CODE", "EXAMTIMECODE")]
   public EXAMTIME_OBJ _EXAMTIMECODE;
 [tablereference("QUESTIONUSE", "CODE", "QUESTIONUSECODE")]
   public QUESTIONUSE_OBJ _QUESTIONUSECODE;

    public virtual System.String SUBJECTCONTENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String EXAMTIMECODE
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONUSECODE
    {
        get ;
        set ;
    }
    public virtual System.String NOTE
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
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String LANG
    {
        get ;
        set ;
    }
    public virtual System.Int32 THEORDER
    {
        get ;
        set ;
    }
    public virtual System.String NAME
    {
        get ;
        set ;
    }
    public virtual System.String EXAMFORMCODE
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

