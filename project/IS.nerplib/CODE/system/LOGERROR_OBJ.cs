using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class LOGERROR_OBJ: BusinessObject<LOGERROR_OBJ.BusinessObjectID>
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
	protected string _codeP="{yyyyMMdd}{CCCCCCCCCCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public LOGERROR_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public LOGERROR_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("CODE",20,"VARCHAR",0)
,new fieldInfo("STAFFCODE",10,"VARCHAR",0)
,new fieldInfo("STAFFNAME",100,"NVARCHAR",0)
,new fieldInfo("CREATETIME",0,"DATETIME",0)
,new fieldInfo("TABLENAME",100,"NVARCHAR",0)
,new fieldInfo("ACTION",10,"VARCHAR",0)
,new fieldInfo("RECORDCODE",50,"VARCHAR",0)
,new fieldInfo("NOTE",1000,"NVARCHAR",0)
,new fieldInfo("IP",64,"VARCHAR",0)
,new fieldInfo("COMPUTERNAME",100,"NVARCHAR",0)
,new fieldInfo("WEBBROWSER",100,"NVARCHAR",0)
,new fieldInfo("ENDTIME",0,"DATETIME",0)
,new fieldInfo("OS",500,"NVARCHAR",0)
,new fieldInfo("SESSIONCODE",20,"VARCHAR",0)
,new fieldInfo("URLSHORT",1000,"NVARCHAR",0)
,new fieldInfo("URLNAME",1000,"NVARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("MES",4000,"NVARCHAR",0)
,new fieldInfo("FUNC",200,"NVARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",20,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("STAFF", "CODE", "STAFFCODE")]
   public STAFF_OBJ _STAFFCODE;
 [tablereference("LOGME", "CODE", "SESSIONCODE")]
   public LOGME_OBJ _SESSIONCODE;

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    [Display(Name="Nhân viên")]
    public virtual System.String STAFFCODE
    {
        get ;
        set ;
    }
    [Display(Name="Tên nhân viên")]
    public virtual System.String STAFFNAME
    {
        get ;
        set ;
    }
    public virtual System.DateTime CREATETIME
    {
        get ;
        set ;
    }
    [Display(Name="Thực hiện trên")]
    public virtual System.String TABLENAME
    {
        get ;
        set ;
    }
    [Display(Name="Hành động")]
    public virtual System.String ACTION
    {
        get ;
        set ;
    }
    public virtual System.String RECORDCODE
    {
        get ;
        set ;
    }
    public virtual System.String NOTE
    {
        get ;
        set ;
    }
    public virtual System.String IP
    {
        get ;
        set ;
    }
    public virtual System.String COMPUTERNAME
    {
        get ;
        set ;
    }
    public virtual System.String WEBBROWSER
    {
        get ;
        set ;
    }
    public virtual System.DateTime ENDTIME
    {
        get ;
        set ;
    }
    public virtual System.String OS
    {
        get ;
        set ;
    }
    public virtual System.String SESSIONCODE
    {
        get ;
        set ;
    }
    public virtual System.String URLSHORT
    {
        get ;
        set ;
    }
    public virtual System.String URLNAME
    {
        get ;
        set ;
    }
    public virtual System.String UNIVERSITYCODE
    {
        get ;
        set ;
    }
    public virtual System.String MES
    {
        get ;
        set ;
    }
    public virtual System.String FUNC
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

