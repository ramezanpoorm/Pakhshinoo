
using _0_Framework.Domain;
using AccountManagement.Application.Contract.Profile;
using System.Collections.Generic;

namespace AccountManagement.Domain.ProfileAgg
{
    public interface IProfileRepository : IRepository<long, Profile>
    {
        Profile GetBy(string username);
        List<ProfileViewModel> Search(ProfileSearchModel searchModel);
        EditProfile GetDeatails(long id);
        List<ProfileViewModel> GetProfiles();
    }
}
