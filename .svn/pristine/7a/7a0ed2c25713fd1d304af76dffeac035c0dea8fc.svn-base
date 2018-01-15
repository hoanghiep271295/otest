using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
namespace IS.uni{
public class CONTENTGROUP_OBJ: BusinessObject<CONTENTGROUP_OBJ.BusinessObjectID>
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
	protected string _codeP= "O{SHORD}{CCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

	private System.String _CODE;
	private System.String _CODEVIEW;
	private System.String _NAME;
	private System.String _NOTE;
	private System.String _EDITUSER;
	private System.DateTime _EDITTIME;
	private System.Int16 _LOCK;
	private System.DateTime _LOCKDATE;
	private System.String _EDUCATIONLEVELCODE;
	private System.String _SUBJECTCODE;
	private System.Decimal _MARK;
	private System.Int32 _QUESTIONTYPELINK;
	private System.Int32 _THEORDER;

	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public CONTENTGROUP_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public CONTENTGROUP_OBJ(BusinessObjectID id)
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
,new fieldInfo("NAME",1000,"NVARCHAR",0)
,new fieldInfo("NOTE",1000,"NVARCHAR",0)
,new fieldInfo("EDITUSER",20,"VARCHAR",0)
,new fieldInfo("EDITTIME",0,"DATETIME",0)
,new fieldInfo("LOCK",0,"SMALLINT",0)
,new fieldInfo("LOCKDATE",0,"DATETIME",0)
,new fieldInfo("EDUCATIONLEVELCODE",10,"VARCHAR",0)
,new fieldInfo("SUBJECTCODE",10,"VARCHAR",0)
,new fieldInfo("MARK",0,"DECIMAL",0)
,new fieldInfo("QUESTIONTYPELINK",0,"INT",0)
,new fieldInfo("THEORDER",0,"INT",0)

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
        get { return _CODE; }
        set { _CODE = value; }
    }
    public virtual System.String CODEVIEW
    {
        get { return _CODEVIEW; }
        set { _CODEVIEW = value; }
    }
    public virtual System.String NAME
    {
        get { return _NAME; }
        set { _NAME = value; }
    }
    public virtual System.String NOTE
    {
        get { return _NOTE; }
        set { _NOTE = value; }
    }
    public virtual System.String EDITUSER
    {
        get { return _EDITUSER; }
        set { _EDITUSER = value; }
    }
    public virtual System.DateTime EDITTIME
    {
        get { return _EDITTIME; }
        set { _EDITTIME = value; }
    }
    public virtual System.Int16 LOCK
    {
        get { return _LOCK; }
        set { _LOCK = value; }
    }
    public virtual System.DateTime LOCKDATE
    {
        get { return _LOCKDATE; }
        set { _LOCKDATE = value; }
    }
    public virtual System.String EDUCATIONLEVELCODE
    {
        get { return _EDUCATIONLEVELCODE; }
        set { _EDUCATIONLEVELCODE = value; }
    }
    public virtual System.String SUBJECTCODE
    {
        get { return _SUBJECTCODE; }
        set { _SUBJECTCODE = value; }
    }
    public virtual System.Decimal MARK
    {
        get { return _MARK; }
        set { _MARK = value; }
    }
    public virtual System.Int32 QUESTIONTYPELINK
    {
        get { return _QUESTIONTYPELINK; }
        set { _QUESTIONTYPELINK = value; }
    }
    public virtual System.Int32 THEORDER
    {
        get { return _THEORDER; }
        set { _THEORDER = value; }
    }


	public override int GetHashCode()
	{
		return _ID.GetHashCode();
	}

}
}

