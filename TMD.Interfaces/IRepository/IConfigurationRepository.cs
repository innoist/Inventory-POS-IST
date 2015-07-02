using System;
using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IConfigurationRepository: IBaseRepository<Configuration, int>
    {
        string GetEbayLoadStartTimeFrom();
        int UpsertEbayLoadStartTimeFromConfiguration(DateTime ebayLoadStartTimeFrom);
    }
}
