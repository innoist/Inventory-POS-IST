using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IVendorRepository : IBaseRepository<Vendor, long>
    {
        IEnumerable<Vendor> GetActiveVendors();
    }
}
