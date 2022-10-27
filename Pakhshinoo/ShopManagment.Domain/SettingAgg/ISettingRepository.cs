
using _0_Framework.Domain;
using ShopManagement.Application.Contracts.Setting;

namespace ShopManagement.Domain.SettingAgg
{
    public interface ISettingRepository : IRepository<long, Setting>
    {
        EditSetting GetDetails(long id);
    }
}
