using System.Data.Entity;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
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
        #endregion
    }
}
