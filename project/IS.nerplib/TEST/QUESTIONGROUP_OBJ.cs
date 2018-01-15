using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class QUESTIONGROUP_OBJ: BusinessObject<QUESTIONGROUP_OBJ.BusinessObjectID>
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
	protected string _codeP= "G{SHORD}{CCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public QUESTIONGROUP_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public QUESTIONGROUP_OBJ(BusinessObjectID id)
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
,new fieldInfo("CONTENT",4000,"NVARCHAR",0)
,new fieldInfo("CONTENTIMG",200,"NVARCHAR",0)
,new fieldInfo("NUMBERCHILDREN",0,"INT",0)
,new fieldInfo("GROUPANSWER",0,"INT",0)
,new fieldInfo("ANSWERTEXT",4000,"NVARCHAR",0)
,new fieldInfo("ANSWERIMG",200,"NVARCHAR",0)
,new fieldInfo("SUBJECTCONTENTCODE",10,"VARCHAR",0)
,new fieldInfo("SUBJECTCODE",10,"VARCHAR",0)
,new fieldInfo("QUESTIONTYPECODE",10,"VARCHAR",0)
,new fieldInfo("QUESTIONUSECODELIST",100,"VARCHAR",0)
,new fieldInfo("MARK",0,"FLOAT",0)
,new fieldInfo("THEORDER",0,"INT",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)

                               }; ;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	 [tablereference("SUBJECTCONTENT", "CODE", "SUBJECTCONTENTCODE")]
   public SUBJECTCONTENT_OBJ _SUBJECTCONTENTCODE;
 [tablereference("SUBJECT", "CODE", "SUBJECTCODE")]
   public SUBJECT_OBJ _SUBJECTCODE;
 [tablereference("QUESTIONTYPE", "CODE", "QUESTIONTYPECODE")]
   public QUESTIONTYPE_OBJ _QUESTIONTYPECODE;

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
    public virtual System.String CONTENT
    {
        get ;
        set ;
    }
    public virtual System.String CONTENTIMG
    {
        get ;
        set ;
    }
    public virtual System.Int32 NUMBERCHILDREN
    {
        get ;
        set ;
    }
    public virtual System.Int32 GROUPANSWER
    {
        get ;
        set ;
    }
    public virtual System.String ANSWERTEXT
    {
        get ;
        set ;
    }
    public virtual System.String ANSWERIMG
    {
        get ;
        set ;
    }
    public virtual System.String SUBJECTCONTENTCODE
    {
        get ;
        set ;
    }
    public virtual System.String SUBJECTCODE
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONTYPECODE
    {
        get ;
        set ;
    }
    public virtual System.String QUESTIONUSECODELIST
    {
        get ;
        set ;
    }
        public virtual System.Double MARK
        {
            get;
            set;
        }
        public virtual System.Int32 THEORDER
        {
            get;
            set;
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

