using System;
using TMD.Models.DomainModels;
using TMD.Models.ReportsModels;

namespace TMD.Models.ModelMapers.ReportsMappers
{
    public static class PurchaseReportMapper
    {
        public static PurchaseReport CreateReport(this InventoryItem source)
        {
            PurchaseReport report = new PurchaseReport();

            report.VendorId = source.VendorId;
            report.ProductCode = source.ProductId;
            report.ProductName = source.Product.Name;
            report.PurchasedQuantity = source.Quantity;
            report.PurchasingDate = source.PurchasingDate;
            report.VendorName = source.Vendor.Name;

            return report;
        }
    }
}
