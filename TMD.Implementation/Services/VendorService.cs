using System.Collections.Generic;
using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;
using TMD.Models.DomainModels;

namespace TMD.Implementation.Services
{
    public class VendorService : IVendorService
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

        public IEnumerable<Vendor> GetActiveVendors()
        {
            return vendorRepository.GetActiveVendors();
        }

        public long AddVendor(Vendor vendor)
        {
            if (vendor.VendorId > 0)
                vendorRepository.Update(vendor);
            else
                vendorRepository.Add(vendor);

            vendorRepository.SaveChanges();
            return vendor.VendorId;
        }
    }
}

