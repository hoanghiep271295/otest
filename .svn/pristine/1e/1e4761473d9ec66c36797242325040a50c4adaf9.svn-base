using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class EQUIPMENT_OBJ: BusinessObject<EQUIPMENT_OBJ.BusinessObjectID>
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

	public EQUIPMENT_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public EQUIPMENT_OBJ(BusinessObjectID id)
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
,new fieldInfo("NOTE",1000,"NVARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("EQUIPMENTTYPECODE",10,"VARCHAR",0)
,new fieldInfo("EQUIPMENTLEVELCODE",10,"VARCHAR",0)
,new fieldInfo("EQUIPMENTGROUPCODE",10,"VARCHAR",0)
,new fieldInfo("EQUIPMENTFIELDCODE",10,"VARCHAR",0)
,new fieldInfo("QUANTITYCODE",10,"VARCHAR",0)
,new fieldInfo("SUPPLIERCODE",10,"VARCHAR",0)
,new fieldInfo("NATIONCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("EQUIPMENTTYPE", "CODE", "EQUIPMENTTYPECODE")]
   public EQUIPMENTTYPE_OBJ _EQUIPMENTTYPECODE;
 [tablereference("EQUIPMENTLEVEL", "CODE", "EQUIPMENTLEVELCODE")]
   public EQUIPMENTLEVEL_OBJ _EQUIPMENTLEVELCODE;
 [tablereference("EQUIPMENTGROUP", "CODE", "EQUIPMENTGROUPCODE")]
   public EQUIPMENTGROUP_OBJ _EQUIPMENTGROUPCODE;
 [tablereference("EQUIPMENTFIELD", "CODE", "EQUIPMENTFIELDCODE")]
   public EQUIPMENTFIELD_OBJ _EQUIPMENTFIELDCODE;
 [tablereference("QUANTITY", "CODE", "QUANTITYCODE")]
   public QUANTITY_OBJ _QUANTITYCODE;

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
    public virtual System.String EQUIPMENTTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String EQUIPMENTLEVELCODE
    {
        get ;
        set ;
    }
    public virtual System.String EQUIPMENTGROUPCODE
    {
        get ;
        set ;
    }
    public virtual System.String EQUIPMENTFIELDCODE
    {
        get ;
        set ;
    }
    public virtual System.String QUANTITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String SUPPLIERCODE
    {
        get ;
        set ;
    }
    public virtual System.String NATIONCODE
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

