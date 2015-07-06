using TMD.Models.DomainModels;
using TMD.Models.RequestModels;
using TMD.Models.ResponseModels;

namespace TMD.Interfaces.IRepository
{
    public interface IInventoryItemRepositoy : IBaseRepository<InventoryItem, long>
    {
        long GetItemCountInInventory(long productId);
        InventoryItemSearchResponse GetInventoryItemSearchResponse(InventoryItemSearchRequest searchRequest);
    }
}
