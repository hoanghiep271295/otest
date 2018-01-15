using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class EXAMHALLSTUDENT_OBJ: BusinessObject<EXAMHALLSTUDENT_OBJ.BusinessObjectID>
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

	public EXAMHALLSTUDENT_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public EXAMHALLSTUDENT_OBJ(BusinessObjectID id)
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
,new fieldInfo("EXAMHALLCODE",10,"VARCHAR",0)
,new fieldInfo("MARKCODE",10,"VARCHAR",0)
,new fieldInfo("RECODE",20,"NVARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("STATUS",0,"INT",0)
,new fieldInfo("NOTE",1000,"NVARCHAR",0)
,new fieldInfo("EXAMTIMECODE",10,"VARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("REALBEGINTIME",0,"DATETIME",0)
,new fieldInfo("REALENDTIME",0,"DATETIME",0)
,new fieldInfo("FINALENDTIME",0,"DATETIME",0)
,new fieldInfo("REPORTTIME",0,"DATETIME",0)
,new fieldInfo("FINISHTIME",0,"DATETIME",0)
,new fieldInfo("STARTED",0,"INT",0)
,new fieldInfo("STARTEDTIME",0,"DATETIME",0)
,new fieldInfo("EXAMSESSION",64,"VARCHAR",0)
,new fieldInfo("EXAMFORMCODE",10,"VARCHAR",0)
,new fieldInfo("FINALMARK",0,"FLOAT",0)
,new fieldInfo("COURSECODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("EXAMHALL", "CODE", "EXAMHALLCODE")]
   public EXAMHALL_OBJ _EXAMHALLCODE;
 [tablereference("MARK", "CODE", "MARKCODE")]
   public MARK_OBJ _MARKCODE;
 [tablereference("EXAMTIME", "CODE", "EXAMTIMECODE")]
   public EXAMTIME_OBJ _EXAMTIMECODE;
 [tablereference("EXAMFORM", "CODE", "EXAMFORMCODE")]
   public EXAMFORM_OBJ _EXAMFORMCODE;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    [Display(Name="Phòng thi")]
    public virtual System.String EXAMHALLCODE
    {
        get ;
        set ;
    }
    [Display(Name="Bảng điểm")]
    public virtual System.String MARKCODE
    {
        get ;
        set ;
    }
    public virtual System.String RECODE
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
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    [Display(Name="Tình trạng")]
    public virtual System.Int32 STATUS
    {
        get ;
        set ;
    }
    public virtual System.String NOTE
    {
        get ;
        set ;
    }
    [Display(Name="Đợt thi")]
    public virtual System.String EXAMTIMECODE
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.DateTime REALBEGINTIME
    {
        get ;
        set ;
    }
    public virtual System.DateTime REALENDTIME
    {
        get ;
        set ;
    }
    public virtual System.DateTime FINALENDTIME
    {
        get ;
        set ;
    }
    public virtual System.DateTime REPORTTIME
    {
        get ;
        set ;
    }
    public virtual System.DateTime FINISHTIME
    {
        get ;
        set ;
    }
    public virtual System.Int32 STARTED
    {
        get ;
        set ;
    }
    public virtual System.DateTime STARTEDTIME
    {
        get ;
        set ;
    }
    public virtual System.String EXAMSESSION
    {
        get ;
        set ;
    }
    public virtual System.String EXAMFORMCODE
    {
        get ;
        set ;
    }
    public virtual System.Double FINALMARK
    {
        get ;
        set ;
    }
    public virtual System.String COURSECODE
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

