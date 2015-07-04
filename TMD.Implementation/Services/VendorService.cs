using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class VendorService:IVendorService
    {
        private readonly IVendorRepository vendorRepository;

        public VendorService(IVendorRepository vendorRepository)
        {
            this.vendorRepository = vendorRepository;
        }

        public Vendor GetVendor(long vendorId)
        {
           return vendorRepository.Find(vendorId);
        }

        public IEnumerable<Vendor> GetAllVendors()
        {
            return vendorRepository.GetAll();
        }
    }
}
