using TMD.Interfaces.IRepository;
using TMD.Interfaces.IServices;

namespace TMD.Implementation.Services
{
    public class StagingEbayBatchImportsService : IStagingEbayBatchImportsService
    {
        public StagingEbayBatchImportsService(IStagingEbayBatchImportsRepository p_istgEbayBatchImportsRepository)
        {
            istgEbayBatchImportsRepository = p_istgEbayBatchImportsRepository;
        }
        private readonly IStagingEbayBatchImportsRepository istgEbayBatchImportsRepository;
        public Models.ResponseModels.BatchImportSearchResponse GetImports(Models.RequestModels.BatchImportSearchRequest oReq)
        {
            return istgEbayBatchImportsRepository.GetImports(oReq);
            //return orep
        }
    }
}
