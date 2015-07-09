using System.Data.Entity;
using System.Linq;
using Microsoft.Practices.Unity;
using TMD.Interfaces.IRepository;
using TMD.Models.DomainModels;
using TMD.Repository.BaseRepository;

namespace TMD.Repository.Repositories
{
    public sealed class CustomerRepository: BaseRepository<Customer>, ICustomerRepository
    {
        #region Constructor
        /// <summary>
        /// Constructor
        /// </summary>
        public CustomerRepository(IUnityContainer container)
            : base(container)
        {
        }

        /// <summary>
        /// Primary database set
        /// </summary>
        protected override IDbSet<Customer> DbSet
        {
            get { return db.Customers; }
        }
        #endregion

        public Customer GetCustomerByEmailOrPhone(string query)
        {
            return DbSet.FirstOrDefault(x => x.Email == query || x.Phone == query);
        }
    }
}
