using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class VendorMapper
    {
        public static Vendor CreateFromClientToServer(this VendorModel source)
        {
            return new Vendor
            {
                VendorId = source.VendorId,
                Name = source.Name,
                ActiveFlag = source.ActiveFlag,
                ContactNo = source.ContactNo,
                
                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }

        public static VendorModel CreateFromServerToClient(this Vendor source)
        {
            return new VendorModel
            {
                VendorId = source.VendorId,
                Name = source.Name,
                ActiveFlag = source.ActiveFlag,
                ContactNo = source.ContactNo,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}