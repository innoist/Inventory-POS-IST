using TMD.Models.DomainModels;

namespace TMD.Interfaces.IRepository
{
    public interface IProductConfigurationRepositoy : IBaseRepository<ProductConfiguration, long>
    {
        ProductConfiguration GetDefaultConfiguration();
    }
}
