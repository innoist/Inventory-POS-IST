using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class ProductMainCategoryRepository: BaseRepository<ProductMainCategory>, IProductMainCategoryRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductMainCategoryRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ProductMainCategory> DbSet
        {
            get { return db.ProductMainCategory; }
        }
        #endregion
    }
}
