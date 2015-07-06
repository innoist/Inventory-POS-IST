using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.Common;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class InventoryItemRepository: BaseRepository<InventoryItem>, IInventoryItemRepositoy
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public InventoryItemRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<InventoryItem> DbSet
        {
            get { return db.InventoryItems; }
        }

        readonly Dictionary<InventoryItemByColumn, Func<InventoryItem, object>> requestClause =
           new Dictionary<InventoryItemByColumn, Func<InventoryItem, object>>
                {
                    {InventoryItemByColumn.Code, c => c.ProductId},
                    {InventoryItemByColumn.Name, c => c.Product.Name},
                    {InventoryItemByColumn.PurchaseDate, c => c.PurchasingDate},
                    {InventoryItemByColumn.Quantity, c => c.Quantity},
                    {InventoryItemByColumn.Vendor, c => c.VendorId}
                };
        #endregion

        public long GetItemCountInInventory(long productId)
        {
            return DbSet.Where(x => x.ProductId == productId).Select(r => r.Quantity).DefaultIfEmpty(0).Sum();
        }

        public InventoryItemSearchResponse GetInventoryItemSearchResponse(InventoryItemSearchRequest searchRequest)
        {
            int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            int toRow = searchRequest.PageSize;
            Expression<Func<InventoryItem, bool>> query =
                    s => (
                            (
                            (searchRequest.ProductCode == 0 || s.ProductId.Equals(searchRequest.ProductCode))
                            && (searchRequest.Vendor == 0 || s.VendorId.Equals(searchRequest.Vendor))
                            && (string.IsNullOrEmpty(searchRequest.Barcode) || s.Product.ProductBarCode.Contains(searchRequest.Barcode))
                            && (string.IsNullOrEmpty(searchRequest.Name) || s.Product.Name.Contains(searchRequest.Name))
                            && (searchRequest.PurchaseDate == null || DbFunctions.TruncateTime(s.PurchasingDate)==searchRequest.PurchaseDate)
                            )
                        );
            IEnumerable<InventoryItem> result =
                searchRequest.IsAsc
                    ? DbSet.Where(query)
                        .OrderBy(requestClause[searchRequest.ItemOrderBy])
                        .Skip(fromRow)
                        .Take(toRow)
                        .ToList()
                    : DbSet.Where(query)
                        .OrderByDescending(requestClause[searchRequest.ItemOrderBy])
                        .Skip(fromRow)
                        .Take(toRow)
                        .ToList();

            return new InventoryItemSearchResponse { InventoryItems = result, TotalCount = DbSet.Count(), FilteredCount = DbSet.Count(query) };

        }
    }
}
