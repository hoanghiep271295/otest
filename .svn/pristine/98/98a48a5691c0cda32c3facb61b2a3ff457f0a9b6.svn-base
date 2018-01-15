using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class EXAMHALL_OBJ: BusinessObject<EXAMHALL_OBJ.BusinessObjectID>
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

	public EXAMHALL_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public EXAMHALL_OBJ(BusinessObjectID id)
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
,new fieldInfo("EXAMTIMECODE",10,"VARCHAR",0)
,new fieldInfo("HALLNUMBER",0,"INT",0)
,new fieldInfo("STAFFCODE1",10,"VARCHAR",0)
,new fieldInfo("STAFFCODE2",10,"VARCHAR",0)
,new fieldInfo("HALLCODE",10,"VARCHAR",0)
,new fieldInfo("MAXSTUDENT",0,"INT",0)
,new fieldInfo("STUDENTAMOUNT",0,"INT",0)
,new fieldInfo("EXAMSTUDENTAMOUNT",0,"INT",0)
,new fieldInfo("PAPERAMOUNT",0,"INT",0)
,new fieldInfo("BAGGROUP",0,"INT",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("BEGINTIME",0,"DATETIME",0)
,new fieldInfo("ENDTIME",0,"DATETIME",0)
,new fieldInfo("LASTTIME",0,"INT",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("EXAMTIME", "CODE", "EXAMTIMECODE")]
   public EXAMTIME_OBJ _EXAMTIMECODE;
 [tablereference("STAFF", "CODE", "STAFFCODE1")]
   public STAFF_OBJ _STAFFCODE1;
 [tablereference("STAFF", "CODE", "STAFFCODE2")]
   public STAFF_OBJ _STAFFCODE2;
 [tablereference("HALL", "CODE", "HALLCODE")]
   public HALL_OBJ _HALLCODE;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    [Display(Name="Mã phòng thi")]
    public virtual System.String CODEVIEW
    {
        get ;
        set ;
    }
    [Display(Name="Tên phòn thi")]
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
    [Display(Name="Đợt thi")]
    public virtual System.String EXAMTIMECODE
    {
        get ;
        set ;
    }
    [Display(Name="Số phòng")]
    public virtual System.Int32 HALLNUMBER
    {
        get ;
        set ;
    }
    [Display(Name="Giáo viên 1")]
    public virtual System.String STAFFCODE1
    {
        get ;
        set ;
    }
    [Display(Name="Giáo viên 2")]
    public virtual System.String STAFFCODE2
    {
        get ;
        set ;
    }
    [Display(Name="Phòng thi")]
    public virtual System.String HALLCODE
    {
        get ;
        set ;
    }
    [Display(Name="Số sinh viên tối đa")]
    public virtual System.Int32 MAXSTUDENT
    {
        get ;
        set ;
    }
    [Display(Name="Số sinh viên thực tế")]
    public virtual System.Int32 STUDENTAMOUNT
    {
        get ;
        set ;
    }
    [Display(Name="Số sinh viên đến thi")]
    public virtual System.Int32 EXAMSTUDENTAMOUNT
    {
        get ;
        set ;
    }
    [Display(Name="Số tồ giấy thi")]
    public virtual System.Int32 PAPERAMOUNT
    {
        get ;
        set ;
    }
    [Display(Name="Nhóm túi")]
    public virtual System.Int32 BAGGROUP
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    [Display(Name="Thời điểm bắt đầu thi")]
    public virtual System.DateTime BEGINTIME
    {
        get ;
        set ;
    }
    [Display(Name="Thời điểm nộp bài")]
    public virtual System.DateTime ENDTIME
    {
        get ;
        set ;
    }
    [Display(Name="Thời gian làm bài")]
    public virtual System.Int32 LASTTIME
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

