using TMD.Models.DomainModels;

namespace TMD.Interfaces.IServices
{
    public interface IProductConfigurationService
    {
        ProductConfiguration GetConfiguration(long configId);
        ProductConfiguration GetDefaultConfiguration();
        long SaveConfiguration(ProductConfiguration config);
    }
}
