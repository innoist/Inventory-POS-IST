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
    public sealed class ProductRepository: BaseRepository<Product>, IProductRepository
    {
        #region Constructor & Private Properties
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Product> DbSet
        {
            get { return db.Products; }
        }

        readonly Dictionary<ProductByColumn, Func<Product, object>> requestClause =
           new Dictionary<ProductByColumn, Func<Product, object>>
                {
                    {ProductByColumn.Code, c => c.ProductId},
                    {ProductByColumn.Name, c => c.Name},
                    {ProductByColumn.Category, c => c.ProductCategory.Name}
                };
        #endregion

        public ProductSearchResponse GetProductSearchResponse(ProductSearchRequest searchRequest)
        {
            int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            int toRow = searchRequest.PageSize;
            Expression<Func<Product, bool>> query =
                    s => (
                            (
                            (searchRequest.ProductCode==0 || s.ProductId.Equals(searchRequest.ProductCode))
                            && (string.IsNullOrEmpty(searchRequest.Barcode) || s.ProductBarCode.Contains(searchRequest.Barcode))
                            && (string.IsNullOrEmpty(searchRequest.Name) || s.Name.Contains(searchRequest.Name))
                            && (string.IsNullOrEmpty(searchRequest.Category) || s.ProductCategory.Name.Contains(searchRequest.Category))
                            )


                        );
            IEnumerable<Product> result =
                searchRequest.IsAsc
                    ? DbSet.Where(query)
                        .OrderBy(requestClause[searchRequest.ProductOrderBy])
                        .Skip(fromRow)
                        .Take(toRow)
                        .ToList()
                    : DbSet.Where(query)
                        .OrderByDescending(requestClause[searchRequest.ProductOrderBy])
                        .Skip(fromRow)
                        .Take(toRow)
                        .ToList();

            return new ProductSearchResponse { Products = result, TotalCount = DbSet.Count(), FilteredCount = DbSet.Count(query) };

        }
    }
}
