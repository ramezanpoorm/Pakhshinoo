
using _0_Framework.Application;
using System.Collections.Generic;

namespace AccountManagement.Application.Contract.Profile
{
    public interface IProfileApplication
    {
        OpretaionResult Create(CreateProfile command);
        OpretaionResult Edit(EditProfile command);
        List<ProfileViewModel> Search(ProfileSearchModel searchModel);
        EditProfile GetDeatails(long id);
        List<ProfileViewModel> GetProfiles();
    }
}
