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
    public class SYSMENU_BUS: BusinessController<SYSMENU_OBJ, SYSMENU_OBJ.BusinessObjectID>
    {
        public SYSMENU_BUS()
        {
        }
        public override SYSMENU_OBJ createObject()
        {
            SYSMENU_OBJ obj = new SYSMENU_OBJ();
            this.setNull(obj);
            return obj;
        }
        public override SYSMENU_OBJ createNull()
        {
            return null;
        }
        /// <summary>
        /// get all backend menu based on the permission of the current user
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="permission">permission in the IN format of SQL commands</param>
        /// <returns></returns>
        public int getMenu(ref DataSet ds, string tableName, string permission)
        {
            string sql = @"select distinct A.code, a.codeview, A.name, a.note, a.lock, isnull(a.parentcode,'') parentcode, theorder, icon, link from SYSMENU A LEFT JOIN 
(
select * from sysmenupriority where prioritycode in (" +permission+@")
) B ON A.code=B.sysmenucode
WHERE isnull(a.lock,0)=0 AND A.thetype='BACKEND' AND ((not(B.prioritycode is null)) or (ISNULL(A.parentcode,'')=''))
order by A.theorder";
            List<fieldpara> li = new List<fieldpara>();
            int ret=getByQuery(ref ds, tableName,sql, li);
            return ret;
        }
        /// <summary>
        /// get all backend menu in a parent group
        /// </summary>
        /// <param name="ds"></param>
        /// <param name="tableName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        public int getMenuFull(ref DataSet ds, string tableName, string code)
        {
            string sql = "";
            List<fieldpara> li = new List<fieldpara>();
            if (code == "")
            {
                sql = @"select A.*, '' groupname from (SELECT [code],[name],[codeview],[icon],isnull([parentcode],'') parentcode,[theorder],isnull([link],'#') link,  prioritycode, [lock] FROM [SYSMENU] where isnull(parentcode,'') ='' AND thetype='BACKEND') A  ORDER BY a.[theorder]";
            }
            else
            {
                sql = @"select A.* from (SELECT [code],[name],[codeview],[icon],isnull([parentcode],'') parentcode,[theorder],isnull([link],'#') link,[prioritycode], [lock] FROM [SYSMENU] where isnull(parentcode,'') =@code AND thetype='BACKEND') A   ORDER BY a.[theorder]";
                li.Add(new fieldpara("CODE",code, SqlDbType.VarChar,0,0));
            }
            return getByQuery(ref ds, tableName, sql, li);
        }
        public int saveFile(string fileName)
        {
            int ret = 0;
            if (db.Open() != 0)
            {
                return -1;//cannot open connection
            }
            string database = db.getConnectInfo().conn.Database;

            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "BACKUP DATABASE "+database+" TO DISK='" + fileName + "' WITH FORMAT;";
            cmd.CommandType = CommandType.Text;

            if (db.doCommand(ref cmd) != 0)
            {
                ret = -2;
            }
            db.Close();
            return ret;
        }
        #region Cho phan xu ly du lieu import
        public int temp_getSubjectList(ref DataSet ds, string tableName)
        {
            string sql = @"select * FROM 
(
select 
case 
	when hinhthuc1 is null then  'LT' 
	when hinhthuc1=N'Thi thường xuyên' then  'LT' 
	when hinhthuc1=N'Thi thường xuyên   T' then  'LT' 
	when hinhthuc1=N'Thi tốt nghiệp' then  '1404050001' 
END learningtypecode,* FROM 
(
select dbo.TCVN2Unicode(tenmh) tenmh1, dbo.TCVN2Unicode(hinhthuc) hinhthuc1 ,* from monhoc
) A
) B ";
            List<fieldpara> li = new List<fieldpara>();
            return getByQuery(ref ds, tableName, sql, li);
        }
        #endregion

        //public int getMenubyParentID(ref DataSet ds, string parentCode)
        //{
        //    string sql = @"SELECT [code],[name],[shortname],[icon],[parentcode],[order],[link],[showtop],[groupcode] FROM [SYSMENU] where isnull(parentcode,'') =@parentcode ORDER BY [order]";
        //    SqlCommand cm = db.createCommandSQL(sql
        //        , new spParam("@parentcode", SqlDbType.VarChar, parentCode, ParameterDirection.Input));
        //    return db.getCommand(ref ds, ref cm);
        //}

        /// <summary>
        /// Lấy tất cả các menu admin thỏa mãn phân quyền được đưa vào
        /// </summary>
        /// <param name="universitycode">Trường</param>
        /// <param name="pris">Danh sách các phân quyền 'dd','ggg' theo session</param>
        /// <returns></returns>
        public List<SYSMENU_OBJ> getAdmin(string universitycode, string pris)
        {
            List<SYSMENU_OBJ> litemp = new List<SYSMENU_OBJ>();
            List<SYSMENU_OBJ> li = new List<uni.SYSMENU_OBJ>();
            //            string sql = @"select  distinct A.* from sysmenu A
            //LEFT join sysmenupriority B ON A.code=B.sysmenucode
            //where ISNULL(A.lock,0)=0 AND A.universitycode=@universitycode  and A.thetype='BACKEND' AND (B.prioritycode in ({0})  or ISNULL(a.parentcode,'')='' or A.prioritycode='EVERYONE') order by a.theorder desc";
            //or ISNULL(a.parentcode,'')='' 
            string sql = @"with BA
AS
(
select  distinct A.* from sysmenu 
A LEFT join sysmenupriority B ON A.code=B.sysmenucode where ISNULL(A.lock,0)=0 AND A.universitycode=
@universitycode  and A.thetype='BACKEND' AND (B.prioritycode in ({0})  or A.prioritycode='EVERYONE') 
)
select distinct * from 
(
select * from BA
union 
select C.* from sysmenu A
inner join BA B on a.code=B.parentcode
inner join sysmenu C ON C.code=A.parentcode
union
select A.* from sysmenu A
inner join BA B on a.code=B.parentcode
) AA order by theorder desc";
            sql = string.Format(sql, pris);
            DataSet ds = new DataSet();
            int ret = 0;
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("universitycode", universitycode, 0, 0));
            ret = getByQuery(ref ds, "menu", sql, lipa);
            if (ret >= 0)
            {
                //parse to list
                DataRow[] drp = ds.Tables["menu"].Select("(parentcode is null) or (parentcode='')");
                foreach (DataRow dr in drp)
                {
                    SYSMENU_OBJ obj = createObjectFromRow(dr);
                    litemp.Add(obj);
                }
                while (litemp.Count > 0)
                {
                    SYSMENU_OBJ obj = litemp.Last();
                    litemp.Remove(obj);
                    li.Add(obj);
                    DataRow[] drs = ds.Tables["menu"].Select("(parentcode='" + obj.CODE + "')");
                    foreach (DataRow dr in drs)
                    {
                        SYSMENU_OBJ obj1 = createObjectFromRow(dr);
                        litemp.Add(obj1);
                    }
                }
                //foreach (DataRow dr in drp)
                //{
                //    SYSMENU_OBJ obj = createObjectFromRow(dr);
                //    DataRow[] drc = ds.Tables["menu"].Select(string.Format("parentcode='{0}'", obj.CODE.Replace("'", "''")));
                //    if (drc.Length > 0)
                //    {
                //        li.Add(obj);
                //        foreach (DataRow item in drc)
                //        {
                //            SYSMENU_OBJ objc = createObjectFromRow(item);
                //            li.Add(objc);
                //        }
                //    }
                //}
            }
            return li;
        }
        /// <summary>
        /// Lấy danh sách menu của sinh viên
        /// </summary>
        /// <param name="universitycode"></param>
        /// <param name="pris"></param>
        /// <returns></returns>
        public List<SYSMENU_OBJ> getStudent(string universitycode, string pris)
        {
            List<SYSMENU_OBJ> litemp = new List<SYSMENU_OBJ>();
            List<SYSMENU_OBJ> li = new List<uni.SYSMENU_OBJ>();
            //            string sql = @"select  distinct A.* from sysmenu A
            //LEFT join sysmenupriority B ON A.code=B.sysmenucode
            //where ISNULL(A.lock,0)=0 AND A.universitycode=@universitycode  and A.thetype='BACKEND' AND (B.prioritycode in ({0})  or ISNULL(a.parentcode,'')='' or A.prioritycode='EVERYONE') order by a.theorder desc";
            string sql = @"with BA
AS
(
select  distinct A.* from sysmenu 
A LEFT join sysmenupriority B ON A.code=B.sysmenucode where ISNULL(A.lock,0)=0 AND A.universitycode=
@universitycode  and A.thetype='TOPMENU' AND (B.prioritycode in ({0})  or ISNULL(a.parentcode,'')='' or A.prioritycode='EVERYONE') 
)
select distinct * from 
(
select * from BA
union 
select C.* from sysmenu A
inner join BA B on a.code=B.parentcode
inner join sysmenu C ON C.code=A.parentcode
union
select A.* from sysmenu A
inner join BA B on a.code=B.parentcode
) AA order by theorder desc";
            sql = string.Format(sql, pris);
            DataSet ds = new DataSet();
            int ret = 0;
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("universitycode", universitycode, 0, 0));
            ret = getByQuery(ref ds, "menu", sql, lipa);
            if (ret >= 0)
            {
                //parse to list
                DataRow[] drp = ds.Tables["menu"].Select("(parentcode is null) or (parentcode='')");
                foreach (DataRow dr in drp)
                {
                    SYSMENU_OBJ obj = createObjectFromRow(dr);
                    litemp.Add(obj);
                }
                while (litemp.Count > 0)
                {
                    SYSMENU_OBJ obj = litemp.Last();
                    litemp.Remove(obj);
                    li.Add(obj);
                    DataRow[] drs = ds.Tables["menu"].Select("(parentcode='" + obj.CODE + "')");
                    foreach (DataRow dr in drs)
                    {
                        SYSMENU_OBJ obj1 = createObjectFromRow(dr);
                        litemp.Add(obj1);
                    }
                }
                //foreach (DataRow dr in drp)
                //{
                //    SYSMENU_OBJ obj = createObjectFromRow(dr);
                //    DataRow[] drc = ds.Tables["menu"].Select(string.Format("parentcode='{0}'", obj.CODE.Replace("'", "''")));
                //    if (drc.Length > 0)
                //    {
                //        li.Add(obj);
                //        foreach (DataRow item in drc)
                //        {
                //            SYSMENU_OBJ objc = createObjectFromRow(item);
                //            li.Add(objc);
                //        }
                //    }
                //}
            }
            return li;
        }
        /// <summary>
        /// Lấy danh sách các menu ở trên
        /// </summary>
        /// <param name="universitycode"></param>
        /// <param name="pris"></param>
        /// <returns></returns>
        public List<SYSMENU_OBJ> getAdminTop(string universitycode, string pris)
        {
            List<SYSMENU_OBJ> litemp = new List<SYSMENU_OBJ>();
            List<SYSMENU_OBJ> li = new List<uni.SYSMENU_OBJ>();
            //            string sql = @"select  distinct A.* from sysmenu A
            //LEFT join sysmenupriority B ON A.code=B.sysmenucode
            //where ISNULL(A.lock,0)=0 AND A.universitycode=@universitycode  and A.thetype='BACKEND' AND (B.prioritycode in ({0})  or ISNULL(a.parentcode,'')='' or A.prioritycode='EVERYONE') order by a.theorder desc";
            string sql = @"with BA
AS
(
select  distinct A.* from sysmenu 
A LEFT join sysmenupriority B ON A.code=B.sysmenucode where ISNULL(A.lock,0)=0 AND A.universitycode=
@universitycode  and A.thetype='TOPMENU' AND (B.prioritycode in ({0})  or ISNULL(a.parentcode,'')='' or A.prioritycode='EVERYONE') 
)
select distinct * from 
(
select * from BA
union 
select C.* from sysmenu A
inner join BA B on a.code=B.parentcode
inner join sysmenu C ON C.code=A.parentcode
union
select A.* from sysmenu A
inner join BA B on a.code=B.parentcode
) AA order by theorder desc";
            sql = string.Format(sql, pris);
            DataSet ds = new DataSet();
            int ret = 0;
            List<fieldpara> lipa = new List<fieldpara>();
            lipa.Add(new fieldpara("universitycode", universitycode, 0, 0));
            ret = getByQuery(ref ds, "menu", sql, lipa);
            if (ret >= 0)
            {
                //parse to list
                DataRow[] drp = ds.Tables["menu"].Select("(parentcode is null) or (parentcode='')");
                foreach (DataRow dr in drp)
                {
                    SYSMENU_OBJ obj = createObjectFromRow(dr);
                    litemp.Add(obj);
                }
                while (litemp.Count > 0)
                {
                    SYSMENU_OBJ obj = litemp.Last();
                    litemp.Remove(obj);
                    li.Add(obj);
                    DataRow[] drs = ds.Tables["menu"].Select("(parentcode='" + obj.CODE + "')");
                    foreach (DataRow dr in drs)
                    {
                        SYSMENU_OBJ obj1 = createObjectFromRow(dr);
                        litemp.Add(obj1);
                    }
                }
                //foreach (DataRow dr in drp)
                //{
                //    SYSMENU_OBJ obj = createObjectFromRow(dr);
                //    DataRow[] drc = ds.Tables["menu"].Select(string.Format("parentcode='{0}'", obj.CODE.Replace("'", "''")));
                //    if (drc.Length > 0)
                //    {
                //        li.Add(obj);
                //        foreach (DataRow item in drc)
                //        {
                //            SYSMENU_OBJ objc = createObjectFromRow(item);
                //            li.Add(objc);
                //        }
                //    }
                //}
            }
            return li;
        }
        /// <summary>
        /// get all front end menu for about, etc.
        /// </summary>
        /// <param name="menu"></param>
        /// <returns></returns>
        public List<SYSMENU_OBJ> getFont(string menu)
        {
            string sql = @"
        with abc as (select *,0 __ord from sysmenu where codeview =@codeview and lock=0),
        bcd as (select a.*,1000*A.theorder __ord from sysmenu A Inner join abc B On a.parentcode=B.code and a.lock=0),
        cde as (select a.*, B.__ord + A.theorder __ord from sysmenu A Inner join bcd B On a.parentcode=B.code and a.lock=0)
        select * from 
        (
        select * from abc
        union all
        select * from bcd
        union all
        select * from cde
        ) AA order by __ord
        ";
            List<fieldpara> lipa = new List<fieldpara>();
            int ret = 0;
            lipa.Add(new fieldpara("CODEVIEW", menu, 0, 0));
            DataSet ds = new DataSet();
            string tableName = "menu";
            ret = getByQuery(ref ds, tableName, sql, lipa);
            List<SYSMENU_OBJ> li = new List<SYSMENU_OBJ>();
            if (ret >= 0)
            {
                foreach (DataRow dr in ds.Tables[tableName].Rows)
                {
                    SYSMENU_OBJ obj = createObjectFromRow(dr);
                    li.Add(obj);
                }
            }
            ds.Dispose();
            return li;
        }
    }

}

