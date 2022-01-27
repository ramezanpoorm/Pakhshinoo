
using _0_Framework.Application;
using System.Collections.Generic;

namespace InventoryManagement.Application.Contract.Inventory
{
    public interface IInventoryApplication
    {
        OpretaionResult Create(CreateInventory command);
        OpretaionResult Edit(EditInventory command);
        OpretaionResult Increase(IncreaseInventory command);
        OpretaionResult Decrease(List<DecreaseInventory> command);
        EditInventory GetDetails(long id);
        List<InventoryViewModel> Search(InventorySearchModel searchModel);
    }
}
