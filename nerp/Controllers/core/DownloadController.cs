using System;
using System.Collections.Generic;
using System.IO;
using System.Web.Mvc;
using IS.fitframework;
using IS.localcomm;
using IS.Sess;
using IS.uni;
using Microsoft.Reporting.WebForms;
//using IS.report;

//using OfficeOpenXml;

namespace nerp.Controllers.core
{
    public class DownloadController : Controller
    {
        localcommonlib com = new localcommonlib();
        session ses = new session();
        private string mimeType;

        // GET: Download
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
       
        public ActionResult subject1(string id)//, string codeView, bool typeCodeView, string name, bool typeName, string note, bool typeNote)
        {
            

            int i = 0;int k = 0;

            k = id.IndexOf('-', i + 1);
            string ID = id.Substring(i, k-i);

            i = k+1;
            k = id.IndexOf('-', i);
            string codeView =id.Substring(i,k-i);

            i = k+1;
            k = id.IndexOf('-', i );
            bool typeCodeView = Convert.ToBoolean(id.Substring(i, k-i));

            i = k+1;
            k = id.IndexOf('-', i );
            string name = id.Substring(i, k-i);

            i = k+1;
            k = id.IndexOf('-', i );
            bool typeName = Convert.ToBoolean(id.Substring(i, k-i));

            i = k+1;
            k = id.IndexOf('-', i );
            string note = id.Substring(i, k-i);

            i = k+1;
            k = id.IndexOf('-', i );
            bool typeNote = Convert.ToBoolean(id.Substring(i, k-i));

            LocalReport lr = new LocalReport();
            string path = Path.Combine(Server.MapPath("~/report"), "DMDonvi.rdlc");
            if (System.IO.File.Exists(path))
            {
                lr.ReportPath = path;
            }
            else
            {
                //return View("Index");
            }

            DEPARTMENT_BUS bus = new DEPARTMENT_BUS();
            List<fieldpara> lipa = new List<fieldpara>();
            if (!string.IsNullOrEmpty(codeView))
            {
                if (typeCodeView)
                    lipa.Add(new fieldpara("CODEVIEW", codeView, 0));
                else
                    lipa.Add(new fieldpara("CODEVIEW", codeView, 1));
            }
            if (!string.IsNullOrEmpty(name))
            {
                if (typeName)
                    lipa.Add(new fieldpara("NAME", name, 0));
                else
                    lipa.Add(new fieldpara("NAME", name, 1));
            }
            if (!string.IsNullOrEmpty(note))
            {
                if (typeNote)
                    lipa.Add(new fieldpara("NOTE", note, 0));
                else
                    lipa.Add(new fieldpara("NOTE", note, 1));
            }
            lipa.Add(new fieldpara("UNIVERSITYCODE", ses.gUNIVERSITYCODE, 0));

            List<DEPARTMENT_OBJ> li = bus.getAllBy2("CODEVIEW", lipa.ToArray());
            bus.CloseConnection();

            ReportDataSource rd = new ReportDataSource("DataSet1", li);
            lr.DataSources.Add(rd);

            string reportType = ID;
            string mineType;
            string encoding;
            string fileNameExtension;

            string deviceInfo = "<DeviceInfo>" +
                "  <OutputFormat>" + ID + "</OutputFormat>" +
                "  <PageWidth>8.5in</PageWidth>" +
                "  <PageHeight>11in</PageHeight>"+
                "  <MarginTop>0.5in</MarginTop>"+
                "  <MarginLeft>1in</MarginLeft>" +
                "  <MarginRight>1in</MarginRight>" +
                "  <MarginBottom>0.5in</MarginBottom>" +
                "</DeviceInfo>";

            Warning[] warnings;
            string[] streams;
            byte[] renderedBytes;
            renderedBytes = lr.Render(reportType,
                                deviceInfo,
                                out mineType,
                                out encoding,
                                out fileNameExtension,
                                out streams,
                                out warnings);

            return File(renderedBytes, mineType);
        }
      
    }
}