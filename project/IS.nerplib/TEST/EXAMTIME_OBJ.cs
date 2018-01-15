using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class EXAMTIME_OBJ: BusinessObject<EXAMTIME_OBJ.BusinessObjectID>
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

	public EXAMTIME_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public EXAMTIME_OBJ(BusinessObjectID id)
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
,new fieldInfo("NOTE",200,"NVARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("STAFFCODE",10,"VARCHAR",0)
,new fieldInfo("EDUCATIONLEVELCODE",10,"VARCHAR",0)
,new fieldInfo("SUBJECTCODE",10,"VARCHAR",0)
,new fieldInfo("YEAR",0,"INT",0)
,new fieldInfo("TERM",0,"SMALLINT",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("STUDENTAMOUNTHALL",0,"INT",0)
,new fieldInfo("STUDENTINBAG",0,"INT",0)
,new fieldInfo("RECODEFORMAT",60,"NVARCHAR",0)
,new fieldInfo("MAPPING",0,"INT",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("TESTCOUNT",0,"INT",0)
,new fieldInfo("MAXSTUDENTPERTEST",0,"INT",0)
,new fieldInfo("QUESTIONUSE",10,"VARCHAR",0)
,new fieldInfo("TESTSTRUCTCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("STAFF", "CODE", "STAFFCODE")]
   public STAFF_OBJ _STAFFCODE;
 [tablereference("EDUCATIONLEVEL", "CODE", "EDUCATIONLEVELCODE")]
   public EDUCATIONLEVEL_OBJ _EDUCATIONLEVELCODE;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    [Display(Name="Mã đợt kiểm tra")]
    public virtual System.String CODEVIEW
    {
        get ;
        set ;
    }
    [Display(Name="Tên đợt kiểm tra")]
    public virtual System.String NAME
    {
        get ;
        set ;
    }
    [Display(Name="Ghi chú")]
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
    [Display(Name="Người phục trách")]
    public virtual System.String STAFFCODE
    {
        get ;
        set ;
    }
    [Display(Name="Cấp học")]
    public virtual System.String EDUCATIONLEVELCODE
    {
        get ;
        set ;
    }
    [Display(Name="Môn học")]
    public virtual System.String SUBJECTCODE
    {
        get ;
        set ;
    }
    [Display(Name="Năm học")]
    public virtual System.Int32 YEAR
    {
        get ;
        set ;
    }
    [Display(Name="Học kỳ")]
    public virtual System.Int16 TERM
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    [Display(Name="Số sinh viên/phòng")]
    public virtual System.Int32 STUDENTAMOUNTHALL
    {
        get ;
        set ;
    }
    [Display(Name="Số sinh viên/túi")]
    public virtual System.Int32 STUDENTINBAG
    {
        get ;
        set ;
    }
    [Display(Name="Định dạng SBD")]
    public virtual System.String RECODEFORMAT
    {
        get ;
        set ;
    }
    public virtual System.Int32 MAPPING
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 TESTCOUNT
    {
        get ;
        set ;
    }
    public virtual System.Int32 MAXSTUDENTPERTEST
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONUSE
    {
        get ;
        set ;
    }
    public virtual System.String TESTSTRUCTCODE
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

