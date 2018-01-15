using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using IS.Base;
using IS.fitframework;
using IS.basetype;
using IS.Comm;
namespace IS.uni
{
    public class DEPARTMENT_BUS: BusinessController<DEPARTMENT_OBJ, DEPARTMENT_OBJ.BusinessObjectID>
    {
        CommonLib com = new CommonLib();
        public static class GlobalVars
        {
            public static bool approved = false;
            public static int approvedStatus = 2;
        }
        public DEPARTMENT_BUS()
        {
        }
        public override DEPARTMENT_OBJ createObject()
        {
            DEPARTMENT_OBJ obj = new DEPARTMENT_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override DEPARTMENT_OBJ createNull()
        {
            return null;
        }
        public int getList(ref DataSet ds, string tableName, string codeview, string name, string parencode)
        {
            List<fieldpara> li = new List<fieldpara>();
            int ret = 0;
            li.Add(new fieldpara("parentcode", parencode, SqlDbType.VarChar, 0, 0));//only compare in the predefined value
            li.Add(new fieldpara("A.codeview", codeview, SqlDbType.VarChar, 1, 1));
            li.Add(new fieldpara("A.name", name, SqlDbType.NVarChar, 1, 1));
            string sql = @"select A.*, B.name managelevelname, C.name parentname from (select * from department where parentcode=@parentcode)A INNER JOIN managelevel B ON A.managelevelcode = B.code LEFT JOIN department C ON A.parentcode=C.code";
            ret = getByQuery(ref ds, tableName, sql," A.theorder ", li);
            return ret;

        }
        public int getList(ref DataSet ds, string tableName, string codeview, string name)
        {
            List<fieldpara> li = new List<fieldpara>();
            int ret = 0;
            li.Add(new fieldpara("A.codeview", codeview, SqlDbType.VarChar, 1, 1));
            li.Add(new fieldpara("A.name", name, SqlDbType.NVarChar, 1, 1));
            string sql = @"select A.*, B.name managelevelname, C.name parentname from (select * from department where isnull(parentcode,'')='')A INNER JOIN managelevel B ON A.managelevelcode = B.code LEFT JOIN department C ON A.parentcode=C.code";
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        /// <summary>
        /// Lấy danh sách đơn vị con từ Khoa, Phòng, Viện
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="codeview"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public int getChilds(ref DataSet ds, string tableName, string parentCode)
        {
            List<fieldpara> li = new List<fieldpara>();
            int ret = 0;
            string sql = @"SELECT code, name FROM department where parentcode = '" + parentCode + "'";
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
        public string getParentCode(string DepartmentCode)
        {
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            int ret = 0;
            string sql = @"SELECT parentcode FROM department where code = '" + DepartmentCode + "'";
            ret = getByQuery(ref ds, "PARENTCODE", sql, li);
            string departmentcode = "";
            if (ret >= 0)
            {
                if (ds.Tables[0].Rows.Count > 0)
                {
                    departmentcode = com.string4Row(ds.Tables[0].Rows[0], "parentcode", "");
                }
            }
            return departmentcode;
        }
        /// <summary>
        /// Thống kê học hàm theo đơn vị
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int AcademictitleStat(ref DataSet ds, string tableName, string code)
        {
            int ret=0;
            string sqlDepartment;
            string sql;
            string sqlAcademictitle = "select * from academictitle order by theorder";
            if (code != "")
            {
                //level 1
                sqlDepartment = "select * from department where parentcode=@departmentcode";
                sql = @"	select codegroup, academictitlecode, count(*) num FROM 
	(
		select B.codegroup, A.* from staff A INNER JOIN 
			(
			select code codegroup, code from department where parentcode=@departmentcode
			) B 
		ON A.departmentcode=B.code
	)
	C
	GROUP BY codegroup, academictitlecode
	order by  codegroup, academictitlecode
";
            }
            else
            {
                //level 2
                sqlDepartment = "select * from department where isnull(parentcode,'') =''";
                sql = @"
	select codegroup, academictitlecode, count(*) num FROM 
	(
		select B.codegroup, A.* from staff A INNER JOIN 
			(
			select parentcode codegroup, code from department  where isnull(parentcode,'') <>''
			) B 
		ON A.departmentcode=B.code
	)
	C
	GROUP BY codegroup, academictitlecode
	order by  codegroup, academictitlecode
";
            }
            DataSet dstemp = new DataSet();
            List<fieldpara> lidep = new List<fieldpara>();
            if(code!="")
            {
                lidep.Add(new fieldpara("departmentcode",code, SqlDbType.VarChar,0,0));
            }
            ret = getByQuery(ref dstemp, "department", sqlDepartment, lidep);
            if (ret >= 0)
            {
                List<fieldpara> liaca = new List<fieldpara>();
                ret = getByQuery(ref dstemp, "academictitle", sqlAcademictitle, liaca);
            }
            if (ret >= 0)
            {
                ret = getByQuery(ref dstemp, "stat", sql, lidep);
            }
            if (ret < 0)
            {
                return ret;
            }
            //OK get all
            DataTable dt = new DataTable(tableName);
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("codeview", typeof(string));
            dt.Columns.Add("name", typeof(string));
            foreach (DataRow dr in dstemp.Tables["academictitle"].Rows)
            {
                //create columns
                dt.Columns.Add(dr["code"].ToString(), typeof(int));
            }
            //create new department row
            foreach (DataRow dr in dstemp.Tables["department"].Rows)
            {
                //all 
                DataRow[] drs = dstemp.Tables["stat"].Select("codegroup='"+dr["code"].ToString().Replace("'","''")+"'");
                DataRow drnew = dt.NewRow();
                drnew["code"] = dr["code"];
                drnew["codeview"] = dr["codeview"];
                drnew["name"] = dr["name"];
                //assign data here
                if (drs.Length != 0)
                {
                    //yes data
                    foreach (DataRow drc in drs)
                    {
                        drnew[drc["academictitlecode"].ToString()] = drc["num"];
                    }
                }
                dt.Rows.Add(drnew);
            }
            //rename the code by codeview
            foreach (DataRow dr in dstemp.Tables["academictitle"].Rows)
            {
                //assign new name
                dt.Columns[dr["code"].ToString()].ColumnName = dr["name"].ToString();
            }

            ds.Tables.Add(dt);
            return ret;
        }
        /// <summary>
        /// Thống kê theo học vị
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int AcademictitleDegree(ref DataSet ds, string tableName, string code)
        {
            int ret = 0;
            string sqlDepartment;
            string sql;
            string sqlAcademictitle = "select * from degree order by theorder";
            if (code != "")
            {
                //level 1
                sqlDepartment = "select * from department where parentcode=@departmentcode";
                sql = @"	select codegroup, degreecode, count(*) num FROM 
	(
		select B.codegroup, A.* from staff A INNER JOIN 
			(
			select code codegroup, code from department where parentcode=@departmentcode
			) B 
		ON A.departmentcode=B.code
	)
	C
	GROUP BY codegroup, degreecode
	order by  codegroup, degreecode
";
            }
            else
            {
                //level 2
                sqlDepartment = "select * from department where isnull(parentcode,'') =''  order by theorder";
                sql = @"
	select codegroup, degreecode, count(*) num FROM 
	(
		select B.codegroup, A.* from staff A INNER JOIN 
			(
			select parentcode codegroup, code from department  where isnull(parentcode,'') <>''
			) B 
		ON A.departmentcode=B.code
	)
	C
	GROUP BY codegroup, degreecode
	order by  codegroup, degreecode
";
            }
            DataSet dstemp = new DataSet();
            List<fieldpara> lidep = new List<fieldpara>();
            if (code != "")
            {
                lidep.Add(new fieldpara("departmentcode", code, SqlDbType.VarChar, 0, 0));
            }
            ret = getByQuery(ref dstemp, "department", sqlDepartment, lidep);
            if (ret >= 0)
            {
                List<fieldpara> liaca = new List<fieldpara>();
                ret = getByQuery(ref dstemp, "degree", sqlAcademictitle, liaca);
            }
            if (ret >= 0)
            {
                ret = getByQuery(ref dstemp, "stat", sql, lidep);
            }
            if (ret < 0)
            {
                return ret;
            }
            //OK get all
            DataTable dt = new DataTable(tableName);
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("codeview", typeof(string));
            dt.Columns.Add("name", typeof(string));
            foreach (DataRow dr in dstemp.Tables["degree"].Rows)
            {
                //create columns
                dt.Columns.Add(dr["code"].ToString(), typeof(int));
            }
            //create new department row
            foreach (DataRow dr in dstemp.Tables["department"].Rows)
            {
                //all 
                DataRow[] drs = dstemp.Tables["stat"].Select("codegroup='" + dr["code"].ToString().Replace("'", "''") + "'");
                DataRow drnew = dt.NewRow();
                drnew["code"] = dr["code"];
                drnew["codeview"] = dr["codeview"];
                drnew["name"] = dr["name"];
                //assign data here
                if (drs.Length != 0)
                {
                    //yes data
                    foreach (DataRow drc in drs)
                    {
                        drnew[drc["degreecode"].ToString()] = drc["num"];
                    }
                }
                dt.Rows.Add(drnew);
            }
            //rename the code by codeview
            foreach (DataRow dr in dstemp.Tables["degree"].Rows)
            {
                //assign new name
                dt.Columns[dr["code"].ToString()].ColumnName = dr["name"].ToString();
            }

            ds.Tables.Add(dt);
            return ret;
        }
        /// <summary>
        /// Thống kê theo quân hàm
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int AcademictitleArmyrank(ref DataSet ds, string tableName, string code)
        {
            int ret = 0;
            string sqlDepartment;
            string sql;
            string sqlAcademictitle = "select * from armyrank order by theorder";
            if (code != "")
            {
                //level 1
                sqlDepartment = "select * from department where parentcode=@departmentcode  order by theorder";
                sql = @"	select codegroup, armyrankcode, count(*) num FROM 
	(
		select B.codegroup, A.* from staff A INNER JOIN 
			(
			select code codegroup, code from department where parentcode=@departmentcode
			) B 
		ON A.departmentcode=B.code
	)
	C
	GROUP BY codegroup, armyrankcode
	order by  codegroup, armyrankcode
";
            }
            else
            {
                //level 2
                sqlDepartment = "select * from department where isnull(parentcode,'') =''  order by theorder";
                sql = @"
	select codegroup, armyrankcode, count(*) num FROM 
	(
		select B.codegroup, A.* from staff A INNER JOIN 
			(
			select parentcode codegroup, code from department  where isnull(parentcode,'') <>''
			) B 
		ON A.departmentcode=B.code
	)
	C
	GROUP BY codegroup, armyrankcode
	order by  codegroup, armyrankcode
";
            }
            DataSet dstemp = new DataSet();
            List<fieldpara> lidep = new List<fieldpara>();
            if (code != "")
            {
                lidep.Add(new fieldpara("departmentcode", code, SqlDbType.VarChar, 0, 0));
            }
            ret = getByQuery(ref dstemp, "department", sqlDepartment, lidep);
            if (ret >= 0)
            {
                List<fieldpara> liaca = new List<fieldpara>();
                ret = getByQuery(ref dstemp, "armyrank", sqlAcademictitle, liaca);
            }
            if (ret >= 0)
            {
                ret = getByQuery(ref dstemp, "stat", sql, lidep);
            }
            if (ret < 0)
            {
                return ret;
            }
            //OK get all
            DataTable dt = new DataTable(tableName);
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("codeview", typeof(string));
            dt.Columns.Add("name", typeof(string));
            foreach (DataRow dr in dstemp.Tables["armyrank"].Rows)
            {
                //create columns
                dt.Columns.Add(dr["code"].ToString(), typeof(int));
            }
            //create new department row
            foreach (DataRow dr in dstemp.Tables["department"].Rows)
            {
                //all 
                DataRow[] drs = dstemp.Tables["stat"].Select("codegroup='" + dr["code"].ToString().Replace("'", "''") + "'");
                DataRow drnew = dt.NewRow();
                drnew["code"] = dr["code"];
                drnew["codeview"] = dr["codeview"];
                drnew["name"] = dr["name"];
                //assign data here
                if (drs.Length != 0)
                {
                    //yes data
                    foreach (DataRow drc in drs)
                    {
                        drnew[drc["armyrankcode"].ToString()] = drc["num"];
                    }
                }
                dt.Rows.Add(drnew);
            }
            //rename the code by codeview
            foreach (DataRow dr in dstemp.Tables["armyrank"].Rows)
            {
                //assign new name
                dt.Columns[dr["code"].ToString()].ColumnName = dr["name"].ToString();
            }

            ds.Tables.Add(dt);
            return ret;
        }
        /// <summary>
        /// Thống kê theo độ tuổi
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int AcademictitleAge(ref DataSet ds, string tableName, string code)
        {
            int ret = 0;
            string sqlDepartment;
            string sql;
            string sqlAcademictitle;
            if (code != "")
            {
                //level 1
                sqlDepartment = @"select * from department  where parentcode=@departmentcode order by theorder";
                sqlAcademictitle = @"select distinct YEAR(getdate())- isnull(YEAR(A.birthday),0) code from staff A INNER JOIN 
			(
			select parentcode codegroup, code from department  where parentcode=@departmentcode
			) B 
		ON A.departmentcode=B.code
		order by YEAR(getdate())- isnull(YEAR(A.birthday),0)";
                sql = @"	select codegroup, age, count(*) num FROM 
	(
		select B.codegroup, YEAR(getdate())- isnull(YEAR(A.birthday),0) age,  A.* from staff A INNER JOIN 
			(
			select code codegroup, code from department  where parentcode=@departmentcode
			) B 
		ON A.departmentcode=B.code
	)
	C
	GROUP BY codegroup, age
	order by  codegroup, age

";
            }
            else
            {
                //level 2
                sqlDepartment = @"select * from department where isnull(parentcode,'') ='' order by theorder";
                sqlAcademictitle = @"select distinct YEAR(getdate())- isnull(YEAR(A.birthday),0) code from staff A INNER JOIN 
			(
			select parentcode codegroup, code from department  where isnull(parentcode,'') <>''
			) B 
		ON A.departmentcode=B.code";

                sql = @"
	select codegroup, age, count(*) num FROM 
	(
		select B.codegroup, YEAR(getdate())- isnull(YEAR(A.birthday),0) age,  A.* from staff A INNER JOIN 
			(
			select parentcode codegroup, code from department  where isnull(parentcode,'') <>''
			) B 
		ON A.departmentcode=B.code
	)
	C
	GROUP BY codegroup, age
	order by  codegroup, age

";
            }
            DataSet dstemp = new DataSet();
            List<fieldpara> lidep = new List<fieldpara>();
            if (code != "")
            {
                lidep.Add(new fieldpara("departmentcode", code, SqlDbType.VarChar, 0, 0));
            }
            ret = getByQuery(ref dstemp, "department", sqlDepartment, lidep);
            if (ret >= 0)
            {
                ret = getByQuery(ref dstemp, "age", sqlAcademictitle, lidep);
            }
            if (ret >= 0)
            {
                ret = getByQuery(ref dstemp, "stat", sql, lidep);
            }
            if (ret < 0)
            {
                return ret;
            }
            //OK get all
            DataTable dt = new DataTable(tableName);
            dt.Columns.Add("code", typeof(string));
            dt.Columns.Add("codeview", typeof(string));
            dt.Columns.Add("name", typeof(string));
            foreach (DataRow dr in dstemp.Tables["age"].Rows)
            {
                //create columns
                dt.Columns.Add(dr["code"].ToString(), typeof(int));
            }
            //create new department row
            foreach (DataRow dr in dstemp.Tables["department"].Rows)
            {
                //all 
                DataRow[] drs = dstemp.Tables["stat"].Select("codegroup='" + dr["code"].ToString().Replace("'", "''") + "'");
                DataRow drnew = dt.NewRow();
                drnew["code"] = dr["code"];
                drnew["codeview"] = dr["codeview"];
                drnew["name"] = dr["name"];
                //assign data here
                if (drs.Length != 0)
                {
                    //yes data
                    foreach (DataRow drc in drs)
                    {
                        drnew[drc["age"].ToString()] = drc["num"];
                    }
                }
                dt.Rows.Add(drnew);
            }
            ////rename the code by codeview
            //foreach (DataRow dr in dstemp.Tables["age"].Rows)
            //{
            //    //assign new name
            //    dt.Columns[dr["code"].ToString()].ColumnName = dr["name"].ToString();
            //}

            ds.Tables.Add(dt);
            return ret;
        }

        /// <summary>
        /// Hàm lấy danh sách staff từ theo departmentcode
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="departmentcode">Mã department, nếu rỗng sẽ hiểu là lấy tất cả staff của HV</param>
        /// <param name="GetLevel">1: Lấy staff của BM; 2: Lấy staff của Khoa; 3: Lấy staff của HV</param>
        /// <returns></returns>
        public int getStaffList(ref DataSet ds, string tableName, string departmentcode, int GetLevel)
        {            
            List<fieldpara> li = new List<fieldpara>();
            int ret = 0;
            li.Add(new fieldpara("departmentcode", departmentcode, SqlDbType.VarChar, 0, 0));

            string sql = @"with FullName_cte as 
                            (
                            select
                                charindex(' ', s.name) -1 as FirstNameEnd,	
                                len(s.name) - charindex(' ',reverse(s.name)) +2  as LastNameStart,
                                s.code, s.name, departmentcode, researchdepartmentcode
                            from staff s LEFT join staffstatus on staffstatus.code = s.staffstatus
							             left join academiclevel on academiclevel.code = s.academiclevelcode						
                            where isnull(staffstatus.isstaff,0) <= 1 and isnull(academiclevel.comparelevel,0) < 10 and s.researchstatus	>0
                            ) 							
                            select
                                code, name,
                                substring(name,0,FirstNameEnd+1) as FirstName,
                                case 
                                    when FirstNameEnd+2 = LastNameStart then '' 
                                    else substring(name, FirstNameEnd+2, LastNameStart-FirstNameEnd-2)
                                end as MiddleName,
                                substring(name, LastNameStart, len(name)) as LastName
                            from FullName_cte ";

            if ((departmentcode.Trim() != "") && (GetLevel != 2))
            {               
                //Cấp Khoa
                if (GetLevel == 1)
                    sql += @"where departmentcode in (select code from department where parentcode = @departmentcode) ";
                else //Cấp bộ môn
                    sql += @"where departmentcode = @departmentcode ";
            }
            //Nếu không có departmentcode hoặc GetLevel = 2 thì lấy tất cả staff của Học viện
            sql += "order by LastName, FirstName, MiddleName ";
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        /// <summary>
        /// Hàm lấy danh sách staff từ theo departmentcode
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="departmentcode">Mã department, nếu rỗng sẽ hiểu là lấy tất cả staff của HV</param>
        /// <param name="GetLevel">1: Lấy staff của BM; 2: Lấy staff của Khoa; 3: Lấy staff của HV</param>
        /// <returns></returns>
        public int getStaffListBy(ref DataSet ds, string tableName, string departmentcode, 
                                   int GetLevel, string WhereStr)
        {
            List<fieldpara> li = new List<fieldpara>();
            int ret = 0;
            li.Add(new fieldpara("departmentcode", departmentcode, SqlDbType.VarChar, 0, 0));

            string sql = @"with FullName_cte as 
                            (
                            select
                                charindex(' ', s.name) -1 as FirstNameEnd,	
                                len(s.name) - charindex(' ',reverse(s.name)) +2  as LastNameStart,
                                s.code, s.name, departmentcode, researchdepartmentcode,
                            academictitle.codeview academictitlecodeview, degree.codeview degreecodeview, 
						    isnull(ACADEMICTITLE.comparelevel,30) academictitlecomparelevel, 
                            isnull(degree.comparelevel, 30) degreecomparelevel
                            from staff s LEFT join staffstatus on staffstatus.code = s.staffstatus
							             left join academiclevel on academiclevel.code = s.academiclevelcode		
										 left join academictitle on academictitle.code = s.academictitlecode
					                    left join degree on degree.code = s.degreecode				
                            where isnull(staffstatus.isstaff,0) <= 1 and isnull(academiclevel.comparelevel,0) < 10 and s.researchstatus	>0
                            ) 							
                            select
                                code, name, academictitlecodeview, degreecodeview, academictitlecomparelevel,
                                degreecomparelevel,
                                substring(name,0,FirstNameEnd+1) as FirstName,
                                case 
                                    when FirstNameEnd+2 = LastNameStart then '' 
                                    else substring(name, FirstNameEnd+2, LastNameStart-FirstNameEnd-2)
                                end as MiddleName,
                                substring(name, LastNameStart, len(name)) as LastName
                            from FullName_cte ";

            if ((departmentcode.Trim() != "") && (GetLevel != 2))
            {
                //Cấp Khoa
                if (GetLevel == 1)
                    sql += @" where departmentcode in (select code from department where parentcode = @departmentcode) ";
                else //Cấp bộ môn
                    sql += @" where departmentcode = @departmentcode ";
                if (WhereStr != "")
                {
                    sql += " and " + WhereStr;
                }

            }
            else
                if (WhereStr != "")
                {
                    sql += " where " + WhereStr;
                }
            //Nếu không có departmentcode hoặc GetLevel = 2 thì lấy tất cả staff của Học viện
            sql += " order by LastName, FirstName, MiddleName ";
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        public int getStaffListToTreeView(ref DataSet ds, string tableName, string departmentcode)
        {
            List<fieldpara> li = new List<fieldpara>();
            int ret = 0;
            li.Add(new fieldpara("departmentcode", departmentcode, SqlDbType.VarChar, 0, 0));

            string sql = @"with FullName_cte as 
                            (
                            select
                                charindex(' ', s.name) -1 as FirstNameEnd,	
                                len(s.name) - charindex(' ',reverse(s.name)) +2  as LastNameStart,
                                s.code, s.name, departmentcode, researchdepartmentcode
                            from staff s LEFT join staffstatus on staffstatus.code = s.staffstatus
							where isnull(staffstatus.isstaff,0) <= 3 and s.researchstatus	>0							
                            ) 							
                            select
                                code, name,
                                substring(name,0,FirstNameEnd+1) as FirstName,
                                case 
                                    when FirstNameEnd+2 = LastNameStart then '' 
                                    else substring(name, FirstNameEnd+2, LastNameStart-FirstNameEnd-2)
                                end as MiddleName,
                                substring(name, LastNameStart, len(name)) as LastName
                            from FullName_cte ";

            if (departmentcode.Trim() != "")
                sql += @"where departmentcode = @departmentcode ";            

            sql += "order by LastName, FirstName, MiddleName ";
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        public int getDepartmentName(ref string departmentname, ref string facultyname, string departmentcode)
        {
            DataSet ds = new DataSet();
            List<fieldpara> li = new List<fieldpara>();
            int ret = 0;
            li.Add(new fieldpara("departmentcode", departmentcode, SqlDbType.VarChar, 0, 0));
            string sql = @"select A.name departmentname, B.name facultyname  
                            from department A 
                            inner join department B on A.parentcode = B.code
                            where A.code = @departmentcode";
            ret = getByQuery(ref ds, departmentcode, sql, li);
            this.CloseConnection();
            if (ret >= 0)
            {
                departmentname = ds.Tables[departmentcode].Rows[0]["departmentname"].ToString();
                facultyname = ds.Tables[departmentcode].Rows[0]["facultyname"].ToString();
            }
            else
            {
                departmentname = "";
                facultyname = "";
            }
            return ret;
        }

        public int getFacultyName(ref string facultyname, string facultycode)
        {
            DataSet ds = new DataSet();
            List<fieldpara> li = new List<fieldpara>();
            int ret = 0;
            li.Add(new fieldpara("facultycode", facultycode, SqlDbType.VarChar, 0, 0));
            string sql = @"select name facultyname 
                            from department  
                            where code = @facultycode";
            ret = getByQuery(ref ds, facultycode, sql, li);
            this.CloseConnection();
            if (ret >= 0)
            {
                facultyname = ds.Tables[facultycode].Rows[0]["facultyname"].ToString();
            }
            else
            {
                facultyname = "";
            }
            return ret;
        }

        /// <summary>
        /// Hàm lấy các đơn vị của Học viện, nếu facultycode rỗng thì trả về danh sách các phòng, khoa thuộc HV
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="facultycode"></param>
        /// <returns></returns>       
        public int getDepartments(ref DataSet ds, string tableName, string facultycode)
        {
            List<fieldpara> li = new List<fieldpara>();
            int ret = 0;
            li.Add(new fieldpara("facultycode", facultycode, SqlDbType.VarChar, 0, 0));
            string sql = "";

            if (facultycode == "ALLDEPARTMENTS") //Lấy tất các Bộ môn
                sql = @"select code, name  from department 
                        where isnull(parentcode,'')<>'' and researchstatus <> 0 
                        order by theorder";
            else if (facultycode == "ALLFACULTIES") //Lấy tất các Khoa
                sql = @" select code, name from department where isnull(parentcode,'')=''  and researchstatus <> 0 
                        order by theorder";
            else           
                sql = @"select code, name  from department 
                        where parentcode = @facultycode and researchstatus <> 0 
                        order by theorder";            
            ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }

        /// <summary>
        /// Trích rút thông tin
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="ListToView"></param>
        /// <param name="Type">1: Liệt kê theo staff, 2: Liệt kê theo bộ môn, 3: Liệt kê theo khoa</param>
        public void ListStaffPapersInDepartment(ref DataSet ds, DataTable ListToView, int Type)
        {
            DataTable result = new DataTable(ListToView.TableName);
            int TotalPaper = 0, NumberDomesticConference = 0, NumberDomesticJournal = 0,
                NumberInternationalConference = 0, NumberInternationalJournal = 0,
                NumberInternationalJournalISI = 0;
            string NameToView = "";
            string Code = "";
            #region ADD CỘT CHO DATATABLE
            result.Columns.Add("department", typeof(string));
            result.Columns.Add("Total", typeof(int));
            result.Columns.Add("NumberDomesticConference", typeof(int));
            result.Columns.Add("NumberDomesticJournal", typeof(int));
            result.Columns.Add("NumberInternationalConference", typeof(int));
            result.Columns.Add("NumberInternationalJournal", typeof(int));
            result.Columns.Add("NumberInternationalJournalISI", typeof(int));
            #endregion
            NameToView = "name";
            switch (Type) 
            {
                case 1:                    
                    Code = "code";
                    break;
                case 2:
                    Code = "departmentcode";
                    break;
                case 3:
                    Code = "facultycode";
                    break;
            }

            for (int i = 0; i < ListToView.Rows.Count; i++)
            {
                string fullName = ListToView.Rows[i][NameToView].ToString();
                string ByCode = Code + " = '" + ListToView.Rows[i]["code"].ToString() + "'";
                TotalPaper = ds.Tables[0].Select(ByCode).ToList().Count;
                NumberDomesticConference = ds.Tables[0].Select(ByCode + " and papertype = 'HOITHAO'").ToList().Count;
                NumberDomesticJournal = ds.Tables[0].Select(ByCode + " and papertype = 'TAPCHI'").ToList().Count;
                NumberInternationalConference = ds.Tables[0].Select(ByCode + " and papertype = 'HOITHAOQUOCTE'").ToList().Count;
                NumberInternationalJournal = ds.Tables[0].Select(ByCode + " and papertype = 'TAPCHIQUOCTE'").ToList().Count;
                NumberInternationalJournalISI = ds.Tables[0].Select(ByCode + " and papertype = 'TAPCHIISI'").ToList().Count +
                                        ds.Tables[0].Select(ByCode + " and papertype = 'TAPCHIISIE'").ToList().Count;
                result.Rows.Add(fullName, TotalPaper, NumberDomesticConference, NumberDomesticJournal,
                                NumberInternationalConference, NumberInternationalJournal, NumberInternationalJournalISI);
            }
            ds.Tables.Clear();
            ds.Tables.Add(result);
        }

        public int getDepartmentPapers(ref DataSet ds, string tableName,
                                       string departmentcode, int GetLevel, 
                                       ReportType typeReport, SubLevelTypeReport sublevel,
                                       DateTime beginDate, DateTime endDate)
        {
            #region SQL truy vấn
            string sql = "";
            sql = @"with FullName_cte as 
                    (
                        select    
	                        charindex(' ', s.name) -1 as FirstNameEnd,	
                            len(s.name) - charindex(' ',reverse(s.name)) +2  as LastNameStart,
                            s.code, s.name, departmentcode, researchdepartmentcode, 
		                    academiclevelcode, academictitlecode, degreecode
                        from staff s LEFT join staffstatus on staffstatus.code = s.staffstatus
				                        left join academiclevel on academiclevel.code = s.academiclevelcode					
					                    left join academictitle on academictitle.code = s.academictitlecode
					                    left join degree on degree.code = s.degreecode			
                        where isnull(staffstatus.isstaff,0) <= 1 and isnull(academiclevel.comparelevel,0) < 10 
                                and s.researchstatus > 0
                    ) 							
                    select distinct upper(paper.name) tenbaibao, paper.authorprint author, papertype.codeview papertype,
		                    isnull(B.codeview, '') academictitle, isnull(C.codeview,'') academiclevel, isnull(D.codeview,'') degree, 
                            isnull(B.comparelevel, '99') academictitlecomparelevel, isnull(D.comparelevel,'99') degreecomparelevel,
                            department.code departmentcode, department.parentcode facultycode,
                            isnull(paper.ISBN,'') ISBN, isnull(paper.expertgroupcode, '') expertgroupcode, 
                            isnull(paper.mark, 0) mark, isnull(staffpaper.researchsupport,0) researchsupport,
							(select name from department tmp where tmp.code = department.parentcode) facultyname,
		                    case 
			                    when paper.authorprint <> '' then paper.authorprint + ', '
                            else ''
                            end  + 								        
		                    case  
			                    when paper.name <> '' then paper.name + ', '
			                    else ''
                            end  + 
                            case  
			                    when paper.journalname <> '' then paper.journalname + ', '
			                    else ''
                            end  + 
                            case  
			                    when paper.journalnumber <> '' then paper.journalnumber + ', '
			                    else ''
                            end +								
		                    case  
			                    when paper.page <> '' then paper.page + ', '
			                    else ''
                            end +                              
                                isnull(paper.publishdateshow,'')  name,
                            papertype.name level, paperrole.name role, paper.numberauthor numberauthors, 
       	
		                    department.name department, T.name fullname, T.code,
                        substring(T.name,0,FirstNameEnd+1) as FirstName,
                        case 
                            when FirstNameEnd+2 = LastNameStart then '' 
                            else substring(T.name, FirstNameEnd+2, LastNameStart-FirstNameEnd-2)
                        end as MiddleName,
                        substring(T.name, LastNameStart, len(T.name)) as LastName, publishdateshow publishdate
                    from staffpaper 
	                    inner join paper on  paper.code = staffpaper.papercode 
	                    inner join papertype on papertype.code = paper.papertypecode
	                    inner join paperrole on paperrole.code = staffpaper.rolecode	
	                    inner join FullName_cte T  on T.code = staffpaper.staffcode
	                    inner join department on department.code = T.departmentcode
                        left JOIN academictitle B ON T.academictitlecode=B.code
	                    LEFT JOIN academiclevel C ON T.academiclevelcode=C.code 	                    
	                    LEFT JOIN degree D ON T.degreecode = D.code 	                    
                    where paper.schoolyear = @year ";
            //Cấp bộ môn
            if (GetLevel == 0)
                sql += @" and T.departmentcode = @departmentcode ";
            else
                if (GetLevel == 1) //Cấp khoa
                    sql += @" and T.departmentcode in (select code from department where parentcode = @departmentcode) ";            
            sql += @" order by publishdate desc, department.name, fullname, upper(paper.name) ";
            #endregion
            DataTable result = new DataTable(tableName);
            if (sql == "")
                return -1;
            #region ADD THAM SỐ
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("departmentcode", departmentcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", beginDate.Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("beginDate", beginDate, SqlDbType.DateTime, 0, 0));
            li.Add(new fieldpara("endDate", endDate, SqlDbType.DateTime, 0, 0));
            #endregion
            int ret = getByQuery(ref ds, tableName, sql, li);            
            return ret;
        }

        public int getDepartmentProjects(ref DataSet ds, string tableName,
                                       string departmentcode, int GetLevel,
                                       ReportType typeReport, SubLevelTypeReport sublevel,
                                       DateTime beginDate, DateTime endDate)
        {
            #region SQL truy vấn
            string sql = "";
            sql = @"with FullName_cte as 
                    (
                        select    
	                        charindex(' ', s.name) -1 as FirstNameEnd,	
                            len(s.name) - charindex(' ',reverse(s.name)) +2  as LastNameStart,
                            s.code, s.name, departmentcode, researchdepartmentcode, 
		                    academiclevelcode, academictitlecode, degreecode
                        from staff s LEFT join staffstatus on staffstatus.code = s.staffstatus
				                        left join academiclevel on academiclevel.code = s.academiclevelcode					
					                    left join academictitle on academictitle.code = s.academictitlecode
					                    left join degree on degree.code = s.degreecode					
                        where isnull(staffstatus.isstaff,0) <= 1 and isnull(academiclevel.comparelevel,0) < 10 
                                and s.researchstatus > 0
                    ) 							
                    select distinct upper(project.name) projectName, project.authorprint author, projecttype.codeview papertype,
		                    isnull(B.codeview, '') academictitle, isnull(B.name, '') academictitlename, 
                            isnull(C.codeview,'') academiclevel, isnull(D.codeview,'') degree, isnull(D.name,'') degreename,
                            isnull(B.comparelevel, '99') academictitlecomparelevel, isnull(D.comparelevel,'99') degreecomparelevel,
                            department.code departmentcode, department.parentcode facultycode,							
                            (select name from department tmp where tmp.code = department.parentcode) facultyname,		                    
							project.name, project.authorprint author, projecttype.codeview projecttype,
							projecttype.name level, projectrole.name role, projectrole.codeview rolecodeview, 
                            project.numberauthor numberauthors, 

                            isnull(project.begintime,'') begintime, isnull(project.endtime,'') endtime,
                            isnull(project.begintimeshow,'') begindate, isnull(project.endtimeshow,'') enddate,
                            isnull(project.finishdate,'') finishdate, isnull(project.finishdateshow,'') finishdateshow,    
                            
                            project.codeview, isnull(project.management,'') management,
							isnull(project.projectvalue,0) projectvalue, 							
							 case 
			                        when project.finishdateshow <> '' then project.finishdateshow + '/' + projectstatus.name
                             else projectstatus.name 
							 end finishdateshowAndResult, isnull(project.finishstatus, '') finishstatus, 
                            
		                    department.name department, T.name fullname, T.code,
                        substring(T.name,0,FirstNameEnd+1) as FirstName,
                        case 
                            when FirstNameEnd+2 = LastNameStart then '' 
                            else substring(T.name, FirstNameEnd+2, LastNameStart-FirstNameEnd-2)
                        end as MiddleName,
                        substring(T.name, LastNameStart, len(T.name)) as LastName
                    from staffproject
	                    inner join project on  project.code = staffproject.projectcode
	                    inner join projecttype on projecttype.code = project.projecttypecode
	                    inner join projectrole on projectrole.code = staffproject.rolecode	
	                    inner join FullName_cte T  on T.code = staffproject.staffcode
                        inner join projectstatus on projectstatus.codelink = project.status
	                    inner join department on department.code = T.departmentcode
                        left JOIN academictitle B ON T.academictitlecode=B.code
	                    LEFT JOIN academiclevel C ON T.academiclevelcode=C.code 	                    
	                    LEFT JOIN degree D ON T.degreecode = D.code 	                    
                    where (project.approvedstatus = 2) and projectrole.codeview = 'CH'
                    and not (begintime >@endDate OR dbo.maxdate(dbo.maxdate(endtime,retime1),retime2)<@beginDate) ";
            //Cấp bộ môn
            if (GetLevel == 0)
                sql += @" and T.departmentcode = @departmentcode ";
            else
                if (GetLevel == 1) //Cấp khoa
                    sql += @" and T.departmentcode in (select code from department where parentcode = @departmentcode) ";
            sql += @" order by begintime desc, department.name, fullname ";
            #endregion
            DataTable result = new DataTable(tableName);
            if (sql == "")
                return -1;
            #region ADD THAM SỐ
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("departmentcode", departmentcode, SqlDbType.VarChar, 0, 0));
            li.Add(new fieldpara("year", beginDate.Year, SqlDbType.Int, 0, 0));
            li.Add(new fieldpara("beginDate", beginDate, SqlDbType.DateTime, 0, 0));
            li.Add(new fieldpara("endDate", endDate, SqlDbType.DateTime, 0, 0));
            #endregion
            int ret = getByQuery(ref ds, tableName, sql, li);
            return ret;
        }
    }

}

