using System;
using Microsoft.Practices.Unity;
using Microsoft.Reporting.WebForms;
using TMD.Interfaces.IServices;
using TMD.WebBase.UnityConfiguration;

namespace TMD.Web.ReportsFiles
{
    public partial class Expenses : System.Web.UI.Page
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
            ExpensesReportViewer.ProcessingMode = ProcessingMode.Local;
            ExpensesReportViewer.LocalReport.ReportPath = Server.MapPath("~/ReportsFiles/Expenses.rdlc");

            string vendor = txtVendorName.Text;
            int year = Convert.ToInt32(ddlYear.SelectedValue);
            int month = Convert.ToInt32(ddlMonth.SelectedValue);

            var reportData = ReportsService.ExpensesReport(year, month, vendor);
            ReportDataSource reportDataSource = new ReportDataSource
            {
                Name = "DataSet1",
                Value = reportData
            };

            ExpensesReportViewer.LocalReport.DataSources.Clear();
            ExpensesReportViewer.LocalReport.DataSources.Add(reportDataSource);
        }
    }
}