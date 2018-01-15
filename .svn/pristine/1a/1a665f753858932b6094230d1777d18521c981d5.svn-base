using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class STUDENTREWARDTYPE_OBJ: BusinessObject<STUDENTREWARDTYPE_OBJ.BusinessObjectID>
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

	public STUDENTREWARDTYPE_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public STUDENTREWARDTYPE_OBJ(BusinessObjectID id)
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
,new fieldInfo("CODEVIEW",20,"NVARCHAR",0)
,new fieldInfo("NAME",1000,"NVARCHAR",0)
,new fieldInfo("RESEARCHPOINT",0,"DECIMAL",0)
,new fieldInfo("RESEARCHSUPPORT",0,"DECIMAL",0)
,new fieldInfo("EDUPOINT",0,"DECIMAL",0)
,new fieldInfo("EDUSUPPORT",0,"DECIMAL",0)
,new fieldInfo("NOTE",200,"NVARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("COMPARELEVEL",0,"INT",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("GENLEVELCODE",10,"VARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("UNIT",0,"FLOAT",0)
,new fieldInfo("UNITNAME",100,"NVARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("STUDENTREWARDLEVEL", "CODE", "GENLEVELCODE")]
   public STUDENTREWARDLEVEL_OBJ _GENLEVELCODE;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    public virtual System.String CODEVIEW
    {
        get ;
        set ;
    }
    public virtual System.String NAME
    {
        get ;
        set ;
    }
    public virtual System.Decimal RESEARCHPOINT
    {
        get ;
        set ;
    }
    public virtual System.Decimal RESEARCHSUPPORT
    {
        get ;
        set ;
    }
    public virtual System.Decimal EDUPOINT
    {
        get ;
        set ;
    }
    public virtual System.Decimal EDUSUPPORT
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
    public virtual System.Int32 COMPARELEVEL
    {
        get ;
        set ;
    }
    public virtual System.Int32 THEORDER
    {
        get ;
        set ;
    }
    public virtual System.String GENLEVELCODE
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.Double UNIT
    {
        get ;
        set ;
    }
    public virtual System.String UNITNAME
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
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

