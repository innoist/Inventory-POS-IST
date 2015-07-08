using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;

namespace TMD.Web.Models
{
    public class OrderItemModel
    {
        public long OrderItemId { get; set; }
        public long ProductId { get; set; }
        public int Quantity { get; set; }
        public long OrderId { get; set; }
        public decimal PurchasePrice { get; set; }
        //THIS IS THE TOTAL PRICE
        public decimal AmountGiven { get; set; }
        public decimal SalePrice { get; set; }
        public decimal MinSalePriceAllowed { get; set; }
        public int Discount { get; set; }
        public string Comments { get; set; }
        public System.DateTime RecCreatedDate { get; set; }
        public System.DateTime RecLastUpdatedDate { get; set; }
        public string RecCreatedBy { get; set; }
        public string RecLastUpdatedBy { get; set; }

        public bool IsModified { get; set; }

        public decimal TotalItemAmount
        {
            get { return Quantity*SalePrice - Discount; }
        }
        //Calculated field
        public decimal Subtotal
        {
            get { return Quantity * SalePrice; }
        }
        public ProductModel Product { get; set; }
    
    }
}