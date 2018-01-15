using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class SYSMENU_OBJ: BusinessObject<SYSMENU_OBJ.BusinessObjectID>
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

	public SYSMENU_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public SYSMENU_OBJ(BusinessObjectID id)
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
,new fieldInfo("NOTE",4000,"NVARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("PARENTCODE",10,"VARCHAR",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("ICON",1000,"NVARCHAR",0)
,new fieldInfo("LINK",1000,"NVARCHAR",0)
,new fieldInfo("PRIORITYCODE",100,"NVARCHAR",0)
,new fieldInfo("THETYPE",10,"VARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("IMG",200,"NVARCHAR",0)
,new fieldInfo("IMGTITLE",500,"NVARCHAR",0)
,new fieldInfo("IMGNOTE",4000,"NVARCHAR",0)
,new fieldInfo("GLANCE",4000,"NVARCHAR",0)
,new fieldInfo("EXTENSIONCODE",200,"VARCHAR",0)
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
	 [tablereference("SYSMENU", "CODE", "PARENTCODE")]
   public SYSMENU_OBJ _PARENTCODE;

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
    public virtual System.String PARENTCODE
    {
        get ;
        set ;
    }
    public virtual System.Int32 THEORDER
    {
        get ;
        set ;
    }
    public virtual System.String ICON
    {
        get ;
        set ;
    }
    public virtual System.String LINK
    {
        get ;
        set ;
    }
    public virtual System.String PRIORITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String THETYPE
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String IMG
    {
        get ;
        set ;
    }
    public virtual System.String IMGTITLE
    {
        get ;
        set ;
    }
    public virtual System.String IMGNOTE
    {
        get ;
        set ;
    }
    public virtual System.String GLANCE
    {
        get ;
        set ;
    }
    public virtual System.String EXTENSIONCODE
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

