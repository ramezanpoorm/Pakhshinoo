
using _0_Framework.Domain;
using InventoryManagement.Application.Contract.Inventory;
using System.Collections.Generic;

namespace InventoryManagement.Domain.InventoryAgg
{
    public interface IInventoryRepository:IRepository<long, Inventory>
    {
        EditInventory GetDetails(long id);
        Inventory GetById(long productId);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
    }
}
