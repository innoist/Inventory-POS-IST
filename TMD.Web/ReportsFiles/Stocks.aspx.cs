using System;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using TMD.Interfaces.IServices;
using TMD.WebBase.UnityConfiguration;

namespace TMD.Web.ReportsFiles
{
    public partial class Stocks : System.Web.UI.Page
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
            StocksReportViewer.ProcessingMode = ProcessingMode.Local;
            StocksReportViewer.LocalReport.ReportPath = Server.MapPath("~/ReportsFiles/Stocks.rdlc");

            string productCode = txtProductCode.Text;
            string barCode = "";//txtBarcode.Text;
            string name = txtProductName.Text;


            var reportData = ReportsService.StocksReport(barCode, productCode,name);
            ReportDataSource reportDataSource = new ReportDataSource
            {
                Name = "DataSet1",
                Value = reportData
            };

            StocksReportViewer.LocalReport.DataSources.Clear();
            StocksReportViewer.LocalReport.DataSources.Add(reportDataSource);
        }
    }
}