using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class ProductConfigurationRepository: BaseRepository<ProductConfiguration>, IProductConfigurationRepositoy
    {
        #region Constructor & Private Properties
        /// <summary>
        /// Constructor
        /// </summary>
        public ProductConfigurationRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<ProductConfiguration> DbSet
        {
            get { return db.ProductConfiguration; }
        }

        #endregion

        public ProductConfiguration GetDefaultConfiguration()
        {
            return DbSet.FirstOrDefault();
        }
    }
}
