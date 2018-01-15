using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IS.fitframework;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
namespace IS.uni{
public class STUDENT_OBJ: BusinessObject<STUDENT_OBJ.BusinessObjectID>
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
	protected string _codeP="S{SHORD}{CCCC}";
	protected override string _codePattern
	{
		get { return _codeP; }
		set { _codeP = value; }
	}

//##fieldList##
	public static System.String pre() { return "PRE"; }
	public static System.String suf() { return "SUF"; }

	public STUDENT_OBJ()
	{
		base._ID = new BusinessObjectID();
	}

	public STUDENT_OBJ(BusinessObjectID id)
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
,new fieldInfo("BIRTHDAY",0,"DATETIME",0)
,new fieldInfo("SEX",0,"SMALLINT",0)
,new fieldInfo("PHOTO",200,"NVARCHAR",0)
,new fieldInfo("PROVINCECODE",10,"VARCHAR",0)
,new fieldInfo("DISTRICTCODE",10,"VARCHAR",0)
,new fieldInfo("TOWNCODE",10,"VARCHAR",0)
,new fieldInfo("TEL",20,"VARCHAR",0)
,new fieldInfo("ETHNICCODE",10,"VARCHAR",0)
,new fieldInfo("RELIGIONCODE",10,"VARCHAR",0)
,new fieldInfo("PRIORITYREGIONCODE",10,"VARCHAR",0)
,new fieldInfo("PRIORITYPOLICYCODE",10,"VARCHAR",0)
,new fieldInfo("ISSUECODE",10,"VARCHAR",0)
,new fieldInfo("MARK",0,"FLOAT",0)
,new fieldInfo("MARK1",0,"FLOAT",0)
,new fieldInfo("MARK2",0,"FLOAT",0)
,new fieldInfo("MARK3",0,"FLOAT",0)
,new fieldInfo("MARK4",0,"FLOAT",0)
,new fieldInfo("MARK5",0,"FLOAT",0)
,new fieldInfo("BONUSMARK",0,"FLOAT",0)
,new fieldInfo("ENROLLREASON",100,"NVARCHAR",0)
,new fieldInfo("XLHTTHPT",20,"NVARCHAR",0)
,new fieldInfo("XLHKTHPT",20,"NVARCHAR",0)
,new fieldInfo("XLTNTHPT",20,"NVARCHAR",0)
,new fieldInfo("YOUTHDATE",0,"DATETIME",0)
,new fieldInfo("PARTYDATE",0,"DATETIME",0)
,new fieldInfo("HIGHSCHOOLYEAR",0,"INT",0)
,new fieldInfo("IDNUMBER",20,"VARCHAR",0)
,new fieldInfo("IDDATE",0,"DATETIME",0)
,new fieldInfo("IDPROVINCE",100,"NVARCHAR",0)
,new fieldInfo("DOCCODE",20,"VARCHAR",0)
,new fieldInfo("STUDENTID",20,"VARCHAR",0)
,new fieldInfo("STUDENTIDDATE",20,"VARCHAR",0)
,new fieldInfo("HOMETOWN",200,"NVARCHAR",0)
,new fieldInfo("ADDRESS",200,"NVARCHAR",0)
,new fieldInfo("REWARD",200,"NVARCHAR",0)
,new fieldInfo("HISTORYNOTE",200,"NVARCHAR",0)
,new fieldInfo("BIRTHCERTIFICATE",0,"BIT",0)
,new fieldInfo("HIGHSCHOOLDEGREE",0,"BIT",0)
,new fieldInfo("INVITEDDOC",0,"BIT",0)
,new fieldInfo("HIGHSCHOOLCERTIFICATE",0,"BIT",0)
,new fieldInfo("ARMYDUTY",0,"BIT",0)
,new fieldInfo("CLASSCODE",10,"VARCHAR",0)
,new fieldInfo("GRADECODE",10,"VARCHAR",0)
,new fieldInfo("EDUCATIONFIELDCODE",10,"VARCHAR",0)
,new fieldInfo("USERPASSWORD",64,"VARCHAR",0)
,new fieldInfo("CHANGEPASS",0,"INT",0)
,new fieldInfo("STUDENTRANKCODE",10,"VARCHAR",0)
,new fieldInfo("STUDENTLEVELTITLE",10,"VARCHAR",0)
,new fieldInfo("DISABLEPERSON",0,"INT",0)
,new fieldInfo("STUDENTSTATUS",0,"INT",0)
,new fieldInfo("STUDENTLEVELTITLECODE",10,"VARCHAR",0)
,new fieldInfo("PREORGANIZATION",500,"NVARCHAR",0)
,new fieldInfo("GROUPNUMBER",20,"NVARCHAR",0)
,new fieldInfo("WHOIS",64,"VARCHAR",0)
,new fieldInfo("CONLIETSI",0,"INT",0)
,new fieldInfo("THUONGBINH",10,"VARCHAR",0)
,new fieldInfo("MOCOI",0,"INT",0)
,new fieldInfo("BENHBINHMATSUC",0,"INT",0)
,new fieldInfo("HONGHEO",0,"INT",0)
,new fieldInfo("DACAM",0,"INT",0)
,new fieldInfo("DOITUONG",100,"NVARCHAR",0)
,new fieldInfo("THANHPHAN",100,"NVARCHAR",0)
,new fieldInfo("SOANHCHIEM",0,"INT",0)
,new fieldInfo("CONTHU",0,"INT",0)
,new fieldInfo("NANGKHIEU",200,"NVARCHAR",0)
,new fieldInfo("DIACHI",1000,"NVARCHAR",0)
,new fieldInfo("PHONE",50,"NVARCHAR",0)
,new fieldInfo("EMAIL",100,"NVARCHAR",0)
,new fieldInfo("THUETRO",0,"INT",0)
,new fieldInfo("BAOTINHOTEN",50,"NVARCHAR",0)
,new fieldInfo("BAOTINDIACHI",200,"NVARCHAR",0)
,new fieldInfo("BAOTINDIENTHOAI",50,"VARCHAR",0)
,new fieldInfo("BAOTINEMAIL",100,"VARCHAR",0)
,new fieldInfo("BAOTROHOTEN",50,"NVARCHAR",0)
,new fieldInfo("BAOTRODIACHI",200,"NVARCHAR",0)
,new fieldInfo("BAOTRODIENTHOAI",50,"VARCHAR",0)
,new fieldInfo("BAOTROEMAIL",100,"VARCHAR",0)
,new fieldInfo("BAOTROMATKHAU",64,"VARCHAR",0)
,new fieldInfo("BAOTRODANGNHAP",50,"NVARCHAR",0)
,new fieldInfo("BAOTRODOIMATKHAU",0,"INT",0)
,new fieldInfo("UNIVERSITYCODE",10,"VARCHAR",0)
,new fieldInfo("LANGUAGECODE",10,"VARCHAR",0)
,new fieldInfo("ORIGINALCODE",10,"VARCHAR",0)

                               };;
		}
	}

	protected override fieldInfo[] _code {
		get { 
			return new fieldInfo[] { new fieldInfo("CODE",10,"VARCHAR",0)
 }; 
		} 
	}
	// [tablereference("PROVINCE", "CODE", "PROVINCECODE")]
 //  public PROVINCE_OBJ _PROVINCECODE;
 //[tablereference("DISTRICT", "CODE", "DISTRICTCODE")]
 //  public DISTRICT_OBJ _DISTRICTCODE;
 //[tablereference("TOWN", "CODE", "TOWNCODE")]
 //  public TOWN_OBJ _TOWNCODE;
 //[tablereference("ETHNIC", "CODE", "ETHNICCODE")]
 //  public ETHNIC_OBJ _ETHNICCODE;
 //[tablereference("RELIGION", "CODE", "RELIGIONCODE")]
 //  public RELIGION_OBJ _RELIGIONCODE;
 [tablereference("CLASS", "CODE", "CLASSCODE")]
   public CLASS_OBJ _CLASSCODE;
 [tablereference("GRADE", "CODE", "GRADECODE")]
   public GRADE_OBJ _GRADECODE;
 //[tablereference("EDUCATIONFIELD", "CODE", "EDUCATIONFIELDCODE")]
 //  public EDUCATIONFIELD_OBJ _EDUCATIONFIELDCODE;
 //[tablereference("STUDENTRANK", "CODE", "STUDENTRANKCODE")]
 //  public STUDENTRANK_OBJ _STUDENTRANKCODE;

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
    public virtual System.DateTime BIRTHDAY
    {
        get ;
        set ;
    }
    public virtual System.Int16 SEX
    {
        get ;
        set ;
    }
    public virtual System.String PHOTO
    {
        get ;
        set ;
    }
    public virtual System.String PROVINCECODE
    {
        get ;
        set ;
    }
    public virtual System.String DISTRICTCODE
    {
        get ;
        set ;
    }
    public virtual System.String TOWNCODE
    {
        get ;
        set ;
    }
    public virtual System.String TEL
    {
        get ;
        set ;
    }
    public virtual System.String ETHNICCODE
    {
        get ;
        set ;
    }
    public virtual System.String RELIGIONCODE
    {
        get ;
        set ;
    }
    public virtual System.String PRIORITYREGIONCODE
    {
        get ;
        set ;
    }
    public virtual System.String PRIORITYPOLICYCODE
    {
        get ;
        set ;
    }
    public virtual System.String ISSUECODE
    {
        get ;
        set ;
    }
    public virtual System.Double MARK
    {
        get ;
        set ;
    }
    public virtual System.Double MARK1
    {
        get ;
        set ;
    }
    public virtual System.Double MARK2
    {
        get ;
        set ;
    }
    public virtual System.Double MARK3
    {
        get ;
        set ;
    }
    public virtual System.Double MARK4
    {
        get ;
        set ;
    }
    public virtual System.Double MARK5
    {
        get ;
        set ;
    }
    public virtual System.Double BONUSMARK
    {
        get ;
        set ;
    }
    public virtual System.String ENROLLREASON
    {
        get ;
        set ;
    }
    public virtual System.String XLHTTHPT
    {
        get ;
        set ;
    }
    public virtual System.String XLHKTHPT
    {
        get ;
        set ;
    }
    public virtual System.String XLTNTHPT
    {
        get ;
        set ;
    }
    public virtual System.DateTime YOUTHDATE
    {
        get ;
        set ;
    }
    public virtual System.DateTime PARTYDATE
    {
        get ;
        set ;
    }
    public virtual System.Int32 HIGHSCHOOLYEAR
    {
        get ;
        set ;
    }
    public virtual System.String IDNUMBER
    {
        get ;
        set ;
    }
    public virtual System.DateTime IDDATE
    {
        get ;
        set ;
    }
    public virtual System.String IDPROVINCE
    {
        get ;
        set ;
    }
    public virtual System.String DOCCODE
    {
        get ;
        set ;
    }
    public virtual System.String STUDENTID
    {
        get ;
        set ;
    }
    public virtual System.String STUDENTIDDATE
    {
        get ;
        set ;
    }
    public virtual System.String HOMETOWN
    {
        get ;
        set ;
    }
    public virtual System.String ADDRESS
    {
        get ;
        set ;
    }
    public virtual System.String REWARD
    {
        get ;
        set ;
    }
    public virtual System.String HISTORYNOTE
    {
        get ;
        set ;
    }
    public virtual System.Boolean BIRTHCERTIFICATE
    {
        get ;
        set ;
    }
    public virtual System.Boolean HIGHSCHOOLDEGREE
    {
        get ;
        set ;
    }
    public virtual System.Boolean INVITEDDOC
    {
        get ;
        set ;
    }
    public virtual System.Boolean HIGHSCHOOLCERTIFICATE
    {
        get ;
        set ;
    }
    public virtual System.Boolean ARMYDUTY
    {
        get ;
        set ;
    }
    public virtual System.String CLASSCODE
    {
        get ;
        set ;
    }
    public virtual System.String GRADECODE
    {
        get ;
        set ;
    }
    public virtual System.String EDUCATIONFIELDCODE
    {
        get ;
        set ;
    }
    public virtual System.String USERPASSWORD
    {
        get ;
        set ;
    }
    public virtual System.Int32 CHANGEPASS
    {
        get ;
        set ;
    }
    public virtual System.String STUDENTRANKCODE
    {
        get ;
        set ;
    }
    public virtual System.String STUDENTLEVELTITLE
    {
        get ;
        set ;
    }
    public virtual System.Int32 DISABLEPERSON
    {
        get ;
        set ;
    }
    public virtual System.Int32 STUDENTSTATUS
    {
        get ;
        set ;
    }
    public virtual System.String STUDENTLEVELTITLECODE
    {
        get ;
        set ;
    }
    public virtual System.String PREORGANIZATION
    {
        get ;
        set ;
    }
    public virtual System.String GROUPNUMBER
    {
        get ;
        set ;
    }
    public virtual System.String WHOIS
    {
        get ;
        set ;
    }
    public virtual System.Int32 CONLIETSI
    {
        get ;
        set ;
    }
    public virtual System.String THUONGBINH
    {
        get ;
        set ;
    }
    public virtual System.Int32 MOCOI
    {
        get ;
        set ;
    }
    public virtual System.Int32 BENHBINHMATSUC
    {
        get ;
        set ;
    }
    public virtual System.Int32 HONGHEO
    {
        get ;
        set ;
    }
    public virtual System.Int32 DACAM
    {
        get ;
        set ;
    }
    public virtual System.String DOITUONG
    {
        get ;
        set ;
    }
    public virtual System.String THANHPHAN
    {
        get ;
        set ;
    }
    public virtual System.Int32 SOANHCHIEM
    {
        get ;
        set ;
    }
    public virtual System.Int32 CONTHU
    {
        get ;
        set ;
    }
    public virtual System.String NANGKHIEU
    {
        get ;
        set ;
    }
    public virtual System.String DIACHI
    {
        get ;
        set ;
    }
    public virtual System.String PHONE
    {
        get ;
        set ;
    }
    public virtual System.String EMAIL
    {
        get ;
        set ;
    }
    public virtual System.Int32 THUETRO
    {
        get ;
        set ;
    }
    public virtual System.String BAOTINHOTEN
    {
        get ;
        set ;
    }
    public virtual System.String BAOTINDIACHI
    {
        get ;
        set ;
    }
    public virtual System.String BAOTINDIENTHOAI
    {
        get ;
        set ;
    }
    public virtual System.String BAOTINEMAIL
    {
        get ;
        set ;
    }
    public virtual System.String BAOTROHOTEN
    {
        get ;
        set ;
    }
    public virtual System.String BAOTRODIACHI
    {
        get ;
        set ;
    }
    public virtual System.String BAOTRODIENTHOAI
    {
        get ;
        set ;
    }
    public virtual System.String BAOTROEMAIL
    {
        get ;
        set ;
    }
    public virtual System.String BAOTROMATKHAU
    {
        get ;
        set ;
    }
    public virtual System.String BAOTRODANGNHAP
    {
        get ;
        set ;
    }
    public virtual System.Int32 BAOTRODOIMATKHAU
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
    public virtual System.String ORIGINALCODE
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

