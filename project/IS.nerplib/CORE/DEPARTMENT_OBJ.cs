using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class DEPARTMENT_OBJ: BusinessObject<DEPARTMENT_OBJ.BusinessObjectID>
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

	public DEPARTMENT_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public DEPARTMENT_OBJ(BusinessObjectID id)
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
,new fieldInfo("PARENTCODE",10,"VARCHAR",0)
,new fieldInfo("COMPARELEVEL",0,"INT",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("PHONE",50,"NVARCHAR",0)
,new fieldInfo("EMAIL",100,"NVARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("AMOUNT",0,"INT",0)
,new fieldInfo("DESCRIPTION",4000,"NVARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("ORIGINALCODE",10,"VARCHAR",0)
,new fieldInfo("EXTENSIONCODE",120,"VARCHAR",0)
,new fieldInfo("LEVELEXTENSION",0,"INT",0)
,new fieldInfo("MANAGELEVELCODE",10,"VARCHAR",0)
,new fieldInfo("ADDRESS",1000,"NVARCHAR",0)
,new fieldInfo("REGIONCODE",10,"VARCHAR",0)
,new fieldInfo("FOUNDEDDATE",0,"DATETIME",0)
,new fieldInfo("FOUNDEDDATESHOW",20,"VARCHAR",0)
,new fieldInfo("SYSCOMPONENTCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("MANAGELEVEL", "CODE", "MANAGELEVELCODE")]
   public MANAGELEVEL_OBJ _MANAGELEVELCODE;
 [tablereference("DEPARTMENT", "CODE", "PARENTCODE")]
   public DEPARTMENT_OBJ _PARENTCODE;
        [tablereference("REGION", "CODE", "REGIONCODE")]
        public REGION_OBJ _REGIONCODE;

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
    [Display(Name="Đơn vị cấp trên")]
    public virtual System.String PARENTCODE
    {
        get ;
        set ;
    }
    [Display(Name="Cấp so sánh")]
    public virtual System.Int32 COMPARELEVEL
    {
        get ;
        set ;
    }
    [Display(Name="Thứ tự")]
    public virtual System.Int32 THEORDER
    {
        get ;
        set ;
    }
    [Display(Name="Điện thoại")]
    public virtual System.String PHONE
    {
        get ;
        set ;
    }
    [Display(Name="email")]
    public virtual System.String EMAIL
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.Int32 AMOUNT
    {
        get ;
        set ;
    }
    public virtual System.String DESCRIPTION
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String ORIGINALCODE
    {
        get ;
        set ;
    }
    public virtual System.String EXTENSIONCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 LEVELEXTENSION
    {
        get ;
        set ;
    }
    public virtual System.String MANAGELEVELCODE
    {
        get ;
        set ;
    }
    public virtual System.String ADDRESS
    {
        get ;
        set ;
    }
    public virtual System.String REGIONCODE
    {
        get ;
        set ;
    }
    public virtual System.DateTime FOUNDEDDATE
    {
        get ;
        set ;
    }
    public virtual System.String FOUNDEDDATESHOW
    {
        get ;
        set ;
    }
    public virtual System.String SYSCOMPONENTCODE
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

