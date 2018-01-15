using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class LEVELTITLE_OBJ: BusinessObject<LEVELTITLE_OBJ.BusinessObjectID>
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

	public LEVELTITLE_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public LEVELTITLE_OBJ(BusinessObjectID id)
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
,new fieldInfo("COMPARELEVEL",0,"INT",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("EDUREDUCERATE",0,"INT",0)
,new fieldInfo("RESEARCHREDUCERATE",0,"INT",0)
,new fieldInfo("EDUDUTY",0,"INT",0)
,new fieldInfo("RESEARCHDUTY",0,"INT",0)
,new fieldInfo("MAN",0,"INT",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("EDUDUTY1",0,"INT",0)
,new fieldInfo("RESEARCHDUTY1",0,"INT",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    [Display(Name="Mã")]
    public virtual System.String CODEVIEW
    {
        get ;
        set ;
    }
    [Display(Name="Tên")]
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
    [Display(Name="Mức so sánh")]
    public virtual System.Int32 COMPARELEVEL
    {
        get ;
        set ;
    }
    [Display(Name="Thứ tự hiển thị")]
    public virtual System.Int32 THEORDER
    {
        get ;
        set ;
    }
    public virtual System.Int32 EDUREDUCERATE
    {
        get ;
        set ;
    }
    public virtual System.Int32 RESEARCHREDUCERATE
    {
        get ;
        set ;
    }
    public virtual System.Int32 EDUDUTY
    {
        get ;
        set ;
    }
    public virtual System.Int32 RESEARCHDUTY
    {
        get ;
        set ;
    }
    [Display(Name="Là quản lý")]
    public virtual System.Int32 MAN
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.Int32 EDUDUTY1
    {
        get ;
        set ;
    }
    public virtual System.Int32 RESEARCHDUTY1
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

