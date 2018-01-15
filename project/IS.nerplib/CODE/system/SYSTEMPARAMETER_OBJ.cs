using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class SYSTEMPARAMETER_OBJ: BusinessObject<SYSTEMPARAMETER_OBJ.BusinessObjectID>
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

	public SYSTEMPARAMETER_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public SYSTEMPARAMETER_OBJ(BusinessObjectID id)
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
,new fieldInfo("CODEVIEW",50,"VARCHAR",0)
,new fieldInfo("NAME",200,"NVARCHAR",0)
,new fieldInfo("NOTE",1000,"NVARCHAR",0)
,new fieldInfo("VALUE",500,"NVARCHAR",0)
,new fieldInfo("THETYPE",100,"NVARCHAR",0)
,new fieldInfo("ACTIVE",0,"INT",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("LANGUAGECODE",10,"VARCHAR",0)

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
    [Display(Name="Giá trị")]
    public virtual System.String VALUE
    {
        get ;
        set ;
    }
    [Display(Name="Kiểu")]
    public virtual System.String THETYPE
    {
        get ;
        set ;
    }
    [Display(Name="Cho phép nhập")]
    public virtual System.Int32 ACTIVE
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
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String LANGUAGECODE
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
