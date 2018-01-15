using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class WAREHOUSE_OBJ: BusinessObject<WAREHOUSE_OBJ.BusinessObjectID>
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

	public WAREHOUSE_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public WAREHOUSE_OBJ(BusinessObjectID id)
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
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("WAREHOUSELEVELCODE",10,"VARCHAR",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("THETYPE",50,"VARCHAR",0)
,new fieldInfo("PROVINCECODOE",10,"VARCHAR",0)
,new fieldInfo("DISTRICTCODE",10,"VARCHAR",0)
,new fieldInfo("TOWNCODE",10,"VARCHAR",0)
,new fieldInfo("DEPARTMENTCODE",10,"VARCHAR",0)
,new fieldInfo("REGIONCODE",10,"VARCHAR",0)
,new fieldInfo("ADDRESS",1000,"NVARCHAR",0)
,new fieldInfo("PHONE",20,"VARCHAR",0)
,new fieldInfo("EMAIL",10,"VARCHAR",0)
,new fieldInfo("MAILCODE",20,"VARCHAR",0)
,new fieldInfo("STAFFCODE1",10,"VARCHAR",0)
,new fieldInfo("STAFFCODE2",10,"VARCHAR",0)
,new fieldInfo("PARENTCODE",10,"VARCHAR",0)

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
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.String WAREHOUSELEVELCODE
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
    public virtual System.String THETYPE
    {
        get ;
        set ;
    }
    public virtual System.String PROVINCECODOE
    {
        get ;
        set ;
    }
    public virtual System.String DISTRICTCODE
    {
        get ;
        set ;
    }
    public virtual System.String TOWNCODE
    {
        get ;
        set ;
    }
    public virtual System.String DEPARTMENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String REGIONCODE
    {
        get ;
        set ;
    }
    public virtual System.String ADDRESS
    {
        get ;
        set ;
    }
    public virtual System.String PHONE
    {
        get ;
        set ;
    }
    public virtual System.String EMAIL
    {
        get ;
        set ;
    }
    public virtual System.String MAILCODE
    {
        get ;
        set ;
    }
    public virtual System.String STAFFCODE1
    {
        get ;
        set ;
    }
    public virtual System.String STAFFCODE2
    {
        get ;
        set ;
    }
    public virtual System.String PARENTCODE
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

