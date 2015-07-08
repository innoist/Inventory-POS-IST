using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Web.Models;

namespace TMD.Web.ViewModels
{
    public class OrderViewModel
    {
        public OrderSearchRequest SearchRequest { get; set; }

        public List<OrderListViewModel> data { get; set; }

        /// <summary>
        /// Total Records in DB
        /// </summary>
        public int recordsTotal;

        /// <summary>
        /// Total Records Filtered
        /// </summary>
        public int recordsFiltered;
    }
}