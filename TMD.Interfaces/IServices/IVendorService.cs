using System.Collections.Generic;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IVendorService
    {
        Vendor GetVendor(long vendorId);
        IEnumerable<Vendor> GetAllVendors();
        IEnumerable<Vendor> GetActiveVendors();
    }
}
