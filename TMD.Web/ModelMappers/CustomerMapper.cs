using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using TMD.Models.DomainModels;
using TMD.Web.Models;

namespace TMD.Web.ModelMappers
{
    public static class CustomerMapper
    {
        public static CustomerModel CreateFromServerToClient(this Customer source)
        {
            return new CustomerModel
            {
               Id = source.Id,
               Name = source.Name,
               Phone = source.Phone,
               Address =  source.Address,
               Email = source.Email,

                Comments = source.Comments,

                RecCreatedBy = source.RecCreatedBy,
                RecCreatedDate = source.RecCreatedDate,
                RecLastUpdatedBy = source.RecLastUpdatedBy,
                RecLastUpdatedDate = source.RecLastUpdatedDate
            };
        }
    }
}