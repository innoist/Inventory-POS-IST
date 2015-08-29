using System;
using System.Web.UI;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using TMD.Interfaces.IServices;
using TMD.WebBase.UnityConfiguration;

namespace TMD.Web.ReportsFiles
{
    public partial class SalesSummary : Page
    {
        public IReportsService ReportsService { get; set; }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Page.IsPostBack)
            {
                return;
            }

            GenerateReport();
        }

        protected void btnFilter_OnClick(object sender, EventArgs e)
        {
            GenerateReport();
        }

        private void GenerateReport()
        {
            ReportsService = UnityWebActivator.Container.Resolve<IReportsService>();
            //string name = TextBox1.Text;
            SalesReportViewer.ProcessingMode = ProcessingMode.Local;
            SalesReportViewer.LocalReport.ReportPath = Server.MapPath("~/ReportsFiles/SalesSummary.rdlc");


            DateTime endDate = string.IsNullOrEmpty(txtTo.Text) ? DateTime.Now : Convert.ToDateTime(txtTo.Text);
            DateTime startDate = string.IsNullOrEmpty(txtFrom.Text) ? DateTime.Now : Convert.ToDateTime(txtFrom.Text);
            //DateTime startDate = string.IsNullOrEmpty(txtFrom.Text) ? new DateTime(endDate.Year,endDate.Month,1) : Convert.ToDateTime(txtFrom.Text);
            
            //var reportData = ReportsService.SalesSummaryReport(startDate,endDate);
            var reportData = ReportsService.SalesSummaryResultByDateRange(startDate,endDate);
            ReportDataSource reportDataSource = new ReportDataSource
            {
                Name = "DataSet1",
                Value = reportData
            };

            SalesReportViewer.LocalReport.DataSources.Clear();
            SalesReportViewer.LocalReport.DataSources.Add(reportDataSource);
        }
    }
}