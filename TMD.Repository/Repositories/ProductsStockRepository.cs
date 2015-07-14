using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Models.ReportsModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class ProductsStockRepository: BaseRepository<ProductsStock>, IProductsStockRepository    
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductsStockRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ProductsStock> DbSet
        {
            get { return db.ProductsStocks; }
        }
        #endregion

        public IEnumerable<ProductsStock> StocksReport(string barCode, string productCode, string productName)
        {
           return DbSet.Where(x => x.ProductId.ToString() == productCode || x.Name.Contains(productName)).ToList();
        }
    }
}
