
using _0_Framework.Application;

namespace ShopManagement.Application.Contracts.Setting
{
    public interface ISettingApplication
    {
        OpretaionResult Edit(EditSetting command);
        EditSetting GetDetails(long id);
    }
}
