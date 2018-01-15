using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
namespace IS.uni
{
    public class STUDENTMORALHISTORY_BUS: BusinessController<STUDENTMORALHISTORY_OBJ, STUDENTMORALHISTORY_OBJ.BusinessObjectID>
    {
        public STUDENTMORALHISTORY_BUS()
        {
        }
        public override STUDENTMORALHISTORY_OBJ createObject()
        {
            STUDENTMORALHISTORY_OBJ obj = new STUDENTMORALHISTORY_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override STUDENTMORALHISTORY_OBJ createNull()
        {
            return null;
        }

        public int GetStudentmoral(ref DataSet ds, string tableName, string classcode, string Month, string Year, string usercode)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("month", Month, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("usercode", usercode, SqlDbType.VarChar, 0, 0));
            ret = storedProcedure("studentmoralhistory_gennewmonth", li);

            if (ret < 0)
            {
                return ret;
            }

            string sql = @"select 
	                            st.codeview studentcode
                                ,st.name  studentname
                                ,st.birthday birthday
                                ,sh.*
                                ,cl.codeview classcode
                                ,cl.name classname
                            from studentmoralhistory sh
                            inner join student st on st.code=sh.studentcode
                            inner join class cl on cl.code=st.classcode
                            where (sh.thetype=0)
	                            and st.classcode=@classcode
	                            and sh.themonth = @month
	                            and sh.theyear=@year";
            li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("month", Month, SqlDbType.Int, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        public int GetStudentmoralTerm(ref DataSet ds, string tableName, string classcode, string Term, string Year, string usercode)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("Term", Term, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("usercode", usercode, SqlDbType.VarChar, 0, 0));
            ret = storedProcedure("studentmoralhistory_gennewterm", li);

            if (ret < 0)
            {
                return ret;
            }

            string sql = @"select 
	                             st.codeview studentcode
                                ,st.name  studentname
                                ,st.birthday birthday
                                ,sh.code   
                                ,sh.codeview
                                ,sh.name
                                ,sh.note
                                ,sh.edituser
                                ,sh.edittime
                                ,sh.lock
                                ,sh.lockdate
                                ,sh.studentcode
                                ,sh.themonth
                                ,sh.theyear
                                ,sh.mark1
                                ,sh.mark2
                                ,sh.mark3
                                ,sh.mark
                                ,isnull(sh.moraltypecode, case when @month=1 then dbo.calMoralTerm(t09.pl,t10.pl,t11.pl,t12.pl,t01.pl,t02.pl) else dbo.calMoralTerm(t03.pl,t04.pl,t05.pl,t06.pl,t07.pl,t08.pl) end) moraltypecode
                                ,sh.whois
                                ,sh.thetype
                                ,cl.codeview classcode
                                ,cl.name classname
                                ,t09.pl mtc09
                                ,t10.pl mtc10
                                ,t11.pl mtc11
                                ,t12.pl mtc12
                                ,t01.pl mtc01
                                ,t02.pl mtc02
                                ,t03.pl mtc03
                                ,t04.pl mtc04
                                ,t05.pl mtc05
                                ,t06.pl mtc06
                                ,t07.pl mtc07
                                ,t08.pl mtc08       
                            from studentmoralhistory sh
                            inner join student st on st.code=sh.studentcode
                            inner join class cl on cl.code=st.classcode
                            left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 9 and theyear=@year   and thetype = 0) t09 on t09.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth=10 and theyear=@year   and thetype = 0) t10 on t10.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth=11 and theyear=@year   and thetype = 0) t11 on t11.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth=12 and theyear=@year   and thetype = 0) t12 on t12.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 1 and theyear=@year+1 and thetype = 0) t01 on t01.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 2 and theyear=@year+1 and thetype = 0) t02 on t02.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 3 and theyear=@year+1 and thetype = 0) t03 on t03.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 4 and theyear=@year+1 and thetype = 0) t04 on t04.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 5 and theyear=@year+1 and thetype = 0) t05 on t05.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 6 and theyear=@year+1 and thetype = 0) t06 on t06.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 7 and theyear=@year+1 and thetype = 0) t07 on t07.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 8 and theyear=@year+1 and thetype = 0) t08 on t08.studentcode = st.code
                            where (sh.thetype=1)
	                            and st.classcode=@classcode
	                            and sh.themonth = @month
	                            and sh.theyear=@year";
            li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("month", Term, SqlDbType.Int, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        public int GetStudentmoralYear(ref DataSet ds, string tableName, string classcode, string Term, string Year, string usercode)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("Term", Term, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("usercode", usercode, SqlDbType.VarChar, 0, 0));
            ret = storedProcedure("studentmoralhistory_gennewyear", li);

            if (ret < 0)
            {
                return ret;
            }

            string sql = @"select 
	                            st.codeview studentcode
                                ,st.name  studentname
                                ,st.birthday birthday
                                 ,sh.code   
                                ,sh.codeview
                                ,sh.name
                                ,sh.note
                                ,sh.edituser
                                ,sh.edittime
                                ,sh.lock
                                ,sh.lockdate
                                ,sh.studentcode
                                ,sh.themonth
                                ,sh.theyear
                                ,sh.mark1
                                ,sh.mark2
                                ,sh.mark3
                                ,sh.mark
                                ,isnull(sh.moraltypecode, dbo.calMoralYear(t09.pl,t10.pl,t11.pl,t12.pl,t01.pl,t02.pl,t03.pl,t04.pl,t05.pl,t06.pl,t07.pl,t08.pl)) moraltypecode
                                ,sh.whois
                                ,sh.thetype
                                ,cl.codeview classcode
                                ,cl.name classname
                                ,t09.pl mtc09
                                ,t10.pl mtc10
                                ,t11.pl mtc11
                                ,t12.pl mtc12
                                ,t01.pl mtc01
                                ,t02.pl mtc02
                                ,t03.pl mtc03
                                ,t04.pl mtc04
                                ,t05.pl mtc05
                                ,t06.pl mtc06
                                ,t07.pl mtc07
                                ,t08.pl mtc08                          
                            from studentmoralhistory sh
                            inner join student st on st.code=sh.studentcode
                            inner join class cl on cl.code=st.classcode
                            left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 9 and theyear=@year   and thetype = 0) t09 on t09.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth=10 and theyear=@year   and thetype = 0) t10 on t10.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth=11 and theyear=@year   and thetype = 0) t11 on t11.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth=12 and theyear=@year   and thetype = 0) t12 on t12.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 1 and theyear=@year+1 and thetype = 0) t01 on t01.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 2 and theyear=@year+1 and thetype = 0) t02 on t02.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 3 and theyear=@year+1 and thetype = 0) t03 on t03.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 4 and theyear=@year+1 and thetype = 0) t04 on t04.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 5 and theyear=@year+1 and thetype = 0) t05 on t05.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 6 and theyear=@year+1 and thetype = 0) t06 on t06.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 7 and theyear=@year+1 and thetype = 0) t07 on t07.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where themonth= 8 and theyear=@year+1 and thetype = 0) t08 on t08.studentcode = st.code
                            where (sh.thetype=2)
	                            and st.classcode=@classcode
	                            and sh.theyear=@year";
            li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("month", Term, SqlDbType.Int, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }


        public int GetStudentmoralGrade(ref DataSet ds, string tableName, string classcode, string Term, string Year, string usercode)
        {
            int ret = 0;
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("Term", Term, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("usercode", usercode, SqlDbType.VarChar, 0, 0));
            ret = storedProcedure("studentmoralhistory_gennewgrade", li);
            
            string sql1 = @"select gr.yearin
                            from class cl
                            inner join grade gr on gr.code=cl.gradecode
                            where cl.code='"+ classcode.Trim() +"'";
            DataSet d1 = new DataSet();
            int ret1 = getByQuery(ref d1, "YearIN", sql1,li);
            if (ret1 < 0)
            {
                return ret1;
            }
            Year = d1.Tables["YearIN"].Rows[0]["yearin"].ToString();

            string sql = @"select 
	                            st.codeview studentcode
                                ,st.name  studentname
                                ,st.birthday birthday
                                 ,sh.code   
                                ,sh.codeview
                                ,sh.name
                                ,sh.note
                                ,sh.edituser
                                ,sh.edittime
                                ,sh.lock
                                ,sh.lockdate
                                ,sh.studentcode
                                ,sh.themonth
                                ,sh.theyear
                                ,sh.mark1
                                ,sh.mark2
                                ,sh.mark3
                                ,sh.mark
                                ,isnull(sh.moraltypecode, dbo.calMoralGrade(n1.pl,n2.pl,n3.pl,n4.pl,n5.pl)) moraltypecode
                                ,sh.whois
                                ,sh.thetype
                                ,cl.codeview classcode
                                ,cl.name classname
                                ,n1.pl n1
                                ,n2.pl n2
                                ,n3.pl n3
                                ,n4.pl n4
                                ,n5.pl n5
                            from studentmoralhistory sh
                            inner join student st on st.code=sh.studentcode
                            inner join class cl on cl.code=st.classcode
                            left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where theyear=@year+0 and thetype = 2) n1 on n1.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where theyear=@year+1 and thetype = 2) n2 on n2.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where theyear=@year+2 and thetype = 2) n3 on n3.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where theyear=@year+3 and thetype = 2) n4 on n4.studentcode = st.code
		                    left join (select smh.*,mt.codeview pl from studentmoralhistory smh inner join moraltype mt on (smh.moraltypecode = mt.code) where theyear=@year+4 and thetype = 2) n5 on n5.studentcode = st.code
		                    where (sh.thetype=3)
	                            and st.classcode=@classcode";
	                            
            li = new List<fieldpara>();
            li.Add(new fieldpara("classcode", classcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("month", Term, SqlDbType.Int, 0, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// get all moral history of the class 's students base on term, year, or all
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="classcode"></param>
        /// <param name="year"></param>
        /// <param name="term"></param>
        /// <returns></returns>
        public int getClassStudentMoral(ref DataSet ds, string tableName, string classcode, int year, int term)
        {
            int ret=0;
            //term
            int thetype = 1;
            if(term==0)
            {
                thetype = 2;
            }
            if(year==0)
            {
                thetype = 3;
            }
            string sql = @"select A.*, B.* from student A 
LEFT JOIN (SELECT  A1.studentcode, A1.themonth, A1.theyear, B1.codeview moralcodeview, B1.name moralnam FROM studentmoralhistory A1 INNER JOIN moraltype B1 ON A1.moraltypecode=B1.code WHERE A1.thetype=@thetype and (A1.theyear=@year OR @year=0) AND (A1.themonth=@term or @term=0)) B ON A.code=B.studentcode
where A.classcode=@classcode";
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("thetype", thetype,paraType.INT,0));
            li.Add(new fieldpara("year", year, paraType.INT, 0));
            li.Add(new fieldpara("term", term, paraType.INT, 0));
            li.Add(new fieldpara("classcode", classcode, paraType.VARCHAR, 0));
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
    }

}

