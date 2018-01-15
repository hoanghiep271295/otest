using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class PRIORITY_OBJ: BusinessObject<PRIORITY_OBJ.BusinessObjectID>
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
	protected string _codeP="{yyyyMMdd}{CCCCCCCCCCCCCCCCCCCCCCCCCCCCCCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public PRIORITY_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public PRIORITY_OBJ(BusinessObjectID id)
	{
		base._ID = new BusinessObjectID();
		base._ID = id;
	}
	protected override fieldInfo[] _fields
	{
		get
		{
			return new fieldInfo[]{
                               new fieldInfo("CODE",40,"NVARCHAR",0)
,new fieldInfo("DESCRIPTION",800,"NVARCHAR",0)
,new fieldInfo("SHOWAUTH",0,"INT",0)
,new fieldInfo("NAME",100,"NVARCHAR",0)
,new fieldInfo("LOCK",0,"INT",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("GROUPCODE",10,"VARCHAR",0)
,new fieldInfo("SYSCOMPONENTCODE",10,"VARCHAR",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)

                               }; ;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",40,"NVARCHAR",0)
 }; 
		} 
	}
	

    public virtual System.String CODE
    {
        get ;
        set ;
    }
    public virtual System.String DESCRIPTION
    {
        get ;
        set ;
    }
    public virtual System.Int32 SHOWAUTH
    {
        get ;
        set ;
    }
    public virtual System.String NAME
    {
        get ;
        set ;
    }
    public virtual System.Int32 LOCK
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.String GROUPCODE
    {
        get ;
        set ;
    }
    public virtual System.String SYSCOMPONENTCODE
    {
        get ;
        set ;
    }
        public virtual System.String UNIVERSITYCODE
        {
            get;
            set;
        }


        public override int GetHashCode()
	{
		return _ID.GetHashCode();
	}

}
}

