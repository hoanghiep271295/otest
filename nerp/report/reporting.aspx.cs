using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using IS.Base;
using IS.Comm;
using IS.fitframework;
using IS.Sess;
using IS.localcomm;
using System.Drawing;
using Microsoft.Reporting.WebForms;
using IS.uni;
using IS.report;
namespace nerp.report
{
    public partial class reporting : System.Web.UI.Page
    {
        localcommonlib com = new localcommonlib();
        protected void Page_Load(object sender, EventArgs e)
        {
            if(IsPostBack)
            {
                return;
            }
            string reporttype = com.getValue(this, "reporttype", "DEFAULT");
            switch(reporttype)
            {
                //Mỗi type khác nhau sẽ gọi một hàm ở dưới
                case "DEFAULT":
                    callreport();
                    break;
                case "DEPARTMENT":
                    Departmentreport();
                    break;
                case "STAFF":
                    Staffreport();
                    break;
                case "ARMYRANK":
                    Armyrankreport();
                    break;
                case "LEVELTITLE":
                    Leveltitlereport();
                    break;
                case "RELIGION":
                    Religionreport();
                    break;
                case "PROVINCE":
                    Provincereport();
                    break;
                case "DISTRICT":
                    Districtreport();
                    break;
                case "TOWN":
                    Townreport();
                    break;
                case "NATION":
                    Nationreport();
                    break;
                case "WAREHOUSELEVEL":
                    Warehouselevelreport();
                    break;
            }



        }
        /// <summary>
        /// Hàm thực hiện để in departement
        /// </summary>
        void callreport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                rprp._default(parentcode,out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();
               
            }
        }
        void Departmentreport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.department(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();
            }
        }
        void Staffreport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.staff(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();
            }
        }
        void Armyrankreport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.armyrank(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();

            }
        }
        void Leveltitlereport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.leveltitle(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();

            }
        }
        void Religionreport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.Religion(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();

            }
        }
        void Provincereport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.Province(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();

            }
        }
        void Districtreport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.District(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();

            }
        }
        void Townreport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.Town(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();

            }
        }
        void Nationreport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.nation(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();

            }
        }

        void Warehouselevelreport()
        {
            string parentcode = com.getValue(this, "code", "");
            int ret = 0;
            if (ret >= 0)
            {
                rdlcreport rprp = new rdlcreport();
                rpViewer.Reset();
                ReportDataSource rpd;
                ReportParameter[] rpp;
                string filename;
                string title;
                //Gọi hàm chuẩn bị report theo đúng chuẩn bị
                rprp.warehouselevel(parentcode, out rpd, out rpp, out filename, out title);
                rpViewer.LocalReport.DataSources.Add(rpd);
                rpViewer.LocalReport.ReportPath = Server.MapPath("/") + filename;
                rpViewer.LocalReport.SetParameters(rpp);
                rpViewer.LocalReport.Refresh();

            }
        }
    }
}