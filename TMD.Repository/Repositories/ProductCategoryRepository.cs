using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class ProductCategoryRepository : BaseRepository<ProductCategory>, IProductCategoryRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductCategoryRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ProductCategory> DbSet => db.ProductCategories;

        #endregion

        #region Public

        /// <summary>
        /// Get All Product Categories
        /// </summary>
        public ProductCategorySearchResponse GetAll(ProductCategorySearchRequest searchRequest)
        {
            int fromRow = (searchRequest.PageNo - 1) * searchRequest.PageSize;
            int toRow = searchRequest.PageSize;
            Expression<Func<ProductCategory, bool>> query = pc =>
                (!searchRequest.MainCategoryId.HasValue || pc.MainCategoryId == searchRequest.MainCategoryId) &&
                (string.IsNullOrEmpty(searchRequest.Name) || pc.Name.Contains(searchRequest.Name));

            IEnumerable<ProductCategory> result =
                        DbSet
                        .Where(query)
                        .OrderBy(pc => pc.Name)
                        .Skip(fromRow)
                        .Take(toRow)
                        .ToList();
            var totalCount = DbSet.Count(query);

            return new ProductCategorySearchResponse { ProductCategories = result, TotalCount = totalCount, FilteredCount = totalCount };
        }

        #endregion
    }
}
