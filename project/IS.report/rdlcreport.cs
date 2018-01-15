using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS.Sess;
using IS.localcomm;
using System.Data;
using Microsoft.Reporting.WebForms;
using IS.uni;
using IS.fitframework;

namespace IS.report
{
    public class rdlcreport
    {
        session ses = new session();

        /// <summary>
        /// Thực hiện tính toán dữ liệu phục vụ cho việc danh sách các phòng ban
        /// </summary>
        /// <param name="datasource"></param>
        /// <param name="parameter"></param>
        /// <param name="filename"></param>
        /// <param name="title"></param>
        /// <returns></returns>
        /// 
        public int _default(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            DEPARTMENT_BUS bus = new DEPARTMENT_BUS();
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            li.Add(new fieldpara("parentcode", parentcode));
            ret = bus.getAllBy2(ref ds, "DataSet1", "codeview", li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSet1", ds.Tables["DataSet1"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[] { };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/danhsach.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách";
            return 0;
        }

        public int department(string parentcode,out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title )
        {
            int ret = 0;
            DEPARTMENT_BUS bus = new DEPARTMENT_BUS();
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            li.Add(new fieldpara("parentcode", parentcode));
            ret = bus.getAllBy2(ref ds, "DataSet1", "codeview",li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSet1", ds.Tables["DataSet1"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[] { };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/danhsachdonvi.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách phòng ban";
            return 0;
        }

        public int staff(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            var depart = new DEPARTMENT_BUS().GetByID(new DEPARTMENT_OBJ.BusinessObjectID(parentcode));
            var nameDepartment = depart.NAME;

            STAFF_BUS bus = new STAFF_BUS();
            List<fieldpara> li = new List<fieldpara>();
            li.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));
            li.Add(new fieldpara("DEPARTMENTCODE", parentcode));
            //if (!string.IsNullOrEmpty(name))
            //{
            //    lipa.Add(new fieldpara("NAME", name, (int)(nametype.ToUpper() == "TRUE" ? searchType.NONE : searchType.LIKE)));
            //}
            //if (!string.IsNullOrEmpty(note))
            //{
            //    lipa.Add(new fieldpara("NOTE", note, (int)(notetype.ToUpper() == "TRUE" ? searchType.NONE : searchType.LIKE)));
            //}
            DataSet ds = new DataSet();
            
            ret = bus.getAllBy2(ref ds, "DataSet1", "codeview", li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSet1", ds.Tables["DataSet1"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[] {
                new ReportParameter("nameDepartment", "Đơn vị: "+nameDepartment)
            };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/danhsachcbnv.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách cán bộ/nhân viên";
            return 0;
        }
        public int armyrank(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            ARMYRANK_BUS bus = new ARMYRANK_BUS();
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            li.Add(new fieldpara("parentcode", parentcode));
            ret = bus.getAllBy2(ref ds, "DataSetArmyRank", "codeview", li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSetArmyRank", ds.Tables["DataSetArmyRank"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[] { };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/Armyrank/Danhmuccapbac.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách cấp bậc";
            return 0;
        }
        public int leveltitle(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            LEVELTITLE_BUS bus = new LEVELTITLE_BUS();
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            li.Add(new fieldpara("parentcode", parentcode));
            ret = bus.getAllBy2(ref ds, "DataSetLevelTitle", "codeview", li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSetLevelTitle", ds.Tables["DataSetLevelTitle"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[] { };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/Leveltitle/Danhmucchucvu.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách chức vụ";
            return 0;
        }
        public int Religion(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            RELIGION_BUS bus = new RELIGION_BUS();
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            li.Add(new fieldpara("parentcode", parentcode));
            ret = bus.getAllBy2(ref ds, "DataSetReligion", "codeview", li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSetReligion", ds.Tables["DataSetReligion"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[] { };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/Religion/Danhmuctongiao.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách tôn giáo";
            return 0;
        }
        public int Province(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            PROVINCE_BUS bus = new PROVINCE_BUS();
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            li.Add(new fieldpara("parentcode", parentcode));
            ret = bus.getAllBy2(ref ds, "DataSetProvince", "codeview", li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSetProvince", ds.Tables["DataSetProvince"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[] { };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/Province/Danhmuctinh.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách tỉnh/ thành phố";
            return 0;
        }
         public int District(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            var province = new PROVINCE_BUS().GetByID(new PROVINCE_OBJ.BusinessObjectID(parentcode));
            var nameProvince = province.NAME;
            DISTRICT_BUS bus = new DISTRICT_BUS();
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            li.Add(new fieldpara("parentcode", parentcode));
            ret = bus.getAllBy2(ref ds, "DataSetDistrict", "codeview", li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSetDistrict", ds.Tables["DataSetDistrict"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[]
            {
                new ReportParameter("nameProvince", nameProvince) 
            };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/District/Danhmuchuyen.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách huyện";
            return 0;
        }
        public int Town(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            // tìm huyện tương ứng
            var district = new DISTRICT_BUS().GetByID(new DISTRICT_OBJ.BusinessObjectID(parentcode));
            var nameDistrict = district.NAME;
            TOWN_BUS bus = new TOWN_BUS();
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            li.Add(new fieldpara("parentcode", parentcode));
            ret = bus.getAllBy2(ref ds, "DataSetTown", "codeview", li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSetTown", ds.Tables["DataSetTown"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[]
            {
                new ReportParameter("nameDistrict", nameDistrict)
            };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/Town/Danhmucxa.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách xã";
            return 0;
        }


        public int nation(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            NATION_BUS bus = new NATION_BUS();
            List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            li.Add(new fieldpara("parentcode", parentcode));
            ret = bus.getAllBy2(ref ds, "DataSet1", "codeview", li.ToArray());
            bus.CloseConnection();
            //Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSet1", ds.Tables["DataSet1"]);
            datasource = rpd;
            //Danh sách các tham số nếu report có được
            //Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[] { };
            parameter = rpp;
            //Đường dẫn tương đối đến file report
            filename = "report/danhsach.rdlc";
            //Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách";
            return 0;
        }


        public int warehouselevel(string parentcode, out ReportDataSource datasource, out ReportParameter[] parameter, out string filename, out string title)
        {
            int ret = 0;
            //WAREHOUSELEVEL_BUS bus = new WAREHOUSELEVEL_BUS();
            //List<fieldpara> li = new List<fieldpara>();
            DataSet ds = new DataSet();
            //li.Add(new fieldpara("parentcode", parentcode));
            //ret = bus.getAllBy2(ref ds, "DataSet1", "codeview", li.ToArray());
            //bus.CloseConnection();
            ////Trả về datasourse theo đúng tên khi thiết kế
            ReportDataSource rpd = new ReportDataSource("DataSet1", ds.Tables["DataSet1"]);
            datasource = rpd;
            ////Danh sách các tham số nếu report có được
            ////Ví dụ: ReportParameter[] rpp = new ReportParameter[] { new ReportParameter("title", "Helelo"), new ReportParameter("studentinfo", "Người không mang họ") };
            ReportParameter[] rpp = new ReportParameter[] { };
            parameter = rpp;
            ////Đường dẫn tương đối đến file report
            filename = "report/danhsach.rdlc";
            ////Tiêu đề sau này dùng để gán lên trên tiêu đề của tab trong trình duyệt
            title = "Danh sách";
            return 0;
        }

    }
}
