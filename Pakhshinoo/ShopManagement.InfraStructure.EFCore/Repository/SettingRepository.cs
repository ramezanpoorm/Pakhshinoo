
using _0_Framework.InfraStructure;
using ShopManagement.Application.Contracts.Setting;
using ShopManagement.Domain.SettingAgg;
using System.Linq;

namespace ShopManagement.InfraStructure.EFCore.Repository
{
    public class SettingRepository : RepositoryBase<long, Setting>, ISettingRepository
    {
        private readonly ShopContext _shopContext;
        public SettingRepository(ShopContext shopContext) : base(shopContext)
        {
            _shopContext = shopContext;
        }

        public EditSetting GetDetails(long id)
        {
            return _shopContext.Settings.Select(x => new EditSetting
            {
                Id = x.Id,
                Address = x.Address,
                Banner1Des = x.Banner1Des,
                Banner2Link = x.Banner2Link,
                Banner2Des = x.Banner2Des,
                Banner1Title = x.Banner1Title,
                Banner1Link = x.Banner1Link,
                //Banner1Pic = x.Banner1Pic,
                //Banner2Pic = x.Banner2Pic,
                Banner2Title = x.Banner2Title,
                Banner3Des = x.Banner3Des,
                Banner3Link = x.Banner3Link,
                //Banner3Pic = x.Banner3Pic,
                Banner3Title = x.Banner3Title,
                EmailAddress = x.EmailAddress,
                Instagram = x.Instagram,
                Percent9 = x.Percent9,
                PhoneNumber = x.PhoneNumber,
                Telegram = x.Telegram
            }).FirstOrDefault(x => x.Id == id);
        }
    }
}
