
using _0_Framework.Application;
using AccountManagement.Application.Contract.Profile;
using AccountManagement.Domain.ProfileAgg;
using System.Collections.Generic;

namespace AccountManagement.Application
{
    public class ProfileApplication : IProfileApplication
    {
        private readonly IFileUploader _fileUploader;
        private readonly IProfileRepository _profileRepository;
        private readonly IAuthHelper _authHelper;

        public ProfileApplication(IFileUploader fileUploader, IProfileRepository profileRepository, IAuthHelper authHelper)
        {
            _fileUploader = fileUploader;
            _profileRepository = profileRepository;
            _authHelper = authHelper;
        }

        public OpretaionResult Create(CreateProfile command)
        {
            var operation = new OpretaionResult();

            if (_profileRepository.Exists(x => x.Email == command.Email))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"coworkerPhotos";
            var picturePath = _fileUploader.Upload(command.PictureCoworker, path);
            var profile = new Profile(command.AccountId, command.CompanyName, command.Contry, command.Region, command.City, command.Address, command.PostalCode, command.Email, command.Coworker, picturePath);

            _profileRepository.Create(profile);
            _profileRepository.SaveChanges();
            return operation.Successeded();
        }

        public OpretaionResult Edit(EditProfile command)
        {
            var operation = new OpretaionResult();
            var profile = _profileRepository.Get(command.Id);
            if (profile == null)
                return operation.Failed(ApplicationMessages.RecordNotFound);

            if (_profileRepository.Exists(x =>
                (x.Email == command.Email) && x.Id != command.Id))
                return operation.Failed(ApplicationMessages.DuplicatedRecord);

            var path = $"coworkerPhotos";
            var picturePath = _fileUploader.Upload(command.PictureCoworker, path);
            profile.Edit(command.CompanyName, command.Contry, command.Region, command.City, command.Address, command.PostalCode, command.Email, command.Coworker, picturePath);
            _profileRepository.SaveChanges();
            return operation.Successeded();
        }

        public List<ProfileViewModel> GetProfiles()
        {
            return _profileRepository.GetProfiles();
        }

        public EditProfile GetDeatails(long id)
        {
            return _profileRepository.GetDeatails(id);
        }

        public List<ProfileViewModel> Search(ProfileSearchModel searchModel)
        {
            return _profileRepository.Search(searchModel);
        }
    }
}
