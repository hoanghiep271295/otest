using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class MARKDETAIL_OBJ: BusinessObject<MARKDETAIL_OBJ.BusinessObjectID>
{
	[Serializable]
	public class BusinessObjectID
	{
		public BusinessObjectID() { }
	private System.String _TESTGROUPDETAILCODE;
	private System.String _MARKCODE;

		public BusinessObjectID(System.String mTESTGROUPDETAILCODE,System.String mMARKCODE)
		{
		_TESTGROUPDETAILCODE = mTESTGROUPDETAILCODE;
		_MARKCODE = mMARKCODE;

		}

    public System.String TESTGROUPDETAILCODE
    {
        get { return _TESTGROUPDETAILCODE; }
        set { _TESTGROUPDETAILCODE = value; }
    }

    public System.String MARKCODE
    {
        get { return _MARKCODE; }
        set { _MARKCODE = value; }
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
		if (this.TESTGROUPDETAILCODE != that.TESTGROUPDETAILCODE) return false;
		if (this.MARKCODE != that.MARKCODE) return false;

				return true;
			}

		}


		public override int GetHashCode()
		{
			return TESTGROUPDETAILCODE.GetHashCode() ^ MARKCODE.GetHashCode();
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

	public MARKDETAIL_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public MARKDETAIL_OBJ(BusinessObjectID id)
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
,new fieldInfo("STUDENTCODE",10,"VARCHAR",0)
,new fieldInfo("COURSECODE",10,"VARCHAR",0)
,new fieldInfo("MARKTYPECODE",10,"VARCHAR",0)
,new fieldInfo("TESTGROUPCODE",10,"VARCHAR",0)
,new fieldInfo("FACTORGROUPCODE",10,"VARCHAR",0)
,new fieldInfo("TESTGROUPDETAILCODE",10,"VARCHAR",0)
,new fieldInfo("FACTOR",0,"FLOAT",0)
,new fieldInfo("MARK",4,"VARCHAR",0)
,new fieldInfo("MARKNUMBER",0,"FLOAT",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("MARKCODE",10,"VARCHAR",0)
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
	 [tablereference("MARKTYPE", "CODE", "MARKTYPECODE")]
   public MARKTYPE_OBJ _MARKTYPECODE;
 [tablereference("STUDENT", "CODE", "STUDENTCODE")]
   public STUDENT_OBJ _STUDENTCODE;
 [tablereference("COURSE", "CODE", "COURSECODE")]
   public COURSE_OBJ _COURSECODE;
 [tablereference("TESTGROUP", "CODE", "TESTGROUPCODE")]
   public TESTGROUP_OBJ _TESTGROUPCODE;
 [tablereference("TESTGROUPDETAIL", "CODE", "TESTGROUPDETAILCODE")]
   public TESTGROUPDETAIL_OBJ _TESTGROUPDETAILCODE;
 [tablereference("MARK", "CODE", "MARKCODE")]
   public MARK_OBJ _MARKCODE;

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
    public virtual System.String STUDENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String COURSECODE
    {
        get ;
        set ;
    }
    public virtual System.String MARKTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String TESTGROUPCODE
    {
        get ;
        set ;
    }
    public virtual System.String FACTORGROUPCODE
    {
        get ;
        set ;
    }
    public virtual System.String TESTGROUPDETAILCODE
    {
        get ;
        set ;
    }
    public virtual System.Double FACTOR
    {
        get ;
        set ;
    }
    public virtual System.String MARK
    {
        get ;
        set ;
    }
    public virtual System.Double MARKNUMBER
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.String MARKCODE
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

