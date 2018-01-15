using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class TESTGROUPDETAIL_OBJ: BusinessObject<TESTGROUPDETAIL_OBJ.BusinessObjectID>
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

	public TESTGROUPDETAIL_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public TESTGROUPDETAIL_OBJ(BusinessObjectID id)
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
,new fieldInfo("MARKTYPECODE",10,"VARCHAR",0)
,new fieldInfo("FACTORGROUPCODE",10,"VARCHAR",0)
,new fieldInfo("FACTOR",0,"FLOAT",0)
,new fieldInfo("TESTGROUPCODE",10,"VARCHAR",0)
,new fieldInfo("MINMARK10",0,"FLOAT",0)
,new fieldInfo("MAXMARK10",0,"FLOAT",0)
,new fieldInfo("SCALETO",0,"FLOAT",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("LANG",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("MARKTYPE", "CODE", "MARKTYPECODE")]
   public MARKTYPE_OBJ _MARKTYPECODE;
 [tablereference("FACTORGROUP", "CODE", "FACTORGROUPCODE")]
   public FACTORGROUP_OBJ _FACTORGROUPCODE;
 [tablereference("TESTGROUP", "CODE", "TESTGROUPCODE")]
   public TESTGROUP_OBJ _TESTGROUPCODE;

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
    public virtual System.String MARKTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String FACTORGROUPCODE
    {
        get ;
        set ;
    }
    public virtual System.Double FACTOR
    {
        get ;
        set ;
    }
    public virtual System.String TESTGROUPCODE
    {
        get ;
        set ;
    }
    public virtual System.Double MINMARK10
    {
        get ;
        set ;
    }
    public virtual System.Double MAXMARK10
    {
        get ;
        set ;
    }
    public virtual System.Double SCALETO
    {
        get ;
        set ;
    }
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
    public virtual System.String LANG
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

