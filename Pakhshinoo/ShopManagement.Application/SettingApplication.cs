
using _0_Framework.Application;
using ShopManagement.Application.Contracts.Setting;
using ShopManagement.Domain.SettingAgg;

namespace ShopManagement.Application
{
    public class SettingApplication : ISettingApplication
    {
        private readonly ISettingRepository _settingRepository;
        private readonly IFileUploader _fileUploader;

        public SettingApplication(ISettingRepository settingRepository, IFileUploader fileUploader)
        {
            _settingRepository = settingRepository;
            _fileUploader = fileUploader;
        }

        public OpretaionResult Edit(EditSetting command)
        {
            var operation = new OpretaionResult();
            var setting = _settingRepository.Get(command.Id);

            if (setting == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            //if (_settingRepository.Exists(x => x.Name == command.Name && x.Id != command.Id))
            //    return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"ProductPictures";
            var picturePath1 = _fileUploader.Upload(command.Banner1Pic, path);
            var picturePath2 = _fileUploader.Upload(command.Banner2Pic, path);
            var picturePath3 = _fileUploader.Upload(command.Banner3Pic, path);

            setting.Edit(command.PhoneNumber, command.EmailAddress, command.Instagram, command.Telegram, command.Address, command.Banner1Title, command.Banner1Des, picturePath1, command.Banner1Link, command.Banner2Title, command.Banner2Des, picturePath2, command.Banner2Link, command.Banner3Title, command.Banner3Des, picturePath3, command.Banner3Link, command.Percent9);

            _settingRepository.SaveChanges();
            return operation.Successeded();
        }

        public EditSetting GetDetails(long id)
        {
            return _settingRepository.GetDetails(id);
        }
    }
}
