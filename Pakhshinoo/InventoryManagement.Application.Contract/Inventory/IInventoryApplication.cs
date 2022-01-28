
using _0_Framework.Application;
using System.Collections.Generic;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OpretaionResult Create(CreateInventory command);
        OpretaionResult Edit(EditInventory command);
        OpretaionResult Increase(IncreaseInventory command);
        OpretaionResult Reduce(List<ReduceInventory> command);
        OpretaionResult Reduce(ReduceInventory command);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
        List<InventoryOperationViewModel> GetOperationLog(long inventoryId);
    }
}
