using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IVendorService
    {
        Vendor GetVendor(long productId);
        IEnumerable<Vendor> GetAllVendors();
    }
}
